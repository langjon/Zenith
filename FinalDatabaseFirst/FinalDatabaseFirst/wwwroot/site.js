const uri = "api/ApiProduct";
const urlCustomer = "api/Customers"

$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#Products");
            $(tBody).empty();
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.prodId))
                    .append($("<td></td>").text(item.prodType))
                    .append($("<td></td>").text(item.prodSize))
                    .append($("<td></td>").text(item.prodMaterial))
                    .append($("<td></td>").text(item.prodQuantity))
                    .append($("<td></td>").text(item.productBriefDescription))
                
                tr.appendTo(tBody);
               
            });

            products = data;
        }
    });
    $.ajax({
        type: "GET",
        url: urlCustomer,
        cache: false,
        success: function (data) {
            const tBody = $("#Customers");
            $(tBody).empty();
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.cusId))
                    .append($("<td></td>").text(item.cusName))
                    .append($("<td></td>").text(item.cusPhone))
                    .append($("<td></td>").text(item.cusEmail))
                    .append($("<td></td>").text(item.cusAddress))
                    .append($("<td></td>").text(item.cusPostalCode))

                tr.appendTo(tBody);

            });

            customers = data;
        }
    });
});




