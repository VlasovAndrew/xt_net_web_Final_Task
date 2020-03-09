$(function () {
    var $city = $('[name="city"]'),
        $street = $('[name="street"]'),
        $building = $('[name="house"]');

    $.fias.setDefault({
        parentInput: '.js-form-address',
        verify: true,
        check: function (obj) {
            console.log(obj);
            var $input = $(this);

            if (!obj) {
                showError($input);
            }
        },
        checkBefore: function () {
            var $input = $(this);
            removeError($input);
        },
        change: function (obj) {
            removeError($(this));
            if (obj && obj.parents) {
                $.fias.setValues(obj.parents, '.js-form-address');
            }
        },
    });


    $city.fias('type', $.fias.type.city);
    $street.fias('type', $.fias.type.street);
    $building.fias('type', $.fias.type.building);

    $city.fias('withParents', true);
    $street.fias('withParents', true);

    $building.fias('verify', true);

    function setLabel($input, text) {
        text = text.charAt(0).toUpperCase() + text.substr(1).toLowerCase();
        $input.parent().find('label').text(text);
    }

    function showError($input, message) {
        $input.addClass('is-invalid');
        $input.parent().find('.invalid-feedback').text('Введите корректный адрес.')
    }

    function removeError($input) {
        $input.removeClass('is-invalid');
        $input.parent().find('.invalid-feedback').text('')
    }
});