function incrementBalance(accountNumber) {
    showModal("inpaymentmodal", accountNumber)
}
function decrementBalance(accountNumber) {
    showModal("paytransfermodal", accountNumber)
}   

function showModal(modalid, accountNumber) {
    var modal = jQuery("." + modalid);
    modal.modal('show');
    modal.find('.modal-title').attr('an', accountNumber);
    jQuery(".modal-backdrop").hide()
    //set click event to savve button
    modal.find(".btn-primary").on('click', function(i,e){
        //pricenumber
        data = prepareData(this);
        if (data !== null) {
            processReuquestData(data, this)
        }
    })
}

function prepareData(dom) {

    data = {
        accountNumber: jQuery(dom).parents(".modal-dialog").find('.modal-title').attr('an')
    }

    jQuery.each(jQuery(dom).parents(".modal-dialog").find('input'), function (i, e) {
        var actualDom = jQuery(e);
        var value = actualDom.val();
        if (actualDom.attr('checknumber') !== undefined) {
            if (value < 0 || isNaN(value)) {
                showAlertModal('Wrong price data', '')
                data = null;
                return;
            }
        }
        data[actualDom.attr('id')] = value; 
    })

    return data;
}

function processReuquestData(dataJSON, dom) {
    var dinUrl = jQuery(dom).parents(".modal-dialog").parent().attr('class').split(' ')[0]
    jQuery.ajax({
        type: "POST",
        url: '/api/AccountApi/' + dinUrl,
        data: dataJSON,
        dataType: 'json',
        success: function (result, status, xhr) {
            debugger

            var modalTitle = "";
            var modalString = ""
            if (result.Success == false) {
                //todo show
                modalTitle = "Sikertelen muvelet";
                jQuery.each(result.ErrorMessage, function (i, e) {
                    modalString += e + "<br>";
                })
            } else {
                //todo show
                modalTitle = "Sikeres muvelet";
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