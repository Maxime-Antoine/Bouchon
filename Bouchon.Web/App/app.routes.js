(function () {
    var app = angular.module('bouchon');

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'App/Views/home.html'
            })
            .when('/register', {
                controller: 'registerCtrl',
                templateUrl: 'App/Views/register.html'
            })
            //.when('/display-message/:msg', {
            //    templateUrl: 'Templates/display-message.html',
            //    controller: 'displayMessageCtrl'
            //})
            //.when('/admin', {
            //    templateUrl: 'Templates/admin/home.html',
            //    access: {
            //        requiresLogin: true,
            //        requiredPermissions: ['Admin'],
            //        permissionType: 'AtLeastOne'
            //    }
            //})
            .otherwise({
                redirectTo: '/'
            });
    }]);
})();
