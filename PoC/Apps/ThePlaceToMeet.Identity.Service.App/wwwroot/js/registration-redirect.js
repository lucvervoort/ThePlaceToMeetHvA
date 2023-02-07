window.addEventListener("load", function () {
    var a = document.querySelector("a.PostRegistrationRedirectUri");
    if (a) {
        window.location = a.href;
    }
});
