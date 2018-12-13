
function MaritalStatusChanged() {
    var selectedMaritalStatus = $('#ddl_maritalstatus option:selected').val();
    $("#id_customermaritalstatus").val(selectedMaritalStatus);
}