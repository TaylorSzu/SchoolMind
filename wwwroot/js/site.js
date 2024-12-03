$(document).ready(function() {
    $('.navbar-nav .nav-item').hover(
        function() {
            $(this).css('background-color', '#444');
        },
        function() {
            $(this).css('background-color', '');
        }
    );

    var turmasDropdown = new bootstrap.Dropdown(document.getElementById('turmasDropdown'));
    var materialDropdown = new bootstrap.Dropdown(document.getElementById('materialDropdown'));
    var calendarioDropdown = new bootstrap.Dropdown(document.getElementById('calendarioDropdown'));
    var chamadaDropdown = new bootstrap.Dropdown(document.getElementById('chamadaDropdown'));

    $('#turmasDropdown').on('click', function() {
        document.title = "Turmas - SchoolMind";
    });

    $(document).click(function(event) {
        var $target = $(event.target);
        if (!($target.closest('.navbar-nav').length || $target.closest('.navbar-toggler').length)) {
            $('.navbar-nav .dropdown-menu').collapse('hide');
        }
    });

    $('#materialDropdown').on('click', function() {
        console.log("Material Didático selecionado!");
    });
});
