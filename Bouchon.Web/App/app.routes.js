﻿(function () {
    var app = angular.module('bouchon');

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'App/Views/home.html'
            })
            .when('/display-message/:msg', {
                templateUrl: 'App/Views/display-message.html',
                controller: 'displayMessageCtrl'
            })
            .when('/register', {
                controller: 'registerCtrl',
                templateUrl: 'App/Views/register.html'
            })
            .when('/login', {
                templateUrl: 'App/Views/login-page.html'
            })
            .when('/request', {
                templateUrl: 'App/Views/post-request.html',
                access: {
                    requiresLogin: true
                }
            })
            .when('/trip', {
                templateUrl: 'App/Views/post-trip.html',
                access: {
                    requiresLogin: true
                }
            })
            .when('/browse', {
                templateUrl: 'App/Views/browse.html'
            })
            .when('/inbox', {
                templateUrl: 'App/Views/inbox.html',
                access: {
                    requiresLogin: true
                }
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
