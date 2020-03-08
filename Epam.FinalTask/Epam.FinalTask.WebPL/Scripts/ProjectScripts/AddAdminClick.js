let addAdminBtn = document.getElementById('create-admin');
let mainForm = document.getElementById('main-form');

addAdminBtn.addEventListener('click', clearAllValidationResult);
addAdminBtn.addEventListener('click', () => {
    event.preventDefault();
    validateAccountData(() => {
        mainForm.submit();
    });
});