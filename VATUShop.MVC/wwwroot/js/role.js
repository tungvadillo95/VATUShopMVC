var users = {} || users;


$(document).ready(function () {
    $("#tbRoles").dataTable(
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
                    "targets": 0,
                    "orderable": false,
                    "width": 300
                },
                {
                    "targets": 1,
                    "orderable": false,
                    "width": 300
                },
                {
                    "targets": 2,
                    "orderable": false,
                    "searchable": false,
                    "width": 300
                }
            ]
        }
    );
});