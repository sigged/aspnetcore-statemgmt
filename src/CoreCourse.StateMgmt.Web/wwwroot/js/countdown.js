$(function () {
    var countDownTo = parseInt($('#cacheDuration').val());
    var counter = 10;

    var interval = setInterval(function () {
        if (counter > 0) {
            $('#counter').html("<big>Cache expires in <b>" + counter + "</b> seconds</big>");
            counter--;
        } else {
            $('#counter').html("<big>Cache has <b>expired</b>!</big> <small>All is lost! <small>Armageddon!</small></small>");
            clearInterval(interval);
        }
    }, 1000);

});