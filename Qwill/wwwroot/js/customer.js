////==============================
//// PAF CODE
////==============================

var token = $('#CustomerInfo_Address_Token').val();
var isLive = $('#CustomerInfo_Address_IsLive').val() === "True";

$('#CurrentAddress').paf({
    token: token,
    element: '#CurrentAddress',
    result: '#CurrentAddressResult',
    addressFields:
    {
        CurrentAddress: "{Postcode}",
        CustomerInfo_Address_Number: "{SubBuildingName} {BuildingName} {BuildingNumber}",
        CustomerInfo_Address_Street: "{Thoroughfare} {ThoroughfareDependent}",
        CustomerInfo_Address_Village: "{Locality} {LocalityDependent} ",
        CustomerInfo_Address_City: "{Town}"
    },
    isLive: isLive
});