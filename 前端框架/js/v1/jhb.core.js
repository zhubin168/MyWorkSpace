(function () {
    function Jhb() {
        this.currentIndex = 1;
        this.waypoint= null;
        this.loadListXhr = null;
    }

    $.extend(Jhb.prototype, {
        getList: function (url, callback) {
            var self = this;

            if (this.loadListXhr) {
                this.loadListXhr.abort();
            }

            // 第一页显示加载提示
            if (this.currentIndex == 1) {
                window.showSysLoading();
            }

            this.loadListXhr = $.ajax({
                url: url,
                type: 'POST',
                dataType: 'json',
                cache: false,
                data: {
                    pageIndex: this.currentIndex,
                },
                success: function (data) {
                    window.hideSysLoading();
                    self.hideListContinueLoading();
                    self.loadListXhr = null;

                    if (!data.IsSuccess) {
                        window.floatNotify.simple(data.Message);
                        return;
                    }

                    if (typeof (callback) != 'undefined') {
                        callback(data);
                    }
                },
                error: function () {
                    window.hideSysLoading();
                    self.hideListContinueLoading();
                }
            });
        },

        initWaypoint: function (isDestory, loadData, element, context, offset) {
            if (this.waypoint) {
                this.waypoint.destroy();

                if (isDestory) {
                    return;
                }
            }

            var self = this;

            context = typeof (context) == 'undefined' ? window : context;
            offset = typeof (offset) == 'undefined' ? 'bottom-in-view' : offset;

            this.waypoint = new Waypoint({
                element: element,
                context: context,
                offset: offset,
                handler: function (direction) {
                    jhb.currentIndex++;
                    loadData();
                }
            });
        },

        showListContinueLoading: function (container) {
            var $listLoading = $('.list-continue-loading');

            if ($listLoading.length > 0) {
                $listLoading.remove();
            }

            $listLoading = $('<div class="list-continue-loading"><div class="spin-box"><div class="la-line-scale-pulse-out la-2x"> <div></div> <div></div> <div></div> <div></div> <div></div> </div></div></div>');

            $(container).append($listLoading);
        },

        hideListContinueLoading: function () {
            var $listLoading = $('.list-continue-loading');

           $listLoading.remove();
        },

        // 移动动画
        translateX: function ($obj, translateXVal) {
            // 切换标签显示内容
            $obj.css('-webkit-transform', 'translateX(-' + (translateXVal) + 'px)');
            $obj.css('transform', 'translateX(-' + (translateXVal) + 'px)');
        },
        // ajax请求
        ajaxRequest: function (url, data, successCallback, errorCallback, ajaxError) {
            var self = this;

            if (appRoot
                && url
                && url.length > 1
                && url.substring(0, 1) == '/') {
                url = appRoot + url;
            }

            var options = {
                url: url,
                type: 'POST',
                data: data,
                cache: false,
                dataType: 'json',
                success: function (data) {
                    self.ajaxSuccess(data, successCallback, errorCallback);
                }
            };

            ajaxError && (options.error = ajaxError);

            $.ajax(options);
        },
        // ajax请求成功处理
        ajaxSuccess: function (data, successCallback, errorCallback) {
            // 错误处理
            if (data.IsSuccess) {
                data.Message && (floatNotify.pop(this.splitMessage(data.Message, 0), this.splitMessage(data.Message, 1)));
                successCallback && successCallback(data);
            }
            else {
                data.Message && (floatNotify.jhbErrorMsg(this.splitMessage(data.Message, 0), this.splitMessage(data.Message, 1), 5000));
                errorCallback && errorCallback(data);
            }
        },
        // 刷新
        reflesh: function () {
            window.location.href = window.location.href;
        },
        back: function () {
            window.history.go(-1);
        },
        splitMessage: function (msg, index) {
            var msgs = msg.split(/,|，/);

            if (index === 0) {
                return msgs[index];
            }
            else {
                if (msgs.length === 1) {
                    return null;
                }

                msgs.shift();

                return msgs.join('，');
            }
        }
    });

    window.jhb = new Jhb();
})();
