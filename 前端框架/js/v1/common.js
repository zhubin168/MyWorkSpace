$.extend($.fn, {
    simpleShow: function () {
        return this.each(function () {
            $(this).css({
                "display": "block"
            });
        });
    },
    simpleHide: function () {
        return this.each(function () {
            $(this).css({
                "display": "none"
            });
        });
    }
});

// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
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
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

function formatJsonDate(date) {
    if (!date) {
        return "";
    }

    return new Date(parseInt(date.substr(6))).format("yyyy-MM-dd hh:mm:ss");
}

String.prototype.formatDate = function (format) {
    if (!this) return "";
    return new Date(parseInt(this.substr(6))).format(format);
};

function formatSeconds(value) {
    var second = parseInt(value);// 秒
    var minutes = 0;// 分
    var hour = 0;// 小时

    if (second >= 60) {
        minutes = parseInt(second / 60);
        second = parseInt(second % 60);

        if (minutes >= 60) {
            hour = parseInt(minutes / 60);
            minutes = parseInt(minutes % 60);
        }
    }

    var result = paddingRight(parseInt(second).toString(), "0", 2);

    if (minutes > 0) {
        result = paddingRight(parseInt(minutes).toString(), "0", 2) + ":" + result;
    }
    else {
        result = "00:" + result;
    }

    if (hour > 0) {
        result = paddingRight(parseInt(hour).toString(), "0", 2) + ":" + result;
    }
    else {
        result = "00:" + result;
    }

    return result;
}

function paddingRight(str, chr, length) {
    // 字符串为空，返回空
    if (!str) {
        return "";
    }

    var len = str.length;

    // 如果字符串的长度比指定的长度长或相等返回源字符串
    if (len >= length) {
        return str;
    }

    var res = str;

    // 补齐
    for (var i = len; i < length; i++) {
        res = chr + res;
    }

    return res;
}

// 设置选中菜单
function setMenu(selector) {
    $(".menu").find(selector).addClass("active");
}

// ============== 短信发送 开始 ==============
var resendSmsTimer = null;

// 短信发送按钮倒计时
function smsTimeOut(timer, $obj, retryText) {
    var $text;
    var text = retryText || "秒后重新获取";

    if (resendSmsTimer) {
        return;
    }

    $text = $(".text", $obj);
    floatNotify.simple("验证码已经通过短信发送到您的手机，请注意查收");
    $obj.attr("disabled", true)
    $text.text((timer / 1000).toString() + text);
    resendSmsTimer = setInterval(function () {
        timer -= 1000;
        $text.text((timer / 1000).toString() + text);

        if (timer <= 0) {
            clearInterval(resendSmsTimer);
            resendSmsTimer = null;
            $obj.removeAttr("disabled");
            $text.text("获取验证码");
        }
    }, 1000);
}
// ============== 短信发送 结束 ==============

// ============== AJAX处理 开始 ==============
$(document).on('ajaxError', function (e, xhr, options) {
    hideSysLoading();

    if (xhr.status == 401) {
        var subStatusCode = xhr.getResponseHeader("JhbStatusCode");
        var url = xhr.getResponseHeader('JhbUrl');
        var msg;

        //处埋首页路演详情的登录跳转
        var href = window.location.href;
        var index = href.indexOf("#");
        if (index >= 0) {
            var param = href.substr(index);
            if (param.length > 8) {
                var rid = param.substr (1, param.length - 3);
                var rtype = param.substr( param.length - 1);
                var surl = appRoot + "/Waiting/" + rid + "/" + rtype;
                var loginurl = appRoot + "/login?returnUrl=" + encodeURI(surl);
                url = loginurl;
            }
         }

        switch (subStatusCode) {
            case '1': // NeedLogin
                msg = '您还未登录,请登录后再来吧';
                break;
            case '2': // NeedAuth
                msg = '您还未认证,认证后将可以拥有更多特权';
                break;
            case '3': // NotAuth
                msg = '没有权限,您未拥有该特权';
                break;
            case '5': //Authing 
                showAuthingMsg();
                return; 
            default:
                successCallback(data.Data);
                return;
        }

        floatNotify.jhbmsg(jhb.splitMessage(msg, 0), jhb.splitMessage(msg, 1));

        if (url) {
            setTimeout(function () {
                window.location.href = url;
            }, 1000);
        }
    }
})
// ============== AJAX处理 结束 ==============

// ============================ 滚动条 开始 ============================

