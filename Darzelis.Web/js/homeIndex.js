/// <reference path="../Scripts/jquery-1.10.2.min.js" />

//homeindex.js

var homeIndexmodule = angular.module("homeIndex", ['ui.bootstrap', 'ngRoute', 'ngCookies', 'userEdit']);

//Route Configuration
homeIndexmodule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/", {

        controller: "homeIndexController",
        templateUrl: "/templates/home.html"

    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/templates/login.html"

    });

    $routeProvider.when("/register", {
        controller: "registerController",
        templateUrl: "/templates/register.html"

    });
    $routeProvider.when("/newUser", {
        resolve: {
            check: function ($location, $rootScope, $cookies, dataService) {

                login = $cookies.navInfo.split('&')[2].split('=')[1];
                if (login === "undefined" || login === "1") {

                    $location.path('/#');
                    $window.location.reload();
                }
            }
        },
        controller: "newUserController",
        templateUrl: "/templates/newuser.html"
    });


    $routeProvider.when("/algorithm", {
        resolve: {
            check: function ($location, $window, $rootScope, $cookies, dataService) {

                login = $cookies.navInfo.split('&')[2].split('=')[1];
                if (login === "undefined" || login === "1") {
                    $location.path('/#');
                    $window.location.reload();


                }
            }
        },
        controller: "algorithmController",
        templateUrl: "/templates/algorithm.html"

    });

    $routeProvider.when("/users", {
        resolve: {
            check: function ($location, $window, $rootScope, $cookies, dataService) {

                login = $cookies.navInfo.split('&')[2].split('=')[1];
                if (login === "undefined" || login === "1") {
                    $location.path('/#');
                    $window.location.reload();


                }
            }
        },
        controller: "usersController",
        templateUrl: "/templates/users.html"

    });
    $routeProvider.when("/profile", {
        resolve: {
            check: function ($location, $window, $rootScope, $cookies, dataService) {

                login = $cookies.navInfo.split('&')[2].split('=')[1];
                if (login === "undefined") {

                    $location.path('/#');
                    $window.location.reload();
                }
            }
        },
        controller: "profileController",
        templateUrl: "/templates/profile.html"

    });

    $routeProvider.when("/MapPreSchools", {
        controller: "mapController",
        templateUrl: "/templates/mapPreSchools.html"
    });
    $routeProvider.when("/aboutapp", {
        controller: "",
        templateUrl: "/templates/aboutapp.html"
    });

    $routeProvider.when("/contactme", {
        controller: "",
        templateUrl: "/templates/contactme.html"
    });
    $routeProvider.otherwise({ redirectTo: "/" });
}]);



