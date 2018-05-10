!(function () {
    "use strict";

    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                telMeetings: [],
                telMeetingPageIndex: 1,
                telMeetingWaypoint: null,
                telMeetingLoadComplete: false,
                pageSize: null
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            var self = this;
            var hasData = jhbDataStorage.init({
                getStorageData: function () {
                    return {
                        pageIndex: self.telMeetingPageIndex,
                        data: self.telMeetings
                    };
                },
                restoreStorageData: function (res) {
                    self.telMeetingPageIndex = res.pageIndex;
                    self.telMeetings = res.data;
                    self.$nextTick(function () {
                        self.scrollTo(res.scrollTop);
                        self.initTelMeetingWaypoint();
                    });
                }
            });

            !hasData && self.loadTelMeeting();
        },
        methods: {
            // 加载可回看活动
            loadTelMeeting: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/TelMeeting/ListTelMeeting';

                this.httpPost(url, {
                    type: this.type,
                    pageIndex: this.telMeetingPageIndex,
                    isForRecent: true
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.telMeetingWaypoint);

                    if (res.code && res.data && res.data.length > 0) {
                        self.pageSize = res.pageSize;
                        self.telMeetings = self.telMeetings.concat(res.data);
                        self.$nextTick(function () {
                            self.telMeetingPageIndex++;
                            self.initTelMeetingWaypoint();
                        })
                    }
                    else {
                        self.telMeetingLoadComplete = true;
                    }
                });
            },

            initTelMeetingWaypoint: function () {
                this.telMeetingWaypoint = jhbCore.initWaypoint(
                    document.getElementById('telMeetingList'),
                    this.loadTelMeeting
                )
            }
        }
    })
})();