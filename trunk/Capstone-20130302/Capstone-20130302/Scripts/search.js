function search() {
    var searchvalue = $('#searchString').val();
    if (searchvalue.length > 0) {
        var datalist = $.ajax({
            url: '/Search/Search?searchString=' + searchvalue,
            data: "{}",
            dataType: 'json',
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#searchresult table tbody").html("");
                var types = ["Products", "Stores", "Users"];
                for (var i = 0; i < types.length; i++) {
                    $("#searchresult table tbody").append("<tr><th colspan='2'>"+ types[i] +" ("+data[types[i]].length+")</th></tr>");
                    if (data[types[i]].length == 0) {
                        $("#searchresult table tbody").append("<tr><td colspan='2'>No matched result.</td></tr>");
                    } else {
                        $.each(data[types[i]], function (i, item) {
                            $("#searchresult table tbody").append("<tr><td><img src='/Image/"+ item.ImageId +"'/></td><td>" + item.Value + "</td></tr>");
                        });
                    }
                };
                $("#searchresult").slideDown(300);
            },
        });
    } else {
        $("#searchresult").hide();
        $("#searchresult table tbody").html("");
    }
}
