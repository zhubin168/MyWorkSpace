/**
 * Created by tianxc on 16-8-2.
 */
define(['angular'], function(angular) {

    var commonService = angular.module('app.commonService', []);

    commonService.service('CommonService', ['$rootScope','$q', '$timeout', '$http','$state','Settings','$window','$localStorageUsage','Upload','$loading','toastr','$filter', function($rootScope ,$q, $timeout, $http,$state,Settings,$window,$localStorageUsage,Upload,$loading,toastr,$filter) {
            var serviceBase = Settings.apiServiceBaseUrl;

            function showToast(string, duration) {

            }
            return {
                showToast: function(string, duration) { //消息提示框
                    showToast(string,duration);
                },
                getAuthorizationData: function() { //获取用户信息
                    var authData = localStorage.getItem('onLineauthorization');
                    if (authData != null) {
                        authData = eval('(' + authData + ')');
                    } else {
                        authData = null;
                    }
                    return authData;
                },
                clearStorage: function() {
                    $localStorageUsage.clear();
                },
                setStorageItem: function(key, value) { //存储数据
                    $localStorageUsage.setItem(key, value, 1);
                },
                getStorageItem: function(key) { //获取本地存储数据
                    return $localStorageUsage.getItem(key);
                },
                removeStorageItem: function(key) { //删除本地存储数据
                    $localStorageUsage.removeItem(key);
                },
                getJsonData: function(url, par) { //获取JSON数据
                    /*var authData = localStorage.getItem('onLineauthorization');
                	console.log(authData);*/
                	 if ($rootScope.token == '' ||$rootScope.token==undefined) {
                        var dataV={'data':{'token':''},'message':'','result':false};
                        var authData = localStorage.getItem('onLineauthorization');
                        if(authData != undefined && authData != null)
                        {
                        	authData = eval('(' + authData + ')');
				            $rootScope.token = authData.token != "" ? authData.token : '';
				            console.log($rootScope.token);
                        }
                   }
                    var deferred = $q.defer();
                    var num=Settings.version;
                    var dataJs = Settings.deBug === true ? '.json?v='+num: '';
                    $http({
                        url: serviceBase + url + dataJs,
                        method: (Settings.deBug === true ? "get" : "post"),
                        headers: {
                            'Authorization': 'Bearer ' + $rootScope.token,
                            'X-Requested-With':'XMLHttpRequest'
                        },
                        data: par,
                        timeout:100000
                    }).success(function(data) {
                        if (JSON.stringify(data).indexOf('login')>0 || (data.message!=undefined && data.message.indexOf('请求授权')>0)) {
                            localStorage.removeItem('onLineauthorization');
                            $state.go('login');
                        }
                        else {
                            deferred.resolve(data);
                        }
                        //deferred.resolve(data);
                    }).error(function(error, status) {                    	
                        var msg = '获取数据出现错误!';
                        if(status == undefined){
                        	toastr.error('认证失效,请重新登录!');
                            localStorage.removeItem('onLineauthorization');
					        $state.go('login');

                        }else if (status==0 || status == 500 || status==404){
                            msg = '服务器错误!';
                            toastr.error(msg);
                            deferred.reject(msg);
                        }else{
                            toastr.error(msg);
                            deferred.reject(msg);
                        }
                    });
                    return deferred.promise;
                },
                //上传文件
                uploadFile: function (url, file, par) {
                	var deferred = $q.defer();
	                Upload.upload({
	                    //服务端接收
	                    url: serviceBase + url,
	                    //上传的同时带的参数
	                    data: par,
	                    file: file
	                }).progress(function (evt) {
	                    //进度条
	                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
	                    $rootScope.progressPercentage=progressPercentage;
	                    console.log('progess:' + progressPercentage + '%' );
	                }).success(function (data, status, headers, config) {
	                    //上传成功
	                    deferred.resolve(data);
	                }).error(function (data, status, headers, config) {
	                    //上传失败
	                    console.log('error status: ' + status+data);
	                });
	                return deferred.promise;
	            },
                //本地存储数据
		        set:function(key,value){
		          $window.localStorage[key]=value;
		        },        //读取单个属性
		        get:function(key,defaultValue){
		          return  $window.localStorage[key] || defaultValue;
		        },        //存储对象，以JSON格式存储
		        setObject:function(key,value){
		          $window.localStorage[key]=JSON.stringify(value);
		        },        //读取对象
		        getObject: function (key) {
		          return JSON.parse($window.localStorage[key] || '{}');
		        },
		        getProvince:function(par,callback,callbackError){
                    this.getJsonData('api/common/getProvince',par).then(function(data) {
                       callback(data);
                    },function(error){
                        callbackError(error);
                    });
		        },
		        getCitys:function(par,callback,callbackError){
                    this.getJsonData('api/common/getCitys',par).then(function(data) {
                       callback(data);
                    },function(error){
                        callbackError(error);
                    });
		        },  
		        getRegions:function(par,callback,callbackError){
                    this.getJsonData('api/common/getRegion',par).then(function(data) {
                       callback(data);
                    },function(error){
                        callbackError(error);
                    });
		        },
		        getDictionaries:function(par,callback,callbackError){
                    this.getJsonData('api/home/dictionaries',par).then(function(data) {
                       callback(data);
                    },function(error){
                        callbackError(error);
                    });
		        }
                
            }
        }]);
    commonService.service('ComExamService', [function() {
            return {
                getExamSubData: function(examDetls) {
                    var noAnswerModel = { type: 0, count: 0 };
                    var noAnswerList = [];
                    for (var n = 1; n <= 3; n++) {
                        noAnswerModel = { type: n, count: 0 };
                        noAnswerList.push(noAnswerModel);
                    }
                    var answerList = { list: [] };
                    var flag = false;

                    if (examDetls != null) {
                        var answer = [];
                        for (var i = 0; i < examDetls.length; i++) {
                            var type = examDetls[i].type;
                            for (var j = 0; j < examDetls[i].subjects.length; j++) {
                                var answerModel = { id: 0, check: '', type: 0 };

                                switch (type) {
                                    case 1:
                                        {
                                            var checkValue = examDetls[i].subjects[j].checked;
                                            var id = examDetls[i].subjects[j].id;
                                            if (checkValue == null) {
                                                flag = true;
                                                noAnswerList[0].count += 1;
                                            } else {
                                                answerModel = { questionId: id, check: checkValue, type: type };
                                                answerList.list.push(answerModel);
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            var checkValue = '';
                                            var id = examDetls[i].subjects[j].id;

                                            for (var d = 0; d < examDetls[i].subjects[j].options.length; d++) {
                                                var check = examDetls[i].subjects[j].options[d].checked;                                                                                                                                                                                      
                                                if (check !== null && check == true) {
                                                   checkValue = checkValue ==""? examDetls[i].subjects[j].options[d].value : 
                                                        checkValue+"|"+examDetls[i].subjects[j].options[d].value;
                                                }
                                            }
                                            if (checkValue == '') {
                                                flag = true;
                                                noAnswerList[1].count += 1;
                                            } else {
                                                answerModel = { questionId: id, check: checkValue, type: type };
                                                answerList.list.push(answerModel);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            var checkValue = '';
                                            var id = examDetls[i].subjects[j].id;
                                            var content = examDetls[i].subjects[j].content;
                                            if (content == null || content == '') {
                                                flag = true;
                                                noAnswerList[2].count += 1;
                                            } else {
                                                answerModel = { questionId: id, check: content, type: type };
                                                answerList.list.push(answerModel);
                                            }
                                            break;
                                        }
                                }
                                // if (flag)
                                //     break;
                            }
                        }
                    }
                    var msg = '';
                    if (flag) {
                        for (var n = 0; n < noAnswerList.length; n++) {
                            var count = noAnswerList[n].count;
                            var type = noAnswerList[n].type;

                            switch (type) {
                                case 1:
                                    {
                                        if (count > 0) {
                                            msg += "选择题,你有" + count + "道题没有答;<br>";
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if (count > 0) {
                                            msg += "多选题,你有" + count + "道题没有答;<br>";
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (count > 0) {
                                            msg += "简答题,你有" + count + "道题没有答;<br>";
                                        }
                                        break;
                                    }
                            }

                        }
                    }
                    if (msg == '') {
                        msg = '你确定要提交?';
                    } else {
                        msg += '你确定要提交?';
                    }
                    var subData = { msg: msg, list: answerList.list };
                    console.log(subData);
                    return subData;
                }
            };
        }])
        .service('UtilService',['$window',function($window){
            return {
                isNull: function (val) {//检查给定的对象是否为Null或未定义
                    return val == null || val=='' || typeof(val) == "undefined";
                },
                isName:function(val){//姓名只能输入最小2个最大15个汉字字母组成
                    return !/^[a-zA-Z\u4e00-\u9fa5]{2,15}$/.test(val);
                },
                isNumber: function (val) {//判断给定的值是否是数字
                    return isNaN(val);
                },
                isInteger:function(val){//8位正整数
                    return !/^[1-9]{1}\d{0,7}$/.test(val);
                },
                isLength:function(val,minNum,maxNum){//判断字符串长度
                    return !(val.length>=minNum && val.length<maxNum)?true:false;
                },
                isEmpty: function (val) {//检查给定的字符串是否是空串或未定义
                    return this.trim(val).length == 0;
                },
                trim: function (val) {//移除给定的字符串两端的空白字符，如果字符串不存在则返回空串。
                    return !val ? "" : val.replace(/(^\s*)|(\s*$)/g, "");
                },
                isMobile:function(val){//检测手机号码格式号码是否正确
                    return !/^1[0-9]{10}$/.test(val);
                },
                isTelephone:function(val){//检测电话号码如0775-88888888
                    return !/^0\d{2,3}-\d{7,8}$/.test(val);
                },
                isEmail:function(val){//检测邮箱格式是否正确
                    return !/^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/.test(val);
                },
                isBankNo:function(val){//检测银行卡号格式是否正确
                    return !/^[0-9]{16,19}$/.test(val);
                },
                isArray: function (val) {//判断是否为数组
                    return !this.isNull(val) && Object.prototype.toString.call(val) === "[object Array]";
                },
                isStartWith: function (val, prefix) {//检查给定的字符串是否以某个字符串开头，如果要检测多个prefix，可指定prefix为数组。
                    if (!val) return false;
                    var arrays = this.isArray(prefix) ? prefix : [prefix];
                    for (var i = 0; i < arrays.length; i++) {
                        if (val.indexOf(arrays[i]) == 0) {
                            return true;
                        }
                    }
                    return false;
                },
                isContain: function (val, array) {//检查指定的值是否在给定的数组中。
                    if (!this.isArray(array)) return false;
                    for (var i = 0; i < array.length; i++) {
                        if (array[i] == val) return true;
                    }
                    return false;
                },
                isIdent:function(val){//验证身份证号格式是否正确
                    if(val.length==15)
                        return !/^\d{15}$/.test(val);
                    else
                        return !/^\d{6}(18|19|20)?\d{2}(0[1-9]|1[012])(0[1-9]|[12]\d|3[01])\d{3}(\d|X)$/.test(val);
                },
                isSexByIdent:function(val){//根据身份证判断性别
                    if(val.length==15){
                        return (parseInt(val.toString().charAt(val.length-1))%2==0?'女':'男');
                    }else{
                        return parseInt(val.toString().charAt(val.length-2))%2==0?'女':'男';
                    }
                },
                generateUUID:function(){
                    var d = new Date().getTime();
                    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
                      var r = (d + Math.random()*16)%16 | 0;
                      d = Math.floor(d/16);
                      return (c=='x' ? r : (r&0x3|0x8)).toString(16);
                    });
                    return uuid;
                },
                getNowFormatDate:function (){
                    var date = new Date();
                    var seperator1 = "-";
                    var seperator2 = ":";
                    var month = date.getMonth() + 1;
                    var strDate = date.getDate();
                    if (month >= 1 && month <= 9) {
                        month = "0" + month;
                    }
                    if (strDate >= 0 && strDate <= 9) {
                        strDate = "0" + strDate;
                    }
                    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                            + " " + date.getHours() + seperator2 + date.getMinutes()
                            + seperator2 + date.getSeconds();
                    return currentdate;
                }
            }
        }])
        .service('dateService',['$window','$filter',function($window,$filter){
        	return {
        		parseDate:function (date) {  
			    var t = Date.parse(date);  
			    if (!isNaN(t)) {  
			        return new Date(Date.parse(date.replace(/-/g, "/")));  
			    } else {  
			        return;  
			    }  
	          },  
        	 formatDate:function (date) {  
				var t=$filter('date')(date,'yyyy-MM-dd');
				return t;
	           },
           formatParse:function(date){
           	var d = $filter('date')(date,'yyyy-MM-dd');
		    var t = Date.parse(d);  
		    if (!isNaN(t)) {  
		        return new Date(Date.parse(d.replace(/-/g, "/")));  
		     } else {  
		        return;  
		     } 	           	
           }
	              }
        }]);  
    return commonService;
});
