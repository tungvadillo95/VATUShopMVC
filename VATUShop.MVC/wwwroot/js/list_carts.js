var carts = carts || {};
carts.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?",
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
                    url: `/ShoppingCart/DeleteCart/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/ShoppingCart/ListCart";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbCarts").dataTable(
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
                    "targets": 5,
                    "orderable": false
                },
                {
                    "targets": 6,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 8,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});