// originalScroller：原滚动条
// scrollBox：设置滚动条元素，缺省值：#container
// scrollContent：滚动内容，缺省值：.iscroll
// scrollEnd：滚动到底部事件
// isLastPage：是否已经是最后一页
// originalScroller, iscroll, sub, scrollEnd, isLastPage
function createScroller(options) {
    var x = 0;
    var y = 0;
    var defaults = {
        scroller: null,
        scrollBox: "#container",
        scrollContent: ".iscroll",
        scrollEnd: null,
        scrollStart: null,
        isLastPage: false
    };

    options = $.extend(defaults, options);

    var scrollBox = options.scrollBox;
    var scrollContent = $(scrollBox).find(options.scrollContent)[0];
    var originalScroller = options.scroller;

    if (originalScroller) {
        var $loading = $(originalScroller.wrapper).find(".loading");
        var loadingHeight = $loading.height();

        x = originalScroller.x;
        y = options.isLastPage && originalScroller.hasVerticalScroll ? originalScroller.y + loadingHeight : originalScroller.y;
        originalScroller = destoryScroller(originalScroller);

        if (options.isLastPage) {
            $loading.hide();
        }
    }

    var newScroller = new IScroll(scrollBox, {
        scrollbars: true,
        mouseWheel: true,
        interactiveScrollbars: true,
        shrinkScrollbars: 'scale',
        fadeScrollbars: true,
        scroller: scrollContent,
        click: true,
        startX: x,
        startY: y
    });

    if (options.scrollEnd && typeof options.scrollEnd == "function") {
        newScroller.on("scrollEnd", options.scrollEnd);
    }

    if (options.scrollStart && typeof options.scrollStart == "function") {
        newScroller.on("scrollStart", options.scrollStart);
    }

    return newScroller;
}

function destoryScroller(scroller, isHideLoading) {
    if (scroller) {
        if (isHideLoading) {
            var $loading = $(scroller.wrapper).find(".loading");

            $loading.hide();
        }

        scroller.destroy();

        return null;
    }
}
// ============================ 滚动条 结束 ============================


// ============================ 链接等点击效果 结束 ============================
function bindClickEffectDefault() {
    var $elements = $("a, .clickable");
    var md = new MobileDetect(window.navigator.userAgent);

    // 如果不是android
    if (!md.is("AndroidOS")) {
        $elements.on("touchstart", function () {
            $(this).addClass("hover-effect");
        }).on("touchend", function (e) {
            $(this).removeClass("hover-effect");
        });
    }

    $elements.on("longTap", function () {
        $(this).removeClass("hover-effect");
    });
}

function bindClickEffect($parent, subSelector) {
    if (typeof ($parentSelector) == "string") {
        $parent = $(parentSelector);
    }

    $parent.on("click", subSelector, function () {
        $(this).addClass("hover-effect");
    });

    $parent.on("longTap", subSelector, function () {
        $(this).removeClass("hover-effect");
    });
}

// 删除点击效果
function removeClickEffect($item) {
    $item.removeClass("hover-effect");
}
// ============================ 链接等点击效果 结束 =========================

// ============================ 隐藏键盘 开始 =========================
function hideKeyboard() {
    var $hideKbTrigger = $(".menu li a, .hide-kb");

    $hideKbTrigger.each(function () {
        var $this = $(this);

        if ($this.is("a") && $this.attr("href")) {
            var href = $this.attr("href");

            $this.attr("href", "javascript:void(0)");
            $this.on("click", function (e) {
                setTimeout(function () {
                    if (window.parent == window) {
                        window.location.href = href;
                    }
                    else {
                        window.open(href, "_top");
                    }
                }, 80);
            });
        }
    });

    $hideKbTrigger.on("click", function (e) {
        var field = document.createElement('input');
        field.setAttribute('type', 'text');
        field.setAttribute('class', 'hide-kb-input');
        document.body.appendChild(field);

        setTimeout(function () {
            field.focus();
            setTimeout(function () {
                field.setAttribute('style', 'display:none;');
            }, 50);
        }, 50);
    });
}
// ============================ 隐藏键盘 结束 =========================

// ============================ 设置页面高度 开始 =========================
function setContentHeight() {
    var $body = $(".body-content");
    var $header = $body.children(".header");
    var $menu = $body.children(".menu");
    var $content = $body.children(".content-container")

    var bodyHeight = document.documentElement.offsetHeight;
    var contentHeight = bodyHeight;

    if ($header.length > 0) {
        contentHeight = contentHeight - $header.height();
    }

    if ($menu.length > 0) {
        contentHeight = contentHeight - $menu.height();
    }

    $content.height(contentHeight);
}
// ============================ 设置页面高度 结束 =========================

// ============================ 底部菜单处理 开始 =========================
function checkDocumentHeightChange() {
    var docHeight = window.document.documentElement.offsetHeight;

    setInterval(function () {
        var $menu = $(".body-content .menu");
        var $container = $(".body-content > .content-container");

        if (docHeight != window.document.documentElement.offsetHeight) {
            $menu.css({ position: "initial" });
            $container.data("data-padding-bottom", $container.css("padding-bottom"));
            $container.css("padding-bottom", 0);
        }
        else {
            var containerPaddingBottom = $container.data("data-padding-bottom");

            $(".body-content .menu").css({ position: "fixed" });
            $container.css("padding-bottom", containerPaddingBottom);
        }
    }, 100);
}
// ============================ 底部菜单处理 结束 =========================

// ============================ 加载状态 开始 =========================

function showSysLoading() {
    $("body > .content-loading").show();
}

