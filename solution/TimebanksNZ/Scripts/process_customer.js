	//Useful links:
// http://code.google.com/apis/maps/documentation/javascript/reference.html#Marker
// http://code.google.com/apis/maps/documentation/javascript/services.html#Geocoding
// http://jqueryui.com/demos/autocomplete/#remote-with-cache
var bEmVal=0; 
var geocoder;
var map;
var marker;

function unloadPopupBox() {    // TO Unload the Popupbox
    $('#popup_box').fadeOut("slow");
    $("#pageBdy").css({ // this is just for style        
        "opacity": "1"  
    }); 
}    

function loadPopupBox() {    // To Load the Popupbox
    $('#popup_box').show();
    $("#pageBdy").css({"opacity": "0.3"});
    $("#popup_box").css({"opacity": "1"});
}        

function initialize(){
//MAP
    var latlng = new google.maps.LatLng(-43.5300, 172.6203);
  var options = {
    zoom: 13,
    center: latlng,
    mapTypeId: google.maps.MapTypeId.ROADMAP
  };
  map = new google.maps.Map(document.getElementById("map_canvas"), options);
        
  //GEOCODER
  geocoder = new google.maps.Geocoder();
        
  marker = new google.maps.Marker({
    map: map,
    draggable: true
  });
}

$(document).keyup(function(e) {
  if (e.keyCode == 27) {unloadPopupBox();}   // esc
});
		
$(document).ready(function() { 
  initialize();
	//$("#Country").blur($("#cus_email").focus())
  $("#address").focus()
	$('#popupBoxClose').click( function() {            
	            unloadPopupBox();
	        });     
    $('#pageBdy').click( function() {
        UnloadPopupBox();
    });
  $(function() {
    $("#address").autocomplete({
      //This bit uses the geocoder to fetch address values
      source: function(request, response) {
        geocoder.geocode( {'address': request.term, componentRestrictions: {country: 'NZ'}}, function(results, status) {
          response($.map(results, function(item) {
            for (var i = 0; i < item.address_components.length; i++)
			  {
				var addr = item.address_components[i];
				var streetNo;
				var getCountry;
				var area;
				var city;
				var suburb;
				var postcode;
				if (addr.types[0] == 'country') getCountry = addr.long_name;
				if (addr.types[0] == 'street_number') streetNo = addr.long_name;
				if (addr.types[0] == 'route')  streetNo = streetNo + ' '+ addr.long_name;
				if (addr.types[0] == 'administrative_area_level_1') area = addr.long_name;
				if (addr.types[0] == 'sublocality_level_1') suburb = addr.long_name;
				if (addr.types[0] == 'locality') city = addr.long_name;
				if (addr.types[0] == 'postal_code') postcode = addr.long_name;
			  }
			return {
              label:  item.address_components.street_number,
              value: item.formatted_address,
              latitude: item.geometry.location.lat(),
              longitude: item.geometry.location.lng(),
			  country: getCountry,
			  street_number: streetNo,
			  Mycity:city,
			  Mysuburb:suburb,
			  MyArea:area,
			  MyPost:postcode
            }
          }));
        })
      },
      //This bit is executed upon selection of an address
      select: function(event, ui) {
        $("#GeoLat").val(ui.item.latitude);
        $("#GeoLong").val(ui.item.longitude);
		$("#Country").val(ui.item.country);
		$("#Address1").val(ui.item.street_number);
		$("#City").val(ui.item.Mycity);
		$("#Area").val(ui.item.MyArea);
		$("#Suburb").val(ui.item.Mysuburb);
		$("#PostalCode").val(ui.item.MyPost);
		//alert(ui.item.formatted_address);
        var location = new google.maps.LatLng(ui.item.latitude, ui.item.longitude);
        marker.setPosition(location);
        map.setCenter(location);
      }
    });
  });
	
  //Add listener to marker for reverse geocoding
  google.maps.event.addListener(marker, 'drag', function() {
    geocoder.geocode({'latLng': marker.getPosition()}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        if (results[0]) {
            $('#Address1').val(results[0].formatted_address);
		  //alert($('#address').val());//$('#street').val(results[0].formatted_address);
            $('#GeoLat').val(marker.getPosition().lat());
            $('#GeoLong').val(marker.getPosition().lng());
        }
      }
    });
  });
});



