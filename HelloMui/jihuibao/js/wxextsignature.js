(function () {
    "use strict";

    window.isWxShareInit = false;
    window.initWxShare = initWxShare;

    // 初始化微信分享
    function initWxShare(force) {
        if (!force && window.isWxShareInit) {
            return;
        }

        window.isWxShareInit = true;
        axios.post('/weixin/GetJsSdk', {
            JSAPI: "1",
            JSURL: location.href.split('#')[0]
        }).then(function (res) {
            configWxShare(res.data);
        }).catch(function (err) {
            console.log(err);
        });
    }

    function configWxShare(dataObject) {
        var wxShareImgUrl = jhbGlobal.host + "/images/wxshare.png?0.1";
        var lineLink = document.getElementById("wxShareUrl") ? document.getElementById("wxShareUrl").value : null;
        var descContent = document.getElementById("wxShareDesc").value;
        var shareTitle = document.getElementById("wxShareTitle").value;
        var wxShareImg = document.getElementById("wxShareImg");
        var appid = '';

        shareTitle = shareTitle || '机会宝·' + window.document.title;
        descContent = descContent || shareTitle;
        lineLink = lineLink || window.location.href;
        wxShareImgUrl = (wxShareImg && wxShareImg.value) || wxShareImgUrl;

        /*
         * 注意：
         * 1. 所有的JS接口只能在公众号绑定的域名下调用，公众号开发者需要先登录微信公众平台进入“公众号设置”的“功能设置”里填写“JS接口安全域名”。
         * 2. 如果发现在 Android 不能分享自定义内容，请到官网下载最新的包覆盖安装，Android 自定义分享接口需升级至 6.0.2.58 版本及以上。
         * 3. 常见问题及完整 JS-SDK 文档地址：http://mp.weixin.qq.com/wiki/7/aaa137b55fb2e0456bf8dd9148dd613f.html
         *
         * 开发中遇到问题详见文档“附录5-常见错误及解决办法”解决，如仍未能解决可通过以下渠道反馈：
         * 邮箱地址：weixin-open@qq.com
         * 邮件主题：【微信JS-SDK反馈】具体问题
         * 邮件内容说明：用简明的语言描述问题所在，并交代清楚遇到该问题的场景，可附上截屏图片，微信团队会尽快处理你的反馈。
         */
        wx.config({
            debug: false,
            appId: dataObject.AppId,
            timestamp: dataObject.TimeStamp,
            nonceStr: dataObject.NonceStr,
            signature: dataObject.Signature,
            jsApiList: [
                'onMenuShareTimeline',
                'onMenuShareAppMessage',
                'onMenuShareQQ',
                'onMenuShareWeibo'
            ]
        });

        wx.ready(function () {
            // 2.1
            //document.querySelector('#onMenuShareAppMessage').onclick = function () {
            wx.onMenuShareAppMessage({
                title: shareTitle,
                desc: descContent,
                link: lineLink,
                imgUrl: wxShareImgUrl,
                trigger: function (res) {
                },
                success: function (res) {
                },
                cancel: function (res) {
                },
                fail: function (res) {
                }
            });
            //};

            // 2.2
            //document.querySelector('#onMenuShareTimeline').onclick = function () {
            wx.onMenuShareTimeline({
                title: shareTitle,
                link: lineLink,
                imgUrl: wxShareImgUrl,
                trigger: function (res) {
                },
                success: function (res) {
                },
                cancel: function (res) {
                },
                fail: function (res) {
                }
            });
            //alert('触发分享朋友圈');
            //};

            // 2.3
            //document.querySelector('#onMenuShareQQ').onclick = function () {
            wx.onMenuShareQQ({
                title: shareTitle,
                desc: descContent,
                link: lineLink,
                imgUrl: wxShareImgUrl,
                trigger: function (res) {
                },
                complete: function (res) {
                },
                success: function (res) {
                },
                cancel: function (res) {
                },
                fail: function (res) {
                }
            });
            //alert('触发分享QQ');
            //};

            // 2.4
            //document.querySelector('#onMenuShareWeibo').onclick = function () {
            wx.onMenuShareWeibo({
                title: shareTitle,
                desc: descContent,
                link: lineLink,
                imgUrl: wxShareImgUrl,
                trigger: function (res) {
                    //alert('鐢ㄦ埛鐐瑰嚮鍒嗕韩鍒板井鍗�');
                },
                complete: function (res) {
                    //alert(JSON.stringify(res));
                },
                success: function (res) {
                    //alert('宸插垎浜�');
                },
                cancel: function (res) {
                    //alert('宸插彇娑�');
                },
                fail: function (res) {
                    // alert(JSON.stringify(res));
                }
            });
            //alert('触发分享微博');
            //};
        });

        wx.error(function (res) {

            console.log(res);

        });
    }

})();