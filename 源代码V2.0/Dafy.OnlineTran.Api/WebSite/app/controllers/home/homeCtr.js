define(['app'], function(app) {
	app.controller('homeCtrl', ['$rootScope', '$scope', '$uibModal', '$loading','$state', 'homeService', 'CommonService', 'AccountService', function($rootScope, $scope, $uibModal,$loading, $state, homeService, CommonService, AccountService) {
		$scope.logout = function() {
			$loading.start("logoutOltr");
			//后台清除登录用户
			homeService.logout({}, function(data) {
				$loading.finish("logoutOltr");
				if(data != null) {
					localStorage.removeItem('onLineauthorization');
					$state.go('login');
				}
			});
		};
		//获取登录姓名
		var authData = localStorage.getItem('onLineauthorization');
		console.log(authData);
        if(authData != undefined && authData != null)
        {
            authData = eval('(' + authData + ')');
			$scope.userName = authData.userName != "" ? authData.userName : '';
        }else{
        	localStorage.removeItem('onLineauthorization');
			$state.go('login');
        }
        //获取登录用户的菜单
        homeService.getAuthorityMeun({}, function(data) {
				if(data!=null)
				{
					$scope.menuAdminList=data.menuAdminList;
				}
			});       
	}]);

});