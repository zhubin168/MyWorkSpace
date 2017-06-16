﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>资讯分类</summary>
    [Serializable]
    [DataObject]
    [Description("资讯分类")]
    [BindIndex("PK_InfoCategory", true, "id")]
    [BindTable("InfoCategory", Description = "资讯分类", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class InfoCategory : IInfoCategory
    {
        #region 属性
        private Int64 _id;
        /// <summary>资讯分类ID</summary>
        [DisplayName("资讯分类ID")]
        [Description("资讯分类ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "id", "资讯分类ID", null, "bigint", 19, 0, false)]
        public virtual Int64 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _name;
        /// <summary>资讯分类名称</summary>
        [DisplayName("资讯分类名称")]
        [Description("资讯分类名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "name", "资讯分类名称", null, "varchar(50)", 0, 0, false)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private DateTime _createTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(3, "createTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(4, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(5, "createUid", "创建者,用户表的uid", null, "bigint", 19, 0, false)]
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
        [BindColumn(6, "modifyUid", "修改者，用户表的uid", null, "bigint", 19, 0, false)]
        public virtual Int64 modifyUid
        {
            get { return _modifyUid; }
            set { if (OnPropertyChanging(__.modifyUid, value)) { _modifyUid = value; OnPropertyChanged(__.modifyUid); } }
        }

        private Int32 _orderNum;
        /// <summary></summary>
        [DisplayName("orderNum")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "orderNum", "", null, "int", 10, 0, false)]
        public virtual Int32 orderNum
        {
            get { return _orderNum; }
            set { if (OnPropertyChanging(__.orderNum, value)) { _orderNum = value; OnPropertyChanged(__.orderNum); } }
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
                    case __.name : return _name;
                    case __.createTime : return _createTime;
                    case __.updateTime : return _updateTime;
                    case __.createUid : return _createUid;
                    case __.modifyUid : return _modifyUid;
                    case __.orderNum : return _orderNum;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt64(value); break;
                    case __.name : _name = Convert.ToString(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    case __.createUid : _createUid = Convert.ToInt64(value); break;
                    case __.modifyUid : _modifyUid = Convert.ToInt64(value); break;
                    case __.orderNum : _orderNum = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得资讯分类字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>资讯分类ID</summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary>资讯分类名称</summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary>创建时间</summary>
            public static readonly Field createTime = FindByName(__.createTime);

            ///<summary>更新时间</summary>
            public static readonly Field updateTime = FindByName(__.updateTime);

            ///<summary>创建者,用户表的uid</summary>
            public static readonly Field createUid = FindByName(__.createUid);

            ///<summary>修改者，用户表的uid</summary>
            public static readonly Field modifyUid = FindByName(__.modifyUid);

            ///<summary></summary>
            public static readonly Field orderNum = FindByName(__.orderNum);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得资讯分类字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>资讯分类ID</summary>
            public const String id = "id";

            ///<summary>资讯分类名称</summary>
            public const String name = "name";

            ///<summary>创建时间</summary>
            public const String createTime = "createTime";

            ///<summary>更新时间</summary>
            public const String updateTime = "updateTime";

            ///<summary>创建者,用户表的uid</summary>
            public const String createUid = "createUid";

            ///<summary>修改者，用户表的uid</summary>
            public const String modifyUid = "modifyUid";

            ///<summary></summary>
            public const String orderNum = "orderNum";

        }
        #endregion
    }

    /// <summary>资讯分类接口</summary>
    public partial interface IInfoCategory
    {
        #region 属性
        /// <summary>资讯分类ID</summary>
        Int64 id { get; set; }

        /// <summary>资讯分类名称</summary>
        String name { get; set; }

        /// <summary>创建时间</summary>
        DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        Int64 createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        Int64 modifyUid { get; set; }

        /// <summary></summary>
        Int32 orderNum { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}