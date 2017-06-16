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
    [BindIndex("PK_LOGINLOG", true, "ID")]
    [BindTable("LoginLog", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class LoginLog : ILoginLog
    {
        #region 属性
        private Int64 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "ID", "", null, "bigint", 19, 0, false)]
        public virtual Int64 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private DateTime _loginTime;
        /// <summary></summary>
        [DisplayName("loginTime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(2, "loginTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime loginTime
        {
            get { return _loginTime; }
            set { if (OnPropertyChanging(__.loginTime, value)) { _loginTime = value; OnPropertyChanged(__.loginTime); } }
        }

        private String _loginIp;
        /// <summary></summary>
        [DisplayName("loginIp")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "loginIp", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String loginIp
        {
            get { return _loginIp; }
            set { if (OnPropertyChanging(__.loginIp, value)) { _loginIp = value; OnPropertyChanged(__.loginIp); } }
        }

        private String _userId;
        /// <summary></summary>
        [DisplayName("userId")]
        [Description("")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(4, "userId", "", null, "nvarchar(150)", 0, 0, true)]
        public virtual String userId
        {
            get { return _userId; }
            set { if (OnPropertyChanging(__.userId, value)) { _userId = value; OnPropertyChanged(__.userId); } }
        }

        private String _loginMode;
        /// <summary></summary>
        [DisplayName("loginMode")]
        [Description("")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(5, "loginMode", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String loginMode
        {
            get { return _loginMode; }
            set { if (OnPropertyChanging(__.loginMode, value)) { _loginMode = value; OnPropertyChanged(__.loginMode); } }
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
                    case __.ID : return _ID;
                    case __.loginTime : return _loginTime;
                    case __.loginIp : return _loginIp;
                    case __.userId : return _userId;
                    case __.loginMode : return _loginMode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt64(value); break;
                    case __.loginTime : _loginTime = Convert.ToDateTime(value); break;
                    case __.loginIp : _loginIp = Convert.ToString(value); break;
                    case __.userId : _userId = Convert.ToString(value); break;
                    case __.loginMode : _loginMode = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary></summary>
            public static readonly Field loginTime = FindByName(__.loginTime);

            ///<summary></summary>
            public static readonly Field loginIp = FindByName(__.loginIp);

            ///<summary></summary>
            public static readonly Field userId = FindByName(__.userId);

            ///<summary></summary>
            public static readonly Field loginMode = FindByName(__.loginMode);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary></summary>
            public const String loginTime = "loginTime";

            ///<summary></summary>
            public const String loginIp = "loginIp";

            ///<summary></summary>
            public const String userId = "userId";

            ///<summary></summary>
            public const String loginMode = "loginMode";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ILoginLog
    {
        #region 属性
        /// <summary></summary>
        Int64 ID { get; set; }

        /// <summary></summary>
        DateTime loginTime { get; set; }

        /// <summary></summary>
        String loginIp { get; set; }

        /// <summary></summary>
        String userId { get; set; }

        /// <summary></summary>
        String loginMode { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}