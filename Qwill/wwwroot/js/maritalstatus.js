
function MaritalStatusChanged() {
    var selectedMaritalStatus = $('#ddl_maritalstatus option:selected').val();
    $("#id_maritalstatus").val(selectedMaritalStatus);
    $("#id_customermaritalstatus").val(selectedMaritalStatus);
}