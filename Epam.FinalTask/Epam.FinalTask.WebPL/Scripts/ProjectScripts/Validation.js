let makeInvalidInput = (inputRow, input, message) => {
    if (!input.classList.contains('is-invalid')) {
        input.classList.add('is-invalid');
    }
    inputRow.querySelector('.invalid-feedback').innerHTML = message;
}


let validateUserData = (callback) => {
    let nameSurnameReg = /^[а-яА-Я]{2,20}$/g;

    let nameRow = document.getElementById('name-input');
    let nameInput = nameRow.querySelector('input');
    if (nameInput.value == '') {
        makeInvalidInput(nameRow, nameInput, 'Пожалуйста введите имя.');
        return;
    }

    if (!nameSurnameReg.test(nameInput.value)) {
        makeInvalidInput(nameRow, nameInput, 'Пожалуйста введите корректное имя русскими буквами.');
        return;
    }
    nameSurnameReg.lastIndex = 0;
    let lastnameRow = document.getElementById('lastname-input');
    let lastnameInput = lastnameRow.querySelector('input');
    if (lastnameInput.value == '') {
        makeInvalidInput(lastnameRow, lastnameInput, 'Пожалуйста введите фамилию.');
        return;
    }

    if (!nameSurnameReg.test(lastnameInput.value)) {
        makeInvalidInput(lastnameRow, lastnameInput, 'Пожалуйста введите корректную фамилию русскими буквами.');
        return;
    }

    let dateRow = document.getElementById('date-row');
    let dateInput = dateRow.querySelector('input');
    if (dateInput.value == '') {
        makeInvalidInput(dateRow, dateInput, 'Пожалуйста введите дату рождения.');
        return;
    }
    console.log(dateInput.value);


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
    callback();
}


let validateAccountData = (callback) => {
    let loginRegex = /^[\w]{5,20}$/g;

    let loginRow = document.getElementById('login-row');
    let loginInput = loginRow.querySelector('input');

    if (loginInput.value == "") {
        makeInvalidInput(loginRow, loginInput, 'Пожалуйста введите Ваш логин.');
        return;
    }

    if (!loginRegex.test(loginInput.value)) {
        makeInvalidInput(loginRow, loginInput, 'Логин может содержать только буквы, цифры и знак подчеркивания, длина от 5 до 20 символов');
        return;
    }

    let passwordRow = document.getElementById('password-row');
    let passwordInput = passwordRow.querySelector('input');
    if (passwordInput.value == "") {
        makeInvalidInput(passwordRow, passwordInput, 'Пожалуйста введите Ваш пароль.');
        return;
    }

    let confirmPasswordRow = document.getElementById('configrm-password-row');
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
            callback();
        }
    });
}

let clearInvalidClass = (collection) => {
    for (let i = 0; i < collection.length; i++) {
        collection[i].classList.remove('is-invalid');
    }
}

let clearAllValidationResult = () => {
    clearInvalidClass(document.getElementsByTagName('input'));
    clearInvalidClass(document.getElementsByTagName('textarea'));
}