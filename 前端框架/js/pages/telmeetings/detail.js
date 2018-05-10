!(function () {
    "use strict";

    var vm = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                telMeetingId: jhbCore.getQueryString('id'),
                telMeeting: {},
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            this.loadTelMeeting();
        },
        methods: {
            // 加载电话会议详情
            loadTelMeeting: function () {
                var self = this;
                var api = jhbGlobal.jhbApi + '/telMeeting/TelMeetingDetail';

                self.showLoading();
                this.httpPost(api, {
                    TelMeetingId: self.telMeetingId
                }).then(function (res) {
                    if (res.code) {
                        self.telMeeting = res.data;
                        self.telMeeting && (document.title = self.telMeeting.Title);
                    }
                });
            },

            // 报名
            apply: function () {
                var self = this;
                var api = jhbGlobal.jhbApi + '/telmeeting/apply';

                this.httpPost(api, {
                    TelMeetingId: self.telMeetingId
                }).then(function (res) {
                    if (res.code) {
                        var content = '会议时间到达请按照以下信息进行拨号参会：参会号码' + res.data.Phone;

                        if (res.data.Room) {
                            content += '，会议室号' + res.data.Room;
                        }

                        content += '，密码' + res.data.Password;
                        weui.alert(
                            content,
                            {
                                title: '报名成功',
                                buttons: [{
                                    label: '知道了',
                                    type: 'primary',
                                }]
                            });

                        self.telMeeting.IsEverJoined = true;
                        self.telMeeting.Phone = res.data.Phone;
                        self.telMeeting.Password = res.data.Password;
                        self.telMeeting.Room = res.data.Room;
                    }
                    else {
                        weui.alert(
                            res.msg,
                            {
                                title: '报名失败',
                                buttons: [{
                                    label: '知道了',
                                    type: 'primary',
                                }]
                            });
                    }
                });


            }
        }
    })
})();