!(function () {
    "use strict";

    jhbCore.setWxShare('机会宝·深度解读列表', '每日股市热点问题深度解读，追求独立、独到的观点，理性与逻辑贯穿、温度与深度交织。')
    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                articles: [],
                articlePageIndex: 1,
                articleWaypoint: null,
                articleLoadComplete: false
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            var self = this;
            var hasData = jhbDataStorage.init({
                getStorageData: function () {
                    return {
                        pageIndex: self.articlePageIndex,
                        data: self.articles
                    };
                },
                restoreStorageData: function (res) {
                    self.articlePageIndex = res.pageIndex;
                    self.articles = res.data;
                    self.$nextTick(function () {
                        self.scrollTo(res.scrollTop);
                        self.initArticleWaypoint();
                    });
                }
            });

            !hasData && self.loadArticle();
        },
        methods: {
            // 加载可回看活动
            loadArticle: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/Article/ListArticle';

                this.httpPost(url, {
                    type: this.type,
                    pageIndex: this.articlePageIndex
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.articleWaypoint);

                    if (res.code && res.data && res.data.length > 0) {
                        self.articles = self.articles.concat(res.data);
                        self.$nextTick(function () {
                            self.articlePageIndex++;
                            self.initArticleWaypoint();
                        })
                    }
                    else {
                        self.articleLoadComplete = true;
                    }
                });
            },

            initArticleWaypoint: function () {
                this.articleWaypoint = jhbCore.initWaypoint(
                    document.getElementById('articleList'),
                    this.loadArticle
                )
            }
        }
    })
})();