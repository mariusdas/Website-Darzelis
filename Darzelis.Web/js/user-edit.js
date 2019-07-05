
var userEdit = angular.module("userEdit", []);


userEdit.config(["$routeProvider", function ($routeProvider) {

    $routeProvider.when("/editUser/:Id", {
        resolve: {
            check: function ($location, $rootScope,$cookies, dataService) {
                debugger;
                login = $cookies.navInfo.split('&')[2].split('=')[1];
                if (login === "undefined" && login==="1") {
                    debugger;
                    $window.location = "/";
                }
            }
        },
        controller: "UserEditController",
        templateUrl: "/templates/editUser.html"
    });

    $routeProvider.otherwise({ redirectTo: "/users" });
}]);

var UserEditController = ["$scope", "dataService", "$window", "$routeParams",
    function ($scope, dataService, $window, $routeParams) {
        $scope.user = null;
        $scope.UserId = null;

        $scope.cancelUser = function () {
            $window.location = "/#users";
        }
        
        dataService.getUserById($routeParams.Id)
            .then(function (result) {
                
                $scope.user = result;
            },
                function () {
                   
                    toastr.error("Klaida gaunant pagal Id:", +$routeParams.Id);
                });

      
        $('#loader').show();
        
        setTimeout(function () {
            $scope.editUser = function () {
                $('#loader1').show();
                dataService.userEdit($scope.user)
                    .then(function () {
                       
                        toastr.success("Vartotojas sėkmingai atnaujintas");
                        $window.location = "#/users";
                    }, function () {
                        
                        toastr.error("Klaida atnaujant vartotoją");
                    })
                .then(function () {
                    $('#loader1').hide();
                });
            }

            $('#loader').hide();

        }, 1000);
        
        $scope.deleteUser = function () {
            dataService.removeUser($scope.user.Id)
                .then(function () {
                    
                    toastr.success("Vartotojas ištrintas sėkmingai");
                    $window.location = "#/users";
                }, function () {
                   
                    toastr.error("Klaida trinant vartotoją Id:", +$scope.user.Id);
                });
        }
    }];
