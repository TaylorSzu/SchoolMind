function toggleMenu(){
    let subMenu = document.getElementById("subMenu");
    subMenu.classList.toggle("open-menu");
}

function toggleDropdown(id) {
    let dropdownMenu = document.getElementById(id);
    dropdownMenu.classList.toggle("show-dropdown");
}
