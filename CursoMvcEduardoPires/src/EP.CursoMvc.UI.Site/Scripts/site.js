$(document).ready(function() {
    $(".dropdown").hover(
        function() {
            $(".dropdown-menu", this).not(".in .dropdown-menu").stop(tru, true).slideDown("fast");
            $(this).toggleClass("open");
        },
        function() {
            $(".dropdown-menu", this).not(".in .dropdown-menu").stop(tru, true).slideUp("fast");
            $(this).toggleClass("open");
        }
    );
});