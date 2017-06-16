define(['app'], function(app) {
	//字典管理
	app.controller('configCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','configService','CommonService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,configService,CommonService,toastr){
			$scope.parm = {
			"paraName":"",
			"pageIndex": 1,
			"pageSize": 10
	        }		
			//字典列表
			$rootScope.getConfigs=function(){
				configService.getConfigs($scope.parm,function(data){
					    console.log(data);
					    $scope.getConfigsList = data.list;
					    $scope.totalItems = data.total;
				        $loading.finish("getConfigs");
				        
			    });
			 }
			$rootScope.getConfigs();
			
		//分页事件,获取当前的点击的页数
		$scope.pageChanged = function() {
			console.log($scope.parm.pageIndex);
			$rootScope.getConfigs();
		};	
	    //删除字典
		$scope.delConfigs = function(id){
			var parm = {"id":id}
			var comfirm =confirm("是否确认删除该行？");
           	  if(comfirm){
				  configService.deleteConfig (parm, function(data) {
				  	     toastr.success(data.message);
				  	     $rootScope.getConfigs();
				    })
			   }
		}
		//编辑、添加字典
		$scope.editConfigs = function(index) { //打开模态 
				var modalInstance = $uibModal.open({
					templateUrl: 'configAdd.html', //指向上面创建的视图
					controller: 'configAddCtrl', // 初始化模态范围
					size: 'lg', //大小配置
					resolve: {
						configItem: function() {
							if(index == -1) {
								return {
									"id": '',
									"paraName": '',
									"paraCode": '',
									"paraGroup": '',
									"remark": '',
									"sortOrder": ''
								};
							} else {
								return $scope.getConfigsList[index];
							}
						}
					}
				})
			}
	}]);	
	//保存字典
	app.controller('configAddCtrl',['$uibModalInstance','$scope','$state','$rootScope','$loading','UtilService','configService','configItem','Settings','toastr', function($uibModalInstance, $scope, $state, $rootScope,$loading ,UtilService,configService, configItem,Settings, toastr) {
			
			$scope.configItem = configItem;
			$scope.ok = function() {
				//保存字典
				console.log(JSON.stringify($scope.configItem));
				configService.saveConfig($scope.configItem, function(data) {
					if(data != null && data.state == 1) {
						 $rootScope.getConfigs();
						 toastr.success(data.message);
					} else {
						toastr.warning(data.message);
						$rootScope.getConfigs();
					}
				})
				$uibModalInstance.close(); //关闭并返回当前选项
			};
			//取消
			$scope.cancel = function() {
					$uibModalInstance.dismiss('cancel'); // 退出
					$rootScope.getConfigs();
			}
	  }]);
	
});