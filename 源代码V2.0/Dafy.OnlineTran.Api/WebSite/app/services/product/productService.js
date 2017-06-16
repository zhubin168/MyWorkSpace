/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('ProductService', function($http,CommonService) {
        return {
            getProducts: function(par,callback) { //产品管理列表
                CommonService.getJsonData('api/Product/GetProducts', par).then(function(data) {
                    callback(data);
                });
            }, 
            getDetailProduct:function(par,callback){//获取产品详情
                CommonService.getJsonData('api/Product/GetDetailProduct', par).then(function(data) {
                    callback(data);
                });
            },
            delProducts: function(par,callback) { //删除产品
                CommonService.getJsonData('api/Product/DelProducts', par).then(function(data) {
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