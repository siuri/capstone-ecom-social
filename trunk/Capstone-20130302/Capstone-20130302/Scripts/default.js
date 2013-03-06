$(function(){
    $(".modal").on("show",function(){
        $(".modal").not(this).modal("hide");
    });
    $('body').tooltip({
        selector: '[rel=tooltip]'
    });
    $("#cart > a").click(function(){
        $("#cart > .cart-container").toggle(300);
    })
})