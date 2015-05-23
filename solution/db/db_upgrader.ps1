
function Connect($username, $password, $database, $hostname) {
    $ConnectionString = "server=" + $hostname + ";port=3306;uid=" + $username + ";pwd=" + $password + ";database="+$database
    [void][System.Reflection.Assembly]::LoadWithPartialName('MySql.Data')
    $Connection = New-Object MySql.Data.MySqlClient.MySqlConnection
    $Connection.ConnectionString = $ConnectionString
    $Connection.Open()
    return $Connection
}

function ApplyUpgradeScripts($connection) {
    Get-ChildItem -Path 'UpgradeScripts' |
        where-object { $_ -like '*.sql'} |
        foreach-object { 
            $query = [IO.File]::ReadAllText( 'UpgradeScripts\' + $_ )
            RunQuery $connection $query
        }
}

function RunQuery($connection, $query) {
    Try {
        $Command = New-Object MySql.Data.MySqlClient.MySqlCommand( $query, $connection)
        $transaction = $connection.BeginTransaction()
        $Command.ExecuteNonQuery()
        $transaction.Commit()
    }
    Catch {
        Write-Host "ERROR : Unable to run query : $query `n$Error[0]"
        $transaction.Rollback()
        $connection.close()
        exit 1
    }
}

$username = Read-Host 'username'
$securePassword = Read-Host 'password' -AsSecureString
$password = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($securePassword))
$database = 'timebanks'
$hostname = 'localhost'

$connection = Connect $username $password $database $hostname
ApplyUpgradeScripts($connection)
$connection.Close()