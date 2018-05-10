!(function () {
    "use strict";

    configAxios();

    // 初始化axios
    function configAxios() {
        //axios.defaults.baseURL = '/';
        var LEVEL_STATE = {
            /// <summary>
            /// 未登录
            /// </summary>
            NeedLogin: 1,

            /// <summary>
            /// 未认证
            /// </summary>
            NeedAuth: 2,

            /// <summary>
            /// 未授权
            /// </summary>
            NotAuth: 3,

            /// <summary>
            /// 通过
            /// </summary>
            PASS: 4,

            /// <summary>
            /// 未找到
            /// </summary>
            NOT_FOUND: 404
        };

        function handleRight(data) {
            switch (data.levelState) {
                case LEVEL_STATE.NeedLogin: {
                    var url = jhbGlobal.loginUrl;
                    var backUrl = window.location.href;

                    url += '?returnUrl=' + encodeURIComponent(backUrl);
                    window.location.href = url;
                    return false;
                }
                case LEVEL_STATE.NeedAuth:
                    weui.alert('\
<div class="weui-flex weui-flex1 weui-flex2">\
    <div class="weui-flex__item">\
        <div class="placeholder">\
            <i class="iconfont icon-fabu"></i>\
        </div>\
        <div class="placeholder text-rz">发布需求</div>\
    </div>\
    <div class="weui-flex__item">\
        <div class="weui-flex__item">\
            <div class="placeholder">\
                <i class="iconfont icon-yinshipinjiaoliu"></i>\
            </div>\
            <div class="placeholder text-rz">音视频交流</div>\
        </div>\
    </div>\
    <div class="weui-flex__item">\
        <div class="weui-flex__item">\
            <div class="placeholder">\
                <i class="iconfont icon-gengduo"></i>\
            </div>\
            <div class="placeholder text-rz">更多参与</div>\
        </div>\
    </div>\
</div>\
                        ', {
                            title: '<div>您尚未实名认证</div><div class="pop-xx1">上传名片认证，解锁以下特权</div>',
                            buttons: [{
                                label: '取消',
                                type: 'default',
                            }, {
                                label: '立即认证',
                                type: 'primary',
                                onClick: function () {
                                    var url = jhbGlobal.authUrl;
                                    //var backUrl = window.location.href;

                                    //url += '?returnUrl=' + encodeURIComponent(backUrl);
                                    window.location.href = url;
                                    return false;
                                }
                            }]
                        });
                    return false;
                case LEVEL_STATE.NotAuth:
                    weui.alert('很抱歉，没有进行操作的权限！！');
                    return false;
                case LEVEL_STATE.NOT_FOUND:
                    weui.alert('未找到信息！');
                    return false;
                default:
                    return true;
            }
        }

        // vue ajax get
        Vue.prototype.httpGet = function (url, params) {
            return new Promise(function (resolve, reject) {
                axios.get(url, {
                    parameters: params
                }).then(function (response) {
                    vm.jhbLoading && vm.jhbLoading.hide();
                    handleRight(response.data) && resolve(response.data);
                }).catch(function (err) {
                    vm.jhbLoading && vm.jhbLoading.hide();
                    reject(err);
                })
            })
        }

        // vue ajax post
        Vue.prototype.httpPost = function (url, data) {
            var vm = this;

            return new Promise(function (resolve, reject) {
                var userObj = vm.getUserInfoObjFromLocal();

                axios.post(url, {
                    parameters: data,
                    userId: userObj && userObj.User ? userObj.User.UserId : 0,
                    token: userObj && userObj.User ? userObj.Token : '',
                }).then(function (response) {
                    vm.jhbLoading && vm.jhbLoading.hide();
                    handleRight(response.data) && resolve(response.data);
                }).catch(function (err) {
                    vm.jhbLoading && vm.jhbLoading.hide();
                    reject(err);
                });
            })
        }
    }

    // 对Date的扩展，将 Date 转化为指定格式的String
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
    // 例子： 
    // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ===> 2006-07-02 08:09:04.423 
    // (new Date()).Format("yyyy-M-d h:m:s.S")      ===> 2006-7-2 8:9:4.18 
    Date.prototype.format = function (fmt) { //author: meizz 
        var o = {
            "M+": this.getMonth() + 1, //月份 
            "d+": this.getDate(), //日 
            "h+": this.getHours(), //小时 
            "m+": this.getMinutes(), //分 
            "s+": this.getSeconds(), //秒 
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
            "S": this.getMilliseconds() //毫秒 
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }

    String.prototype.toDateTime = function () {
        var year = 1970, month = 0, day = 1, hour = 0, minute = 0, second = 0;
        var dateTime = this.replace('Z', '');
        var arrDateTime = dateTime.replace('T', ' ').split(' ');

        if (arrDateTime.length > 0) {
            var splitChar = '-';

            if (arrDateTime[0].indexOf('-') === -1) {
                splitChar = '/';
            }

            var arrDate = arrDateTime[0].split(splitChar);
            year = arrDate.length > 0 && parseInt(arrDate[0]);
            month = arrDate.length > 1 && parseInt(arrDate[1] - 1);
            day = arrDate.length > 2 && parseInt(arrDate[2]);
        }

        if (arrDateTime.length > 1) {
            var arrTime = arrDateTime[1].split(':');
            hour = arrTime.length > 0 && parseInt(arrTime[0]);
            minute = arrTime.length > 1 && parseInt(arrTime[1]);
            second = arrTime.length > 2 && parseInt(arrTime[2]);
        }

        return new Date(year, month, day, hour, minute, second);
    }

    window.jhbCore = {
        // 设置微信分享
        setWxShare: function (title, desc, picture) {
            console.log('page custom init wxshare');

            if (window.navigator.userAgent.indexOf('MicroMessenger') === -1) {
                return;
            }

            var titleElem = document.getElementById('wxShareTitle');
            var descElem = document.getElementById('wxShareDesc');
            var pictureElem = document.getElementById('wxShareUrl');

            title && (titleElem.value = title);
            desc && (descElem.value = desc);
            picture && (pictureElem.value = picture);

            window.initWxShare(true);
        },

        // 删除html
        trimHtml: function (str) {
            if (!str) {
                return str;
            }

            return str.replace(/(<\/?.+?>)|(&nbsp;)/g, '');
        },

        reloadOnSafari: function (evt) {
            var str = navigator.userAgent;
            var isiPhone = str.indexOf("iPhone") !== -1;
            var isSafari = str.indexOf("Safari") !== -1;
            if (isiPhone && isSafari) {
                evt.persisted && window.location.reload();
            }
        },

        // 初始化无限加载
        initWaypoint: function (element, handler, context, offset) {
            context = typeof (context) === 'undefined' ? window : context;
            offset = typeof (offset) === 'undefined' ? 'bottom-in-view' : offset;

            return new Waypoint({
                element: element,
                context: context,
                offset: offset,
                handler: function (direction) {
                    if (direction === 'down') {
                        handler && handler();
                    }
                }
            });
        },

        // 消毁无限加载
        destroyWaypoint: function (waypoint) {
            waypoint && waypoint.destroy();
        },

        // 获取查询字符串参数
        getQueryString: function (field, url) {
            var href = url ? url : window.location.href;
            var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
            var string = reg.exec(href);
            return string ? string[1] : null;
        },

        getCookie: function (c_name) {
            if (document.cookie.length > 0) {
                var c_start = document.cookie.indexOf(c_name + "=")
                if (c_start !== -1) {
                    c_start = c_start + c_name.length + 1
                    var c_end = document.cookie.indexOf(";", c_start)
                    if (c_end === -1) c_end = document.cookie.length
                    return unescape(document.cookie.substring(c_start, c_end))
                }
            }
            return ""
        },

        setCookie: function (name, value, exdays) {
            var exp = new Date();
            exp.setTime(exp.getTime() + exdays * 24 * 60 * 60 * 1000);
            document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + "; path=/";
        },

        // 两当前日期与offset日期相关的小时数
        getDateTimeDiffHour: function (dateTime, offset) {
            var date = new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate());
            var targetDate = new Date(date.getTime() + offset * 86400000);
            var diff = (targetDate - dateTime) / 3600000;

            return Math.abs(diff);
        },

        //与当前时间比较
        getDate: function (time) {
            //时间戳
            var str = time;
            //将字符串转换成时间格式
            var timePublish = str.toDateTime();
            var timeNow = new Date();
            var year = timeNow.getFullYear();
            var minute = 1000 * 60;
            var hour = minute * 60;
            var diffValue = timeNow - timePublish;
            var diffHour = Math.abs(diffValue / hour);
            var diffMinute = Math.abs(diffValue / minute);
            var result = '';

            //将昨天前天，明天后天转换成格式
            //判断时间并赋值
            if (diffValue < 0) {
                if (diffHour >= this.getDateTimeDiffHour(timeNow, 3)) {
                    //当前年份与活动年份对比
                    if (year !== (timePublish.getFullYear())) {
                        result = timePublish.getFullYear() + "/";
                    }

                    result += ("0" + (timePublish.getMonth() + 1)).slice(-2) + "/";
                    result += ("0" + timePublish.getDate()).slice(-2);
                }
                else if (diffHour >= this.getDateTimeDiffHour(timeNow, 2)
                    && diffHour < this.getDateTimeDiffHour(timeNow, 3)) {
                    result = "后天";
                }
                else if (diffHour >= this.getDateTimeDiffHour(timeNow, 1)
                    && diffHour < this.getDateTimeDiffHour(timeNow, 2)) {
                    result = "明天";
                }
                else if (diffHour >= 1 && diffHour < this.getDateTimeDiffHour(timeNow, 1)) {
                    result = parseInt(diffHour) + "小时后";
                }
                else if (diffMinute >= 1 && diffMinute < 60) {
                    result = parseInt(diffMinute) + "分钟后";
                }
                else if (diffMinute >= 0 && diffMinute < 1) {
                    result = "刚刚";
                }
            }
            else if (diffHour > this.getDateTimeDiffHour(timeNow, -2)) {
                if (year !== (timePublish.getFullYear())) {
                    result = timePublish.getFullYear() + "/";
                }

                result += ("0" + (timePublish.getMonth() + 1)).slice(-2) + "/";
                result += ("0" + timePublish.getDate()).slice(-2);
            }
            else if (diffHour > this.getDateTimeDiffHour(timeNow, -1)
                && diffHour <= this.getDateTimeDiffHour(timeNow, -2)) {
                result = "前天";
            }
            else if (diffHour > this.getDateTimeDiffHour(timeNow, 0)
                && diffHour <= this.getDateTimeDiffHour(timeNow, -1)) {
                result = "昨天";
            }
            else if (diffHour > 1 && diffHour <= this.getDateTimeDiffHour(timeNow, 0)) {
                result = parseInt(diffHour) + "小时前";
            }
            else if (diffMinute > 1 && diffMinute <= 60) {
                result = parseInt(diffMinute) + "分钟前";
            }
            else if (diffMinute > 0 && diffMinute <= 1) {
                result = "刚刚";
            }

            return result;
        },

        // vue混入
        vueMixin: {
            data: function () {
                return {
                    jhbLoading: null
                }
            },
            // jhbGlobal：定义机会宝全局变量，定义文件：Views/Shared/_Layout.cshtml
            methods: {
                alert: function (msg, title) {
                    weui.alert(
                        msg,
                        {
                            title: title,
                            buttons: [{
                                label: '确定',
                                type: 'primary',
                            }]
                        });
                },
                toast: function (msg, options) {
                    weui.toast(msg, options);
                },
                openApp: function () {
                    window.location.href = "http://a.app.qq.com/o/simple.jsp?pkgname=com.dianyi.jihuibao";
                },
                getImg: function (src, defaultSrc) {
                    if (src) {
                        return src;
                    }
                    else {
                        return defaultSrc || jhbGlobal.host + '/images/default.png';
                    }
                },

                // 获取深度解读封面图
                getArticleImg: function (src) {
                    if (src) {
                        return src;
                    }
                    else {
                        return jhbGlobal.host + '/images/default.png';
                    }
                },

                // 获取用户默认头像
                getHeadImg: function (src) {
                    var defaultImg = jhbGlobal.host + '/images/head-mrimg@2x.png';

                    return this.getImg(src, defaultImg);
                },

                // 获取公司logo
                getUnitLogo(src) {
                    var defaultImg = jhbGlobal.host + '/images/gs-mrimg.png';

                    return this.getImg(src, defaultImg);
                },

                // 图片加载失败处理函数
                imgLoadError: function (event) {
                    event.target.src = jhbGlobal.host + '/images/default.png'
                },

                // 公司logo图片加载失败处理函数
                unitLogoLoadError(event) {
                    event.target.src = jhbGlobal.host + '/images/gs-mrimg.png'
                },

                // 获取活动详细地址
                getViewUrl: function (type, id, state) {
                    switch (type) {
                        case 2: // 调研
                            return jhbGlobal.surveyDetailUrl + '/' + id.toString()
                        case 1: // 路演
                        default:
                            if (state && (state === 4 || state === 5)) {
                                return jhbGlobal.roadShowPlayUrl + '/' + id.toString();
                            }
                            else {
                                return jhbGlobal.roadShowDetailUrl + '/' + id.toString();
                            }
                    }
                },

                // 获取文章详情地址
                getArticleDetailUrl: function (id) {
                    return jhbGlobal.articleDetailUrl + '?id=' + id.toString();
                },

                // 获取电话会议详情地址
                getTelMeetingDetailUrl: function (id) {
                    return jhbGlobal.telMeetingDetailUrl + '?id=' + id.toString();
                },

                formatJhbDate: function (strDateTime) {
                    if (!strDateTime) {
                        return strDateTime;
                    }

                    return jhbCore.getDate(strDateTime);
                },

                // 格式化日期字符串
                formatDateTimeStr: function (str, formatStr) {
                    if (!str) {
                        return str;
                    }

                    var datetime = str.toDateTime();

                    formatStr = formatStr || 'yyyy-MM-dd hh:mm:ss';

                    return datetime.format(formatStr);
                },

                saveUserInfoToLocal: function (userInfo) {
                    var userInfoStr = JSON.stringify(userInfo);
                    if (window.localStorage) {
                        localStorage.setItem('userInfo', userInfoStr);
                    }
                    window.jhbCore.setCookie('userInfo', userInfoStr, 30);
                },

                clearLocalUserInfo: function () {
                    if (window.localStorage) {
                        localStorage.removeItem('userInfo');
                    }
                    window.jhbCore.setCookie('userInfo', '', -1);
                },

                getUserInfoObjFromLocal: function () {
                    var self = this;
                    var userInfo = window.jhbCore.getCookie('userInfo');
                    if (isBlankStr(userInfo)) {
                        if (window.localStorage) {
                            userInfo = localStorage.getItem('userInfo');
                            console.info("userInfo from localstorage:" + userInfo);
                        } else {
                            userInfo = '';
                        }
                    }
                    if (typeof userInfo === 'string') {
                        var user = null;
                        try {
                            user = JSON.parse(userInfo);
                        } catch (error) {
                            self.clearLocalUserInfo();
                        }
                        return user;
                    }
                    return userInfo;
                },

                // 显示加载样式
                showLoading: function (msg) {
                    this.jhbLoading = weui.loading(msg || '请稍等');
                },

                // 隐藏加载样式
                hideLoading: function () {
                    if (this.jhbLoading) {
                        this.jhbLoading.hide();
                    };
                },

                // 滚动页面
                scrollTo: function (scrollTop) {
                    window.document.documentElement.scrollTop = scrollTop;
                },

                // 清空文本框
                clearInput: function (targetId, event) {
                    this[targetId] = '';
                },

                // 隐藏文本输入框后面的关闭
                hideClear: function (targetId, event) {
                    var target = document.getElementById(targetId);

                    setTimeout(function () {
                        target.style.display = 'none';
                    }, 0);
                },

                initClear: function (targetId, event) {
                    var target = document.getElementById(targetId);

                    if (event.target.value) {
                        target.style.display = 'initial';
                    }
                },

                /**
                 * url跳转，不记住位置
                 */
                redirect(url) {
                    this.clearJhbPathStorage(window.localStorage);
                    this.clearJhbPathStorage(window.sessionStorage);
                    window.sessionStorage.clear();
                    window.jhbDataStorage && window.jhbDataStorage.disableSaveData();
                    window.location.href = url;
                },

                /**
                 * 删除键
                 * @param {Storage} storage
                 */
                clearJhbPathStorage(storage) {
                    const len = storage.length;

                    if (len) {
                        for (let i = 0; i < len; i++) {
                            const key = storage.key(i);

                            if (key && key.indexOf('/') === 0) {
                                storage.removeItem(key);
                            }
                        }
                    }
                },
            }
        }
    }
})();