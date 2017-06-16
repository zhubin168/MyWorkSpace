define(['app'], function(app) {
		app.controller('toolsCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','ToolsService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,ToolsService,toastr){
            $scope.parm = {
			"paraName":"",
			"type":"",
			"status":"",
			"pageIndex": 1,
			"pageSize": 10
	        };

	        $scope.getType=function(type){
	        	var  proTypeName='';
	        	  switch(type+'')
	        	  {
	        		case "1":
	        		{
	        			proTypeName="座右铭";
	        			break;
	        		}
	        		case "2":
	        		{
	        			proTypeName="节日问候";
	        			break;
	        		}
	        		case "3":
	        		{
	        			proTypeName="理财产品";
	        			break;
	        		}
	        		case "4":
	        		{
	        			proTypeName="诗和远方";
	        			break;
	        		}
	        	}
	        	return proTypeName;
	        };

	        $scope.getStatus=function(type){
	        	var  proTypeName='';
	        	  switch(type+'')
	        	  {
	        		case "0":
	        		{
	        			proTypeName="草稿";
	        			break;
	        		}
	        		case "1":
	        		{
	        			proTypeName="已发布";
	        			break;
	        		}
	        		case "2":
	        		{
	        			proTypeName="待发布";
	        			break;
	        		}
	        	}
	        	return proTypeName;
	        };

	        $scope.editTools=function(id){
	        	$state.go("home.addTools",{'id':id});
	        }

			//活动管理
			$rootScope.getTools=function(){
				ToolsService.getTools($scope.parm,function(data){
					    console.log(data);
					    if(data!=null){
					    $scope.getToolsList = data.list;
					    $scope.totalItems = data.total;
					    } 
				        $loading.finish("getTools");
				        
			    });
			 }
			$rootScope.getTools();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$rootScope.getTools();
			};	
			//删除
			$scope.delTools = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  ToolsService.delTools(parm, function(data) {
					  	     toastr.success(data.message);
					  	     $rootScope.getTools();
					    })
				   }
			}
		}]);
		
		//保存助手
		app.controller('saveToolsCtrl',['$scope','$state','$stateParams','$rootScope','$loading','UtilService','ToolsService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams, $rootScope,$loading ,UtilService,ToolsService,Settings, toastr,upLoadFileService) {
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';

				$scope.configItem = {
					  "id":$scope.id,
					  "title": "",
					  "type":"",
					  "sequence": 1,
					  "imageUrl": "",
					  "status": 0,
					  "publishTime": ""
					};
				$scope.goBack=function(){
					$state.go("home.getTools");
				}

				$scope.getDetailTools=function(id){
					ToolsService.getDetailTool({'id':id},function(data){
						console.log(data);
						if(data!=null){
						    $scope.configItem = data;
						    if(data.type!=0){
						    	$scope.configItem.type=data.type+'';
							}
							if(data.publishTime!=''){
								$scope.sendTimeStatus='false';
							}
						    if(data.imageUrl!=''){
						    	$scope.imageUrl='http://'+data.imageUrl;
						    	$scope.configItem.imageUrl=data.imageUrl;
						    }
						}
				    });
			 	}

			 	if($scope.id!=-1){
			 		$scope.getDetailTools($scope.id);
			 	}
				$scope.ok = function(type) {
					if($scope.sendTimeStatus=='true'){
						$scope.configItem.publishTime='';// UtilService.getNowFormatDate(); 
					}
					$scope.configItem.status=type;
					//console.log(JSON.stringify($scope.configItem));
					ToolsService.saveTools($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.getTools");
						} else {
							toastr.warning(data.message);
							$rootScope.getTools();
						}
					});
				}

				$scope.imageUrl='';

	        	$scope.uploadImg = function (file,type) {
	            	$loading.start("upLoadTrainImg");
	                upLoadFileService.upLoadFile({}, file, function(data) {
	                	    console.log(data);
					        if (data.state != 0) {
		                    	var photoUrl=data.data;
		                    	$scope.imageUrl="http://"+photoUrl;
		                    	$scope.configItem.imageUrl=photoUrl;
					        }else{
					            toastr.warning(data.message);
					        }
					        $loading.finish("upLoadTrainImg");
		               });
	            }
		  }]);
		//文章管理
	    app.controller('toolArticlesCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','ToolsService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,ToolsService,toastr){
		            $scope.parm = {
					"paraName":"",
					"type":"",
					"status":"",
					"pageIndex": 1,
					"pageSize": 10
			        };

			        $scope.getType=function(type){
			        	var  proTypeName='';
			        	  switch(type+'')
			        	  {
			        		case "1":
			        		{
			        			proTypeName="资讯";
			        			break;
			        		}
			        		case "2":
			        		{
			        			proTypeName="小知识";
			        			break;
			        		}
			        		case "3":
			        		{
			        			proTypeName="鸡汤";
			        			break;
			        		}
			        	}
			        	return proTypeName;
			        };

			        $scope.getStatus=function(type){
			        	var  proTypeName='';
			        	  switch(type+'')
			        	  {
			        		case "0":
			        		{
			        			proTypeName="草稿";
			        			break;
			        		}
			        		case "1":
			        		{
			        			proTypeName="已发布";
			        			break;
			        		}
			        		case "2":
			        		{
			        			proTypeName="待发布";
			        			break;
			        		}
			        	}
			        	return proTypeName;
			        };

			        $scope.editToolArticle=function(id){
			        	$state.go("home.addToolArticle",{'id':id});
			        }		
					//资讯管理
					$rootScope.getArticles=function(){
						ToolsService.getToolArticles($scope.parm,function(data){
							    console.log(data);
							    $scope.getArticlesList = data.list;
							    $scope.totalItems = data.total;
						        $loading.finish("getArticles");
						        
					    });
					 }
					$rootScope.getArticles();
					
					//分页事件,获取当前的点击的页数
					$scope.pageChanged = function() {
						console.log($scope.parm.pageIndex);
						$rootScope.getArticles();
					};	
					
					//删除
					$scope.delToolArticles = function(id){
						var parm = {"id":id}
						var comfirm =confirm("是否确认删除该行？");
			           	  if(comfirm){
			           	  	  console.log(parm);
							  ToolsService.delToolDeleteArticle (parm, function(data) {
							  	console.log(data);
							  	     toastr.success(data.message);
							  	     $rootScope.getArticles();
							    })
						   }
					}
					
		}]);
		 //保存资讯
		 app.controller('saveToolArticlesCtrl',['$scope','$state','$stateParams','$rootScope','$loading','UtilService','ToolsService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams,$rootScope,$loading ,UtilService,ToolsService,Settings, toastr,upLoadFileService) {
				 //console.log(configItem);
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';
				$scope.conStatus='false';

				$scope.goBack=function(){
					$state.go("home.getToolArticles");
				}
				$scope.listUrl='';
				$scope.shareUrl='';

				$scope.configItem ={
					  "id": 0,
					  "title": "",
					  "type":"",
					  "shareUrl": "",
					  "shareTitle": "",
					  "listUrl": "",
					  "contentUrl": "",
					  "content": "",
					  "status": 0,
					  "publishTime": "",
					  "createTime": "",
					  "updateTime": "",
					  "createUid": 0,
					  "modifyUid": 0
					};
				$scope.ok = function(type) {
					if($scope.conStatus=='true'){
						$scope.configItem.content='';
					}else{
						$scope.configItem.contentUrl='';
					}
					$scope.configItem.status=type;
					console.log(JSON.stringify($scope.configItem));
					ToolsService.saveToolArticles($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.getToolArticles");
						} else {
							toastr.warning(data.message);
						}
					});
				};

				$scope.getToolArticles=function(id){
					ToolsService.getToolDetailArticle({'id':id},function(data){
						console.log(data);
						if(data!=null){
						    $scope.configItem = data;
						    if(data.type!=0){
						    	$scope.configItem.type=data.type+'';
							}
							if(data.publishTime!=''){
								$scope.sendTimeStatus='false';
							}
							if(data.contentUrl==null || data.contentUrl==''){
								$scope.conStatus='false';
								$scope.configItem.contentUrl='';
							}else{
								$scope.conStatus='true';
								$scope.configItem.content='';
							}
						    if(data.shareUrl!=''){
						    	$scope.shareUrl='http://'+data.shareUrl;
						    	$scope.configItem.shareUrl=data.shareUrl;
						    }
						    if(data.listUrl!=''){
						    	$scope.listUrl='http://'+data.listUrl;
						    	$scope.configItem.listUrl=data.listUrl;
						    }
						}
				    });
			 	}

			 	if($scope.id!=-1){
			 		$scope.getToolArticles($scope.id);
			 	}
				
				$scope.uploadImg = function (file,type) {
	            	$loading.start("upLoadTrainImg");
	                upLoadFileService.upLoadFile({}, file, function(data) {
	                	    console.log(data);
					        if (data.state != 0) {
		                    	var photoUrl=data.data;
		                    	switch(type){
		                    		case "listUrl":
		                    		{
		                    			$scope.listUrl="http://"+photoUrl;
		                    			$scope.configItem.listUrl=photoUrl;
		                    			break;
		                    		}
		                    		case "shareUrl":
		                    		{
		                    			$scope.shareUrl="http://"+photoUrl;
		                    			$scope.configItem.shareUrl=photoUrl;
		                    			break;
		                    		}
		                    	}
					        }else{
					            toastr.warning(data.message);
					        }
					        $loading.finish("upLoadTrainImg");
		               });
	            }		
		  }]);
});