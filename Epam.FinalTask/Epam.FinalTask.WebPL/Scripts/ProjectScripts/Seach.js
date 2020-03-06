const searchBtn = document.getElementById('search-btn');
const usernameInput = document.getElementById('user-name-input');
const cityInput = document.getElementById('city-input');
const streetInput = document.getElementById('street-input');

let search = () => {
    let nameSearchParams = usernameInput.value.split(' ');
    let name = nameSearchParams[0];
    let surname = nameSearchParams[1];

    let city = cityInput.value;
    let street = streetInput.value;

    $.get('/user/search');
}

searchBtn.addEventListener('click', search);


