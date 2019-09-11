const uri = "api/ApiProduct";

$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#Students");
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
});




