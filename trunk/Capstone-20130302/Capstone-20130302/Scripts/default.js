$(function(){
    $(".modal").on("show",function(){
        $(".modal").not(this).modal("hide");
    });
    //$('[rel=tooltip]').tooltip();
    $("#cart > a").click(function(){
        $("#cart > .cart-container").toggle(200);
    })
})