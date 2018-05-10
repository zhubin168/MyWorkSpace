!(function () {
    "use strict";

    var vm = new Vue({
        el: '#articleDetail',
        data: function () {
            return {
                articleId: jhbCore.getQueryString('id'),
                article: [],
                loadArticleCompleted: false
            }
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            this.loadArticle();
        },
        methods: {
            loadArticle: function () {
                var self = this;
                var api = jhbGlobal.jhbApi + '/article/GetArticleDetail';

                self.showLoading();
                this.httpPost(api, {
                    ArticleId: self.articleId
                }).then(function (res) {
                    self.loadArticleCompleted = true;

                    if (res.code) {
                        self.article = res.data;
                        document.title = self.article.Title;
                        jhbCore.setWxShare(self.article.Title, self.article.Summary);
                    }
                }).catch(function () {
                    self.loadArticleCompleted = true;
                });
            }
        }
    })
})();