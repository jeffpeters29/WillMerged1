//READY
$(function () {
    var currentModel = new ChildManager($('#childModalAdd'), $('[childListTarget]'));
});

//=======================================================

function ChildManager(element, listElement) {

    this.$modalElement = $(element);
    this.$listElement = $(listElement);

    this.$modalSaveButton = $("#childModal [save-child-button]");

    //this.model = $('#data').val();
    this.model =
        [
            { ChildId: 1, Name: "Ian", Over18: true },
            { ChildId: 2, Name: "Jeff", Over18: false }
        ];

    var that = this;

    this.$modalSaveButton.on("click", function () {
        event.preventDefault();
        var childId = $("#childModal #childId").val();
        var childName = $("#childModal [FirstName]").val();
        var over18 = $("#childModal [Over18]").is(":checked");
        that.saveChild(childId, childName, over18);
    });
    
    this.renderChildList(this.model);
}

//===========================
// RENDER LIST
//===========================
ChildManager.prototype.renderChildList = function (children) {
    var listTemplate = "<table class='table table-striped'>#listitems#</table>";

    var constructItems = "";
    for (var c = 0; c < children.length; c++) {
        constructItems += this.renderChild(children[c]);
    }

    listTemplate = listTemplate.replace("#listitems#", constructItems);

    this.$listElement.html(listTemplate);
};

ChildManager.prototype.renderChild = function (child) {
    return "<tr><td>Name: " + child.Name
         + "</td><td>  Over 18? " + child.Over18 + '</td><td>'
         + '<button type="button" class="btn btn-success" data-toggle="modal" data-target="#childModal">Edit</button>'
         + '<button type="button" class="btn btn-danger">Delete</button>'
         + '</td></tr>';
};


//===========================
// EVENTS
//===========================
ChildManager.prototype.saveChild = function (childId, childName, over18) {

    var childData = {
        willId: childId,
        childId: childId,
        childName: childName,
        over18: over18
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(childData),
        url: "/Step2?handler=SaveChildDetails",
        contentType: "application/json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        }
    })
    .done(function (res) {
        alert(res);
    })
    .fail(function (res) {
        alert(res);
    });
};

ChildManager.prototype.deleteChild = function (id) {

};





//$("#saveChildButton")
//    .click(function (event) {
//        event.preventDefault();
//        var form = $("#updateCompanyForm");
//        var id = $(this).attr("data-id");
//        if (form.valid() && id) {
//            //Hide modal
//            $("#updateCompany").modal('hide');
//            // Submit the form using AJAX.
//            $.ajax({
//                type: 'POST',
//                url: "/Admin/AffiliatedCompany/UpdateCompanyDetails",
//                data: {
//                    id: id,
//                    companyName: $("#companyNameInput").val(),
//                    fee: $("#companyFeeInput").val()
//                },
//                success: function (response) {
//                    if (!response) {
//                        //ERROR
//                        $("#errorMessageDialog .custom-error-message")
//                            .text("There was an error updating the affiliated company details.");
//                        $("#errorMessageDialog").modal('show');
//                    } else {
//                        //Replace values
//                        $("#" + id + " .companyName").text($("#companyNameInput").val());
//                        $("#" + id + " .companyFee").text(parseFloat($("#companyFeeInput").val()).toFixed(2));
//                        //SUCCESS
//                        $("#successMessageDialog .custom-success-message")
//                            .text("The affiliated company details were updated successfully.");
//                        $("#successMessageDialog").modal('show');
//                        ClearInviteCustomerForm();
//                    }
//                }
//            });
//        }
//    })