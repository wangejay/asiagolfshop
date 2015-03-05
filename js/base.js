function getSearchCondition() {
    var data = [];
    $(".cSearch").each(function() {
        var current = $(this);
        var type = current.attr("type");
        switch (type) {
            case "text":
                data.push({Name:current.attr("id"),Value:current.val()});
                break;

        }
    });
    return { "SearchCondition": data };
}
function baseSucceededCallback(result, userContext, methodName) {
    switch (methodName) {
        case "IsAuthenticated":
            SetAuthenticatet(result);
            break;
        case "Logout":
            SetLogoutResponset();
            break;
    }
}
function baseFailedCallback(error, userContext, methodName) {

}
function SetAuthenticatet(result) {
    if (result.length > 0) {
        var inner = result + ' 您好，' + '<a href="javascript:logout()">登出</a>';
        $("#login_Div").html(inner);
    }
}

function errorAlert(element,msg) {
    $(element).html('<div class="alert alert-danger">' +
    '<a class="close" href="#" data-dismiss="alert">×</a>' +
    '<strong>發生錯誤</strong>' +
    msg +
    '</div>');
    setTimeout(function() {
        $(element).html('');
    }, 3000);
}
function logout() {
    AspAjax.Logout();
}
function SetLogoutResponset() {
    window.location.reload();
}