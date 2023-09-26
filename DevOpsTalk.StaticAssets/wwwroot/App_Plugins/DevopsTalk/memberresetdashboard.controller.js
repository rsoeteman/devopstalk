angular.module("umbraco")
    .controller("devOpsTalk.memberresetdashboardcontroller",
        function ($scope, $http, notificationsService) {

            //Binds Members
            $scope.bindData = function () {

                $http.get("backoffice/devopstalk/passwordresetapi/getallmembers").then(function (res) {

                    $scope.members = res.data;
                },
                    function (res) {
                        notificationsService.error("Server error", "A server error occured");
                    });
            };

            //Resets passwords of selected members
            $scope.resetPasswords = function () {
                $http.post("backoffice/devopstalk/passwordresetapi/resetpasswords", $scope.members).then(function (res) {
                    notificationsService.success("Success", "Passwords for selected members were reset");
                    $scope.bindData();
                },
                    function (res) {
                        notificationsService.error("Server error", "A server error occured");
                    });
            }

            $scope.getVersion = function () {
                return Umbraco.Sys.ServerVariables.devopsTalkPackageVersion;
            }

            //Disable reset button when no item is selected
            $scope.disableResetButton = function () {
                var disableReset = true;
                angular.forEach($scope.members, function (member) {
                    if (member.ShouldReset === true) {
                        disableReset = false;
                    }
                });
                return disableReset;
            }

            //Initialize
            $scope.bindData();
        });