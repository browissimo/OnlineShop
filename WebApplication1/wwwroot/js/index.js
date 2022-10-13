window.addEventListener('DOMContentLoaded', () => {
    const menu = document.querySelector('.main_menu'),
        menuItem = document.querySelectorAll('.main_menu_item'),
        hamburger = document.querySelector('.hamburger'),
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