var MessageSuccess = "success";
function gup(name) {
    name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
    var regexS = '[\\?&]' + name + '=([^&#]*)';
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);

    if (results)
        return results[1];
    else
        return '';
}
function getSearchCondition() {
    var data = [];
    $(".cSearch").each(function() {
        var current = $(this);
        var type = current.attr("type");
        switch (type) {
            case "text":
                data.push({ Name: current.attr("id"), Value: current.val() });
                break;
            case "":
                break;

        }
    });
    $("#search_table select").each(function(n) {
        if (this.type == "select-one") {
            var fn; //= this.id;

            fn = this.id;
            var val = ""; //Avoid IE8 JSON bug
            if (this.type == "checkbox" || this.type == "radio")
                val = this.checked + "";
            else if (this.type == "select-one") {
                var itemValue = $(this).find('option:selected').attr("value");
                if (itemValue != "0") {
                    val = $(this).find('option:selected').attr("value") + "";
                }
            }
            else if (this.type == "select-multiple") {
                var selected = [];
                $(this).children().each(function(i) {
                    if (this.selected) selected.push(i);
                });
                val = selected.join(",") + "";
            }
            else {
                val = this.value + "";
            }
            if (val.length > 0 && val != undefined && val != "undefined" && val != "請選擇" && fn.length > 0) {
                data.push({ Name: fn, Value: val });
            }

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