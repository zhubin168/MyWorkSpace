define(['app'], function(app) {
		app.controller('CategorysCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','CategorysService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,CategorysService,toastr){
			$scope.parm={
				  "pageIndex": 1,
				  "pageSize": 10,
				  "paraName": ""
				};
			//活动管理
			$rootScope.getInfoCategorys=function(){
				CategorysService.getInfoCategorys($scope.parm,function(data){
					    console.log(data);
					    if(data!=null){
					    $scope.categorysList = data.list;
					    $scope.totalItems = data.total;
					    } 
				        $loading.finish("getCategorys");
			    });
			 }
			$rootScope.getInfoCategorys();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$rootScope.getInfoCategorys();
			};	
			//删除
			$scope.delCategorys = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  CategorysService.deleteCategory(parm, function(data) {
					  	     toastr.success(data.message);
					  	     $rootScope.getInfoCategorys();
					    })
				   }
			}
			$scope.editCategorys = function(index) { //打开模态 
				var modalInstance = $uibModal.open({
					templateUrl: 'addCategorys.html', //指向上面创建的视图
					controller: 'SaveCategorysCtrl', // 初始化模态范围
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
								return $scope.categorysList[index];
							}
						}
					}
				})
			}
		}]);
		 app.controller('SaveCategorysCtrl',['$uibModalInstance','$scope','$state','$rootScope','$loading','UtilService','CategorysService','configItem','Settings','toastr', function($uibModalInstance, $scope, $state, $rootScope,$loading ,UtilService,CategorysService, configItem,Settings, toastr) {
				
				$scope.configItem = configItem;
				console.log($scope.configItem);
				$scope.ok = function(ident,cardNo,bankName) {
					console.log(JSON.stringify($scope.configItem));
					CategorysService.saveInfoCategory($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 $rootScope.getInfoCategorys();
							 toastr.success(data.message);
						} else {
							toastr.warning(data.message);
							//$rootScope.detailManager();
						}
					})
					$uibModalInstance.close(); //关闭并返回当前选项
				};
				//取消
				$scope.cancel = function() {
					$uibModalInstance.dismiss('cancel'); // 退出
				}
		  }]);
		 app.controller('InformationsCtrl', ['$rootScope','$state','$scope','$loading','CategorysService','toastr', function($rootScope, $state,$scope,$loading,CategorysService,toastr){
            $scope.parm ={
						  "pageIndex": 1,
						  "pageSize": 10,
						  "paraName": "",
						  "type": "",
						  "status": "",
						  "id": 0};

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



			$scope.getInformations=function(){
				CategorysService.getInformations($scope.parm,function(data){
					    console.log(data);
					    $scope.InformationsList = data.list;
					    $scope.totalItems = data.total;
				        $loading.finish("getInformations");
				        
			    });
			 }

			$scope.getCategorys=function(){
			 	CategorysService.getInfoCategorys({'pageIndex':1,'pageSize':20,'paraName':''},function(data){
					    $scope.Categorys = data.list;
			    });
			}
			$scope.getCategorys();

			$scope.getInformations();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$scope.getInformations();
			};	
			
		    //删除
			$scope.delInformations = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  CategorysService.deleteInformation (parm, function(data) {
					  	     toastr.success(data.message);
					  	     $scope.getInformations();
					    })
				   }
			}

			$scope.editInformations=function(id){
				$state.go("home.addInformations",{'id':id});
			}
		}]);
		app.controller('SaveInformationsCtrl',['$scope','$state','$stateParams','$rootScope','$loading','UtilService','CategorysService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams,$rootScope,$loading ,UtilService,CategorysService,Settings, toastr,upLoadFileService) {
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';
				$scope.conStatus='false';

				$scope.goBack=function(){
					$state.go("home.informations");
				}
				$scope.listUrl='';
				$scope.shareUrl='';

				$scope.configItem ={
					  "id": 0,
					  "title": "",
					  "cid":"",
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

					$scope.getCategorys=function(){
					 	CategorysService.getInfoCategorys({'pageIndex':1,'pageSize':20,'paraName':''},function(data){
							    $scope.Categorys = data.list;
					    });
					}
					$scope.getCategorys();

				$scope.ok = function(type) {
					$scope.configItem.status=type;

					if($scope.conStatus=='true'){
						$scope.configItem.content='';
					}else{
						$scope.configItem.contentUrl='';
					}
					console.log($scope.configItem);
					CategorysService.saveInformation($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.informations");
						} else {
							toastr.warning(data.message);
						}
					});
				};

				$scope.getDetailInformation=function(id){
					CategorysService.getDetailInformation({'id':id},function(data){
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
			 		$scope.getDetailInformation($scope.id);
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
		 app.controller('KnowledgesCtrl', ['$rootScope','$state','$scope','$loading','CategorysService','toastr', function($rootScope, $state,$scope,$loading,CategorysService,toastr){
            $scope.parm ={
						  "pageIndex": 1,
						  "pageSize": 10,
						  "paraName": "",
						  "type": "",
						  "status":'',
						  "id": 0
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

	        

			$scope.getKnowledges=function(){
				console.log($scope.parm);
				CategorysService.getKnowledges($scope.parm,function(data){
					    console.log(data);
					    $scope.KnowledgesList = data.list;
					    $scope.totalItems = data.total;
				        $loading.finish("getKnowledges");
				        
			    });
			}
			$scope.getKnowledges();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$scope.getKnowledges();
			};	
			
		    //删除
			$scope.delKnowledges = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  CategorysService.deleteKnowledge (parm, function(data) {
					  	     toastr.success(data.message);
					  	     $scope.getKnowledges();
					    })
				   }
			}

			$scope.editKnowledges=function(id){
				$state.go("home.addKnowledges",{'id':id});
			}
		}]);
		app.controller('SaveKnowledgesCtrl',['$scope','$state','$stateParams','$rootScope','$loading','UtilService','CategorysService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams,$rootScope,$loading ,UtilService,CategorysService,Settings, toastr,upLoadFileService) {
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';
				$scope.conStatus='false';

				$scope.goBack=function(){
					$state.go("home.knowledges");
				}
				$scope.listUrl='';
				$scope.shareUrl='';

				$scope.configItem ={
					  "id": 0,
					  "title": "",
					  "cid":"",
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
					$scope.configItem.status=type;
					if($scope.conStatus=='true'){
						$scope.configItem.content='';
					}else{
						$scope.configItem.contentUrl='';
					}
					console.log($scope.configItem);
					CategorysService.saveKnowledge($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.knowledges");
						} else {
							toastr.warning(data.message);
						}
					});
				};

				$scope.getDetailKnowledge=function(id){
					CategorysService.getDetailKnowledge({'id':id},function(data){
						console.log(data);
						if(data!=null){
						    $scope.configItem = data;

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
			 		$scope.getDetailKnowledge($scope.id);
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
		 app.controller('CoursesCtrl', ['$rootScope','$state','$scope','$loading','CategorysService','toastr', function($rootScope, $state,$scope,$loading,CategorysService,toastr){
            $scope.parm ={
						  "pageIndex": 1,
						  "pageSize": 10,
						  "paraName": "",
						  "type": "",
						  "status":'',
						  "id": 0
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

	        

			$scope.getCourses=function(){
				console.log($scope.parm);
				CategorysService.getCourses($scope.parm,function(data){
					    console.log(data);
					    $scope.CoursesList = data.list;
					    $scope.totalItems = data.total;
				        $loading.finish("getCourses");
				        
			    });
			}
			$scope.getCourses();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$scope.getCourses();
			};	
			
		    //删除
			$scope.delCourses = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  CategorysService.deleteCourse(parm, function(data) {
					  	     toastr.success(data.message);
					  	     $scope.getCourses();
					    })
				   }
			}

			$scope.editCourses=function(id){
				$state.go("home.addCourses",{'id':id});
			}
		}]);
		app.controller('SaveCoursesCtrl',['$scope','$state','$stateParams','$rootScope','$loading','UtilService','CategorysService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams,$rootScope,$loading ,UtilService,CategorysService,Settings, toastr,upLoadFileService) {
				 //console.log(configItem);
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';
				$scope.conStatus='false';

				$scope.goBack=function(){
					$state.go("home.courses");
				}
				$scope.listUrl='';
				$scope.shareUrl='';

				$scope.configItem ={
					  "id": 0,
					  "title": "",
					  "subTitle":"",
					  "shareUrl": "",
					  "shareTitle": "",
					  "listUrl": "",
					  "contentUrl": "",
					  "content": "",
					  "status": 0,
					  "publishTime": "",
					  "createTime": "",
					  "position":'0',
					  "updateTime": "",
					  "createUid": 0,
					  "modifyName":""
					};

				$scope.ok = function(type) {
					$scope.configItem.status=type;
					if($scope.conStatus=='true'){
						$scope.configItem.content='';
					}else{
						$scope.configItem.contentUrl='';
					}
					console.log($scope.configItem);
					CategorysService.saveCourses($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.courses");
						} else {
							toastr.warning(data.message);
						}
					});
				};

				$scope.getDetailCourse=function(id){
					CategorysService.getDetailCourse({'id':id},function(data){
						console.log(data);
						if(data!=null){
						    $scope.configItem = data;

							if(data.publishTime!=''){
								$scope.sendTimeStatus='false';
							}
							$scope.configItem.position=data.position+'';
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
			 		$scope.getDetailCourse($scope.id);
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
		 app.controller('BannersCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','CategorysService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,CategorysService,toastr){
            $scope.parm = {
			"paraName":"",
			"status":"",
			"pageIndex": 1,
			"pageSize": 10
	        };

	        $scope.getStatus=function(type){
	        	var  proTypeName='';
	        	  switch(type+'')
	        	  {
	        		case "1":
	        		{
	        			proTypeName="未进行";
	        			break;
	        		}
	        		case "2":
	        		{
	        			proTypeName="进行中";
	        			break;
	        		}
	        		case "3":
	        		{
	        			proTypeName="已结束";
	        			break;
	        		}
	        	}
	        	return proTypeName;
	        };

	        $scope.editBanners=function(id){
	        	$state.go("home.addBanners",{'id':id});
	        }

			//活动管理
			$rootScope.getBanners=function(){
				CategorysService.getBanners($scope.parm,function(data){
					    console.log(data);
					    if(data!=null){
					    $scope.getBannersList = data.list;
					    $scope.totalItems = data.total;
					    } 
				        $loading.finish("getBanners");
				        
			    });
			 }
			$rootScope.getBanners();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$rootScope.getBanners();
			};	
			//删除
			$scope.delBanners = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  CategorysService.deleteBanner(parm, function(data) {
					  	     toastr.success(data.message);
					  	     $rootScope.getBanners();
					    })
				   }
			}
		}]);
		app.controller('saveBannersCtrl',['$scope','$state','$stateParams','$rootScope','$loading','$timeout','UtilService','CategorysService','Settings','toastr','upLoadFileService', function($scope, $state,$stateParams, $rootScope,$loading ,$timeout,UtilService,CategorysService,Settings, toastr,upLoadFileService) {
				$scope.id=$stateParams.id;
				$scope.sendTimeStatus='true';
				$scope.imageUrl='';
				$scope.shareImageUrl='';

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
				$scope.startDate = "";
				$scope.endDate = "";

				$scope.roleList=[];
				$scope.getRoleList=function(){
					CategorysService.getRoleList(null,function(data){
						console.log(data);
						if(data!=null){
						    $scope.roleList=data.list;
						}
				    });
				}
				$scope.getRoleList();


				$scope.selected = [];
     			$scope.selectedTags = [];

			    var updateSelected = function(action,id,name){
			         if(action == 'add' && $scope.selected.indexOf(id) == -1){
			             $scope.selected.push(id);
			             $scope.selectedTags.push(name);
			         }
			         if(action == 'remove' && $scope.selected.indexOf(id)!=-1){
			             var idx = $scope.selected.indexOf(id);
			             $scope.selected.splice(idx,1);
			             $scope.selectedTags.splice(idx,1);
			         }
			     }
			 
			    $scope.updateSelection = function($event, id){
			         var checkbox = $event.target;
			         var action = (checkbox.checked?'add':'remove');
			         updateSelected(action,id,checkbox.name);
			     }
			 
			     $scope.isSelected = function(id){
			         return $scope.selected.indexOf(id)>=0;
			     }

				$scope.configItem = {
								  "id":$scope.id,
								  "title": "",
								  "imageUrl": "",
								  "contentUrl": "",
								  "visiableUid": "",
								  "status": 0,
								  "publishTime": "",
								  "createTime": "",
								  "updateTime": "",
								  "createUid": 0,
								  "modifyUid": 0,
								  "visibleStartTime": "",
								  "visibleEndTime": "",
								  "shareTitle": "",
								  "shareImageUrl": "",
								  "shareContent": "",
								  "shareUrl": "",
								  "orderNum": 0,
								  "modifyName": ""
								};

				$scope.goBack=function(){
					$state.go("home.getBanners");
				}

				$scope.getDetailBanners=function(id){
					CategorysService.getDetailBanner({'id':id},function(data){
						console.log(data);
						if(data!=null){
						    $scope.configItem = data;
						    if(data.imageUrl!=''){
						    	$scope.imageUrl='http://'+data.imageUrl;
						    	$scope.configItem.imageUrl=data.imageUrl;
						    }
						     if(data.shareImageUrl!=''){
						    	$scope.shareImageUrl='http://'+data.shareImageUrl;
						    	$scope.configItem.shareImageUrl=data.shareImageUrl;
						    }

						    if($scope.configItem.visiableUid!=''){//test
						    	var roleList=[{'roleId':0,'roleName':'客户'},{'roleId':2,'roleName':'理财师'}];
						    	angular.forEach(roleList, function (i) {
						            updateSelected('add',i.roleId,i.roleName);
						        });
						    }
						    //$scope.isSelected(0);
						}
				    });
			 	}

			 	if($scope.id!=-1){
			 		$scope.getDetailBanners($scope.id);
			 	}
				$scope.ok = function(type) {
					if($scope.selected.length>0){
						$scope.configItem.visiableUid=$scope.selected.toString();
					}
					$scope.configItem.status=type;
					console.log(JSON.stringify($scope.configItem));

					CategorysService.saveBanner($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.getBanners");
						} else {
							toastr.warning(data.message);
							$rootScope.getTools();
						}
					});
				}

	        	$scope.uploadImg = function (file,type) {
	            	$loading.start("upLoadTrainImg");
	                upLoadFileService.upLoadFile({}, file, function(data) {
	                	    console.log(data);
					        if (data.state != 0) {
		                    	var photoUrl=data.data;
		                    	switch(type){
		                    		case "imageUrl":
		                    		{
		                    			$scope.imageUrl="http://"+photoUrl;
		                    			$scope.configItem.imageUrl=photoUrl;
		                    			break;
		                    		}
		                    		case "shareImageUrl":
		                    		{
		                    			$scope.shareImageUrl="http://"+photoUrl;
		                    			$scope.configItem.shareImageUrl=photoUrl;
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