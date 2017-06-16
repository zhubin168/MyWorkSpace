define(['app'], function(app) {
	app.controller('productsCtrl', ['$rootScope','$state','$scope','$uibModal','$loading','ProductService','toastr', function($rootScope, $state,$scope,$uibModal,$loading,ProductService,toastr){
            $scope.parm = {
	          "pageIndex": 1,
	          "pageSize": 10,
	          "paraName": "",
	          "productType": "",
	          "status": "",
	          "pid": 0
	        };	
			//产品管理
			$rootScope.getProducts=function(){
				ProductService.getProducts($scope.parm,function(data){
					    //console.log(data);
					    $scope.getProductsList = data.list;
					    $scope.totalItems = data.total;
				        $loading.finish("getProducts");
				        
			    });
			 }
			$rootScope.getProducts();
			
			//分页事件,获取当前的点击的页数
			$scope.pageChanged = function() {
				$rootScope.getProducts();
			};	
			
		    //删除
			$scope.delProducts = function(id){
				var parm = {"id":id}
				var comfirm =confirm("是否确认删除该行？");
	           	  if(comfirm){
					  ProductService.delProducts (parm, function(data) {
					  	     toastr.success(data.message);
					  	     $rootScope.getProducts();
					    })
				   }
			}

			$scope.editProduct=function(id){
				$state.go("home.addProducts",{'id':id});
			}
		}]);

		//保存产品
		app.controller('saveProductsCtrl',['$scope','$state','$rootScope','$loading','$stateParams','UtilService','ProductService','upLoadFileService','Settings','toastr','Settings',function($scope, $state, $rootScope,$loading,$stateParams,UtilService,ProductService,upLoadFileService,Settings, toastr,Settings) {
				$scope.id=$stateParams.id;

				$scope.companyLogo='';
			 	$scope.detailTopUrl='';
			 	$scope.productPDF=[];
			 	$scope.isHotPostion='true';

				$scope.goBack=function(){
					$state.go("home.products");
				}

				$scope.configItem={
				  "pid":$scope.id,
				  "productName": "",
				  "productType": "",
				  "companyId":"",
				  "companyName": "",
				  "companyLogo": "",
				  "description": "",
				  "content": "",
				  "docUrl": "",
				  "proAge":"",
				  "price":"",
				  "demoContent": "",
				  "reasonContent": "",
				  "guideContent": "",
				  "problemContent": "",
				  "detailTopUrl": "",
				  "position":0,
				  "hotPosition":"1",
				  "status":"3"
				};
				$scope.getProdcutType=function(type){
					var  proTypeName='';
					  switch(type)
					  {
						case "保险类":
						{
							proTypeName="1";
							break;
						}
						case "投融类":
						{
							proTypeName="2";
							break;
						}
						case "其他类":
						{
							proTypeName="3";
							break;
						}
					}
					return proTypeName;
				}

				$scope.getProdcutState=function(type){
					var  proTypeName='';
					  switch(type)
					  {
						case "草稿":
						{
							proTypeName="3";
							break;
						}
						case "上架":
						{
							proTypeName="1";
							break;
						}
						case "下架":
						{
							proTypeName="2";
							break;
						}
					}
					return proTypeName;
				}

				$scope.getDetailProduct=function(id){
					ProductService.getDetailProduct({'pid':id},function(data){
						//console.log(data);
						if(data!=null){
						    $scope.configItem = data;
						    if(data.status!=0){
						    	$scope.configItem.status=data.status+'';
							}
						    if(data.hotPosition==0){
						    	$scope.configItem.hotPosition="1";
						    	$scope.isHotPostion='false';
						    }else{
						    	$scope.isHotPostion='true';
						    	$scope.configItem.hotPosition=data.hotPosition+'';
						    }
						    $scope.configItem.status=$scope.getProdcutState($scope.configItem.status);

						    if(data.companyLogo!=''){
						    	$scope.companyLogo='http://'+data.companyLogo;
						    }
						    if(data.detailTopUrl!=''){
						    	$scope.detailTopUrl='http://'+data.detailTopUrl;
						    }
						    if(data.docUrl!=''){
						    	var fileList=data.docUrl.split(";");
						    	if(fileList.length>0){
						    		var j=1;
						    		for(var i=0;i<fileList.length;i++){
						    			if(fileList[i]==null || fileList[i]=='') continue;
						    			var item={'id':UtilService.generateUUID(),'saveUrl':fileList[i],'url':'http://'+fileList[i],'fileName':'文档'+j};
						    			j++;
		                    			$scope.productPDF.push(item);
						    		}
						    	}
						    }
						    $scope.configItem.productType=$scope.getProdcutType(data.productType);
						}
				    });
			 	}

			 	if($scope.id!=-1){
			 		$scope.getDetailProduct($scope.id);
			 	}

				$scope.saveData=function() 
				{
					if($scope.isHotPostion=='false'){
						$scope.configItem.hotPosition=0;
					}
					console.log('$scope.productPDF.length='+$scope.productPDF.length);
					if($scope.productPDF.length>0){
						$scope.configItem.docUrl='';
						for(var i=0;i<$scope.productPDF.length;i++){
							$scope.configItem.docUrl+=$scope.productPDF[i].saveUrl+';';
						}
					}
				    console.log($scope.configItem);
					ProductService.saveProducts($scope.configItem, function(data) {
						if(data != null && data.state == 1) {
							 toastr.success(data.message);
							 $state.go("home.products");
						} else {
							toastr.warning(data.message);
						}
					});
				};

				$scope.uploadPDF = function (file,type) {
	            	$loading.start("upLoadTrainImg");
	                upLoadFileService.upLoadFileDoc({}, file, function(data) {
					        if (data.state != 0) {
					        	var url="http://"+data.data;
					        	var item={'id':UtilService.generateUUID(),'saveUrl':data.data,'url':url,'fileName':file[0].name};
		                    	$scope.productPDF.push(item);
					        }else{
					            toastr.warning(data.message);
					        }
					        $loading.finish("upLoadTrainImg");
		               });
	            }
	            $scope.delPDF=function(item){
	            	if(item!=null){
	            		var index = $scope.productPDF.indexOf(item);
						$scope.productPDF.splice(index, 1);
	            	}
	            }
				//文件上传
	            $scope.uploadImg = function (file,type) {
	            	$loading.start("upLoadTrainImg");
	                upLoadFileService.upLoadFile({}, file, function(data) {
	                	    console.log(data);
					        if (data.state != 0) {
		                    	var photoUrl=data.data;
		                    	switch(type){
		                    		case "companyLogo":
		                    		{
		                    			$scope.companyLogo="http://"+photoUrl;
		                    			$scope.configItem.companyLogo=photoUrl;
		                    			break;
		                    		}
		                    		case "detailTopUrl":
		                    		{
		                    			$scope.detailTopUrl="http://"+photoUrl;
		                    			$scope.configItem.detailTopUrl=photoUrl;
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