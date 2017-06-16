/**
 * Created by tianxc on 16-8-3.
 */
define([
    'app'
], function(app) {
    'use strict';

    app.factory('upLoadFileService', function($http,CommonService) {
        return {
            upLoadFile: function(par,file,callback) {
                CommonService.uploadFile('api/common/UploadImg',file,  par).then(function(data) {
                    callback(data);
                });
            },
            upLoadFileDoc: function(par,file,callback) {
                CommonService.uploadFile('api/common/UploadDoc',file,  par).then(function(data) {
                    callback(data);
                });
            }
        }
    });
});