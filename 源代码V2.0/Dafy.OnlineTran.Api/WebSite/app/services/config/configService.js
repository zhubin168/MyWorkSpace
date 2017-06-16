define([
    'app'
], function(app) {
    'use strict';

    app.factory('configService',['$http','CommonService', function($http,CommonService) {
        return {
            getConfigs: function(par,callback) { //字典列表
                CommonService.getJsonData('api/config/getConfigs', par).then(function(data) {
                    callback(data);
                });
            },
            saveConfig: function(par,callback) { //保存字典
                CommonService.getJsonData('api/config/saveConfig', par).then(function(data) {
                    callback(data);
                });
            },
            deleteConfig: function(par,callback) { //删除字典
                CommonService.getJsonData('api/config/deleteConfig', par).then(function(data) {
                    callback(data);
                });
            }, getVisitors: function(par,callback) { //催收员列表
                CommonService.getJsonData('api/config/getVisitors', par).then(function(data) {
                    callback(data);
                });
            }, saveVisitor: function(par,callback) { //保存催收员
                CommonService.getJsonData('api/config/saveVisitor', par).then(function(data) {
                    callback(data);
                });
            }, deleteVisitor: function(par,callback) { //删除催收员
                CommonService.getJsonData('api/config/deleteVisitor', par).then(function(data) {
                    callback(data);
                });
            },
            getCaseNumbers: function(par,callback) { //案件数量列表
                CommonService.getJsonData('api/config/getCaseNumbers', par).then(function(data) {
                    callback(data);
                });
            },
            saveCaseNumber: function(par,callback) { //保存案件数量
                CommonService.getJsonData('api/config/saveCaseNumber', par).then(function(data) {
                    callback(data);
                });
            },
            deleteCaseNumber: function(par,callback) { //删除案件数量
                CommonService.getJsonData('api/config/deleteCaseNumber', par).then(function(data) {
                    callback(data);
                });
            },
        }
    }]);
});