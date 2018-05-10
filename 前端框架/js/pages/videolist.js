!(function () {
    "use strict";

    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                videos: [],
                videoPageIndex: 1,
                videoWaypoint: null,
                videoLoadComplete: false
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            var self = this;
            var hasData = jhbDataStorage.init({
                getStorageData: function () {
                    return {
                        pageIndex: self.videoPageIndex,
                        data: self.videos
                    };
                },
                restoreStorageData: function (res) {
                    self.videoPageIndex = res.pageIndex;
                    self.videos = res.data;
                    self.$nextTick(function () {
                        self.scrollTo(res.scrollTop);
                        self.initVideoWaypoint();
                    });
                }
            });

            !hasData && self.loadvideo();
        },
        methods: {
            // 加载可回看活动
            loadvideo: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + videoListConfig.dataApi;

                this.httpPost(url, {
                    type: this.type,
                    pageIndex: this.videoPageIndex
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.videoWaypoint);

                    if (res.code && res.data && res.data.length > 0) {
                        self.videos = self.videos.concat(res.data);
                        self.$nextTick(function () {
                            self.videoPageIndex++;
                            self.initVideoWaypoint();
                        })
                    }
                    else {
                        self.videoLoadComplete = true;
                    }
                });
            },
            
            initVideoWaypoint: function () {
                this.videoWaypoint = jhbCore.initWaypoint(
                    document.getElementById('videoList'),
                    this.loadvideo
                )
            }
        }
    })
})();