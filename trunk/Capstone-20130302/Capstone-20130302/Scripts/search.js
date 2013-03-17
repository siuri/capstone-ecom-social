function search() {
    var searchvalue = document.getElementById('searchString').value;
    //alert(searchvalue);           
    var datalist = $.ajax({
        url: 'Search/Search?searchString=' + searchvalue,
        data: "{}",
        dataType: 'json',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#searchresult").text("<table>");
            $.each(data, function (i, item) {
                $("#searchresult").append("<tr><td>" + item.Text + "</td><td>" + item.Value + "</td><td>" + item.Value + "</td></tr>");
            });
            $("#searchresult").append("</table>");
        },
    });
}