homeIndexmodule.factory("dataService", ["$http", "$q", function ($http, $q) {

    var _users = [];
    var _profileModel = {};
    var _preSchoolModel = {};
    var _algorithmModel = {};
    var _getUsers = function () {

        var deferred = $q.defer();
        $http.get('/api/users')
            .then(function (result) {
                angular.copy(result.data, _users);
                deferred.resolve();
            },
                function () {

                    //Error
                    deferred.reject();
                });
        return deferred.promise;
    };
    var login = {};

    var addCookie = function (username, password, email, loggedIn, type) {
        login.username = username;
        login.password = password;
        login.email = email;
        login.loggedIn = loggedIn;
        login.type = type;
    }

    var getCookie = function () {
        return login;
    }

    var _getUserById = function (Id) {
        var deferred = $q.defer();
        $http.get('/api/users/' + Id)
            .then(function (result) {
                deferred.resolve(result.data);
            }, function () {
                
                deferred.reject();
            });
        return deferred.promise;
    }

    var _addUser = function (newUser) {

        var deferred = $q.defer();
        $http.post('/api/users', newUser)
                .then(function (result) {

                    deferred.resolve();
                },
                    function () {
                        deferred.reject();
                    });
        return deferred.promise;
    }
    var _updateAlgorithm = function (newAlgorithm) {
        
        var deferred = $q.defer();
        $http.post('/api/algorithm/post', newAlgorithm)
                .then(function (result) {
                    

                    angular.copy(result.data, _algorithmModel);
                    deferred.resolve();
                },
                    function () {
                        deferred.reject();
                    });
        return deferred.promise;
    }
    var _updateProfile = function (newProfile) {

        var deferred = $q.defer();
        $http.post('/api/profile/post', newProfile)
                .then(function (result) {

                    angular.copy(result.data, _profileModel);
                    deferred.resolve();
                },
                    function () {
                        deferred.reject();
                    });
        return deferred.promise;
    }

    var _getPreSchools = function () {
        var deferred = $q.defer();
        $http.get('/api/Map/GetAllPreSchools')
                .then(function (result) {
                    deferred.resolve(result.data);
                },
                    function () {
                        deferred.reject();
                    });
        return deferred.promise;
    }

    var _userEdit = function (user) {
        var deferred = $q.defer();
        $http.put('/api/users/', user)
            .then(function () {
                
                deferred.resolve();
            }, function () {
                
                deferred.reject();
            });
        return deferred.promise;
    }
    var _removeUser = function (Id) {
        var deferred = $q.defer();
        $http.delete('/api/users/' + Id)
            .then(function () {
               
                deferred.resolve();
            },
                function () {
                   
                    deferred.reject();
                });
        return deferred.promise;
    }
    var _Login = function (newLogin) {

        var deferred = $q.defer();
        $http.post('/api/Accounts', newLogin)
                .then(function (result) {
                    
                    
                    newLogin.email = result.data.Email;
                    newLogin.type = result.data.Type;
                    deferred.resolve();
                },
                    function () {

                        deferred.reject();
                    });
        return deferred.promise;
    }
    var _register = function (newRegister) {

        var deferred = $q.defer();
        $http.post('/api/Register', newRegister)
                .then(function (result) {


                    newRegister.username = result.data.newRegister;
                    newRegister.email = result.data.Email;
                    newRegister.type = result.data.Type;
                    deferred.resolve();
                },
                    function (result) {


                        toastr.error(result.data);
                        deferred.reject();
                    });
        return deferred.promise;
    }




    return {
        users: _users,
        getUsers: _getUsers,
        getUserById: _getUserById,
        addUser: _addUser,
        userEdit: _userEdit,
        removeUser: _removeUser,
        addCookie: addCookie,
        getCookie: getCookie,
        Login: _Login,
        register: _register,
        algorithModel: _algorithmModel,
        updateAlgorithm: _updateAlgorithm,
        profileModel: _profileModel,
        updateProfile: _updateProfile,
        getPreSchools: _getPreSchools

    };
}]);






