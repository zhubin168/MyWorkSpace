(function (e) {
    if (void 0 == window.define) {
        var d = {},
            h = d.exports = {};
        e(null, h, d);
        window.floatNotify = window.notification = d.exports
    } else define(e)
})(function (require, exports, module) {
    function e(a) {
        this._options = d.extend({
            mode: "msg",
            text: "\u7f51\u9875\u63d0\u793a",
            useTap: !1,
            modal: !1,
            modalClass: void 0
        }, a || {});
        this._init()
    }
    var d = require ? require("zepto") : window.$,
        h = d(window),
        c = d('<div class="c-float-popWrap msgMode hide"><div class="c-float-modePop"><div class="warnMsg"></div><div class="content"></div><div class="doBtn"><button class="ok">\u786e\u5b9a</button><button class="cancel">\u53d6\u6d88</button></div></div>'),
        m = c.find(".warnMsg"),
        n = c.find(".content"),
        o = c.find(".doBtn .ok"),
        p = c.find(".doBtn .cancel"),
        j = !1,
        f,
        mark = d('<div class="c-float-modal hide"></div>')
    d.extend(e.prototype, {
        _init: function () {
            var a = this,
                b = a._options,
                g = b.mode,
                k = b.text,
                e = b.content,
                f = b.callback,
                l = b.background,
                modal = b.modal,
                modalClass = b.modalClass,
                iconClass = b.iconClass == void 0 ? modalClass : b.iconClass,
                b = b.useTap ? "tap" : "click",
                i = c.attr("class"),
                i = i.replace(/(msg|alert|confirm)Mode/i, g + "Mode");

            c.attr("class", i);
            modal && modalClass ? c.addClass(modalClass) : void 0;
            c.on("click", function (e) {
                f && (clearTimeout(f), f = void 0);
                a.hide();
            });
            modal ? mark.on("click", function (e) {
                f && (clearTimeout(f), f = void 0);
                a.hide();
            }) : void 0;
            l && c.css("background", l);
            var icon = modal ? '<div class="if-box"><i class="if if-' + iconClass + '"></i></div>' : void 0
            k && (modal ? k = icon + k : void 0, m.html(k));
            e && n.html(e);
            o.off(b).on(b, function (b) {
                f.call(a, b, !0)
            });
            p.off(b).on(b, function (b) {
                f.call(a, b, !1)
            });
            j || (j = !0, d(document.body).append(c), d(document.body).append(mark), h.on("resize",
                function () {
                    setTimeout(function () {
                        a._pos()
                    }, 500)
                }))
        },
        _pos: function () {
            var a = document,
                b = a.documentElement,
                g = a.body,
                e, d, f;
            this.isHide() || (a = g.scrollTop, g = g.scrollLeft, e = b.clientWidth, b = b.clientHeight, d = c.width(), f = c.height(), c.css({
                left: g + (e - d) / 2
            }), (this._options.modal ? c.css({ top: "20vh" }) : c.css({ top: (b - f) / 2 })))
        },
        isShow: function () {
            return c.hasClass("show")
        },
        isHide: function () {
            return c.hasClass("hide")
        },
        _cbShow: function () {
            var o = this._options;
            var a = o.onShow;
            c.css("opacity", "1").addClass("show");
            o.modal ? mark.css("opacity", "1").addClass("show") : void 0;
            a && a.call(this)
        },
        show: function () {
            var a = this;
            f && (clearTimeout(f), f =
                void 0);
            a.isShow() ? (a._cbShow(), a._pos()) : (c.css("opacity", "0").removeClass("hide"), (a._options.modal ? mark.css("opacity", "0").removeClass("hide") : void 0), a._pos(), setTimeout(function () {
                a._cbShow()
            }, 300), setTimeout(function () {
                c.animate({
                    opacity: "1"
                }, 300, "linear")
                a._options.modal ? mark.animate({
                    opacity: "1"
                }, 300, "linear") : void 0
            }, 1))
        },
        _cbHide: function () {
            var a = this._options.onHide;
            c.css("opacity", "0").addClass("hide");
            this._options.modal ? mark.css("opacity", "0").addClass("hide") : void 0;
            a && a.call(this, c)
        },
        hide: function () {
            var a = this;
            a.isHide() ? a._cbHide() : (c.css("opacity", "1").removeClass("show"), (a._options.modal ? mark.css("opacity", "1").removeClass("show") : void 0), setTimeout(function () {
                a._cbHide()
            }, 300), setTimeout(function () {
                c.animate({
                    opacity: "0"
                }, 300, "linear")
                a._options.modal ? c.animate({
                    opacity: "0"
                }, 300, "linear") : void 0
            }, 1))
        },
        flash: function (a) {
            var b =
                this;
            opt = b._options;
            opt.onShow = function () {
                f = setTimeout(function () {
                    f && b.hide()
                }, a)
            };
            b.show()
        }
    });
    module.exports = new function () {
        this.simple = function (a, b, c) {
            2 == arguments.length && "number" == typeof arguments[1] && (c = arguments[1], b = void 0);
            var d = new e({
                mode: "msg",
                text: a,
                background: b
            });
            d.flash(c || 2E3);
            return d
        };
        this.jhbmsg = function (text, content, icon, c) {
            var d = new e({
                mode: "msg",
                text: text,
                content: content,
                background: void 0,
                modal: true,
                modalClass: "jhb-float-msg",
                iconClass: icon,
                onHide: function ($popWrap) {
                    $popWrap.removeClass(this._options.modalClass);
                }
            });
            d.flash(c || 2E3);
            return d
        },
        this.jhbErrorMsg = function (text, content, c) {
            var d = new e({
                mode: "msg",
                text: text,
                content: content,
                background: void 0,
                modal: true,
                modalClass: "jhb-float-msg",
                iconClass: "cancel",
                onHide: function ($popWrap) {
                    $popWrap.removeClass(this._options.modalClass);
                }
            });
            d.flash(c || 2E3);
            return d
        },
        this.msg = function (a, b) {
            return new e(d.extend({
                mode: "msg",
                text: a
            }, b || {}))
        };
        this.alert = function (a, b, c) {
            return new e(d.extend({
                mode: "alert",
                text: a,
                callback: b
            }, c || {}))
        };
        this.confirm = function (a, b, c, f) {
            return new e(d.extend({
                mode: "confirm",
                text: a,
                content: b,
                callback: c
            }, f || {}))
        };
        this.pop = function (a) {
            return new e(a)
        }
    }
});