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
                // $("#searchresult table tbody").append("<tr><th class='head' colspan='2'>Results for \""+searchvalue+"\"</th></tr>");
                for (var i = 0; i < types.length; i++) {
                    $("#searchresult table tbody").append("<tr><th colspan='2'>"+ types[i] +" ("+data[types[i]].length+")</th></tr>");
                    if (data[types[i]].length == 0) {
                        $("#searchresult table tbody").append("<tr><td colspan='2' class='empty'>No matched result.</td></tr>");
                    } else {
                        $.each(data[types[i]], function (i, item) {
                            $("#searchresult table tbody").append("<tr><td><a href='"+item.ID+"'>"+"<div class='frame' style='background-image: url(/Image/"+ item.ImageId +");'></div></a></td><td><a class='value' href='"+item.ID+"'>" + item.Value + "</a></td></tr>");
                        });
                    }
                };
                $("#searchresult").show();
            },
        });
    } else {
        $("#searchresult").hide();
        $("#searchresult table tbody").html("");
    }
}
