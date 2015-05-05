function goBidDetail(index) {
    window.location = "./biddetail.aspx?id=" + index;
}

// 倒數時日計算，使用 jquery.timers.js
// 讀取 .timeLeft span:not(.counted) 中的日期資料並轉換成倒數時間
// 因為最後會把標籤加上 counted 的 class
// 所以重複執行並不會把轉換過的再做一次轉換，造成錯誤。
// 之後若是要改成動態連續載入時，請在載入完成後，
// 重新呼叫一次這個函數即可。

function endDateCalc() {
    var startDate = new Date();

    $('.timeLeft span:not(.counted)').each(function() {
        var endDate = new Date($(this).text());
        var spantime = (endDate - startDate) / 1000;
        var countText = '';

        spantime--;
        var d = Math.floor(spantime / (24 * 3600));
        var h = Math.floor((spantime % (24 * 3600)) / 3600);
        var m = Math.floor((spantime % 3600) / (60));
        var s = Math.floor(spantime % 60);


        if (spantime > 0) {

            countText += (d > 0) ? d + '日' : '';
            countText += (h > 0) ? h + '時' : '';
            countText += (d < 1) ? m + '分' : '';

        } else { // 避免倒數變成負的

            countText = '此競標已結束';
        }

        $(this).text(countText).addClass('counted');
    });
}

($(function() {
    // 執行倒數時日計算
    endDateCalc();

}));