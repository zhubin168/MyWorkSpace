﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK__AuditRec__DE508E2E0425A276", true, "aid")]
    [BindTable("AuditRecord", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class AuditRecord : IAuditRecord
    {
        #region 属性
        private Int64 _aid;
        /// <summary>审核ID</summary>
        [DisplayName("审核ID")]
        [Description("审核ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "aid", "审核ID", null, "bigint", 19, 0, false)]
        public virtual Int64 aid
        {
            get { return _aid; }
            set { if (OnPropertyChanging(__.aid, value)) { _aid = value; OnPropertyChanged(__.aid); } }
        }

        private Int64 _auditUid;
        /// <summary>审核者uid</summary>
        [DisplayName("审核者uid")]
        [Description("审核者uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(2, "auditUid", "审核者uid", null, "bigint", 19, 0, false)]
        public virtual Int64 auditUid
        {
            get { return _auditUid; }
            set { if (OnPropertyChanging(__.auditUid, value)) { _auditUid = value; OnPropertyChanged(__.auditUid); } }
        }

        private Int64 _requestUid;
        /// <summary>请求者uid</summary>
        [DisplayName("请求者uid")]
        [Description("请求者uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(3, "requestUid", "请求者uid", null, "bigint", 19, 0, false)]
        public virtual Int64 requestUid
        {
            get { return _requestUid; }
            set { if (OnPropertyChanging(__.requestUid, value)) { _requestUid = value; OnPropertyChanged(__.requestUid); } }
        }

        private DateTime _createTime;
        /// <summary>申请时间</summary>
        [DisplayName("申请时间")]
        [Description("申请时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(4, "createTime", "申请时间", null, "datetime", 3, 0, false)]
        public virtual DateTime createTime
        {
            get { return _createTime; }
            set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
        }

        private DateTime _auditTime;
        /// <summary>审核时间</summary>
        [DisplayName("审核时间")]
        [Description("审核时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "auditTime", "审核时间", null, "datetime", 3, 0, false)]
        public virtual DateTime auditTime
        {
            get { return _auditTime; }
            set { if (OnPropertyChanging(__.auditTime, value)) { _auditTime = value; OnPropertyChanged(__.auditTime); } }
        }

        private String _applyContent;
        /// <summary>申请内容</summary>
        [DisplayName("申请内容")]
        [Description("申请内容")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "applyContent", "申请内容", null, "varchar(200)", 0, 0, false)]
        public virtual String applyContent
        {
            get { return _applyContent; }
            set { if (OnPropertyChanging(__.applyContent, value)) { _applyContent = value; OnPropertyChanged(__.applyContent); } }
        }

        private String _auditMark;
        /// <summary>审核描述</summary>
        [DisplayName("审核描述")]
        [Description("审核描述")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(7, "auditMark", "审核描述", null, "varchar(2000)", 0, 0, false)]
        public virtual String auditMark
        {
            get { return _auditMark; }
            set { if (OnPropertyChanging(__.auditMark, value)) { _auditMark = value; OnPropertyChanged(__.auditMark); } }
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
                    case __.aid : return _aid;
                    case __.auditUid : return _auditUid;
                    case __.requestUid : return _requestUid;
                    case __.createTime : return _createTime;
                    case __.auditTime : return _auditTime;
                    case __.applyContent : return _applyContent;
                    case __.auditMark : return _auditMark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.aid : _aid = Convert.ToInt64(value); break;
                    case __.auditUid : _auditUid = Convert.ToInt64(value); break;
                    case __.requestUid : _requestUid = Convert.ToInt64(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.auditTime : _auditTime = Convert.ToDateTime(value); break;
                    case __.applyContent : _applyContent = Convert.ToString(value); break;
                    case __.auditMark : _auditMark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>审核ID</summary>
            public static readonly Field aid = FindByName(__.aid);

            ///<summary>审核者uid</summary>
            public static readonly Field auditUid = FindByName(__.auditUid);

            ///<summary>请求者uid</summary>
            public static readonly Field requestUid = FindByName(__.requestUid);

            ///<summary>申请时间</summary>
            public static readonly Field createTime = FindByName(__.createTime);

            ///<summary>审核时间</summary>
            public static readonly Field auditTime = FindByName(__.auditTime);

            ///<summary>申请内容</summary>
            public static readonly Field applyContent = FindByName(__.applyContent);

            ///<summary>审核描述</summary>
            public static readonly Field auditMark = FindByName(__.auditMark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>审核ID</summary>
            public const String aid = "aid";

            ///<summary>审核者uid</summary>
            public const String auditUid = "auditUid";

            ///<summary>请求者uid</summary>
            public const String requestUid = "requestUid";

            ///<summary>申请时间</summary>
            public const String createTime = "createTime";

            ///<summary>审核时间</summary>
            public const String auditTime = "auditTime";

            ///<summary>申请内容</summary>
            public const String applyContent = "applyContent";

            ///<summary>审核描述</summary>
            public const String auditMark = "auditMark";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IAuditRecord
    {
        #region 属性
        /// <summary>审核ID</summary>
        Int64 aid { get; set; }

        /// <summary>审核者uid</summary>
        Int64 auditUid { get; set; }

        /// <summary>请求者uid</summary>
        Int64 requestUid { get; set; }

        /// <summary>申请时间</summary>
        DateTime createTime { get; set; }

        /// <summary>审核时间</summary>
        DateTime auditTime { get; set; }

        /// <summary>申请内容</summary>
        String applyContent { get; set; }

        /// <summary>审核描述</summary>
        String auditMark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}