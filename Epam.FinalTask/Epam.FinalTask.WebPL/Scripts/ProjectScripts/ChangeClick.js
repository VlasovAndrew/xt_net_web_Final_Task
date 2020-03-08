let mainForm = document.getElementById('main-form');
let changeBtn = document.getElementById('change-btn');

changeBtn.addEventListener('click', clearAllValidationResult);
changeBtn.addEventListener('click', () => {
    event.preventDefault();
    validateUserData(() => {
        mainForm.submit();
    });
});