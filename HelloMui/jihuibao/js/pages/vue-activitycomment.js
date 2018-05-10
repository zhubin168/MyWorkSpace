(function ($) {
    "use strict";

    Vue.component('activity-comment', {
        props: {
            commentUser: {
                type: Object,
                default: function () {
                    return {
                        Logo: null,
                        IsInsti: false
                    }
                }
            }, 
            activityId: Number,
            activityType: Number,
            autoLoadComment: Boolean,
            autoCheckNewComment: Boolean,
        },
        data: function () {
            return {
                comments: [],
                pageIndex: 1,
                enableCommentSubmit: false,
                enableReplayInputBox: false,
                isAnonymous: false,
                isReplyAnonymous: false,
                commentContent: null,
                commentParrent: null,
                replyContent: null,
                commentLoadComplete: false,
                isShowMore: false,
                lastLoadCommentTime: null,
            }
        },
        mixins: [jhbCore.vueMixin],
        template: '\
<div class="comment">\
    <div v-bind:class="[\'tw-k\', comments && comments.length > 0 ? \'\' : \'tw-nok\']">\
        <table>\
            <tr>\
                <td class="tx-li" valign="top"><img v-bind:src="getImg(commentUser.Logo, \'http://www.jhbshow.com/imgs/head/headdef11.jpeg\')" class="img-user" /></td>\
                <td class="text-area" valign="top">\
                    <div class="tw-focus" >\
                        <div class="ly-tarea" id="commentArea">\
                            <textarea v-bind:class="[!enableCommentSubmit ? \'text-arealy\' : null]" placeholder="快来说说你的想法" ref="commentInput" v-on:focus="doEnableCommentSubmit" v-model="commentContent" v-on:blur="emitInputBlur"></textarea>\
                        </div>\
                        <div class="btn-all" v-show="enableCommentSubmit">\
                            <span class="nim-left" v-if="commentUser.IsInsti" v-on:click="toggleAnonymous"><i v-bind:class="[\'iconfont\', isAnonymous ? \'icon-gouxuankuang\' : \'icon-weigouxuanccc\']"></i>匿名</span>\
                            <div class="btn-group">\
                                <button class="qx" v-on:click="doDisableCommentSubmit">取消</button>\
                                <button class="pose" v-on:click="rootComment">发送</button>\
                            </div>\
                        </div>\
                    </div>\
                </td>\
            </tr>\
        </table>\
    </div>\
    \
    <div class="ly-li">\
        <table>\
            <tbody>\
                <tr v-for="comment in comments">\
                    <td class="tx-li" valign="top"><img v-bind:src="getImg(comment.CreatorImage)" v-on:error="imgLoadError" class="img-user"></td>\
                    <td class="hf-li">\
                        <!--留言展示带头像-->\
                        <div class="ly-zs">\
                            <div class="ly-name">{{comment.CreatorName}}</div>\
                            <div class="ly-info">\
                                {{comment.Content}}\
                            </div>\
                            <div class="ly-time"><span>{{formatJhbDate(comment.CreateTime)}}</span><span class="ly-hfright" v-on:click="toggleReplyInputBox($event, comment)">回复</span></div>\
                        </div>\
                        <!--留言回复展示-->\
                        <div class="lyhf-zs" v-for="reply in comment.ReplyList">\
                            <div class="ly-name"><span class="lyhf-gsname">{{reply.CreatorName}}</span><span class="hf-greg">回复:</span><span class="hf-time">{{formatJhbDate(reply.CreateTime)}}</span></div>\
                            <div class="ly-info">\
                                {{reply.Content}}\
                            </div>\
                        </div>\
                    </td>\
                </tr>\
            </tbody>\
        </table>\
    </div>\
    <div class="more">\
        <a class="more-a" v-show="isShowMore" v-on:click="loadMore">{{commentLoadComplete ? "没有更多了！" : "点击查看更多"}}</a>\
    </div>\
    <div class="ly-zs lyhf-input" ref="replyInputBox" v-show="enableReplayInputBox">\
        <div class="ly-name"><span class="lyhf-gsname">我</span><span class="hf-greg">回复:</span></div>\
        <div class="ly-tarea">\
            <textarea placeholder="快来说说你的想法" v-model="replyContent" v-on:focus="emitInputFoucs" v-on:blur="emitInputBlur"></textarea>\
        </div>\
        <div class="btn-all">\
            <span class="nim-left" v-if="commentUser.IsInsti" v-on:click="toggleReplyAnonymous"><i v-bind:class="[\'iconfont\', isReplyAnonymous ? \'icon-gouxuankuang\' : \'icon-weigouxuanccc\']"></i>匿名</span>\
            <div class="btn-group">\
               <button class="qx" v-on:click="closeReplyInputBox">取消</button>\
                <button class="pose" v-on:click="replyComment">发送</button>\
            </div>\
        </div>\
    </div>\
</div>\
        ',        
        created: function () {
            var vm = this;
            this.autoLoadComment && this.loadComment();

            if (this.autoCheckNewComment) {
                setInterval(function () {
                    vm.checkHasNewComment();
                }, 60000);
            }
        },
        methods: {
            // 启用评论提交
            doEnableCommentSubmit: function () {
                this.enableCommentSubmit = true;
                this.emitInputFoucs();
            },
            // 禁用评论提交
            doDisableCommentSubmit: function () {
                this.enableCommentSubmit = false;
            },   
            // 获取评论
            loadComment: function (reload) {
                var self = this;
                var api = jhbGlobal.jhbApi + '/activity/listactivitycomment';

                reload && (self.pageIndex = 1);
                self.lastLoadCommentTime = new Date();
                self.httpPost(api, {
                    activityId: self.activityId,
                    type: self.activityType,
                    pageIndex: self.pageIndex
                }).then(function (res) {
                    if (res.code && res.data && res.data.length > 0) {                        
                        var isFirstPage = self.pageIndex === 1;
                        
                        self.comments = isFirstPage ? res.data : self.comments.concat(res.data);

                        if (res.data.length < res.pageSize) {
                            self.isShowMore = !isFirstPage;
                            self.commentLoadComplete = true;
                        }
                        else {
                            self.isShowMore = true;
                            self.commentLoadComplete = false;
                        }
                    }
                    else {
                        self.commentLoadComplete = true;
                    }
                });
            },
            // 切换评论匿名
            toggleAnonymous: function () {
                this.isAnonymous = !this.isAnonymous;
            },
            // 切换回复匿名
            toggleReplyAnonymous: function () {
                this.isReplyAnonymous = !this.isReplyAnonymous;
            },
            // 显示回复输入框
            toggleReplyInputBox: function (event, parrentComment) {
                $(this.$refs.replyInputBox).insertAfter($(event.target).parents('.ly-zs'));
                this.enableReplayInputBox = true;
                this.commentParrent = parrentComment;
            },
            // 关闭回复输入框
            closeReplyInputBox: function(){
                this.enableReplayInputBox = false;
            },
            // 评论
            rootComment: function () {
                var self = this;
                var comment = {
                    parentCommentId: 0,
                    postText: this.commentContent,
                    isAnonymous: this.isAnonymous
                };

                this.doComment(comment, function (data) {
                    self.enableCommentSubmit = false;
                    self.commentContent = null;
                    self.comments.splice(0, 0, {
                        Id: data.QadetailId,
                        CreatorName: data.CreatorName,
                        CreatorImage: data.CreatorHeaderImage,
                        CreateTime: data.DateCreated,
                        Content: data.PostText
                    });
                });
            },
            // 回复
            replyComment: function () {
                var self = this;
                var comment = {
                    parentCommentId: this.commentParrent.Id,
                    postText: this.replyContent,
                    isAnonymous: this.isReplyAnonymous
                };

                this.doComment(comment, function (data) {
                    if (!self.commentParrent.ReplyList) {
                        self.commentParrent.ReplyList = [];
                    }

                    self.commentParrent.ReplyList.splice(0, 0, {
                        Id: data.QadetailId,
                        CreatorName: data.CreatorName,
                        CreatorImage: data.CreatorHeaderImage,
                        CreateTime: data.DateCreated,
                        Content: data.PostText
                    });
                    self.replyContent = null;
                    self.enableReplayInputBox = false;
                });
            },
            // 提交评论
            doComment: function (newComment, callback) {
                var self = this;
                var api = jhbGlobal.jhbApi + '/activity/createcomment';

                if (!newComment.postText) {
                    weui.alert('请输入内容');
                    return false;
                }
                self.showLoading();
                this.httpPost(api, {
                    type: self.activityType,
                    mainId: self.activityId,
                    parentCommentId: newComment.parentCommentId,
                    postText: newComment.postText,
                    isAnonymous: newComment.isAnonymous,
                }).then(function (res) {
                    if (res.code) {
                        weui.toast('提交成功', 1000);

                        callback && callback(res.data);
                    }
                });
            },
            focusComment: function () {
                this.$refs.commentInput.focus();
            },

            // 加载更多评论
            loadMore: function () {
                if (this.commentLoadComplete) {
                    return;
                }

                this.pageIndex++;

                this.loadComment();
            },

            /**
             *  检查是否有新评论
             */
            checkHasNewComment: function () {
                var vm = this;
                var api = jhbGlobal.jhbApi + '/activity/hasNewComment';

                vm.httpPost(api, {
                    RelateId: vm.activityId,
                }).then(function (res) {
                    if (res.code && res.data) {
                        vm.$emit('newcomment');
                    }
                });
            },

            /**
             * 触发评论框或回复框获得焦点事件
             */
            emitInputFoucs: function () {
                console.log('commentfocus');
                this.$emit('commentfocus');
            },

            /**
             * 触发评论框或回复框获得焦点事件
             */
            emitInputBlur: function () {
                console.log('commentblur');
                this.$emit('commentblur');
            }
        }
    })
})(Zepto);