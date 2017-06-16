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
    [BindTable("UserRelation", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class UserRelation : IUserRelation
    {
        #region 属性
        private Int64 _rid;
        /// <summary>关系id</summary>
        [DisplayName("关系id")]
        [Description("关系id")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "rid", "关系id", null, "bigint", 19, 0, false)]
        public virtual Int64 rid
        {
            get { return _rid; }
            set { if (OnPropertyChanging(__.rid, value)) { _rid = value; OnPropertyChanged(__.rid); } }
        }

        private Int64 _uid;
        /// <summary>用户uid</summary>
        [DisplayName("用户uid")]
        [Description("用户uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(2, "uid", "用户uid", null, "bigint", 19, 0, false)]
        public virtual Int64 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private Int64 _pUid;
        /// <summary>上级用户Uid</summary>
        [DisplayName("上级用户Uid")]
        [Description("上级用户Uid")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(3, "pUid", "上级用户Uid", null, "bigint", 19, 0, false)]
        public virtual Int64 pUid
        {
            get { return _pUid; }
            set { if (OnPropertyChanging(__.pUid, value)) { _pUid = value; OnPropertyChanged(__.pUid); } }
        }

        private String _bindSource;
        /// <summary>绑定方式</summary>
        [DisplayName("绑定方式")]
        [Description("绑定方式")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "bindSource", "绑定方式", null, "varchar(10)", 0, 0, false)]
        public virtual String bindSource
        {
            get { return _bindSource; }
            set { if (OnPropertyChanging(__.bindSource, value)) { _bindSource = value; OnPropertyChanged(__.bindSource); } }
        }

        private DateTime _bingTime;
        /// <summary>绑定时间</summary>
        [DisplayName("绑定时间")]
        [Description("绑定时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "bingTime", "绑定时间", null, "datetime", 3, 0, false)]
        public virtual DateTime bingTime
        {
            get { return _bingTime; }
            set { if (OnPropertyChanging(__.bingTime, value)) { _bingTime = value; OnPropertyChanged(__.bingTime); } }
        }

        private DateTime _unbindTime;
        /// <summary>解绑时间</summary>
        [DisplayName("解绑时间")]
        [Description("解绑时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "unbindTime", "解绑时间", null, "datetime", 3, 0, false)]
        public virtual DateTime unbindTime
        {
            get { return _unbindTime; }
            set { if (OnPropertyChanging(__.unbindTime, value)) { _unbindTime = value; OnPropertyChanged(__.unbindTime); } }
        }

        private DateTime _createTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "createTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(8, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime updateTime
        {
            get { return _updateTime; }
            set { if (OnPropertyChanging(__.updateTime, value)) { _updateTime = value; OnPropertyChanged(__.updateTime); } }
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
                    case __.rid : return _rid;
                    case __.uid : return _uid;
                    case __.pUid : return _pUid;
                    case __.bindSource : return _bindSource;
                    case __.bingTime : return _bingTime;
                    case __.unbindTime : return _unbindTime;
                    case __.createTime : return _createTime;
                    case __.updateTime : return _updateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.rid : _rid = Convert.ToInt64(value); break;
                    case __.uid : _uid = Convert.ToInt64(value); break;
                    case __.pUid : _pUid = Convert.ToInt64(value); break;
                    case __.bindSource : _bindSource = Convert.ToString(value); break;
                    case __.bingTime : _bingTime = Convert.ToDateTime(value); break;
                    case __.unbindTime : _unbindTime = Convert.ToDateTime(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>关系id</summary>
            public static readonly Field rid = FindByName(__.rid);

            ///<summary>用户uid</summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary>上级用户Uid</summary>
            public static readonly Field pUid = FindByName(__.pUid);

            ///<summary>绑定方式</summary>
            public static readonly Field bindSource = FindByName(__.bindSource);

            ///<summary>绑定时间</summary>
            public static readonly Field bingTime = FindByName(__.bingTime);

            ///<summary>解绑时间</summary>
            public static readonly Field unbindTime = FindByName(__.unbindTime);

            ///<summary>创建时间</summary>
            public static readonly Field createTime = FindByName(__.createTime);

            ///<summary>更新时间</summary>
            public static readonly Field updateTime = FindByName(__.updateTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>关系id</summary>
            public const String rid = "rid";

            ///<summary>用户uid</summary>
            public const String uid = "uid";

            ///<summary>上级用户Uid</summary>
            public const String pUid = "pUid";

            ///<summary>绑定方式</summary>
            public const String bindSource = "bindSource";

            ///<summary>绑定时间</summary>
            public const String bingTime = "bingTime";

            ///<summary>解绑时间</summary>
            public const String unbindTime = "unbindTime";

            ///<summary>创建时间</summary>
            public const String createTime = "createTime";

            ///<summary>更新时间</summary>
            public const String updateTime = "updateTime";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IUserRelation
    {
        #region 属性
        /// <summary>关系id</summary>
        Int64 rid { get; set; }

        /// <summary>用户uid</summary>
        Int64 uid { get; set; }

        /// <summary>上级用户Uid</summary>
        Int64 pUid { get; set; }

        /// <summary>绑定方式</summary>
        String bindSource { get; set; }

        /// <summary>绑定时间</summary>
        DateTime bingTime { get; set; }

        /// <summary>解绑时间</summary>
        DateTime unbindTime { get; set; }

        /// <summary>创建时间</summary>
        DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime updateTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}