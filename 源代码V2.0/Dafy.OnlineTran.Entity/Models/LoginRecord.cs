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
    [BindIndex("PK__LoginRec__DE105D0707F6335A", true, "lid")]
    [BindTable("LoginRecord", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class LoginRecord : ILoginRecord
    {
        #region 属性
        private Int64 _lid;
        /// <summary>登陆ID</summary>
        [DisplayName("登陆ID")]
        [Description("登陆ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "lid", "登陆ID", null, "bigint", 19, 0, false)]
        public virtual Int64 lid
        {
            get { return _lid; }
            set { if (OnPropertyChanging(__.lid, value)) { _lid = value; OnPropertyChanged(__.lid); } }
        }

        private DateTime _loginTime;
        /// <summary>登陆时间</summary>
        [DisplayName("登陆时间")]
        [Description("登陆时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(2, "loginTime", "登陆时间", null, "datetime", 3, 0, false)]
        public virtual DateTime loginTime
        {
            get { return _loginTime; }
            set { if (OnPropertyChanging(__.loginTime, value)) { _loginTime = value; OnPropertyChanged(__.loginTime); } }
        }

        private Int64 _uid;
        /// <summary>登陆者uid</summary>
        [DisplayName("登陆者uid")]
        [Description("登陆者uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(3, "uid", "登陆者uid", null, "bigint", 19, 0, false)]
        public virtual Int64 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private String _loginMode;
        /// <summary>登陆方式</summary>
        [DisplayName("登陆方式")]
        [Description("登陆方式")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(4, "loginMode", "登陆方式", null, "varchar(1)", 0, 0, false)]
        public virtual String loginMode
        {
            get { return _loginMode; }
            set { if (OnPropertyChanging(__.loginMode, value)) { _loginMode = value; OnPropertyChanged(__.loginMode); } }
        }

        private String _weixinID;
        /// <summary></summary>
        [DisplayName("weixinID")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "weixinID", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String weixinID
        {
            get { return _weixinID; }
            set { if (OnPropertyChanging(__.weixinID, value)) { _weixinID = value; OnPropertyChanged(__.weixinID); } }
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
                    case __.lid : return _lid;
                    case __.loginTime : return _loginTime;
                    case __.uid : return _uid;
                    case __.loginMode : return _loginMode;
                    case __.weixinID : return _weixinID;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.lid : _lid = Convert.ToInt64(value); break;
                    case __.loginTime : _loginTime = Convert.ToDateTime(value); break;
                    case __.uid : _uid = Convert.ToInt64(value); break;
                    case __.loginMode : _loginMode = Convert.ToString(value); break;
                    case __.weixinID : _weixinID = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>登陆ID</summary>
            public static readonly Field lid = FindByName(__.lid);

            ///<summary>登陆时间</summary>
            public static readonly Field loginTime = FindByName(__.loginTime);

            ///<summary>登陆者uid</summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary>登陆方式</summary>
            public static readonly Field loginMode = FindByName(__.loginMode);

            ///<summary></summary>
            public static readonly Field weixinID = FindByName(__.weixinID);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>登陆ID</summary>
            public const String lid = "lid";

            ///<summary>登陆时间</summary>
            public const String loginTime = "loginTime";

            ///<summary>登陆者uid</summary>
            public const String uid = "uid";

            ///<summary>登陆方式</summary>
            public const String loginMode = "loginMode";

            ///<summary></summary>
            public const String weixinID = "weixinID";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ILoginRecord
    {
        #region 属性
        /// <summary>登陆ID</summary>
        Int64 lid { get; set; }

        /// <summary>登陆时间</summary>
        DateTime loginTime { get; set; }

        /// <summary>登陆者uid</summary>
        Int64 uid { get; set; }

        /// <summary>登陆方式</summary>
        String loginMode { get; set; }

        /// <summary></summary>
        String weixinID { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}