!(function (searchConfig) {
    "use strict";

    var searchTypeConst = {
        ALL: 0,
        COMPANY: 1,
        ACTIVITY: 2,
        TEL_MEETING: 3,
        VIDEO_SURVEY: 4,
        ARTICLE: 5,
        PRIVATE_MEETING: 6
    };

    function getDefaultResult() {
        return {
            Units: [],
            HasMoreUnit: false,
            Activities: [],
            HasMoreActivity: false,
            TelMeetings: [],
            HasMoreTelMeeting: false,
            VideoSurveys: [],
            HasMoreVideoSurvey: false,
            Articles: [],
            HasMoreArticle: false,
            PrivateMeetings: [],
            HasMorePrivateMeeting: false,
        };
    }

    var app = new Vue({
        el: '#contentBody',
        data: function () {
            return {
                loading: null,
                searchTypeConst: searchTypeConst,
                type: searchConfig.type,
                keyWord: searchConfig.keyWord,
                pageIndex: 1,
                searchResult: getDefaultResult(),
                loadListComplete: false,
                contentWaypoint: null,
            }
        },
        computed: {
            hasUnit: function () {
                return this.searchResult.Units && this.searchResult.Units.length > 0;
            },
            hasActivity: function () {
                return this.searchResult.Activities && this.searchResult.Activities.length > 0;
            },
            hasTelMeeting: function () {
                return this.searchResult.TelMeetings && this.searchResult.TelMeetings.length > 0;
            },
            hasVideoSurvey: function () {
                return this.searchResult.VideoSurveys && this.searchResult.VideoSurveys.length > 0;
            },
            hasArticle: function () {
                return this.searchResult.Articles && this.searchResult.Articles.length > 0;
            },
            hasPrivateMeeting: function () {
                return this.searchResult.PrivateMeetings && this.searchResult.PrivateMeetings.length > 0;
            },
            isSearchAll: function () {
                return this.type === this.searchTypeConst.ALL;
            },
        },
        mixins: [jhbCore.vueMixin],
        created: function () {
            this.loadContent();
        },
        mounted: function () {
            this.setTabLocation();
        },
        methods: {
            // 设置tab位置
            setTabLocation: function () {
                var element = document.querySelector('.jhb__live_on');
                var scrollLeft = element.offsetLeft;

                document.querySelector('.search-tab').scrollLeft = scrollLeft - window.screen.width + element.offsetWidth;
            },
            // 格式化关键字显示
            formatKeyword: function (val) {
                var keyword = this.keyWord;

                if (!val) {
                    return null;
                }
                
                if (!keyword) {                    
                    return val;
                }

                var result = val.replace(keyword, '<span class="highlight">' + keyword + '</span>');

                return result;
            },
            submitForm: function (event) {
                if (!this.keyWord) {
                    this.toast('请输入搜索内容');
                }

                event.preventDefault();
                event.stopPropagation()
            },
            isTabActivity: function (tab) {
                return this.type === tab;
            },
            // 加载可回看活动
            loadContent: function () {
                var self = this;
                var url = jhbGlobal.jhbApi + '/search/search';

                if (!self.keyWord) {
                    return;
                }

                this.pageIndex === 1 && this.showLoading();
                this.httpPost(url, {
                    type: this.type,
                    pageIndex: this.pageIndex,
                    keyWord: this.keyWord
                }).then(function (res) {
                    jhbCore.destroyWaypoint(self.contentWaypoint);

                    if (res.code && res.data) {
                        var hasData = false;

                        switch (self.type) {
                            case self.searchTypeConst.ALL:
                                self.searchResult = res.data;
                                break;
                            case self.searchTypeConst.COMPANY:
                                hasData = res.data.Units && res.data.Units.length > 0;
                                if (hasData) {
                                    self.searchResult.Units = self.searchResult.Units.concat(res.data.Units);
                                }
                                break;
                            case self.searchTypeConst.ACTIVITY:
                                hasData = res.data.Activities && res.data.Activities.length > 0;
                                if (hasData) {
                                    self.searchResult.Activities = self.searchResult.Activities.concat(res.data.Activities);
                                }
                                break;
                            case self.searchTypeConst.TEL_MEETING:
                                hasData = res.data.TelMeetings && res.data.TelMeetings.length > 0;
                                if (hasData) {
                                    self.searchResult.TelMeetings = self.searchResult.TelMeetings.concat(res.data.TelMeetings);
                                }
                                break;
                            case self.searchTypeConst.VIDEO_SURVEY:
                                hasData = res.data.VideoSurveys && res.data.VideoSurveys.length > 0;
                                if (hasData) {
                                    self.searchResult.VideoSurveys = self.searchResult.VideoSurveys.concat(res.data.VideoSurveys);
                                }
                                break;
                            case self.searchTypeConst.ARTICLE:
                                hasData = res.data.Articles && res.data.Articles.length > 0;
                                if (hasData) {
                                    self.searchResult.Articles = self.searchResult.Articles.concat(res.data.Articles);
                                }
                                break;
                            case self.searchTypeConst.PRIVATE_MEETING:
                                hasData = res.data.PrivateMeetings && res.data.PrivateMeetings.length > 0;
                                if (hasData) {
                                    self.searchResult.PrivateMeetings = self.searchResult.PrivateMeetings.concat(res.data.PrivateMeetings);
                                }
                                break;
                        }

                        if (!self.isSearchAll) {
                            if (hasData) {
                                self.$nextTick(function () {
                                    self.pageIndex++;
                                    self.initContentWaypoint();
                                });
                            }
                            else {
                                self.loadListComplete = true;
                            }
                        }
                    }
                    else {
                        self.loadListComplete = true;
                    }
                });
            },

            initContentWaypoint: function () {
                this.contentWaypoint = jhbCore.initWaypoint(
                    document.getElementById('searchResultBox'),
                    this.loadContent
                )
            },

            doSearch: function (type) {
                this.pageIndex = 1;
                this.type = type;
                this.searchResult = getDefaultResult();
                this.loadContent();
                this.replaceHistory();
            },

            // 按回车键执行搜索
            keyWordChange: function (event) {
                if (event.keyCode === 13) {
                    this.pageIndex = 1;
                    this.searchResult = getDefaultResult();
                    this.loadContent();
                    this.replaceHistory();
                }
            },

            // 替换历史记录
            replaceHistory: function () {
                var url = searchConfig.url + '?type=' + this.type + '&keyWord=' + this.keyWord;

                history.replaceState(null, '搜索', url);
            },

            // 取消搜索
            cancelSearch: function () {
                // 如果后退页面为search/search，执行history.go(-2)
                if (document.referrer
                    && document.referrer.toLowerCase().indexOf('search/search') > -1) {
                    window.history.go(-2);
                }
                else {
                    window.history.go(-1);
                }
            }
        }
    })
})(searchConfig);