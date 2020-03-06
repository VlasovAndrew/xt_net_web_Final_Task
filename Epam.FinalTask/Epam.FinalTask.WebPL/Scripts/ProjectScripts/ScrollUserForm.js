const mainForm = document.getElementById('main-form');
const formTabs = document.getElementsByClassName('tab');
const actionBtn = document.getElementById('action-btn');
const backBtn = document.getElementById('back-btn');

let tabIndex = 0;

let makeInvalidInput = (inputRow, input, message) => {
    input.classList.add('is-invalid');
    inputRow.querySelector('.invalid-feedback').innerHTML = message;
}

let validateAccountData = (form) => {
    let loginRow = document.getElementById('login-row');
    let loginInput = loginRow.querySelector('input');
    
    if (loginInput.value == "") {
        makeInvalidInput(loginRow, loginInput, 'Пожалуйста введите Ваш логин.');
        
        return;    
    }

    let passwordRow = form.querySelector('#password-row');
    let passwordInput = passwordRow.querySelector('input');
    if (passwordInput.value == "") {
        makeInvalidInput(passwordRow, passwordInput, 'Пожалуйста введите Ваш пароль.');
        
        return;
    }

    let confirmPasswordRow = form.querySelector('#configrm-password-row');
    let confirmPasswordInput = confirmPasswordRow.querySelector('input');
    if (confirmPasswordInput.value == "") {
        makeInvalidInput(confirmPasswordRow, confirmPasswordInput, 'Пожалуйста повторите Ваш пароль.');
        return;
    }

    if (confirmPasswordInput.value !== passwordInput.value) {
        makeInvalidInput(confirmPasswordRow, confirmPasswordInput, 'Ввведенные пароли не совпадают.');        
        return;
    }

    $.get('/actions/CheckAccount', { login: loginInput.value }, function (data) {
        let response = JSON.parse(data);
        if (response.status == "exist") {
            makeInvalidInput(loginRow, loginInput, 'Аккаунт уже существует. Пожалуйста выберите другой.');
        }
        else {
            scrollRightForm();
        }
    });
}

let validateUserData = (form) => {
    let nameRow = document.getElementById('name-input');
    let nameInput = nameRow.querySelector('input');
    if (nameInput.value == '') {
        makeInvalidInput(nameRow, nameInput, 'Пожалуйста введите имя.');
        return;
    }

    let lastnameRow = document.getElementById('lastname-input');
    let lastnameInput = lastnameRow.querySelector('input');

    if (lastnameInput.value == '') {
        makeInvalidInput(lastnameRow, lastnameInput, 'Пожалуйста введите фамилию.');
        return;
    }

    let dateRow = document.getElementById('date-row');
    let dateInput = dateRow.querySelector('input');
    if (dateInput.value == '') {
        makeInvalidInput(dateRow, dateInput, 'Пожалуйста введите дату рождения.'); 
        return;
    }
    // validate input date

    let cityRow = document.getElementById('city-row');
    let cityInput = cityRow.querySelector('input');
    if (cityInput.value == '') {
        makeInvalidInput(cityRow, cityInput, 'Пожалуйста введите Ваш город.');
        return;
    }

    let streetRow = document.getElementById('street-row');
    let streetInput = streetRow.querySelector('input');
    if (streetInput.value == '') {
        makeInvalidInput(streetRow, streetInput, 'Пожалуйста введите Вашу улицу');
        return;
    }

    let houseRow = document.getElementById('house-row');
    let houseInput = houseRow.querySelector('input');
    if (houseInput.value == '') {
        makeInvalidInput(houseRow, houseInput, 'Пожалуйста введите Ваш дом.');
        return;
    }

    mainForm.submit();
}

let scrollRightForm = () => {
    formTabs[tabIndex].style.display = 'none';
    if (tabIndex == 0) {
        backBtn.style.display = 'block';
    }

    tabIndex++;
    if (tabIndex == formTabs.length - 1) {
        actionBtn.type = 'submit';
        actionBtn.innerHTML = 'Создать';
    }
    formTabs[tabIndex].style.display = 'block';
}

let scrollLeftForm = () => {
    formTabs[tabIndex].style.display = 'none';
    tabIndex--;
    if (tabIndex == 0) {
        backBtn.style.display = 'none';
        actionBtn.innerHTML = 'Далее';
    }
    formTabs[tabIndex].style.display = 'block';
}

let clearAllValidationResult = () => {
    let input = document.getElementsByTagName('input');
    for (let i = 0; i < input.length; i++) {
        input[i].classList.remove('is-invalid');
    }
}

let prevTab = (event) => {
    event.preventDefault();
    scrollLeftForm();
}

let nextTab = (event) => {
    event.preventDefault();
    if (tabIndex == 0) {
        validateAccountData(formTabs[0]);
    }
    else if (tabIndex == 1) {
        validateUserData(formTabs[1]);
    }
}

formTabs[0].style.display = 'block';

backBtn.addEventListener('click', prevTab);
actionBtn.addEventListener('click', clearAllValidationResult);
actionBtn.addEventListener('click', nextTab);

