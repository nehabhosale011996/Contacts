(function () {
    "use strict";
    angular
        .module("common.services", ["ngResource"])
        .constant("appSettings", {
            serverPath: "https://localhost:44393/"
        });
}());