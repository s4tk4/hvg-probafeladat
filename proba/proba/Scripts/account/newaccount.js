console.log('aa')

function createNewAccount() {
    var accountForm = jQuery("#newaccountform");
    dataJSON = {
        AccountNumber: accountForm.find("#AccountNumber").val(),
        Currency: accountForm.find("#Currency").val(),
        Balance: accountForm.find("#Balance").val(),
        OwnerName: accountForm.find("#OwnerName").val(),
        CanWithdrawCash: accountForm.find("#CanWithdrawCash").val(),
        CanBeDeposited: accountForm.find("#CanBeDeposited").val(),
        ExistCreditLine: accountForm.find("#ExistCreditLine").val(),
    }

    jQuery.ajax({
        type: "POST",
        url: '/api/AccountApi/CreateNewAccount',
        data: dataJSON,
        dataType: 'json',
        success: function (result, status, xhr) {
            debugger

            var modalTitle = "";
            var modalString = ""
            if (result.Success == false) {
                //todo show
                modalTitle = "Sikertelen letrehozas";
                jQuery.each(result.ErrorMessage, function (i, e) {
                    modalString += e + "<br>";
               })
            } else {
                //todo show
                modalTitle = "Sikeres letrehozas";
                jQuery.each(result.ResultMessage, function (i, e) {
                    modalString += e + "<br>";
                })
            }

            showAlertModal(modalTitle, modalString);
        },
        error: function (result, status, xhr) {
            console.log(result)
            console.log(status)
            console.log(xhr)
            console.log('ajax call failed');
        },
    });


}