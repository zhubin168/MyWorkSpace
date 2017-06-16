/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('AccountService', function($http,CommonService) {
        return {
            login: function(par,callback) { //登录
                CommonService.getJsonData('api/home/login', par).then(function(data) {
                    callback(data);
                });
            },
            updatePassword: function(par,callback) { //修改密码
                CommonService.getJsonData('api/home/updatePassword', par).then(function(data) {
                    callback(data);
                });
            },
            findPassword: function(par,callback) { //忘记密码
                CommonService.getJsonData('api/home/FindPassword', par).then(function(data) {
                    callback(data);
                });
            },
            verifyCode: function(par,callback) { //获取手机验证码
                CommonService.getJsonData('api/home/verifyCode', par).then(function(data) {
                    callback(data);
                });
            },
            getUsers: function(par,callback) { //客户管理列表
                CommonService.getJsonData('api/Financial/GetUsers', par).then(function(data) {
                    callback(data);
                });
            },
            setUsers: function(par,callback) { //设为理财师
                CommonService.getJsonData('api/Financial/SetUsers', par).then(function(data) {
                    callback(data);
                });
            }, 
            getManagers: function(par,callback) { //理财师管理列表
                CommonService.getJsonData('api/Financial/GetManagers', par).then(function(data) {
                    callback(data);
                });
            },
            getChannels: function(par,callback) { //渠道管理列表
                CommonService.getJsonData('api/Financial/GetChannels', par).then(function(data) {
                    callback(data);
                });
            },
            detailManager: function(par,callback) { //理财师详情
                CommonService.getJsonData('api/Financial/DetailManager', par).then(function(data) {
                    callback(data);
                });
            },
            setAllowance: function(par,callback) { //任务津贴设置
                CommonService.getJsonData('api/Financial/SetAllowance', par).then(function(data) {
                    callback(data);
                });
            },
            setBank: function(par,callback) { //设置银行卡
                CommonService.getJsonData('api/Financial/setBank', par).then(function(data) {
                    callback(data);
                });
            },
            setRelation: function(par,callback) { //设置上级信息
                CommonService.getJsonData('api/Financial/SetRelation', par).then(function(data) {
                    callback(data);
                });
            },
            setCompany: function(par,callback) { //设置机构信息
                CommonService.getJsonData('api/Financial/SetCompany', par).then(function(data) {
                    callback(data);
                });
            },
            detailCustomer: function(par,callback) { //名下客户列表
                CommonService.getJsonData('api/Financial/DetailCustomer', par).then(function(data) {
                    callback(data);
                });
            },
            detailMember: function(par,callback) { //名下团队列表
                CommonService.getJsonData('api/Financial/DetailMember', par).then(function(data) {
                    callback(data);
                });
            },
            getArticles: function(par,callback) { //资讯管理列表
                CommonService.getJsonData('api/Article/getArticles', par).then(function(data) {
                    callback(data);
                });
            }, 
            getOrders: function(par,callback) { //订单管理列表
                CommonService.getJsonData('api/Order/GetOrders', par).then(function(data) {
                    callback(data);
                });
            }, 
            updateOrders: function(par,callback) { //更新状态
                CommonService.getJsonData('api/Order/UpdateOrders', par).then(function(data) {
                    callback(data);
                });
            }, 
            opRecord: function(par,callback) { //操作记录
                CommonService.getJsonData('api/Order/OpRecord', par).then(function(data) {
                    callback(data);
                });
            }, 
            getAllowances: function(par,callback) { //理财师业绩
                CommonService.getJsonData('api/Financial/GetAllowances', par).then(function(data) {
                    callback(data);
                });
            }, 
            getDetailAllowances: function(par,callback) { //业绩详情
                CommonService.getJsonData('api/Financial/GetDetailAllowances', par).then(function(data) {
                    callback(data);
                });
            }, 
            getIncomes: function(par,callback) { //理财师收益
                CommonService.getJsonData('api/Financial/GetIncomes', par).then(function(data) {
                    callback(data);
                });
            }, 
            getDetailIncomes: function(par,callback) { //收益详情
                CommonService.getJsonData('api/Financial/GetDetailIncomes', par).then(function(data) {
                    callback(data);
                });
            }, 
            getCheckUsers: function(par,callback) { //认证审核
                CommonService.getJsonData('api/Financial/GetCheckUsers', par).then(function(data) {
                    callback(data);
                });
            }, 
            checkUser: function(par,callback) { //审核
                CommonService.getJsonData('api/Financial/CheckUser', par).then(function(data) {
                    callback(data);
                });
            }, 
            getProducts: function(par,callback) { //产品管理列表
                CommonService.getJsonData('api/Product/GetProducts', par).then(function(data) {
                    callback(data);
                });
            }, 
            getCourses: function(par,callback) { //课程管理列表
                CommonService.getJsonData('api/Course/GetCourses', par).then(function(data) {
                    callback(data);
                });
            }, 
            getActives: function(par,callback) { //活动管理列表
                CommonService.getJsonData('api/Active/GetActives', par).then(function(data) {
                    callback(data);
                });
            }, 
            delActives: function(par,callback) { //删除活动
                CommonService.getJsonData('api/Active/DelActives', par).then(function(data) {
                    callback(data);
                });
            }, 
            delArticles: function(par,callback) { //删除文章
                CommonService.getJsonData('api/Article/DelArticles', par).then(function(data) {
                    callback(data);
                });
            }, 
            delConfig: function(par,callback) { //删除字典
                CommonService.getJsonData('api/Config/DeleteConfig', par).then(function(data) {
                    callback(data);
                });
            }, 
            delCourses: function(par,callback) { //删除课程
                CommonService.getJsonData('api/Course/DelCourses', par).then(function(data) {
                    callback(data);
                });
            }, 
            delUsers: function(par,callback) { //删除用户
                CommonService.getJsonData('api/Financial/DelUsers', par).then(function(data) {
                    callback(data);
                });
            }, 
            delProducts: function(par,callback) { //删除产品
                CommonService.getJsonData('api/Product/DelProducts', par).then(function(data) {
                    callback(data);
                });
            }, 
            delOrders: function(par,callback) { //删除订单
                CommonService.getJsonData('api/Order/DelOrders', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveActives: function(par,callback) { //保存活动信息
                CommonService.getJsonData('api/Active/SaveActives', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveArticles: function(par,callback) { //保存资讯信息
                CommonService.getJsonData('api/Article/SaveArticles', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveCourses: function(par,callback) { //保存课程信息
                CommonService.getJsonData('api/Course/SaveCourses', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveUsers: function(par,callback) { //修改用户信息
                CommonService.getJsonData('api/Financial/SaveUsers', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveProducts: function(par,callback) { //保存产品信息
                CommonService.getJsonData('api/Product/SaveProducts', par).then(function(data) {
                    callback(data);
                });
            }, 
            uploadImg: function(par,file, callback) { //上传模板
                CommonService.uploadFile('api/Common/UploadImg',file,par).then(function(data) {
                    callback(data);
                });
            }
        }
    });
});