let form = document.getElementsByTagName('form')[0];

form.addEventListener('submit', (event) => {
    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
    }
    form.classList.add('was-validated');
});
