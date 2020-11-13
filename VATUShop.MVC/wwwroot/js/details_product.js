var products = products || {};
products.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa sản phẩm này không?",
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
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Product/Index";
                        }
                    }
                });
            }
        }
    });
}

products.addCart = function (productId, check) {
    var quantity = parseInt($('#quantity').val());
    console.log(quantity);
    if (quantity > 0 && productId > 0) {
        $.ajax({
            url: `/ShoppingCart/AddCart/${productId}/${quantity}`,
            method: "GET",
            contentType: 'json',
            success: function (data) {
                if (data && check == 1) {
                    //window.location.href = `/Home/Details/${productId}`;
                    var count = $('#countCart').text();
                    $('#countCart').text(parseInt(count) + quantity);
                    bootbox.alert("Bạn đã thêm sản phẩm vào giỏ hàng thành công !");
                }
                if (data && check == 0) {
                    var count = $('#countCart').text();
                    $('#countCart').text(parseInt(count) + quantity);
                    window.location.href = "/Order/Create";
                }
            }
        });
    }
    else {
        bootbox.alert("Số lượng sản phẩm không hợp lệ !");
    }
}