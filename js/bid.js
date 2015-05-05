function goBidDetail(index) {
    window.location = "./biddetail.aspx?id=" + index;
}

($(function() {
    // 計算倒數計時，使用 jquery.timers.js
    var startDate = new Date();

    $('.timeLeft span').each(function() {
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
            countText += (h > 0) ? d + '時' : '';
            countText += (d < 1) ? d + '分' : '';
            countText += (d < 1 && h < 1 ) ? s + '秒' : '';

        } else { // 避免倒數變成負的

            countText = '此競標已結束';
        }

        $(this).text(countText);
    });
}));