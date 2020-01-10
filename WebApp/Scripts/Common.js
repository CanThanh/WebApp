function objectifyForm(formArray) {//serialize data function

    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}

function getFormData($form){
    var unindexedArray = $form.serializeArray();
    var indexedArray = {};

    $.map(unindexedArray, function(n, i){
        indexedArray[n['name']] = n['value'];
    });

    return indexedArray;
}

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function messageSuccess(message) {
    toastr["success"](message);
}

function messageError(message) {

    toastr["error"](message);
}

function messageWarning(message) {
    toastr["warning"](message);
}

function confirmDelete(title, message, callback) {

    bootbox.confirm({
        title: title,
        message: message,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Thoát',
                className: 'btn-sm'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Đồng ý',
                className: 'btn btn-sm btn-green-site'
            }
        },
        callback: callback
    });
}
