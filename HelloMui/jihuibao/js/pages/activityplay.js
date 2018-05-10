!(function ($) {
    "use strict";

    var activityStateConst = {
        Live: 1
    };

    var app = new Vue({
        el: '#playContent',
        data: function () {
            return {
                activityStateConst: activityStateConst,
                activityId: jhbActivityPlayConfig.id,
                activityType: jhbActivityPlayConfig.activityType,
                activity: {
                    Unit: {}
                },
                loadActivityComplete: false,
                unitOpen: false,
                unitDetail: {},
                isCommentLoad: false,
                hasNewComment: false,
                isCommentInputFocus: false,
            }
        },        
        mixins: [jhbCore.vueMixin],
        created: function () {            
            this.loadActivity();
        },
        mounted: function () {
            this.initTab();
        },
        methods: {
            // 加载可回看活动
            loadActivity: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/activity/play';

                this.showLoading();
                this.httpPost(url, {
                    activityId: self.activityId,
                    type: self.activityType
                }).then(function (res) {
                    self.loadActivityComplete = true;

                    if (res.code && res.data) {
                        self.activity = res.data;                        
                    }                    
                });
            },   

            initTab: function () {
                var self = this;
                weui.tab('#playTab', {
                    defaultIndex: 0,
                    onChange: function (index) {
                        if (!self.isCommentLoad && index === 1) {
                            self.isCommentLoad = true;
                            self.$refs.comment.loadComment();
                        }
                    }
                });
            },

            // 加载评论
            reloadComment: function () {                
                this.$refs.comment.loadComment(true);
                this.hasNewComment = false;
            },

            // 处理有新评论
            handleHasNewComment: function() {
                this.hasNewComment = true;
            },   

            handleCommentFocus: function () {
                this.isCommentInputFocus = true;
            },

            handleCommentBlur: function () {
                this.isCommentInputFocus = false;
            },
        }
    })
})(Zepto);