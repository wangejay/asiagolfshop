window.onload = initPage;
document.onkeydown = keyFunction;
var CheckEmail = false;
var CheckPassword = false;
var CheckcPassword = false;
var CheckvalidImg = false;
var goSignupNow = false;
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
        case "CheckUserIDNotExit":
            if (result) {
                errorAlert("#signupResult", "帳號已註冊");
                CheckEmail = false;
                goSignupNow = false;
            }
            else if (goSignupNow) {
                CheckEmail = true;
                signup();
            }
            break;
        case "ValidateCheck":
            CheckvalidImg = result;
            if (result) {
                if (goSignupNow)
                    signup();
            }
            else {
                errorAlert("#signupResult", "驗證碼錯誤");
                goSignupNow = false;

            }
            break;
        case "CreateUserMember":
            goSignupNow = false;
            if (result == "Success") {
                goLogin();
            }
            else {
                errorAlert("#signupResult", result);
            }
            break;
    }
}
function FailedCallback(error, userContext, methodName) {

}
function SetAuthenticatetAll(result) {
    if (result.length > 0) {
        window.location = "./default.aspx";
    }
    else {
        eventSetting();
    }
}
function eventSetting() {
    $("#validateJpg").click(function() {
        $(this).attr("src", "./SentValidate.ashx?ts=" + new Date().getTime());
    });
    $("#userEmail").unbind('blur').blur(function() {
        emailCheck();
    }).change(function() {
        CheckEmail = false;
    });

    $("#userPassword").unbind('blur').blur(function() {
        CheckPassword = passwordCheck($(this).val());
    }).change(function() {
        CheckcPassword = false;
    });
    $("#userPasswordConfirm").unbind('blur').blur(function() {
        CheckcPassword=passwordAgainCheck($(this).val());
    });

    $("#validImg").blur(function() {
        AspAjax.ValidateCheck($(this).val(), SucceededCallback);
    });
    $("#btn_signup").click(function() {
        signup();
    });
}

function signup() {
    goSignupNow = true;
    var obj = new Object();
    obj.Email = $("#userEmail").val();
    obj.Password = $("#userPassword").val();

    if (!CheckEmail) {
        emailCheck();
    }
    else if (!passwordCheck(obj.Password)) {
        goSignupNow = false;
    }
    else if (!passwordAgainCheck($("#userPasswordConfirm").val())) {
        goSignupNow = false;
    }
    else if (!CheckvalidImg) {
        AspAjax.ValidateCheck($("#validImg").val(), SucceededCallback);
    }
    else {
        AspAjax.CreateUserMember(obj, SucceededCallback);
    }

}

function isemail(email) {
    if (email.length > 100) {
        return false;
    }
    if (email == undefined || email.length == 0) {
        return false;
    }
    var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;
    if (reg.test(email)) {
        return true;
    } else {
        return false;
    }
}
function emailCheck() {
    var UserEmail = $("#userEmail").val()
    if (isemail(UserEmail)) {
        AspAjax.CheckUserIDNotExit(UserEmail, SucceededCallback);
    } else {
        CheckEmail = false;
        goSignupNow = false;
        errorAlert("#signupResult", "E-Mail格式不正確");
        
    }
}
function passwordAgainCheck() {
    var returnValue = false;
    if (CheckPassword) {
        if ($("#userPasswordConfirm").val() == $("#userPassword").val()) {
            returnValue = true;
        } else {
            errorAlert("#signupResult", "密碼不符");
            returnValue = false;
        }
    }
    return returnValue;
}
function passwordCheck(Password) {
    var returnValue;
    returnValue = CheckUserPassword(Password);
    if (returnValue) {
        if (Password.length < 6) {
            errorAlert("#signupResult", "密碼不足六碼");
            returnValue = false;
        } else {
        returnValue = true;
        }
    } else {
        errorAlert("#signupResult", "密碼為數字和英文之組合");
    }
    return returnValue;
}
function CheckUserPassword(Password) {
    if (Password == undefined || Password.length == 0) {
        return true;
    }
    var reg = /^[a-zA-Z0-9]+$/;
    if (reg.test(Password)) {
        return true;
    } else {
        return false;
    }
}
function goLogin() {
    Sys.Services.AuthenticationService.login($("#userEmail").val(), $("#userPassword").val(),
        false, null, null, OnLoginCompleted, OnFailed, name);
}
function keyFunction(event) {
    if (event.keyCode == 13) {
        signup();
    }
}

function OnLoginCompleted(validCredentials, userContext, methodName) {
    window.location="./default.aspx";
}


function OnFailed(error, userContext, methodName) {
    var msg = "";
    msg += "錯誤訊息：" + error.get_message() + "\n\n";
    msg += "逾時時間：" + error.get_timedOut() + "\n\n";
    msg += "狀態代碼：" + error.get_statusCode() + "\n\n";
    msg += "堆疊追蹤：" + error.get_stackTrace() + "\n\n";
    msg += "例外類型：" + error.get_exceptionType();
    errorAlert("#signupResult", msg);
}

/*


function OnClickLogin() {
    if (document.getElementById("LoginUserName").value.length == 0)
        document.getElementById("result").innerHTML = '<div class="little_window_bg"/><p>' + "請輸入帳號" + '</p>';
    else if (document.getElementById("LoginPassword").value.length == 0)
        document.getElementById("result").innerHTML = '<div class="little_window_bg"/><p>' + "請輸入密碼" + '</p>';
    else {
        var name = document.getElementById("LoginUserName").value;
        var LoginPassword = document.getElementById("LoginPassword").value;
        Sys.Services.AuthenticationService.login(name, LoginPassword,
            false, null, null, OnLoginCompleted, OnFailed, name);
    }
}


function CreateUser_click() {
    parent.window.location.href = './register.aspx';
    //parent.openjoin();
}
function OnForgetPassword() {
    parent.head.forgetpasswordEnter();
}



*/