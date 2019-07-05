//appJSTest
(function (myapp) {
    myapp.isLocale = true;

    myapp.log = function (msg) {
        if (myapp.isLocale) {
            console.log(msg);
        }
    };
})(window.myapp = window.myapp || {});