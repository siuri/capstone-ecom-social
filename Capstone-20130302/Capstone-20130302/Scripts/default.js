$(function(){
    $(".modal").on("show",function(){
        $(".modal").not(this).modal("hide");
    });
    //$('[rel=tooltip]').tooltip();
    $("#cart > a").click(function(){
        $("#cart > .cart-container").toggle(200);
    })
    $(document).click(function(){
        $(".cart-container").hide(200);
    })
    $(".cart-container,#cart > a").click(function (e) {
        e.preventDefault();
        return false;
    })
})