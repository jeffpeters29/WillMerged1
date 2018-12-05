var children = [];

//READY
$(function () {

    $.each(json,
        function (i, c) {
            children.push({ Id: c.Id, FirstName: c.FirstName, Over18: c.Over18 });
        });

    var currentModel = new ChildManager($('#childModal'), $('[childListTarget]'));
});

//=======================================================

function ChildManager(element, listElement) {

    this.$modalElement = $(element);
    this.$listElement = $(listElement);

    this.$modalSaveButton = $("#childModal [save-child-button]");

    this.model = children;
  
    var that = this;

    this.$modalSaveButton.on("click", function () {
        event.preventDefault();
        var childId = $("#childModal #childId").val();
        var childName = $("#childModal [FirstName]").val();
        var over18 = $("#childModal [Over18]").is(":checked");
        that.addChild(childName, over18);
        //that.saveChild(childId, childName, over18);
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
    return "<tr><td>Name: " + child.FirstName
        + "</td><td>  Over 18? " + child.Over18 + '</td><td>'
        + '<button type="button" edit-child-button class="btn btn-success"'
        + ' data-childid="' + child.Id + '" '
        + ' data-childfirstname="' + child.FirstName + '" '
        + ' data-toggle="modal" data-target="#childModal" > Edit</button > '
        + '<button type="button" class="btn btn-danger">Delete</button>'
        + '</td></tr>';
};

//===========================
// POPULATE CHILD ON EDIT
//===========================
$(document).on("click", "[edit-child-button]", function (e) {
    var childId = $(this).closest('[edit-child-button]').attr("data-childid");
    var childFirstName = $(this).closest('[edit-child-button]').attr("data-childfirstname");
    $('#childModal #childId').val(childId);
    $('#childModal [FirstName]').val(childFirstName);
});

//===========================
// EVENTS
//===========================

ChildManager.prototype.addChild = function (childName, over18) {

    children.push({ FirstName: childName, Over18: over18 });

    this.renderChildList(children);

    $('#childModal').modal('hide');
};

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




//===========================
// OLD
//===========================

  //this.model = $('#data').val();
    //this.model =
    //    [
    //        { ChildId: 1, FirstName: "Ian", Over18: true },
    //        { ChildId: 2, FirstName: "Jeff", Over18: false }
    //    ];