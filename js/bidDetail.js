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