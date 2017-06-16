/**
 * Created by tianxc on 16-7-29.
 */
var serviceUrl = 'http://shangrongfintech.com/';
var simditorUploadUrl=serviceUrl+'/api/common/uploadImg';//配置编辑器里上传图片地址
define([
    'angular',
    'angularAMD',
    'file-upload',
    'ngFile',
    'bindonce',
    'ui-bootstrap',
    'ngAnimate',
    'ngSanitize',
    'ui-router',
    'directive/directives',
    'filters/filters',
    'services/common/commonService',
    'jquery',
    'localStorageUsage',
    'angular-loading',
    'spinjs',
    'angular-toastr',
    'dateTimePicker',
    'angular-zh-cn',
    'simple-hotkeys',
    'simple-uploader',
    'simditor',
    'simditor-html',
    'angular-simditor'
], function(angular, angularAMD) {
    'use strict';

    var picterServiceURL="";

    var app = angular.module('app', [
         'ui.router', 'ui.bootstrap','ui.bootstrap.datetimepicker','ngAnimate','angular-simditor','ngSanitize','ngFileUpload', 'app.directives', 'app.filters', 'app.commonService','localStorageUsage','darthwade.dwLoading','toastr'
    ]);

    //全局常量
    app.constant('Settings', {
        apiServiceBaseUrl: serviceUrl,
        picterServiceURL:picterServiceURL,
        clientId: 'shangRong',
        version: '1.0.0',
        simditorUploadUrl:simditorUploadUrl,
        deBug: false
    });

    // 配置
    app.config(['$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
        
        //判断是否登录
        var authData = null;
        authData = localStorage.getItem('onLineauthorization');
        if(authData != undefined && authData != null)
        {
            authData = eval('(' + authData + ')');
        }
        if (authData === null) {
            $urlRouterProvider.otherwise('/login');
        } else {
            $urlRouterProvider.otherwise('/home');
        }
        $stateProvider
            .state('home', angularAMD.route({
                url: '/home',
                templateUrl:  'templates/home/index.html',
                resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var homeCtrl = "app/controllers/home/homeCtr.js";
		                        var homeService = "app/services/home/homeService.js";
		                        var accountService = "app/services/account/accountService.js";
		                        var deferred = $q.defer();
		                        require([homeCtrl, homeService, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		        controllerProvider: function($stateParams) {
		                return "homeCtrl";
		            }
            }))

            .state('login', angularAMD.route({ //登录
		            url: '/login',
		            templateUrl: 'templates/account/login.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "LoginCtrl";
		            }
		    }))
            
            .state('forgetPwd', angularAMD.route({ //忘记密码
		            url: '/forgetPwd',
		            templateUrl: 'templates/account/forgetPwd.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "forgetPwdCtrl";
		            }
		    }))
            
            .state('home.modifPwd', angularAMD.route({ //修改密码
		            url: '/modifPwd',
		            templateUrl: 'templates/account/modifPwd.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "modifPwdCtrl";
		            }
		    }))
            
             .state('home.report', angularAMD.route({ //首页报表
		            url: '/report',
		            templateUrl: 'templates/account/report.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                         var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "managersCtrl";
		            }
		    }))
             
           .state('home.getAllowances', angularAMD.route({ //理财师业绩
		            url: '/getAllowances',
		            templateUrl: 'templates/account/getAllowances.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                         var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "allowancesCtrl";
		            }
		    }))
           
             .state('home.getIncomes', angularAMD.route({ //理财师收益
		            url: '/getIncomes',
		            templateUrl: 'templates/account/getIncomes.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                         var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "incomesCtrl";
		            }
		    }))
             
             .state('home.getCheckUsers', angularAMD.route({ //认证审核
		            url: '/getCheckUsers',
		            templateUrl: 'templates/account/getCheckUsers.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                         var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "checkUserCtrl";
		            }
		    }))
            
            .state('home.categorys', angularAMD.route({ //资讯分类管理
		            url: '/categorys',
		            templateUrl: 'templates/categorys/categorys.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
		
		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "CategorysCtrl";
		            }
		    }))

		    .state('home.informations', angularAMD.route({ //资讯管理
		            url: '/informations',
		            templateUrl: 'templates/categorys/informations.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
		
		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "InformationsCtrl";
		            }
		    }))

		    .state('home.addInformations', angularAMD.route({ //编辑资讯
		            url: '/editInformations/:id',
		            templateUrl: 'templates/categorys/addInformations.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "SaveInformationsCtrl";
		            }
		    }))

			.state('home.knowledges', angularAMD.route({ //小知识管理
		            url: '/knowledges',
		            templateUrl: 'templates/knowledges/knowledges.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
		
		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "KnowledgesCtrl";
		            }
		    }))

		    .state('home.addKnowledges', angularAMD.route({ //编辑小知识
		            url: '/editKnowledges/:id',
		            templateUrl: 'templates/knowledges/addKnowledges.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "SaveKnowledgesCtrl";
		            }
		    }))
			.state('home.courses', angularAMD.route({ //小知识管理
		            url: '/courses',
		            templateUrl: 'templates/courses/courses.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
		
		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "CoursesCtrl";
		            }
		    }))

		    .state('home.addCourses', angularAMD.route({ //编辑小知识
		            url: '/editCourses/:id',
		            templateUrl: 'templates/courses/addCourses.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "SaveCoursesCtrl";
		            }
		    }))
            
            .state('home.getCustomers', angularAMD.route({ //客户管理
		            url: '/getCustomers',
		            templateUrl: 'templates/account/getCustomers.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "weixinUserCtrl";
		            }
		    }))
            
             .state('home.getChannels', angularAMD.route({ //渠道管理
		            url: '/getChannels',
		            templateUrl: 'templates/account/getChannels.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "managersCtrl";
		            }
		    }))
            
            .state('home.getUsers', angularAMD.route({ //理财师管理列表
		            url: '/getUsers',
		            templateUrl: 'templates/account/getUsers.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "managersCtrl";
		            }
		    }))
            
            .state('home.detailManager', angularAMD.route({ //理财师详情
		            url: '/detailManager/:selectedItem',
		            templateUrl: 'templates/account/getUserDetails.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "detailManagerCtrl";
		            }
		    }))
           
            
               .state('home.getTeamDetails', angularAMD.route({ //团队详情
		            url: '/getTeamDetails/:selectedItem',
		            templateUrl: 'templates/account/getTeamDetails.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "weixinUserCtrl";
		            }
		    }))
               
           .state('home.getCustomerDetails', angularAMD.route({ //名下客户列表
		            url: '/getCustomerDetails/:selectedItem',
		            templateUrl: 'templates/account/getCustomerDetails.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "detailCustomerCtrl";
		            }
		    }))
           
           .state('home.getDetailAllowances', angularAMD.route({ //业绩详情
		            url: '/getDetailAllowances/:selectedItem',
		            templateUrl: 'templates/account/getDetailAllowances.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "detailAllowancesCtrl";
		            }
		    }))
           
          .state('home.getDetailIncome', angularAMD.route({ //收益详情
		            url: '/getDetailIncome/:selectedItem',
		            templateUrl: 'templates/account/getDetailIncome.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "detailIncomeCtrl";
		            }
		    }))

            .state('home.getToolArticles', angularAMD.route({ //资讯管理列表
		            url: '/getToolArticles',
		            templateUrl: 'templates/article/articles.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var toolsCtr = "app/controllers/tools/toolsCtr.js";
		                        var toolsService = "app/services/tools/toolsService.js";
		
		                        var deferred = $q.defer();
		                        require([toolsCtr, toolsService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "toolArticlesCtrl";
		            }
		    }))

		     .state('home.addToolArticle', angularAMD.route({ //添加资讯
		            url: '/editToolArticle/:id',
		            templateUrl: 'templates/article/addArticle.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                         var toolsCtr = "app/controllers/tools/toolsCtr.js";
		                        var toolsService = "app/services/tools/toolsService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([toolsCtr, toolsService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "saveToolArticlesCtrl";
		            }
		    }))
            
            .state('home.getOrders', angularAMD.route({ //订单管理列表
		            url: '/getOrders',
		            templateUrl: 'templates/account/getOrders.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "ordersCtrl";
		            }
		    }))
            
             .state('home.products', angularAMD.route({ //产品管理列表
		            url: '/getProducts',
		            templateUrl: 'templates/product/products.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/product/productCtr.js";
		                        var accountService = "app/services/product/productService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "productsCtrl";
		            }
		    }))

            .state('home.addProducts', angularAMD.route({ //产品管理列表
		            url: '/editProducts/:id',
		            templateUrl: 'templates/product/addProduct.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/product/productCtr.js";
		                        var accountService = "app/services/product/productService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "saveProductsCtrl";
		            }
		    }))
             
             .state('home.getActives', angularAMD.route({ //活动管理列表
		            url: '/getActives',
		            templateUrl: 'templates/account/getActives.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var accountCtrl = "app/controllers/account/accountCtr.js";
		                        var accountService = "app/services/account/accountService.js";
		
		                        var deferred = $q.defer();
		                        require([accountCtrl, accountService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "activesCtrl";
		            }
		    }))
               
            .state('home.getTools', angularAMD.route({ //获客助手管理列表
		            url: '/getTools',
		            templateUrl: 'templates/tools/tools.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var toolsCtr = "app/controllers/tools/toolsCtr.js";
		                        var toolsService = "app/services/tools/toolsService.js";
		
		                        var deferred = $q.defer();
		                        require([toolsCtr, toolsService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "toolsCtrl";
		            }
		    }))

		    .state('home.addTools', angularAMD.route({ //获客助手管理列表
		            url: '/tools/:id',
		            templateUrl: 'templates/tools/addTools.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var toolsCtr = "app/controllers/tools/toolsCtr.js";
		                        var toolsService = "app/services/tools/toolsService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([toolsCtr, toolsService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "saveToolsCtrl";
		            }
		    }))
		    .state('home.getBanners', angularAMD.route({ //Banners管理列表
		            url: '/getBanners',
		            templateUrl: 'templates/banner/banners.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
		
		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "BannersCtrl";
		            }
		    }))

		    .state('home.addBanners', angularAMD.route({ //编辑Banners
		            url: '/editBanners/:id',
		            templateUrl: 'templates/banner/addBanner.html',
		            resolve: {
		                loadController: ['$q', '$stateParams',
		                    function($q, $stateParams) {
		                        var categorysCtr = "app/controllers/categorys/categorysCtr.js";
		                        var categorysService = "app/services/categorys/categorysService.js";
								var upLoadFileService = "app/services/upLoadFile/upLoadFileService.js";

		                        var deferred = $q.defer();
		                        require([categorysCtr, categorysService,upLoadFileService], function() {
		                            deferred.resolve();
		                        });
		                        return deferred.promise;
		                    }
		                ]
		            },
		            controllerProvider: function($stateParams) {
		                return "saveBannersCtrl";
		            }
		    }))
    }]);

    return angularAMD.bootstrap(app);
});
