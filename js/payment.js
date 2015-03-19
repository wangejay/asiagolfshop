window.onload = initPage;

function initPage() {
    AspAjax.set_defaultSucceededCallback(SucceededCallback);
    AspAjax.set_defaultFailedCallback(FailedCallback);
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
        $("#cityName").change(function() {
            AspAjax.getTown($(this).val());
        });
}
function SucceededCallback(result, userContext, methodName) {
    baseSucceededCallback(result, userContext, methodName);
    switch (methodName) {
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
