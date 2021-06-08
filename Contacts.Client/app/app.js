var app = angular.module("Contacts", ["common.services", "ngRoute", "ngHandsontable"]);
app.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/contacts", {
                templateUrl: "app/Contacts/Templates/Contact.html",
            });
    }])
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(false);
    }]);
