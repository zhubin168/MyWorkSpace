/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('homeService', function($http,CommonService) {
        return {
            dictionaries: function(par,callback) { //获取字典值
                CommonService.getJsonData('api/home/Dictionaries', par).then(function(data) {
                    callback(data);
                });
            },
            saveDictionary: function(par,callback) { //保存字典值
                CommonService.getJsonData('api/home/saveDictionary', par).then(function(data) {
                    callback(data);
                });
            },
            delDictionary: function(par,callback) { //删除字典值
                CommonService.getJsonData('api/home/delDictionary', par).then(function(data) {
                    callback(data);
                });
            },
            logout: function(par,callback) { //退出登录
                CommonService.getJsonData('api/home/Logout', par).then(function(data) {
                    callback(data);
                });
            },
            getAuthorityMeun: function(par,callback) { //获取登录用户菜单
                CommonService.getJsonData('api/home/getAuthorityMeun', par).then(function(data) {
                    callback(data);
                });
            }  
        }
    });
});