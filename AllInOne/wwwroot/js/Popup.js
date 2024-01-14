$(function () {
    var placeHolderElement = $('#placeHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var type = $(this).data('type');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        });
    });

    placeHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionurl = form.attr('action');
        var url = "/popup/popup/" + actionurl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            placeHolderElement.find('.modal').modal('hide');
        });
    });


    $('button[data-toggle="ajax-delete"]').click(function (event) {

        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            alert("Deleted");
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