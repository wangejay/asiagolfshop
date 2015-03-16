﻿var editor;
var uploadQueryString = "";
$(function() {
    Supervisor.set_defaultSucceededCallback(SucceededCallback);
    Supervisor.set_defaultFailedCallback(FailedCallback);
    //$('input[type="text"]').val("");
    editor = CKEDITOR.replace('FullIntro', { 'height': 400 });
    $("#uploadFile").uploadPreview({ width: "auto", height: "auto", imgDiv: "#storePhotoUrl" });
    $("#uploadFile").live('change', function() {
        if (($(this).val).length > 0) {
            var src = $("#storePhotoHideDiv").find("img").attr("src");
            $("#PhotoShow").html('<img src="' + src + '" alt="" style="width:180px;"/>');
            //$("#PhotoShow").find("img").muImageResize({ width: 270, height: 310 });
        }
    });
});
function SucceededCallback(result, userContext, methodName) {
    switch (methodName) {

        case "UpdateProduction":
            uploadProductPhoto(result);
            break;

    }
}
function FailedCallback(error, userContext, methodName) {
    //  alert("功能有問題 請再試一次 或重新整理" + error.get_message() + " " + methodName);
}

function UpdateProduction() {
    var obj = new Object();
    obj.ID = gup("id");
    obj.Name = $("#name").val();
    obj.Price = $("#price").val();
    obj.ProductionCategory = $("#Production_Category").val();
    obj.ProductionLevel = $("#ProductionLevel").val();
    obj.Introduction = $("#Introduction").val();
    obj.FullIntro = editor.getData();
    for (var i = 1; i <= 5; i++) {
        if ($("#uploadFile" + i).val().length > 0) {
           
            uploadQueryString += "&file" + i + "=1";
        }
        else {
            uploadQueryString += "&file" + i + "=0";
        }
    }
    var Hand = new Array();
    $('input[name="hand"]:checked').each(function(i) {
        Hand[Hand.length] = this.value;
    });
    obj.Hand = Hand;

    var Angle = new Array();
    $('input[name="angle"]:checked').each(function(i) {
        Angle[Angle.length] = this.value;
    });
    obj.Angle = Angle;

    var GolfClub = new Array();
    $('input[name="golfClub"]:checked').each(function(i) {
        GolfClub[GolfClub.length] = this.value;
    });
    obj.GolfClub = GolfClub;

    var GolfHard = new Array();
    $('input[name="hardness"]:checked').each(function(i) {
        GolfHard[GolfHard.length] = this.value;
    });
    obj.GolfHard = GolfHard;
    if (obj.Name.length == 0)
        alert("請填寫產品名稱");
    else if (obj.Price.length == 0)
        alert("請填寫價格");
    else if (isNaN(obj.Price)) {
        alert("價格請填寫數字");
    }
    else
        Supervisor.UpdateProduction(obj);
}
function uploadProductPhoto(result) {
    if (result == "0")
        return;
    var hasPic = false;
    for (var i = 1; i <= 5; i++) {
        if ($("#uploadFile" + i).val().length > 0) {
            hasPic = true;
        }
    }
    if (hasPic){
        var obj = new Object();
        var picSave = false;
        var options = {
            type: "POST",
            url: '../Files.ashx?type=productionPic&productid=' + result + uploadQueryString,
            async: false,
            success: function(value) {
                if (value.length > 0) {
                    saveProductionSuccess(value);
                }
                else {
                    alert("上傳照片發生錯誤");
                }
            }
        };
        $('#GmyForm').ajaxSubmit(options); // 將options傳給ajaxForm
    }
    else {
        saveProductionSuccess(result);
    }
}
function saveProductionSuccess(result) {
    if (result > 0) {
        alert("更新成功");
        window.location = "./product.aspx?id=" + result;
    }
    else
        alert("更新失敗");

}
