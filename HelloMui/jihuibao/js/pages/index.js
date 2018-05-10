!(function () {
    "use strict";

    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                replayActivities: [],
                replayActivityPageIndex: 1,
                replayActivityWaypoint: null,
                replayActivityLoadComplete: false,
                hideReserve: false,
                jhbDataStorage: jhbDataStorage
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            var self = this;            
            var hasData = jhbDataStorage.init({
                getStorageData: function () {
                    return {
                        pageIndex: self.replayActivityPageIndex,
                        data: self.replayActivities
                    };
                },
                restoreStorageData: function (res) {
                    self.replayActivities = res.data;
                    self.replayActivityPageIndex = res.pageIndex;
                    self.$nextTick(function () {
                        self.scrollTo(res.scrollTop);
                        self.initreplayActivityWaypoint();
                    });
                }
            });

            !hasData && self.loadReplayActivity();            
        },
        mounted: function () {
            var swiper = new Swiper('.swiper-container', {
                loop: true,
                pagination: {
                    el: '.swiper-pagination'
                },
                paginationClickable: true,
                spaceBetween: 30,
                autoplay: 3000,
                spaceBetween: 0
            });
        }, // end of mounted
        computed: {
            isShowReserve: function () {
                if (this.hideReserve) {
                    return false;
                }

                return window.sessionStorage.getItem('hide-index-my-reserve') !== '1';
            }
        }, // end of computed
        methods: {
            // 加载可回看活动
            loadReplayActivity: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/Activity/ListReplayActivity';

                this.httpPost(url, {
                    pageIndex: this.replayActivityPageIndex
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.replayActivityWaypoint);

                    if (res.code && res.data && res.data.length > 0) {
                        self.replayActivities = self.replayActivities.concat(res.data);
                        self.$nextTick(function () {
                            self.replayActivityPageIndex++;
                            self.initreplayActivityWaypoint();
                        });
                    }
                    else {
                        self.replayActivityLoadComplete = true;
                    }
                });
            },

            initreplayActivityWaypoint: function () {
                this.replayActivityWaypoint = jhbCore.initWaypoint(
                    document.getElementById('indexactlist'),
                    this.loadReplayActivity
                )
            },

            doHideReserve: function () {
                this.hideReserve = true;
                window.sessionStorage.setItem('hide-index-my-reserve', '1');
            }
        } // end of methods
    }); // end of var app = new Vue({
})();