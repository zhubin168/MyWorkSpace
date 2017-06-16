/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('CategorysService', function($http,CommonService) {
        return {
            getInfoCategorys: function(par,callback) { //资讯分类管理
                CommonService.getJsonData('api/Course/GetInfoCategorys', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveInfoCategory: function(par,callback) { //保存资讯分类
                CommonService.getJsonData('api/Course/SaveInfoCategory', par).then(function(data) {
                    callback(data);
                });
            },
            deleteCategory: function(par,callback) { //保存资讯分类
                CommonService.getJsonData('api/Course/DeleteCategory', par).then(function(data) {
                    callback(data);
                });
            },
            getInformations: function(par,callback) { //资讯管理
                CommonService.getJsonData('api/Course/GetInformations', par).then(function(data) {
                    callback(data);
                });
            },
            saveInformation: function(par,callback) { //保存资讯
                CommonService.getJsonData('api/Course/SaveInformation', par).then(function(data) {
                    callback(data);
                });
            },
            getDetailInformation: function(par,callback) { //获取资讯详情
                CommonService.getJsonData('api/Course/GetDetailInformation', par).then(function(data) {
                    callback(data);
                });
            },
            deleteInformation: function(par,callback) { //删除资讯
                CommonService.getJsonData('api/Course/DeleteInformation', par).then(function(data) {
                    callback(data);
                });
            },
            getKnowledges: function(par,callback) { //小知识管理
                CommonService.getJsonData('api/Course/GetKnowledges', par).then(function(data) {
                    callback(data);
                });
            },
            saveKnowledge: function(par,callback) { //小知识管理
                CommonService.getJsonData('api/Course/SaveKnowledge', par).then(function(data) {
                    callback(data);
                });
            },
            getDetailKnowledge: function(par,callback) { //小知识管理
                CommonService.getJsonData('api/Course/GetDetailKnowledge', par).then(function(data) {
                    callback(data);
                });
            },
            deleteKnowledge: function(par,callback) { //小知识管理
                CommonService.getJsonData('api/Course/DeleteKnowledge', par).then(function(data) {
                    callback(data);
                });
            },
            getCourses: function(par,callback) { //理财师充电站
                CommonService.getJsonData('api/Course/GetCourses', par).then(function(data) {
                    callback(data);
                });
            },
            saveCourses: function(par,callback) { //理财师充电站
                CommonService.getJsonData('api/Course/SaveCourse', par).then(function(data) {
                    callback(data);
                });
            },
            getDetailCourse: function(par,callback) { //理财师充电站
                CommonService.getJsonData('api/Course/GetDetailCourse', par).then(function(data) {
                    callback(data);
                });
            },
            deleteCourse: function(par,callback) { //理财师充电站
                CommonService.getJsonData('api/Course/DeleteCourse', par).then(function(data) {
                    callback(data);
                });
            },
            getBanners: function(par,callback) {
                CommonService.getJsonData('api/Course/GetBanners', par).then(function(data) {
                    callback(data);
                });
            },
            saveBanner: function(par,callback) {
                CommonService.getJsonData('api/Course/SaveBanner', par).then(function(data) {
                    callback(data);
                });
            },
            deleteBanner: function(par,callback) {
                CommonService.getJsonData('api/Course/DeleteBanner', par).then(function(data) {
                    callback(data);
                });
            },
            getDetailBanner: function(par,callback) {
                CommonService.getJsonData('api/Course/GetDetailBanner', par).then(function(data) {
                    callback(data);
                });
            },
            getRoleList: function(par,callback) {
                CommonService.getJsonData('api/Home/GetRoleList', par).then(function(data) {
                    callback(data);
                });
            }
        }
    });
});