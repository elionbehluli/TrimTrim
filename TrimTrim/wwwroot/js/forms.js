function displaySelectedFile(input) {
    var fileInput = input.files[0];
    var imageElement = $('.selectedImage');

    if (fileInput) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imageElement.attr('src', e.target.result);
        };

        reader.readAsDataURL(fileInput);
    } else {
        imageElement.attr('src', '');
    }
}