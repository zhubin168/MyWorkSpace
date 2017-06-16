﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>活动表</summary>
    [Serializable]
    [DataObject]
    [Description("活动表")]
    [BindIndex("PK_Banner", true, "id")]
    [BindTable("Banner", Description = "活动表", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Banner : IBanner
    {
        #region 属性
        private Int64 _id;
        /// <summary>活动页ID</summary>
        [DisplayName("活动页ID")]
        [Description("活动页ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "id", "活动页ID", null, "bigint", 19, 0, false)]
        public virtual Int64 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _title;
        /// <summary>活动页标题</summary>
        [DisplayName("活动页标题")]
        [Description("活动页标题")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "title", "活动页标题", null, "varchar(50)", 0, 0, false)]
        public virtual String title
        {
            get { return _title; }
            set { if (OnPropertyChanging(__.title, value)) { _title = value; OnPropertyChanged(__.title); } }
        }

        private String _imageUrl;
        /// <summary>活动页图片地址</summary>
        [DisplayName("活动页图片地址")]
        [Description("活动页图片地址")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(3, "imageUrl", "活动页图片地址", null, "varchar(500)", 0, 0, false)]
        public virtual String imageUrl
        {
            get { return _imageUrl; }
            set { if (OnPropertyChanging(__.imageUrl, value)) { _imageUrl = value; OnPropertyChanged(__.imageUrl); } }
        }

        private String _contentUrl;
        /// <summary>活动页内容地址</summary>
        [DisplayName("活动页内容地址")]
        [Description("活动页内容地址")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(4, "contentUrl", "活动页内容地址", null, "varchar(500)", 0, 0, false)]
        public virtual String contentUrl
        {
            get { return _contentUrl; }
            set { if (OnPropertyChanging(__.contentUrl, value)) { _contentUrl = value; OnPropertyChanged(__.contentUrl); } }
        }

        private String _visiableUid;
        /// <summary>可见用户</summary>
        [DisplayName("可见用户")]
        [Description("可见用户")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "visiableUid", "可见用户", null, "varchar(50)", 0, 0, false)]
        public virtual String visiableUid
        {
            get { return _visiableUid; }
            set { if (OnPropertyChanging(__.visiableUid, value)) { _visiableUid = value; OnPropertyChanged(__.visiableUid); } }
        }

        private Int32 _status;
        /// <summary>活动状态</summary>
        [DisplayName("活动状态")]
        [Description("活动状态")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "status", "活动状态", null, "int", 10, 0, false)]
        public virtual Int32 status
        {
            get { return _status; }
            set { if (OnPropertyChanging(__.status, value)) { _status = value; OnPropertyChanged(__.status); } }
        }

        private DateTime _publishTime;
        /// <summary>发布时间</summary>
        [DisplayName("发布时间")]
        [Description("发布时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "publishTime", "发布时间", null, "datetime", 3, 0, false)]
        public virtual DateTime publishTime
        {
            get { return _publishTime; }
            set { if (OnPropertyChanging(__.publishTime, value)) { _publishTime = value; OnPropertyChanged(__.publishTime); } }
        }

        private DateTime _createTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "createTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime createTime
        {
            get { return _createTime; }
            set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
        }

        private DateTime _updateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime updateTime
        {
            get { return _updateTime; }
            set { if (OnPropertyChanging(__.updateTime, value)) { _updateTime = value; OnPropertyChanged(__.updateTime); } }
        }

        private Int64 _createUid;
        /// <summary>创建者,用户表的uid</summary>
        [DisplayName("创建者,用户表的uid")]
        [Description("创建者,用户表的uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(10, "createUid", "创建者,用户表的uid", null, "bigint", 19, 0, false)]
        public virtual Int64 createUid
        {
            get { return _createUid; }
            set { if (OnPropertyChanging(__.createUid, value)) { _createUid = value; OnPropertyChanged(__.createUid); } }
        }

        private Int64 _modifyUid;
        /// <summary>修改者，用户表的uid</summary>
        [DisplayName("修改者，用户表的uid")]
        [Description("修改者，用户表的uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(11, "modifyUid", "修改者，用户表的uid", null, "bigint", 19, 0, false)]
        public virtual Int64 modifyUid
        {
            get { return _modifyUid; }
            set { if (OnPropertyChanging(__.modifyUid, value)) { _modifyUid = value; OnPropertyChanged(__.modifyUid); } }
        }

        private DateTime _visibleStartTime;
        /// <summary></summary>
        [DisplayName("visibleStartTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "visibleStartTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime visibleStartTime
        {
            get { return _visibleStartTime; }
            set { if (OnPropertyChanging(__.visibleStartTime, value)) { _visibleStartTime = value; OnPropertyChanged(__.visibleStartTime); } }
        }

        private DateTime _visibleEndTime;
        /// <summary></summary>
        [DisplayName("visibleEndTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "visibleEndTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime visibleEndTime
        {
            get { return _visibleEndTime; }
            set { if (OnPropertyChanging(__.visibleEndTime, value)) { _visibleEndTime = value; OnPropertyChanged(__.visibleEndTime); } }
        }

        private String _shareTitle;
        /// <summary></summary>
        [DisplayName("shareTitle")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "shareTitle", "", null, "varchar(50)", 0, 0, false)]
        public virtual String shareTitle
        {
            get { return _shareTitle; }
            set { if (OnPropertyChanging(__.shareTitle, value)) { _shareTitle = value; OnPropertyChanged(__.shareTitle); } }
        }

        private String _shareImageUrl;
        /// <summary></summary>
        [DisplayName("shareImageUrl")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(15, "shareImageUrl", "", null, "varchar(500)", 0, 0, false)]
        public virtual String shareImageUrl
        {
            get { return _shareImageUrl; }
            set { if (OnPropertyChanging(__.shareImageUrl, value)) { _shareImageUrl = value; OnPropertyChanged(__.shareImageUrl); } }
        }

        private String _shareContent;
        /// <summary></summary>
        [DisplayName("shareContent")]
        [Description("")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(16, "shareContent", "", null, "text", 0, 0, false)]
        public virtual String shareContent
        {
            get { return _shareContent; }
            set { if (OnPropertyChanging(__.shareContent, value)) { _shareContent = value; OnPropertyChanged(__.shareContent); } }
        }

        private String _shareUrl;
        /// <summary></summary>
        [DisplayName("shareUrl")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(17, "shareUrl", "", null, "varchar(500)", 0, 0, false)]
        public virtual String shareUrl
        {
            get { return _shareUrl; }
            set { if (OnPropertyChanging(__.shareUrl, value)) { _shareUrl = value; OnPropertyChanged(__.shareUrl); } }
        }

        private Int32 _orderNum;
        /// <summary></summary>
        [DisplayName("orderNum")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(18, "orderNum", "", null, "int", 10, 0, false)]
        public virtual Int32 orderNum
        {
            get { return _orderNum; }
            set { if (OnPropertyChanging(__.orderNum, value)) { _orderNum = value; OnPropertyChanged(__.orderNum); } }
        }

        private String _modifyName;
        /// <summary></summary>
        [DisplayName("modifyName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "modifyName", "", null, "varchar(50)", 0, 0, false)]
        public virtual String modifyName
        {
            get { return _modifyName; }
            set { if (OnPropertyChanging(__.modifyName, value)) { _modifyName = value; OnPropertyChanged(__.modifyName); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.id : return _id;
                    case __.title : return _title;
                    case __.imageUrl : return _imageUrl;
                    case __.contentUrl : return _contentUrl;
                    case __.visiableUid : return _visiableUid;
                    case __.status : return _status;
                    case __.publishTime : return _publishTime;
                    case __.createTime : return _createTime;
                    case __.updateTime : return _updateTime;
                    case __.createUid : return _createUid;
                    case __.modifyUid : return _modifyUid;
                    case __.visibleStartTime : return _visibleStartTime;
                    case __.visibleEndTime : return _visibleEndTime;
                    case __.shareTitle : return _shareTitle;
                    case __.shareImageUrl : return _shareImageUrl;
                    case __.shareContent : return _shareContent;
                    case __.shareUrl : return _shareUrl;
                    case __.orderNum : return _orderNum;
                    case __.modifyName : return _modifyName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt64(value); break;
                    case __.title : _title = Convert.ToString(value); break;
                    case __.imageUrl : _imageUrl = Convert.ToString(value); break;
                    case __.contentUrl : _contentUrl = Convert.ToString(value); break;
                    case __.visiableUid : _visiableUid = Convert.ToString(value); break;
                    case __.status : _status = Convert.ToInt32(value); break;
                    case __.publishTime : _publishTime = Convert.ToDateTime(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    case __.createUid : _createUid = Convert.ToInt64(value); break;
                    case __.modifyUid : _modifyUid = Convert.ToInt64(value); break;
                    case __.visibleStartTime : _visibleStartTime = Convert.ToDateTime(value); break;
                    case __.visibleEndTime : _visibleEndTime = Convert.ToDateTime(value); break;
                    case __.shareTitle : _shareTitle = Convert.ToString(value); break;
                    case __.shareImageUrl : _shareImageUrl = Convert.ToString(value); break;
                    case __.shareContent : _shareContent = Convert.ToString(value); break;
                    case __.shareUrl : _shareUrl = Convert.ToString(value); break;
                    case __.orderNum : _orderNum = Convert.ToInt32(value); break;
                    case __.modifyName : _modifyName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得活动表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>活动页ID</summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>活动页标题</summary>
            public static readonly Field title = FindByName(__.title);

            ///<summary>活动页图片地址</summary>
            public static readonly Field imageUrl = FindByName(__.imageUrl);

            ///<summary>活动页内容地址</summary>
            public static readonly Field contentUrl = FindByName(__.contentUrl);

            ///<summary>可见用户</summary>
            public static readonly Field visiableUid = FindByName(__.visiableUid);

            ///<summary>活动状态</summary>
            public static readonly Field status = FindByName(__.status);

            ///<summary>发布时间</summary>
            public static readonly Field publishTime = FindByName(__.publishTime);

            ///<summary>创建时间</summary>
            public static readonly Field createTime = FindByName(__.createTime);

            ///<summary>更新时间</summary>
            public static readonly Field updateTime = FindByName(__.updateTime);

            ///<summary>创建者,用户表的uid</summary>
            public static readonly Field createUid = FindByName(__.createUid);

            ///<summary>修改者，用户表的uid</summary>
            public static readonly Field modifyUid = FindByName(__.modifyUid);

            ///<summary></summary>
            public static readonly Field visibleStartTime = FindByName(__.visibleStartTime);

            ///<summary></summary>
            public static readonly Field visibleEndTime = FindByName(__.visibleEndTime);

            ///<summary></summary>
            public static readonly Field shareTitle = FindByName(__.shareTitle);

            ///<summary></summary>
            public static readonly Field shareImageUrl = FindByName(__.shareImageUrl);

            ///<summary></summary>
            public static readonly Field shareContent = FindByName(__.shareContent);

            ///<summary></summary>
            public static readonly Field shareUrl = FindByName(__.shareUrl);

            ///<summary></summary>
            public static readonly Field orderNum = FindByName(__.orderNum);

            ///<summary></summary>
            public static readonly Field modifyName = FindByName(__.modifyName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得活动表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>活动页ID</summary>
            public const String id = "id";

            ///<summary>活动页标题</summary>
            public const String title = "title";

            ///<summary>活动页图片地址</summary>
            public const String imageUrl = "imageUrl";

            ///<summary>活动页内容地址</summary>
            public const String contentUrl = "contentUrl";

            ///<summary>可见用户</summary>
            public const String visiableUid = "visiableUid";

            ///<summary>活动状态</summary>
            public const String status = "status";

            ///<summary>发布时间</summary>
            public const String publishTime = "publishTime";

            ///<summary>创建时间</summary>
            public const String createTime = "createTime";

            ///<summary>更新时间</summary>
            public const String updateTime = "updateTime";

            ///<summary>创建者,用户表的uid</summary>
            public const String createUid = "createUid";

            ///<summary>修改者，用户表的uid</summary>
            public const String modifyUid = "modifyUid";

            ///<summary></summary>
            public const String visibleStartTime = "visibleStartTime";

            ///<summary></summary>
            public const String visibleEndTime = "visibleEndTime";

            ///<summary></summary>
            public const String shareTitle = "shareTitle";

            ///<summary></summary>
            public const String shareImageUrl = "shareImageUrl";

            ///<summary></summary>
            public const String shareContent = "shareContent";

            ///<summary></summary>
            public const String shareUrl = "shareUrl";

            ///<summary></summary>
            public const String orderNum = "orderNum";

            ///<summary></summary>
            public const String modifyName = "modifyName";

        }
        #endregion
    }

    /// <summary>活动表接口</summary>
    public partial interface IBanner
    {
        #region 属性
        /// <summary>活动页ID</summary>
        Int64 id { get; set; }

        /// <summary>活动页标题</summary>
        String title { get; set; }

        /// <summary>活动页图片地址</summary>
        String imageUrl { get; set; }

        /// <summary>活动页内容地址</summary>
        String contentUrl { get; set; }

        /// <summary>可见用户</summary>
        String visiableUid { get; set; }

        /// <summary>活动状态</summary>
        Int32 status { get; set; }

        /// <summary>发布时间</summary>
        DateTime publishTime { get; set; }

        /// <summary>创建时间</summary>
        DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        Int64 createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        Int64 modifyUid { get; set; }

        /// <summary></summary>
        DateTime visibleStartTime { get; set; }

        /// <summary></summary>
        DateTime visibleEndTime { get; set; }

        /// <summary></summary>
        String shareTitle { get; set; }

        /// <summary></summary>
        String shareImageUrl { get; set; }

        /// <summary></summary>
        String shareContent { get; set; }

        /// <summary></summary>
        String shareUrl { get; set; }

        /// <summary></summary>
        Int32 orderNum { get; set; }

        /// <summary></summary>
        String modifyName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}