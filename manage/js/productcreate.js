var editor;
$(function() {
    Supervisor.set_defaultSucceededCallback(SucceededCallback);
    Supervisor.set_defaultFailedCallback(FailedCallback);
    $('input[type="text"]').val("");
    editor = CKEDITOR.replace('FullIntro', { 'height': 400 });
    for (var i = 1; i <= 5; i++) {
        $("#uploadFile" + i).uploadPreview({ width: "auto", height: "auto", imgDiv: "#storePhotoUrl" + i });
        $("#uploadFile" + i).live('change', function() {
            if (($(this).val).length > 0) {
                var index = $(this).attr("class").replace("file_","");
                var src = $("#storePhotoHideDiv" + index).find("img").attr("src");
                $("#PhotoShow" + index).html('<img src="' + src + '" alt="" style="width:180px;"/>');
                //$("#PhotoShow").find("img").muImageResize({ width: 270, height: 310 });
            }
        });
    }
});
function SucceededCallback(result, userContext, methodName) {
    switch (methodName) {
       
        case "CreateProduction":
            uploadProductPhoto(result);
            break;
       
    }
}
function FailedCallback(error, userContext, methodName) {
    //  alert("功能有問題 請再試一次 或重新整理" + error.get_message() + " " + methodName);
}

function CreateProduction() {
    var obj = new Object();
    obj.Name = $("#Name").val();
    obj.Price = $("#Price").val();
    obj.ProductionCategory = $("#Production_Category").val();
    obj.ProductionLevel = $("#ProductionLevel").val();
    obj.Introduction = $("#Introduction").val();
    obj.FullIntro = editor.getData();

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
        Supervisor.CreateProduction(obj);
}
function uploadProductPhoto(result) {
    if (result == "0")
        return;
    //var Filevalue = $("#uploadFile").val();
    //if (Filevalue.length > 0) {
        var obj = new Object();
        var picSave = false;
        var options = {
            type: "POST",
            url: '../Files.ashx?type=productionPic&productid=' + result,
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
    //}
    //else {
    //    saveProductionSuccess(result);
    //}
}
function saveProductionSuccess(result) {
    if (result > 0) {
        alert("新增成功");
        window.location = "./product.aspx?id=" + result;
    }
    else
        alert("新增失敗");
    
}
