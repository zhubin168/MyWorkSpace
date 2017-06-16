define(['app'], function(app) {
	 //合同列表
	app.controller('contractCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','ContractService','CommonService','toastr','dateService','Settings','$timeout', function($rootScope, $state,$scope,$uibModal,$loading,ContractService,CommonService,toastr,dateService,Settings,$timeout){
	
			//搜索框 时间选择器配置
			$scope.beginOptions = {
			    dateDisabled: false,
			    maxDate: '',
			    minDate: '',
			    startingDay: 1
			};
			$scope.endOSptions = {
			    dateDisabled: false,
			    maxDate: '',
			    minDate: '',
			    startingDay: 1
			};
			$scope.openBegin = function() {
			    $timeout(function() {
			        $scope.popupBegin.opened = true;
			    });
			};
			$scope.openEnd = function() {
			    $timeout(function() {
			        $scope.popupEnd.opened = true;
			    });
			};
			$scope.popupBegin ={"opened":false};
			$scope.popupEnd ={"opened":false};	
		    //定义列表参数
			$scope.parm = {
			"contractNo":"",
			"ident":"",
			"result":"",
			"startDate":"",
			"endDate":"",
			"state":"",
			"visitor":"",
			"pageIndex": 1,
			"pageSize": 10
	        }		
	        $rootScope.contractCtrl={"master":false} ; //初始化contractCtrl下的全选标志master
	        $scope.contractList = [];
			$rootScope.GetContracts =function(){ //列表函数
				     $loading.start("getContracts");
                    $scope.parm.startDate =dateService.formatDate($scope.parm.startDate); //转化时间
                    $scope.parm.endDate =dateService.formatDate($scope.parm.endDate);
				        console.log(JSON.stringify($scope.parm));
				ContractService.GetContracts($scope.parm,function(data){
					    console.log(data);
				        $loading.finish("getContracts");
					    	for(i=0;i<data.list.length;i++){  //添加一个标志字段selectFlag，初始设置默认为未选择
					    		data.list[i].selectFlag = false;
					    	}
						    $scope.contractList = data.list;
						    $scope.totalItems = data.total;					    	

			    });
			 }
			$rootScope.GetContracts();	//打开页面获取数据	
			$scope.pageChanged=function(){ //分页
		    	$rootScope.GetContracts();	
			    $rootScope.contractCtrl.master=false; //全选checkbox 重新设置为未选状态			             
			}
			
		    $scope.selectAll = function (m) {//全选
		    	var contractList =$scope.contractList;
		        for(var i=0;i<contractList.length;i++){  
		          if(m===true){  
		              contractList[i].selectFlag=true;  
		          }else {  
		              contractList[i].selectFlag=false;  
		          }  
		        }  
		    }; 	
		    
		    $scope.getSelectedNo=function(){  //返回一个被选中的合同号数组$scope.selected
				$scope.selected = [];  //每次获取前先置空
		    	var contractList =$scope.contractList;
		        for(var i=0;i<contractList.length;i++){  
		          if(contractList[i].selectFlag===true){  
		                $scope.selected.push({"contractNo":contractList[i].contractNo,"idPerson":contractList[i].idPerson,"state":contractList[i].state});
		          } 
		        }  		  
		        return $scope.selected;
		    }
		    
			$scope.autoMethod =function(){ //自动分案
				$loading.start("warpperRight");
				ContractService.autoMethod({},function(data){
					if(data.state==1){
						toastr.success("自动分案成功！");
			             $rootScope.GetContracts();
					}else{
						toastr.error("自动分案失败！");
					}
				   $loading.finish("warpperRight");
				})
			}
		$scope.handMethod = function() { //手动分案 
				var modalInstance = $uibModal.open({
					templateUrl: 'handMethod.html', //指向上面创建的视图
					controller: 'handMethodCtrl', // 初始化模态范围
					size: 'default', //大小配置
					resolve: {
						selectedItem: function() {
								return $scope.getSelectedNo();
						}
					}
				})
			}
		$scope.cancelCases = function() { //撤销分案
				var modalInstance = $uibModal.open({
					templateUrl: 'cancelCases.html', //指向上面创建的视图
					controller: 'cancelCasesCtrl', // 初始化模态范围
					size: 'sm', //大小配置
					resolve: {
						selectedItem: function() {
								return $scope.getSelectedNo();
						}
					}
				})
			}
		$scope.caseDelay = function() { //案件延期 
				var modalInstance = $uibModal.open({
					templateUrl: 'caseDelay.html', //指向上面创建的视图
					controller: 'caseDelayCtrl', // 初始化模态范围
					size: 'default', //大小配置
					resolve: {
						selectedItem: function() {
								return $scope.getSelectedNo();
						}
					}
				})
			}
		$scope.handFinishCase = function() { //人工结案 
				var modalInstance = $uibModal.open({
					templateUrl: 'handFinishCase.html', //指向上面创建的视图
					controller: 'handFinishCaseCtrl', // 初始化模态范围
					size: 'sm', //大小配置
					resolve: {
						selectedItem: function() {
								return $scope.getSelectedNo();
						}
					}
				})
			}
		$scope.toExcelContracts=function(){  //导出
	    	var importUrl=Settings.apiServiceBaseUrl+"api/contract/toExcelContracts?ident="+$scope.parm.ident+"&result="+$scope.parm.result+"&startDate="+dateService.formatDate($scope.parm.startDate)+"&endDate="+dateService.formatDate($scope.parm.endDate)+"&state="+$scope.parm.state+"&visitor="+$scope.parm.visitor;
		    window.location.href=importUrl;		
		}
	}]);
	//手动分案controller
	app.controller('handMethodCtrl', ['$rootScope','$state','$scope','$uibModalInstance','$loading','ContractService','CommonService','toastr','selectedItem', function($rootScope, $state,$scope,$uibModalInstance,$loading,ContractService,CommonService,toastr,selectedItem){
	       $scope.parm = {
	       	"list":selectedItem,
	       	"userId":'',
	       	"userName":''
	       }
	       $scope.getUsers=function(){
	       	  ContractService.getUsers({"searchKey":$scope.parm.userName},function(data){
	       	  	   $scope.userList =data.list;
	       	  	   if($scope.userList!=null){
	       	  	     $scope.parm.userId= $scope.userList[0].userId;
	       	  	   }
	       	  })
	       }
			$scope.ok = function() {
				console.info($scope.parm);
				if(selectedItem.length==0){
				    toastr.warning("请先选择合同！");
				    return;
				}
				ContractService.handMethod($scope.parm, function(data) {
					if(data.state == 1) {
						 toastr.success(data.message);
				         $uibModalInstance.close(); //关闭并返回当前选项
			             $rootScope.GetContracts();
			             $rootScope.contractCtrl.master=false; //全选checkbox 重新设置为未选状态			             
					} else {
						toastr.warning(data.message);
					}
				})
			};
			//取消
			$scope.cancel = function() {
					$uibModalInstance.dismiss('cancel'); // 退出
			}	       
	}]);
	//案件延期caseDelayCtrl
	app.controller('caseDelayCtrl', ['$rootScope','$state','$scope','$uibModalInstance','$loading','ContractService','CommonService','toastr','selectedItem', function($rootScope, $state,$scope,$uibModalInstance,$loading,ContractService,CommonService,toastr,selectedItem){
	       console.log(selectedItem);
	       $scope.parm = {
	       	"list":selectedItem,
	       	"days":""
	       }
			$scope.ok = function() {
				if(selectedItem.length==0){
				    toastr.warning("请先选择合同！");
				    return;
				}				
				console.info($scope.parm);
				ContractService.caseDelay($scope.parm, function(data) {
					if(data.state == 1) {
						 toastr.success(data.message);
			             $rootScope.GetContracts();
			             $rootScope.contractCtrl.master=false; //全选checkbox 重新设置为未选状态
				         $uibModalInstance.close(); //关闭并返回当前选项
					} else {
						toastr.warning(data.message);
					}
				})
			};
			//取消
			$scope.cancel = function() {
					$uibModalInstance.dismiss('cancel'); // 退出
			}	       
	}]);
	//人工结案handFinishCase
	app.controller('handFinishCaseCtrl', ['$rootScope','$state','$scope','$uibModalInstance','$loading','ContractService','CommonService','toastr','selectedItem', function($rootScope, $state,$scope,$uibModalInstance,$loading,ContractService,CommonService,toastr,selectedItem){
	       $scope.parm = {
	       	"list":selectedItem,
	       }
			$scope.ok = function() {
				if(selectedItem.length==0){
				    toastr.warning("请先选择合同！");
				    return;
				}				
				console.info($scope.parm);
				ContractService.handFinishCase($scope.parm, function(data) {
					if(data.state == 1) {
						 toastr.success(data.message);
				         $uibModalInstance.close(); //关闭并返回当前选项
			             $rootScope.GetContracts();	
			             $rootScope.contractCtrl.master=false; //全选checkbox 重新设置为未选状态			             
					} else {
						toastr.warning(data.message);
					}
				})

			};
			//取消
			$scope.cancel = function() {
					$uibModalInstance.dismiss('cancel'); // 退出
			}			
	}]);
	//撤销分案cancelCasesCtrl
	app.controller('cancelCasesCtrl', ['$rootScope','$state','$scope','$uibModalInstance','$loading','ContractService','CommonService','toastr','selectedItem', function($rootScope, $state,$scope,$uibModalInstance,$loading,ContractService,CommonService,toastr,selectedItem){
		   $scope.selectedItem =[];
		   if(selectedItem.length>=1){  //过滤取出状态为已分配(state=5)的案件
			angular.forEach(selectedItem, function(data){
				if(data.state==5){
				$scope.selectedItem.push(data);
				}
			});				   	
		   }
   
	       $scope.parm = {
	       	"list":$scope.selectedItem,
	       }
	       
			$scope.ok = function() {  //确定
				if($scope.selectedItem.length==0){
				    toastr.warning("请先选择已分配的合同再操作！");
				    return;
				}				
				console.info($scope.parm);
				ContractService.cancelCases($scope.parm, function(data) {
					if(data.state == 1) {
						 toastr.success(data.message);
				         $uibModalInstance.close(); //关闭并返回当前选项
			             $rootScope.GetContracts();	
			             $rootScope.contractCtrl.master=false; //全选checkbox 重新设置为未选状态			             
					} else {
						toastr.warning(data.message);
					}
				})

			};
			$scope.cancel = function() {  //取消
					$uibModalInstance.dismiss('cancel'); // 退出
			}			
	}]);
	
});