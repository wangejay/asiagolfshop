var editor;
$(function() {
Supervisor.set_defaultSucceededCallback(SucceededCallback);
Supervisor.set_defaultFailedCallback(FailedCallback);
    $('input[type="text"]').val("");
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
        case "CreateCategory":
            CreateCategoryResponse(result);
            break;
        case "CreateProduction":
            uploadProductPhoto(result);
            break;
        case "PauseCategory":
            setCategoryResponse(result, "下架");
            break;
        case "RestartCategory":
            setCategoryResponse(result, "上架");
            break;
        case "DeleteCategory":
            setCategoryResponse(result, "刪除");
            break;
    }
}
function FailedCallback(error, userContext, methodName) {
    //  alert("功能有問題 請再試一次 或重新整理" + error.get_message() + " " + methodName);
}
function goCreateCategory() {
    var Category = $("#search_account").val();
    if (Category.length == 0) {
        alert("請填寫分類名稱");
    }
    else {
        Supervisor.CreateCategory(Category);
    }
}
function setCategoryResponse(result, actionName) {
    if (result == MessageSuccess)
        alert(actionName + "成功");
    else
        alert(actionName + "失敗");
    window.location.reload();
}
function CreateCategoryResponse(result) {
    if (result = MessageSuccess) {
        alert("新增成功");
        window.location.reload();
    }
    else { 
        alert("新增失敗");
    }
}
function CreateProduction() {
    var obj = new Object();
    obj.Name = $("#Name").val();
    obj.Price = $("#Price").val();
    obj.ProductionCategory = $("#Production_Category").val();
    obj.ProductionLevel = $("#ProductionLevel").val();
    obj.Hand = $("#Hand").val();
    obj.Angle = $("#Angle").val();
    obj.GolfClub = $("#GolfClub").val();
    obj.GolfHard = $("#GolfHard").val();
    obj.Introduction = $("#Introduction").val();
    obj.FullIntro = editor.getData();
    
    Supervisor.CreateProduction(obj);
}
function uploadProductPhoto(result) {
    if (result == "0")
        return;
    var Filevalue = $("#uploadFile").val();
    if (Filevalue.length > 0) {
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
    }
    else {
        saveProductionSuccess(result);
    }
}
function saveProductionSuccess(result) {
    if (result == MessageSuccess)
        alert("新增成功");
    else
        alert("新增失敗");
    location.reload();
}
function pauseCategory(id) {
    Supervisor.PauseCategory(id);
}
function restartCategory(id) {
    Supervisor.RestartCategory(id);
}
function deleteCategory(id) {
    var r = confirm("刪除此分類，會將所有此分類的產品通通下架，確定要刪除嗎?");
    if (r == true) {
        Supervisor.DeleteCategory(id);
    }
}
