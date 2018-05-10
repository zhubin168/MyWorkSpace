!(function () {
    "use strict";

    const activityStateConst = {
        Reserve: 2,
        Pending: 3,
        Live: 4,
        Replay: 5,
        Convening: 6
    };
    var joinWayConst = {
        Online: 1,
        OnlineOffline: 2,
        Offline: 3
    };
    
    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                activityStateConst: activityStateConst,
                joinWayConst: joinWayConst,
                activityId: jhbActivityDetailConfig.id,
                activityType: jhbActivityDetailConfig.activityType,
                activity: {
                    IsActivity: true,
                    Unit: {}
                },
                loadActivityComplete: false,
                joinWayOpen: false,
                selectedJoinWay: null,
                unitOpen: false,
                unitDetail: {},
                enableSubmit: false,
                isCommentInputFocus: false,
            }
        },
        computed: {
            isOnlineOffline: function () {
                return this.activity.Way === this.joinWayConst.OnlineOffline;
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            this.loadActivity();
        },
        methods: {
            // 加载可回看活动
            loadActivity: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/activity/activitydetail';

                this.showLoading();
                this.httpPost(url, {
                    activityId: self.activityId,
                    type: self.activityType
                }).then(function (res) {
                    self.loadActivityComplete = true;

                    if (res.code && res.data) {
                        self.activity = res.data;
                        document.title = res.data.Title;
                        self.initSelectedJoinWay();                       
                    }
                });
            },

            initSelectedJoinWay: function () {
                if (this.activity && !this.activity.JoinWay) {
                    if (!this.isOnlineOffline) {
                        this.selectedJoinWay = this.activity.Way;
                    }
                }
            },

            // 预约
            reserve: function () {
                if (this.isOnlineOffline) {
                    this.openReserveWayChoose();
                }
                else {
                    this.doReserve();
                }
            },

            doReserve: function (callback) {
                var self = this;

                this.httpPost(jhbGlobal.jhbApi + '/activity/apply', {
                    activityId: self.activityId,
                    activityType: self.activityType,
                    way: self.selectedJoinWay,
                    isEverJoined: self.activity.IsEverJoined
                }).then(function (res) {
                    if (res.code) {
                        self.activity.JoinWay = self.selectedJoinWay;

                        if (!self.activity.IsEverJoined) {
                            self.activity.IsEverJoined = true;
                            weui.alert(
                                '请按时参会，如果您不方便参会可以自行取消预约',
                                {
                                    title: '预约成功',
                                    buttons: [{
                                        label: '知道了',
                                        type: 'primary',
                                    }]
                                });
                        }
                        else {
                            weui.toast('修改成功', 1000);
                        }
                    }
                    else {
                        weui.alert(
                            res.msg,
                            {
                                title: '预约失败',
                                buttons: [{
                                    label: '知道了',
                                    type: 'primary',
                                }]
                            });
                    }

                    callback && callback(res);
                });
            },

            // 取消预约
            cacelReserve: function () {
                var self = this;

                // 线上、线下会议取消预约
                if (self.isOnlineOffline) {
                    var isOnline = this.activity.JoinWay === this.joinWayConst.Online;
                    var labelName = isOnline ? '线下' : '线上';
                    var pop = weui.alert(
                        '您还可以更改参会方式',
                        {
                            title: '是否确定取消',
                            buttons: [{
                                label: '改为' + labelName,
                                type: 'default',
                                onClick: function () {
                                    self.selectedJoinWay = isOnline ? self.joinWayConst.Offline : self.joinWayConst.Online;
                                    self.doReserve(function () {
                                        pop.hide();
                                    });
                                    return false;
                                }
                            }, {
                                label: '确定取消',
                                type: 'primary',
                                onClick: function () {
                                    self.doCancelReserve(function () {
                                        pop.hide();
                                    });
                                }
                            }]
                        });
                }
                else { // 线上或线下会议取消预约
                    var pop = weui.alert(
                        '取消后可重新预约',
                        {
                            title: '是否确定取消',
                            buttons: [{
                                label: '暂不取消',
                                type: 'default',
                            }, {
                                label: '确定取消',
                                type: 'primary',
                                onClick: function () {
                                    self.doCancelReserve(function () {
                                        pop.hide();
                                    });
                                }
                            }]
                        });
                }
            },

            // 请求取消预约
            doCancelReserve: function (callback) {
                var self = this;

                this.httpPost(jhbGlobal.jhbApi + '/activity/cancelapply', {
                    activityId: self.activityId,
                    activityType: self.activityType
                }).then(function (res) {
                    if (res.code) {
                        self.activity.IsEverJoined = false;
                        self.activity.JoinWay = null;

                        if (self.isOnlineOffline) {
                            self.selectedJoinWay = null;
                        }

                        weui.toast('取消成功', 1000);

                        callback && callback();
                    }
                    else {
                        weui.alert(
                            res.msg,
                            {
                                title: '取消预约失败',
                                buttons: [{
                                    label: '知道了',
                                    type: 'primary',
                                }]
                            });
                    }
                });
                return false;
            },

            // 选择参会方式
            changeReserveWay: function (way) {
                this.selectedJoinWay = way;
                this.enableSubmit = true;
            },

            openReserveWayChoose: function () {
                this.joinWayOpen = true;
            },

            confirmReserve: function () {
                if (!this.selectedJoinWay) {
                    weui.alert(
                        '需要您选择线上或线下参会',
                        {
                            title: '请选择参会形式',
                            buttons: [{
                                label: '确定',
                                type: 'primary',
                            }]
                        });
                    return false;
                }

                this.doReserve(this.closeReserveWayChoose);
            },

            closeReserveWayChoose: function () {
                this.joinWayOpen = false;
            },

            // 查看公司详情
            viewCompanyDetail: function (id) {
                var self = this;
                var url = jhbGlobal.jhbApi + '/unit/getunitdetail';

                this.httpPost(url, {
                    unitId: id
                }).then(function (res) {
                    if (res.code && res.data) {
                        self.unitDetail = res.data;
                        self.unitOpen = true;
                    }
                })
            },

            hideCompanyDetail: function () {
                this.unitOpen = false;
            },

            toComment: function () {
                this.$refs.comment.focusComment();
            },

            // 参会
            viewActivity: function (type, id, state) {
                var vm = this;
                vm.httpPost(jhbGlobal.jhbApi + '/auth/checkactivityviewauth', {
                    activityId: id,
                    activityType: type
                }).then(function (res) {
                    if (res.code) {
                        var url = vm.getViewUrl(type, id, state);

                        window.location.href = url;
                    }
                });
            },

            handleCommentFocus: function () {
                this.isCommentInputFocus = true;
            },

            handleCommentBlur() {
                this.isCommentInputFocus = false;
            },
        }
    })
})();