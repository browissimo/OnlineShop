window.addEventListener('DOMContentLoaded', () => {
    const menu = document.querySelector('.main_menu'),
        menuItem = document.querySelectorAll('.main_menu_item'),
        hamburger = document.querySelector('.hamburger');
        mainMenuDiv = document.querySelector('.main_menu_div');

    hamburger.addEventListener('click', () => {
        hamburger.classList.toggle('hamburger_active');
        menu.classList.toggle('main_menu_active');
        mainMenuDiv.classList.toggle('main_menu_div_active');
    });

    menuItem.forEach(item => {
        item.addEventListener('click', () => {
            hamburger.classList.toggle('hamburger_active');
            menu.classList.toggle('main_menu_active');

        })
    })
})

var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}