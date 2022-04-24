// Format options


export function buildCountrySelect(element) {
    var optionFormat = function (item) {
        if (!item.id) {
            return item.text;
        }
        var span = document.createElement('span');
        var imgUrl = item.element.getAttribute('data-kt-select2-country');
        var template = '';

        template += '<img src="' + imgUrl + '" class="rounded-circle h-20px me-2" alt="image"/>';
        template += item.text;

        span.innerHTML = template;

        return $(span);
    }


    $(element).select2({
        templateSelection: optionFormat,
        templateResult: optionFormat
    });
}