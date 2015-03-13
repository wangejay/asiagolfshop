$(function() {
    Supervisor.set_defaultSucceededCallback(SucceededCallback);
    Supervisor.set_defaultFailedCallback(FailedCallback);
    $('input[type="text"]').val("");
});
function SucceededCallback(result, userContext, methodName) {
    switch (methodName) {
        case "CreateCategory":
            CreateCategoryResponse(result);
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
