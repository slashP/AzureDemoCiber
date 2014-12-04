(function() {
    var urlPortions = document.URL.split("/");
    var container = urlPortions[urlPortions.length - 1];

    document.onpaste = handlePaste;

    function handlePaste(e) {
        var item = e.clipboardData.items[0];
        if (item.type.indexOf("image") != -1) {
            uploadFile(item.getAsFile());
        }
    }

    function uploadFile(file) {
        var formData = new FormData();
        formData.append('file', file);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/imageUpload/' + container);
        xhr.onreadystatechange = function() {
            if (xhr.readyState == 4) {
                console.log(xhr.responseText);
                window.location.reload();
            }
        };
        xhr.send(formData);
    }
})();