const mainForm = document.getElementById('main-form');
const formTabs = document.getElementsByClassName('tab');
const actionBtn = document.getElementById('action-btn');
const backBtn = document.getElementById('back-btn');

let tabIndex = 0;

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
    if (tabIndex < 0) {
        tabIndex = 0;
    }
    if (tabIndex == 0) {
        backBtn.style.display = 'none';
        actionBtn.innerHTML = 'Далее';
    }
    formTabs[tabIndex].style.display = 'block';
}

let prevTab = (event) => {
    event.preventDefault();
    scrollLeftForm();
}

let nextTab = (event) => {
    event.preventDefault();
    if (tabIndex == 0) {
        validateAccountData(scrollRightForm);
    }
    else if (tabIndex == 1) {
        validateUserData(() => {
            mainForm.submit();
        });
    }
}

formTabs[0].style.display = 'block';

backBtn.addEventListener('click', prevTab);
actionBtn.addEventListener('click', clearAllValidationResult);
actionBtn.addEventListener('click', nextTab);

