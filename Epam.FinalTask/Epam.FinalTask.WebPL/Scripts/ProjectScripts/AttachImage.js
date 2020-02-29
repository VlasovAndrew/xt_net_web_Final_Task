let readURL = (input) => {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#user-image').attr('src', e.target.result);
            $('#user-image').show();
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#user-image-input").change(function () {
    readURL(this);
});
