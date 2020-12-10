var orders = orders || {};
orders.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa đơn hàng này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Order/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Order/Index";
                        }
                    }
                });
            }
        }
    });
}


var orders = orders || {};
orders.changeStatus = function (orderId, statusId) {
    var statusName = "";
    switch (statusId) {
        case 2: statusName = "Active"
            break;
        case 3: statusName = "Complete"
            break;
    }
    bootbox.confirm({
        title: "Cảnh báo",
        message: `Bạn có muốn chuyển trạng thái đơn hàng này sang trạng thái <b class='text-danger'>${statusName}</b> không?`,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Order/ChangeStatus/${orderId}/${statusId}`,
                    method: "PATCH",
                    contentType: 'json',
                    success: function (data) {
                        if (data) {
                            window.location.href = "/Order/Index";
                        }
                    }
                });
            }
        }
    });
}

jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "formatted-num-pre": function (a) {
        a = (a === "-" || a === "") ? 0 : a.replace(/[^\d\-\.]/g, "");
        return parseFloat(a);
    },

    "formatted-num-asc": function (a, b) {
        return a - b;
    },

    "formatted-num-desc": function (a, b) {
        return b - a;
    }
});


$(document).ready(function () {
    $("#tbOrders").dataTable(
        {
            "language": {
                "sProcessing": "Đang xử lý...",
                "sLengthMenu": "Xem _MENU_ mục",
                "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                "sInfoPostFix": "",
                "sSearch": "Tìm:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Đầu",
                    "sPrevious": "Trước",
                    "sNext": "Tiếp",
                    "sLast": "Cuối"
                }
            },
            "columnDefs": [
                {
                    "targets": 3,
                    "orderable": false,
                    "width" : 100
                },
                {
                    "targets": 4,
                    "orderable": false,
                    "width": 100
                },
                {
                    "targets": 5,
                    "searchable": false,
                    "type": "formatted-num"
                },
                {
                    "targets": 6,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});