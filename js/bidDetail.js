window.onload = initPage;

function initPage() {
    AspAjax.set_defaultSucceededCallback(SucceededCallback);
    AspAjax.set_defaultFailedCallback(FailedCallback);
    AspAjax.IsAuthenticated();
}
function SucceededCallback(result, userContext, methodName) {
    baseSucceededCallback(result, userContext, methodName);
    switch (methodName) {
        case "addBidPrice":
            if (result == Message_NoAuth)
                alert("請先登入");
            else {
                alert("新增出價成功");
                window.location = "./biddetail.aspx?id=" + result;
            }
            break;
    }
}
function FailedCallback(error, userContext, methodName) {
    baseFailedCallback(error, userContext, methodName);
}

function goAddNewPrice() {
    var obj = {
        BidID : $('#bidID').val(),
        BidPrice: parseInt($('#newPrice').val())
    };
    AspAjax.addBidPrice(obj);
}


($(function() {
    // 計算倒數計時，使用 jquery.timers.js
    var pRecordCounter = $('#pRecordCounter');
    var startDate = new Date();
    var endDate = new Date(pRecordCounter.text());
    var spantime = (endDate - startDate) / 1000;
    var countText = '';

    $(this).everyTime('1s', function(i) {
        spantime--;
        var d = Math.floor(spantime / (24 * 3600));
        var h = Math.floor((spantime % (24 * 3600)) / 3600);
        var m = Math.floor((spantime % 3600) / (60));
        var s = Math.floor(spantime % 60);


        if (spantime > 0) {
        
            countText += (d > 0) ? d + '日' : '';
            countText += (h > 0) ? d + '時' : '';
            countText += (m > 0) ? d + '分' : '';
            countText += s + '秒';

        } else { // 避免倒數變成負的
        
            countText = '此競標已結束';
        }

        pRecordCounter.text(countText);
    });





    // 按下出價按鈕後的行為
    $('#btn-new-price').click(function() {
        var newPriceInput = $('#newPrice');
        var newPrice = parseInt(newPriceInput.val());
        var priceInterval = parseInt($('#priceInterval').val());
        var maxBidPrice = parseInt($('#pMaxBidPrice span').text());
        var aleast = priceInterval + maxBidPrice;

        if (newPriceInput.is(':hidden')) { // 第一次顯示出價輸入框

            newPriceInput.val(aleast);
            newPriceInput.slideDown('fast');
            $(this).text('確認出價');

        } else {

            if (newPrice < aleast) { // 如果最低出價就警告

                $('#newBidPriceAlert p').html('新增標價須大於' + aleast + "元").slideDown('fast');

            } else { // 高於最低出價就進行處理

                goAddNewPrice();

            }

        }
    });
    $('#newPrice').click(function() {
        $('#newBidPriceAlert p').slideUp('fast');
    });


    // 滑鼠移動到縮圖上會換產品圖的程式碼
    $('.productImgs UL LI')
        .mouseover(function() {
            $('#mainImg').css('background-image', 'url(' + $(this).find('IMG').attr('src') + ')');
            $('#productImgBig').css('visibility', 'hidden');
        })
        .click(function() {
            $('#productImgBig').attr('src', $(this).find('IMG').attr('src'));
        });
    $('.productImgs UL')
        .mouseout(function() {
            $('#productImgBig').css('visibility', 'visible');
            $('#mainImg').css('background-image', 'none');
        });
}));