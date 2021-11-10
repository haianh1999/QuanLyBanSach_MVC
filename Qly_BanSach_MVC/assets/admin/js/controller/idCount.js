
$(document).ready(function () {
    $(".p-text-id").each(function (index) {
        $(this).addClass('tab' + (index + 1));
    })
    for (i = 1; i <= $('.p-text-id').length; i++) {
        $('.tab' + i).text(i);
    }



})