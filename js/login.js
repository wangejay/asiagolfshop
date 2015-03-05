window.onload = initPage;
document.onkeydown = keyFunction;
function initPage() {
    AspAjax.set_defaultSucceededCallback(SucceededCallback);
    AspAjax.set_defaultFailedCallback(FailedCallback);
    AspAjax.IsAuthenticated();
}
function SucceededCallback(result, userContext, methodName) {
    switch (methodName) {
        case "IsAuthenticated":
            SetAuthenticatetAll(result);
            break;
    }
}
function FailedCallback(error, userContext, methodName) {

}
function goLogin() {
    Sys.Services.AuthenticationService.login($("#userEmail").val(), $("#userPassword").val(),
        false, null, null, OnLoginCompleted, OnFailed, name);
}
function keyFunction(event) {
    if (event.keyCode == 13) {
        goLogin();
    }
}

function OnLoginCompleted(validCredentials, userContext, methodName) {
    
    if (validCredentials == true) {
        window.location = "./default.aspx";
    } else {
        errorAlert("#signupResult", "帳號密碼錯誤");
    }
}


function OnFailed(error, userContext, methodName) {
    var msg = "";
    msg += "錯誤訊息：" + error.get_message() + "\n\n";
    msg += "逾時時間：" + error.get_timedOut() + "\n\n";
    msg += "狀態代碼：" + error.get_statusCode() + "\n\n";
    msg += "堆疊追蹤：" + error.get_stackTrace() + "\n\n";
    msg += "例外類型：" + error.get_exceptionType();
    errorAlert(msg);
}
function SetAuthenticatetAll(result) {
    if (result.length > 0) {
        window.location = "./default.aspx";
    } 
}
