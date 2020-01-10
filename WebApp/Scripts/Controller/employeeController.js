var employeeConfig = {
    pageIndex: 1,
    pageSize: 5
}

var employeeController = {
    init: function () {
        employeeController.loadData();
        employeeController.registerEvent();
    },

    registerEvent: function () {
        $('#frmAddOrEdit').validate({
            rules: {
                Name: {
                    required: true,
                    minlength: 5
                },
                Salary: {
                    required: true,
                    number: true,
                    min: 0
                }
            },
            messages: {
                Name: {
                    required: "Bạn phải nhập tên",
                    minlength: "Tên phải lớn hơn 5 ký tự"
                },
                Salary: {
                    required: "Bạn phải nhập lương",
                    number: "Lương phải là số",
                    min: "Lương của bạn phải lớn hơn hoặc bằng 0"
                }
            }
        });

        $('#Keyword').off('keypress').on('keypress', function (e) {
            if (e.which === 13) {
                employeeController.loadData(true);
            }
        });

        $('#btnSearch').off('click').on('click', function () {
            employeeController.loadData(true);
        });

        $('#btnSave').off('click').on('click', function () {
            employeeController.saveData();
        });

        $('#btnAdd').off('click').on('click', function () {
            employeeController.loadDetail(0);
        });

        $('.btn-edit').off('click').on('click', function () {
            var id = $(this).data('id');
            employeeController.loadDetail(id);
        });

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Are you sure to delete this employee?", function (result) {
                employeeController.deleteEmployee(id);
            });
        });
    },

    configCkeditor: function() {
        CKEDITOR.replace('Name');
        CKEDITOR.instances['Name'].setData($("#Name").val());
    },

    loadDetail: function (id) {
        $.ajax({
            url: '/Employee/AddOrEdit',
            data: {
                id: id
            },
            type: 'GET',
            success: function (response) {
                $('#myModal div.modal-dialog').empty();
                $('#myModal div.modal-dialog').append(response);
                $('#myModal').modal('toggle');
                employeeController.registerEvent();
                //employeeController.configCkeditor();
            },
            error: function (err) {
                console.log(err);
            }
        });
    },

    loadData: function (changePageSize) {
        $("#divLoading").show();
        var inputData = {
            PageIndex: employeeConfig.pageIndex,
            PageSize: employeeConfig.pageSize,
            //Cretia: objectifyForm($('#frmSearch').serializeArray())
            Cretia: getFormData($('#frmSearch'))
        };

        $.ajax({
            url: '/Employee/Search',
            type: 'POST',
            data: JSON.stringify(inputData),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data,
                        function (i, item) {
                            html += Mustache.render(template,
                                {
                                    ID: item.Id,
                                    Name: item.Name,
                                    Salary: item.Salary
                                    //Status: item.Status == true
                                    //    ? "<span class=\"label label-success\">Actived</span>"
                                    //    : "<span class=\"label label-danger\">Locked</span>"
                                });

                        });
                    $('#tblData').html(html);
                    employeeController.paging(response.total,
                        function () {
                            employeeController.loadData();
                        },
                        changePageSize);
                    employeeController.registerEvent();
                    $("#divLoading").hide();
                }
            }
        });
    },

    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / employeeConfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }

        if (totalPage > 0) {
            $('#pagination').twbsPagination({
                totalPages: totalPage,
                first: "Đầu",
                next: "Tiếp",
                last: "Cuối",
                prev: "Trước",
                visiblePages: 5,
                onPageClick: function (event, page) {
                    if (employeeConfig.pageIndex !== page) {
                        employeeConfig.pageIndex = page;
                        setTimeout(callback, 200);
                    }
                }
            });
        }
    },

    saveData: function () {
        //$('#Name').val(CKEDITOR.instances["Name"].getData());
        if ($("#frmAddOrEdit").valid()) {
            var fileData = new FormData($('#frmAddOrEdit')[0]);
            $.ajax({
                url: '/Employee/AddOrEdit',
                type: "POST",
                //data: JSON.stringify(getFormData($('#frmAddOrEdit'))),
                //contentType: 'application/json',
                data: fileData,
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                success: function (response) {
                    if (response.IsError) {
                        if (response.ErrorCode === 1) {
                            $('#myModal div.modal-dialog').empty();
                            $('#myModal div.modal-dialog').append(response.Message);
                        } else {
                            alert(response.Message);
                        }
                    } else {
                        $('#myModal').modal('toggle');
                        employeeController.loadData(true);
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
    },

    deleteEmployee: function (id) {
        $.ajax({
            url: '/Employee/Delete',
            data: {
                id: id
            },
            type: 'POST',
            success: function (response) {
                if (response.IsError === false) {
                    employeeController.loadData(true);
                }
                else {
                    bootbox.alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
}

//function AddOrEdit(id) {
//    employeeController.loadDetail(id);
//};

//function Delete(id) {
//    employeeController.deleteEmployee(id);
//};

employeeController.init();