window.onload = initPage;

function initPage() {
    AspAjax.set_defaultSucceededCallback(SucceededCallback);
    AspAjax.set_defaultFailedCallback(FailedCallback);
    AspAjax.IsAuthenticated();
    $('.productImgs>UL>LI')
        .mouseover(function() {
            $('#mainImg').css('background-image', 'url(' + $(this).find('IMG').attr('src') + ')');
            $('#productImgBig').css('visibility', 'hidden');
        })
        .click(function() {
            $('#productImgBig').attr('src', $(this).find('IMG').attr('src'));
        });
    $('.productImgs>UL')
        .mouseout(function() {
            $('#productImgBig').css('visibility', 'visible');
            $('#mainImg').css('background-image', 'none');
        });
}
function SucceededCallback(result, userContext, methodName) {
    baseSucceededCallback(result, userContext, methodName);
    switch (methodName) {
        case "deleteCartProduction":
            if (result == Message_NoAuth)
                alert("請先登入");
            else if (result == Message_SuccessInt) {
                alert("已刪除商品");
                window.location.reload();
            }
            break;
    } 
}
function FailedCallback(error, userContext, methodName) {
    baseFailedCallback(error, userContext, methodName);
}
function goDetail(id) {
    window.location = "./detail.aspx?id=" + id;
}

function goCart() {
    var obj = new Object();
    obj.ProductionID = gup("id");
    obj.Hand = $("#sHand").val();
    obj.Angle = $("#sAngle").val();
    obj.GolfClub = $("#sGolfClub").val();
    obj.GolfHand = $("#sGolfHard").val();
    obj.ProductionCounter = 1;
    //alert(idx);
    AspAjax.AddToCart(obj);
}
function deleteCart(idx) {
    AspAjax.deleteCartProduction(idx);
}
function gobackProductionList() {
    window.location = "./product.aspx";
}
function goOrder() {
    window.location = "./payment.aspx";
}