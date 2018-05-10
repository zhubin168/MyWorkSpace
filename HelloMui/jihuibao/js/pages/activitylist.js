!(function () {
    "use strict";

    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                activities: [],
                activityPageIndex: 1,
                activityWaypoint: null,
                activityLoadComplete: false,
                type: activityListConfig.type
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            var self = this;
            var hasData = jhbDataStorage.init({
                getStorageData: function () {                    
                    return {                        
                        pageIndex: self.activityPageIndex,
                        data: self.activities
                    };
                },
                restoreStorageData: function (res) {                    
                    self.activityPageIndex = res.pageIndex;
                    self.activities = res.data;
                    self.$nextTick(function () {
                        self.scrollTo(res.scrollTop);
                        self.initActivityWaypoint();
                    });
                }
            });
            
            !hasData && this.loadActivity();
        },
        methods: {
            // 加载可回看活动
            loadActivity: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/Activity/ListActivity';

                this.httpPost(url, {
                    type: this.type,
                    pageIndex: this.activityPageIndex
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.activityWaypoint);

                    if (res.code && res.data && res.data.length > 0) {
                        if (self.activityPageIndex === 1) {
                            self.activities = res.data;
                        }
                        else {
                            self.activities = self.activities.concat(res.data);
                        }
                        self.$nextTick(function () {
                            self.activityPageIndex++;
                            self.initActivityWaypoint();
                        })
                    }
                    else {
                        self.activityLoadComplete = true;
                    }
                });
            },          

            initActivityWaypoint: function () {
                this.activityWaypoint = jhbCore.initWaypoint(
                    document.getElementById('activityList'),
                    this.loadActivity
                )
            },

            changeType: function (type) {
                this.type = type;
                this.activityPageIndex = 1;
                this.loadActivity();
                window.localStorage.setItem(activityListConfig.typeKey, type);
            }
        }
    })
})();