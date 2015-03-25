window.onload = initPage;

function initPage() {
    AspAjax.set_defaultSucceededCallback(SucceededCallback);
    AspAjax.set_defaultFailedCallback(FailedCallback);

    $('#sameAsOrderer').change(orderInfoAction);
}
function SucceededCallback(result, userContext, methodName) {
    baseSucceededCallback(result, userContext, methodName);
    switch (methodName) {
        case "setOrder":
            setOrderResponse(result);
            break;
        case "getTown":
            changeTownData(result);
            break;
    }
}
function FailedCallback(error, userContext, methodName) {
    baseFailedCallback(error, userContext, methodName);
}
function changeTownData(result) {
    var inner = "";
    for(var i=0;i<result.length;i++)
    {
        inner+="<option value='"+result[i].ID+"'>"+result[i].Name+"</option>";
    }
    $("#townName").html(inner);
}
function goOrder() {
    var obj = new Object();
    obj.PayWay = $("input[name='paytype']:checked").val();

    obj.PayTime = $("input[name='paytime']:checked").val();

    
    //obj.ReceiverInfo.Order_Cellphone = $("#mName").val();

    obj.SenderInfo = new Object();
    obj.SenderInfo.Order_Name = $("#mName").val();
    obj.SenderInfo.Order_Phone = $("#mPhone").val();
    obj.SenderInfo.Order_Email = $("#mMail").val();
    obj.ReceiverInfo = new Object();
    obj.ReceiverInfo.Receiver_Name = $("#rName").val();
    obj.ReceiverInfo.Receiver_Phone = $("#rPhone").val();
    obj.ReceiverInfo.Receiver_Email = $("#rMail").val();
    obj.ReceiverInfo.Receiver_City = $("#cityName").val();
    obj.ReceiverInfo.Receiver_Town = $("#townName").val();
    //obj.ReceiverInfo.Receiver_Zip = $("#rPhone").val();
    obj.ReceiverInfo.Receiver_Address = $("#rAddr").val();
    obj.InvoiceInfo = new Object();
    obj.InvoiceInfo.InvoiceWay = $("input[name='InvoiceInfo']:checked").val();
    obj.InvoiceInfo.CompanyID = $("#company_id").val();
    obj.InvoiceInfo.CompanyName = $("#company_title").val();
    //
    AspAjax.setOrder(obj);
}
function setOrderResponse(result) {
    if (result == MessageSuccess) {
        alert("訂購成功，非常感謝您的訂購");
        window.location = "./default.aspx";
    }
}
function gobackProductionList() {
    window.location = "./product.aspx";
}

function orderInfoAction() {
    if (this.checked) {

        $('#rName').prop("disabled", true).val($('#mName').val());
        $('#rPhone').prop("disabled", true).val($('#mPhone').val());
        $('#rMail').prop("disabled", true).val($('#mMail').val());

        $('#mName').keyup(function() {
                    $('#rName').val($(this).val());
                });
        $('#mPhone').keyup(function() {
                    $('#rPhone').val($(this).val());
                });
        $('#mMail').keyup(function() {
                    $('#rMail').val($(this).val());
                });

    } else {
        $('#rName,#rPhone,#rMail').prop("disabled", false);
        $('#mName,#mPhone,#mMail').off("keyup");
    }
}