function pwdValidate(oPassInputName)
{
	var sRE=/(?=.*\d)(?=.*[a-z]).{6,}/;
	var sPass=document.getElementById(oPassInputName).value
	var dvInput="dvRegisterPassResponse"
	if (oPassInputName=="cus_password2") {dvInput="dvRegisterPassResponse2";}
	if (sRE.test(sPass)) {bEmVal=1;
		document.getElementById(dvInput).innerHTML='<img class="ajax-save-pass" title="Input Accepted" src="/images/shared/icons/ajax_tick.png"> Secure password confirmed. '
		document.getElementById(dvInput).style.display="inline";
		document.getElementById(dvInput).className="dvPassUser"
		}
	else {
		document.getElementById(dvInput).innerHTML='<img class="ajax-save-fail" title="Input Accepted" src="/images/shared/icons/ajax_cross.png"> 6-20 characters (1 letter and 1 number at least.)'
		document.getElementById(dvInput).className="dvErrorUser"
		document.getElementById(dvInput).style.display="inline";
		}
}
//function pwdMatch()
//{if (document.getElementById("cus_password").value!=document.getElementById("cus_password2").value)
//	{alert("passwords do not match. Please re-enter");document.getElementById("pwdValid").value=0;}
//}
function checkMail(sEML)
{
document.getElementById("dvRegisterEmailResponse").style.display="none"
document.getElementById("ajax_loader").style.visibility="visible"
xmlHttp=GetXmlHttpObject()
//alert("all good")
if (xmlHttp==null)
  {
  alert ("Your browser does not support AJAX!");
  return;
  } 		
var sURL
sURL="/admin/checkEmalValid.asp?eml="+sEML+""
//alert (sURL)
xmlHttp.onreadystatechange=stateChanged;
xmlHttp.open("GET",sURL,true);
xmlHttp.send(null);
}

function upAddressOpt(sID,sVal)
{
document.getElementById("dvRegisterEmailResponse").style.display="none"
document.getElementById("ajax_loader").style.visibility="visible"
var sURL
sURL="/admin/checkAddress.asp?as="+sID+"&id="+sVal.value
$.ajax({
		type: "GET",
		url: sURL,
		success: function(msg)
		{if (sID==1){oSel=document.getElementById("cuDistrict");document.getElementById("cuSuburb").disabled=true}
			if (sID==2){oSel=document.getElementById("cuSuburb");document.getElementById("cuSuburb").disabled=false}
			//update districts}
			var sOpts=msg.split(";")
			var sObj=sOpts[0]
			//alert(sObj)
			oSel.options.length=0
			for (i=0;i<sOpts.length;i++)
			{
			oSel.options[oSel.options.length]=new Option(sOpts[i+1],sOpts[i], false, false)
			i++
			}
			oSel.disabled=false;
		}
	}
	)
}


function stateChanged(){
	if (xmlHttp.readyState==4)
	{
		s=xmlHttp.responseText
		document.getElementById("ajax_loader").style.visibility="hidden"
		document.getElementById("dvRegisterEmailResponse").innerHTML=s
		document.getElementById("dvRegisterEmailResponse").style.display="block"
		document.getElementById("emlChktext").innerHTML=""
		if (s.indexOf("pass")>0){document.getElementById("dvRegisterEmailResponse").className="dvPassUser"}
		else {document.getElementById("dvRegisterEmailResponse").className="dvErrorUser"}
		
	}
}
function GetXmlHttpObject()
{
  var xmlHttp=null;
  try
    {
    // Firefox, Opera 8.0+, Safari
    xmlHttp=new XMLHttpRequest();
    }
  catch (e)
    {
    // Internet Explorer
    try
      {
      xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");
      }
    catch (e)
      {
      xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
      }
    }
  return xmlHttp;
}