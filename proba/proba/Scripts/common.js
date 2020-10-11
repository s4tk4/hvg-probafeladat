function showAlertModal(title, value) {


    jQuery('.alertmodal').find(".modal-title").html(title);
    jQuery('.alertmodal').find(".modal-body").html(value);
    jQuery('.alertmodal').modal('show')
    jQuery(".modal-backdrop").hide()
    //jQuery("#dialog-message").html(value)
    //jQuery(function () {
    //    jQuery("#dialog-message").dialog({
    //        modal: true,
    //        title: title,
    //        buttons: {
    //            Ok: function () {
    //                jQuery(this).dialog("close");
    //            }
    //        }
    //    });
    //});

}