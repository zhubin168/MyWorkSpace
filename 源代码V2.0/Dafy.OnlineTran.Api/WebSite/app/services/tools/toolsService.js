/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('ToolsService', function($http,CommonService) {
        return {
            getTools: function(par,callback) { //获客助手管理列表
                CommonService.getJsonData('api/Tool/GetTools', par).then(function(data) {
                    callback(data);
                });
            }, 
            getDetailTool: function(par,callback) { //获客助手详情
                CommonService.getJsonData('api/Tool/GetDetailTool', par).then(function(data) {
                    callback(data);
                });
            }, 
            delTools: function(par,callback) { //删除助手
                CommonService.getJsonData('api/Tool/DeleteTool', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveTools: function(par,callback) { //保存获客助手
                CommonService.getJsonData('api/Tool/SaveTools', par).then(function(data) {
                    callback(data);
                });
            }, 
            getToolArticles: function(par,callback) { //获取文章管理
                CommonService.getJsonData('api/Tool/GetArticles', par).then(function(data) {
                    callback(data);
                });
            }, 
            getToolDetailArticle: function(par,callback) { //获取文章详情
                CommonService.getJsonData('api/Tool/GetDetailArticle', par).then(function(data) {
                    callback(data);
                });
            }, 
            delToolDeleteArticle: function(par,callback) { //删除文章
                CommonService.getJsonData('api/Tool/DeleteArticle', par).then(function(data) {
                    callback(data);
                });
            }, 
            saveToolArticles: function(par,callback) { //保存文章
                CommonService.getJsonData('api/Tool/SaveArticles', par).then(function(data) {
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