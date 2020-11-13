var create = create || {};
var provinceId = 0;
create.changeProvince = function (id) {
    create.drawDistrict(id);
    $("#WardId").append(`<option selected value="">-Chọn-</option>`);
}

create.drawDistrict = function (provinceId) {
    $.ajax({
        url: `/ShoppingCart/Districts/${provinceId}`,
        method: "GET",
        contentType: "json",
        success: function (data) {
            console.log(data);
            $("#DistrictId").empty();
            $("#DistrictId").append(`<option selected value="">-Chọn-</option>`);
            $.each(data.districts, function (i, v) {
                $("#DistrictId").append(`
                    <option value=${v.id}>${v.districtName}</option>
                `);
            });
        }
    });
    $("#WardId").empty();
}

create.changeDistrict = function (id) {
    provinceId = $("#ProvinceId").val();
    create.drawWard(id, provinceId);
}

create.drawWard = function (districtId, provinceId) {
    $.ajax({
        url: `/ShoppingCart/Wards/${districtId}/${provinceId}`,
        method: "GET",
        contentType: "json",
        success: function (data) {
            console.log(data);
            $("#WardId").empty();
            $("#WardId").append(`<option selected value="">-Chọn-</option>`);
            $.each(data.wards, function (i, v) {
                $("#WardId").append(`
                    <option value=${v.id}>${v.wardName}</option>
                `);
            });
        }
    });
}