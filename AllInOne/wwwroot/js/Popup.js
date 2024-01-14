$(function () {
    GetData();
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
        debugger;
        $.post(url, sendData).done(function (data) {
            placeHolderElement.find('.modal').modal('hide');
            GetData();
            loadPartialView('success','Record save successfully');
        });
    });
});

function Delete(id) {
    $.get(URl.Delete + id).done(function (data) {
        GetData();
        loadPartialView('success','Record deleted successfully');
    });
}

function Edit(id) {
    var placeHolderElement = $('#placeHolderHere');
    $.get(URl.Edit + id).done(function (data) {
        placeHolderElement.html(data);
        placeHolderElement.find('.modal').modal('show');
    });
}

function loadPartialView(type,msg) {
    $.ajax({
        type: "POST",
        url: "/popup/popup/AlertMessage",
        data: { type: type,msg:msg },
        success: function (result, status) {
            $("#alertmsg").html(result);
        }
    });
}

function GetData() {
    var url = "/popup/popup/GetData";
    $.get(url).done(function (data) {
        $('#t_body').empty();
        var tableData = "";
        $.each(data, function (index, row) {
            tableData += "<tr>";
            tableData += "<td>" + (index + 1) + "</td>";
            tableData += "<td>" + row.name + "</td>";
            tableData += "<td>" + row.age + "</td>";
            tableData += "<td>" + row.address + "</td>";
            tableData += "<td> <a href='javascript:void(0)' class='btn btn-sm btn-outline-primary' onclick='return Edit(" + row.id + ")'> Edit</a > | "
            tableData += "<a href='javascript:void(0)' class='btn btn-sm btn-outline-danger' onclick='return Delete(" + row.id + ")'>Delete</a>";
            tableData += "</tr>";
        })
        $('#t_body').html(tableData);
    });
}