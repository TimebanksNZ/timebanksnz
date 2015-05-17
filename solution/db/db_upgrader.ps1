
function Connect($username, $password, $database, $hostname) {
    $ConnectionString = "server=" + $hostname + ";port=3306;uid=" + $username + ";pwd=" + $password + ";database="+$database
    [void][System.Reflection.Assembly]::LoadWithPartialName('MySql.Data')
    $Connection = New-Object MySql.Data.MySqlClient.MySqlConnection
    $Connection.ConnectionString = $ConnectionString
    $Connection.Open()
    return $Connection
}

function ApplyUpgradeScripts($connection) {
    Get-ChildItem -Path 'UpgradeScripts' | where-object { $_.Name -eq '*.sql' } #need to figure out how to do "Matches"
}

function RunQuery($connection) {
    Try {
        $Command = New-Object MySql.Data.MySqlClient.MySqlCommand($Query, $Connection)
        $DataAdapter = New-Object MySql.Data.MySqlClient.MySqlDataAdapter($Command)
        $DataSet = New-Object System.Data.DataSet
        $RecordCount = $dataAdapter.Fill($dataSet, "data")
        $DataSet.Tables[0]
    }
    Catch {
        Write-Host "ERROR : Unable to run query : $query `n$Error[0]"
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