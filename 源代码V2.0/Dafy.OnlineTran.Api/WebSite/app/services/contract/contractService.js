/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('ContractService', function($http,CommonService) {
        return {
            GetContracts: function(par,callback) { //获取合同列表
                CommonService.getJsonData('api/Contract/GetContracts', par).then(function(data) {
                    callback(data);
                });
            },
            autoMethod: function(par,callback) { //自动分案
                CommonService.getJsonData('api/contract/autoMethod', par).then(function(data) {
                    callback(data);
                })	
            },
            handMethod: function(par,callback) { //手动分案
                CommonService.getJsonData('api/contract/handMethod', par).then(function(data) {
                    callback(data);
                })	
            }, 
            cancelCases: function(par,callback) { //撤销分案
                CommonService.getJsonData('api/contract/cancelCases', par).then(function(data) {
                    callback(data);
                })	
            }, 
            caseDelay: function(par,callback) { //案件延期
                CommonService.getJsonData('api/contract/caseDelay', par).then(function(data) {
                    callback(data);
                })	
            }, 
            handFinishCase: function(par,callback) { //人工结案
                CommonService.getJsonData('api/contract/handFinishCase', par).then(function(data) {
                    callback(data);
                })	
            }, 
            toExcelContracts: function(par,callback) { //导出
                CommonService.getJsonData('api/contract/toExcelContracts', par).then(function(data) {
                    callback(data);
                })	
            },     
            getUsers: function(par,callback) { //检索员工信息
                CommonService.getJsonData('api/common/getUsers', par).then(function(data) {
                    callback(data);
                })	
            }          
        }
    });
});