function hideSysLoading() {
    $("body > .content-loading").hide();
}

function showSysModalLoading() {
    $("body > .modal-content-loading").show();
}

function hideSysModalLoading() {
    $("body > .modal-content-loading").fadeOut();
}

// ============================ 加载状态 结束 =========================

// ============================ Deparam 开始 =========================
// Section: Deparam (from string)
// 
// Method: jQuery.deparam
// 
// Deserialize a params string into an object, optionally coercing numbers,
// booleans, null and undefined values; this method is the counterpart to the
// internal jQuery.param method.
// 
// Usage:
// 
// > jQuery.deparam( params [, coerce ] );
// 
// Arguments:
// 
//  params - (String) A params string to be parsed.
//  coerce - (Boolean) If true, coerces any numbers or true, false, null, and
//    undefined to their actual value. Defaults to false if omitted.
// 
// Returns:
// 
//  (Object) An object representing the deserialized params string.

$.deparam = function (params, coerce) {
    var obj = {},
      coerce_types = { 'true': !0, 'false': !1, 'null': null },
      decode = decodeURIComponent;

    // Iterate over all name=value pairs.
    $.each(params.replace(/\+/g, ' ').split('&'), function (j, v) {
        var param = v.split('='),
          key = decode(param[0]),
          val,
          cur = obj,
          i = 0,

          // If key is more complex than 'foo', like 'a[]' or 'a[b][c]', split it
          // into its component parts.
          keys = key.split(']['),
          keys_last = keys.length - 1;

        // If the first keys part contains [ and the last ends with ], then []
        // are correctly balanced.
        if (/\[/.test(keys[0]) && /\]$/.test(keys[keys_last])) {
            // Remove the trailing ] from the last keys part.
            keys[keys_last] = keys[keys_last].replace(/\]$/, '');

            // Split first keys part into two parts on the [ and add them back onto
            // the beginning of the keys array.
            keys = keys.shift().split('[').concat(keys);

            keys_last = keys.length - 1;
        } else {
            // Basic 'foo' style key.
            keys_last = 0;
        }

        // Are we dealing with a name=value pair, or just a name?
        if (param.length === 2) {
            val = decode(param[1]);

            // Coerce values.
            if (coerce) {
                val = val && !isNaN(val) ? +val              // number
                  : val === 'undefined' ? undefined         // undefined
                  : coerce_types[val] !== undefined ? coerce_types[val] // true, false, null
                  : val;                                                // string
            }

            if (keys_last) {
                // Complex key, build deep object structure based on a few rules:
                // * The 'cur' pointer starts at the object top-level.
                // * [] = array push (n is set to array length), [n] = array if n is 
                //   numeric, otherwise object.
                // * If at the last keys part, set the value.
                // * For each keys part, if the current level is undefined create an
                //   object or array based on the type of the next keys part.
                // * Move the 'cur' pointer to the next level.
                // * Rinse & repeat.
                for (; i <= keys_last; i++) {
                    key = keys[i] === '' ? cur.length : keys[i];
                    cur = cur[key] = i < keys_last
                      ? cur[key] || (keys[i + 1] && isNaN(keys[i + 1]) ? {} : [])
                      : val;
                }

            } else {
                // Simple key, even simpler rules, since only scalars and shallow
                // arrays are allowed.

                if ($.isArray(obj[key])) {
                    // val is already an array, so push on the next value.
                    obj[key].push(val);

                } else if (obj[key] !== undefined) {
                    // val isn't an array, but since a second value has been specified,
                    // convert val into an array.
                    obj[key] = [obj[key], val];

                } else {
                    // val is a scalar.
                    obj[key] = val;
                }
            }

        } else if (key) {
            // No value was defined, so set something meaningful.
            obj[key] = coerce
              ? undefined
              : '';
        }
    });

    return obj;
};
// ============================ Deparam 结束 =========================

// ============================ 判断手机操作系统类型 开始 =========================
function isIOS() {
    var md = new MobileDetect(window.navigator.userAgent);

    return md.is("iOS");
}
// ============================ 判断手机操作系统类型 开始 =========================

// 初始化a发布需求提示下载app
function initPublishReqDownloadApp() {
    var $pop = $('.publish-req-download-app');

    $('.company-admin-publish-req, .only-use-in-app').on('click', function () {
        if ($(this).is('.only-use-in-app')) {
            $pop.addClass('only-use-in-app-pop');
        }

        $pop.css('display', 'block');
    });

    $('.close-limit', $pop).on('click', function () {
        $pop.removeClass('only-use-in-app-pop');
        $pop.css('display', 'none');
    });
}

$(function () {
    initPublishReqDownloadApp();
});


//显示认证中弹窗
function showAuthingMsg() {
    $("#modal_authing").css('display', 'block');
    $("#shade_authing").unbind("click").bind("click", function () {
        $("#modal_authing").css('display', 'none');
    });
    $("#btn_ok_authing").unbind("click").bind("click", function () {
        $("#modal_authing").css('display', 'none');
    }); 
}