var homeIndexController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {
    //Empty Collection

}
];
var mapController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {
  
    $('#loader').show();
    dataService.getPreSchools()
    .then(function (result) {


        $scope.AllPreSchools = result;

        for (var i = 0; i < $scope.AllPreSchools.length; i++)
        {
            var x = $scope.AllPreSchools[i].GisX.toString();
            var y = $scope.AllPreSchools[i].GisY.toString();
            var xAdded = parseFloat([x.slice(0, 2), '.', x.slice(2)].join(''));
            var yAdded = parseFloat([y.slice(0, 2), '.', y.slice(2)].join(''));
            $scope.AllPreSchools[i].GisX = xAdded;
            $scope.AllPreSchools[i].GisY = yAdded;
        }
      
        toastr.success("Sėkmingai užkrautas");
    }, function () {
        toastr.error("Klaida kraunant");
    })
    .then(function () {

        
        
        var mapCanvas = document.getElementById("map");
        var mapOptions = {
            center: new google.maps.LatLng(54.6998479, 25.0208216),
            zoom: 10
        }
        
        $window.map = new google.maps.Map(mapCanvas, mapOptions);

        var infowindow = new google.maps.InfoWindow();

        var marker, i;

        for (i = 0; i < $scope.AllPreSchools.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng($scope.AllPreSchools[i].GisX, $scope.AllPreSchools[i].GisY),
                map: $window.map
            });

            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent($scope.AllPreSchools[i].Label);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }

       $('#loader').hide();
        
    });

        

}
];
var registerController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {

    $scope.submit = function () {


        $scope.vardas = registerForm.vardas.value;
        $scope.pavarde = registerForm.pavarde.value;
        $scope.email = registerForm.email.value;
        $scope.username = registerForm.username.value;
        $scope.password = registerForm.password.value;
        $scope.passwordConfirm = registerForm.passwordConfirm.value;

        $scope.bornYear = registerForm.bornYear.value;
        $scope.vaikoINDnr = registerForm.vaikoINDnr.value;
        $scope.city = registerForm.city.value;
        $scope.region = registerForm.region.value;

        $scope.newRegister = {
            vardas: $scope.vardas, pavarde: $scope.pavarde, email: $scope.email, username: $scope.username,
            password: $scope.password, confirmPassword: $scope.passwordConfirm, metai: $scope.bornYear, vaikoINDnr: $scope.vaikoINDnr,
            city: $scope.city, region: $scope.region

        };
        dataService.register($scope.newRegister)
                    .then(function () {

                        toastr.success("Sėkmingai atnaujinta");

                        $window.location = "home/";
                    }, function () {

                        toastr.error("Klaida saugant duomenis");
                    }).then(function () {

                        $('#loader').hide();
                    });
    }


}
];
var loginController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {


    $scope.submit = function () {


        $('#loader').show();
        $scope.username = loginForm.username.value;
        $scope.password = loginForm.password.value;

        $scope.newLogin = { username: $scope.username, password: $scope.password };
        dataService.Login($scope.newLogin)
                    .then(function () {

                        toastr.success("Sėkmingai prisijungta");
                        $('#loader').hide();
                        $window.location = "home/";
                    }, function () {

                        toastr.error("Klaida jungiantis");
                    }).then(function () {

                        $('#loader').hide();
                    });
    }


}
];
var algorithmController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {
    
    $scope.data = dataService;
    $scope.newAlgorithm = {};

    $scope.updateAlgorithm = function () {

        $('#loader').show();

        dataService.updateAlgorithm($scope.newAlgorithm)
            .then(function () {

                $scope.currentPage = 1;
                $scope.numPerPage = 10;
                $scope.maxSize = 11;

                $scope.numPages = function () {
                    return Math.ceil($scope.data.algorithModel.length / $scope.numPerPage);
                };

                $scope.$watch('currentPage + numPerPage', function () {
                    var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                    , end = begin + $scope.numPerPage;
                    
                    $scope.AllFiltredRequests = $scope.data.algorithModel.AllRequests.slice(begin, end);
                    $scope.AllAccepted = $scope.data.algorithModel.AllAcceptedRequests.slice(begin, end);
                    $scope.AllNotAccepted = $scope.data.algorithModel.AllDeclinedRequests.slice(begin, end);
                });
                toastr.success("Sėkmingai atnaujinta");
            }, function () {
                toastr.error("Klaida saugant duomenis");
            }).then(function () {
                $('#loader').hide();
            });
    };

    $('#loader').show();
    
    setTimeout(function () {
       
        dataService.updateAlgorithm($scope.newAlgorithm)
            .then(function () {

                $scope.currentPage = 1;
                $scope.numPerPage = 10;
                $scope.maxSize = 11;

                $scope.numPages = function () {

                    return Math.ceil($scope.AllFiltredRequests.length / $scope.numPerPage);
                };

                $scope.$watch('currentPage + numPerPage', function () {
                    
                    var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                    , end = begin + $scope.numPerPage;
                    
                    $scope.AllFiltredRequests = $scope.data.algorithModel.AllRequests.slice(begin, end);
                    $scope.AllAccepted = $scope.data.algorithModel.AllAcceptedRequests.slice(begin, end);
                    $scope.AllNotAccepted = $scope.data.algorithModel.AllDeclinedRequests.slice(begin, end);


                });
                toastr.success("sėkmingai užkrauti");
            }, function () {
                toastr.error("Klaida kraunant");
            })
            .then(function () {
                $('#loader').hide();
            });
    }, 1000);
}

];
var profileController = ["$scope", "$http", "dataService", "$window", "$cookies", function ($scope, $http, dataService, $window, $cookies) {
    $scope.data = dataService;
    $scope.newProfile = {};

    $scope.newProfile.username = $cookies.navInfo.split('&')[0].split('=')[1]
    $scope.newProfile.email = $cookies.navInfo.split('&')[1].split('=')[1]
    $('#loader').show();

    setTimeout(function () {
        dataService.updateProfile($scope.newProfile)
            .then(function () {

                
                if ($scope.data.profileModel.Username !== "admin") {
                    $scope.preRequestSchool1 = $scope.data.profileModel.ProfileView.PreRequestSchool1;
                    $scope.preRequestSchool2 = $scope.data.profileModel.ProfileView.PreRequestSchool2;
                    $scope.preRequestSchool3 = $scope.data.profileModel.ProfileView.PreRequestSchool3;
                    $scope.preRequestSchool4 = $scope.data.profileModel.ProfileView.PreRequestSchool4;
                    $scope.preRequestSchool5 = $scope.data.profileModel.ProfileView.PreRequestSchool5;
                    $scope.preSchool1 = $scope.data.profileModel.ProfileView.PreSchool1;
                    $scope.preSchool2 = $scope.data.profileModel.ProfileView.PreSchool2;
                    $scope.preSchool3 = $scope.data.profileModel.ProfileView.PreSchool3;
                    $scope.preSchool4 = $scope.data.profileModel.ProfileView.PreSchool4;
                    $scope.preSchool5 = $scope.data.profileModel.ProfileView.PreSchool5;
                    $scope.priimtas = $scope.data.profileModel.ProfileView.Accepted;
                    $scope.priimtasDarzelis = $scope.data.profileModel.UserRequest.PreSchoolAccepted;
                }

                toastr.success("Sėkmingai užkrautas");
            }, function () {
                toastr.error("Klaida kraunant");
            })
            .then(function () {
                $('#loader').hide();
            });
    }, 1000);
}

];
var newUserController = ["$scope", "$http", "$window", "dataService", function ($scope, $http, $window, dataService) {

    $scope.newUser = {};

    $scope.cancelUser = function () {
        $window.location = "#/users";
    }

    setTimeout(function () {
        $scope.save = function () {

            $('#loader').show();
            dataService.addUser($scope.newUser)
                .then(function () {
                    toastr.success("Sėkmingai atnaujinta");
                    $window.location = "#/users";
                }, function () {
                    toastr.error("Klaida saugant duomenis");
                }).then(function () {
                    $('#loader').hide();
                });
        }
    }, 1000);
}
];

var usersController = ["$scope", "$http", "dataService", "$window", function ($scope, $http, dataService, $window) {

    $scope.data = dataService;

    $scope.addUser = function () {

        $window.location = "/#/newUser";
    }

    $('#loader').show();


    setTimeout(function () {
        dataService.getUsers()
            .then(function () {


                $scope.currentPage = 1;
                $scope.numPerPage = 10;
                $scope.maxSize = 11;

                $scope.numPages = function () {
                    return Math.ceil($scope.data.users.length / $scope.numPerPage);
                };

                $scope.$watch('currentPage + numPerPage', function () {
                    var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                    , end = begin + $scope.numPerPage;

                    $scope.filteredUsers = $scope.data.users.slice(begin, end);

                });


                toastr.success("Vartotojai sėkmingai užkrauti");
            }, function () {
                toastr.error("Klaida kraunant vartotojus");
            })
            .then(function () {
                $('#loader').hide();
            });
    }, 1000);

}
];

