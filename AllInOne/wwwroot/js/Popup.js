$(function () {
    var placeHolderElement = $('#placeHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        });
    });

    //placeHolderElement.on('click', '[data-dismiss = "modal"]', function (event) {
    //    placeHolderElement.find('.modal').modal('hide');
    //});


});

function onSuccess() {
    alert("onSuccess");
}


function onFailed() {
    alert("onFailed");
}