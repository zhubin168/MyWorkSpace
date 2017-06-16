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
    [BindIndex("PK_Dictionary", true, "id")]
    [BindTable("Dictionary", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Dictionary : IDictionary
    {
        #region 属性
        private Int64 _id;
        /// <summary></summary>
        [DisplayName("id")]
        [Description("")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "id", "", null, "bigint", 19, 0, false)]
        public virtual Int64 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _para_name;
        /// <summary></summary>
        [DisplayName("para_name")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "para_name", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String para_name
        {
            get { return _para_name; }
            set { if (OnPropertyChanging(__.para_name, value)) { _para_name = value; OnPropertyChanged(__.para_name); } }
        }

        private String _para_code;
        /// <summary></summary>
        [DisplayName("para_code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "para_code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String para_code
        {
            get { return _para_code; }
            set { if (OnPropertyChanging(__.para_code, value)) { _para_code = value; OnPropertyChanged(__.para_code); } }
        }

        private String _para_group;
        /// <summary></summary>
        [DisplayName("para_group")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "para_group", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String para_group
        {
            get { return _para_group; }
            set { if (OnPropertyChanging(__.para_group, value)) { _para_group = value; OnPropertyChanged(__.para_group); } }
        }

        private String _para_value;
        /// <summary></summary>
        [DisplayName("para_value")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "para_value", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String para_value
        {
            get { return _para_value; }
            set { if (OnPropertyChanging(__.para_value, value)) { _para_value = value; OnPropertyChanged(__.para_value); } }
        }

        private Int32 _status;
        /// <summary></summary>
        [DisplayName("status")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "status", "", null, "int", 10, 0, false)]
        public virtual Int32 status
        {
            get { return _status; }
            set { if (OnPropertyChanging(__.status, value)) { _status = value; OnPropertyChanged(__.status); } }
        }

        private String _remark;
        /// <summary></summary>
        [DisplayName("remark")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "remark", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String remark
        {
            get { return _remark; }
            set { if (OnPropertyChanging(__.remark, value)) { _remark = value; OnPropertyChanged(__.remark); } }
        }

        private Int32 _sort_order;
        /// <summary></summary>
        [DisplayName("sort_order")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "sort_order", "", null, "int", 10, 0, false)]
        public virtual Int32 sort_order
        {
            get { return _sort_order; }
            set { if (OnPropertyChanging(__.sort_order, value)) { _sort_order = value; OnPropertyChanged(__.sort_order); } }
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
                    case __.para_name : return _para_name;
                    case __.para_code : return _para_code;
                    case __.para_group : return _para_group;
                    case __.para_value : return _para_value;
                    case __.status : return _status;
                    case __.remark : return _remark;
                    case __.sort_order : return _sort_order;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt64(value); break;
                    case __.para_name : _para_name = Convert.ToString(value); break;
                    case __.para_code : _para_code = Convert.ToString(value); break;
                    case __.para_group : _para_group = Convert.ToString(value); break;
                    case __.para_value : _para_value = Convert.ToString(value); break;
                    case __.status : _status = Convert.ToInt32(value); break;
                    case __.remark : _remark = Convert.ToString(value); break;
                    case __.sort_order : _sort_order = Convert.ToInt32(value); break;
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
            public static readonly Field id = FindByName(__.id);

            ///<summary></summary>
            public static readonly Field para_name = FindByName(__.para_name);

            ///<summary></summary>
            public static readonly Field para_code = FindByName(__.para_code);

            ///<summary></summary>
            public static readonly Field para_group = FindByName(__.para_group);

            ///<summary></summary>
            public static readonly Field para_value = FindByName(__.para_value);

            ///<summary></summary>
            public static readonly Field status = FindByName(__.status);

            ///<summary></summary>
            public static readonly Field remark = FindByName(__.remark);

            ///<summary></summary>
            public static readonly Field sort_order = FindByName(__.sort_order);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary></summary>
            public const String para_name = "para_name";

            ///<summary></summary>
            public const String para_code = "para_code";

            ///<summary></summary>
            public const String para_group = "para_group";

            ///<summary></summary>
            public const String para_value = "para_value";

            ///<summary></summary>
            public const String status = "status";

            ///<summary></summary>
            public const String remark = "remark";

            ///<summary></summary>
            public const String sort_order = "sort_order";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IDictionary
    {
        #region 属性
        /// <summary></summary>
        Int64 id { get; set; }

        /// <summary></summary>
        String para_name { get; set; }

        /// <summary></summary>
        String para_code { get; set; }

        /// <summary></summary>
        String para_group { get; set; }

        /// <summary></summary>
        String para_value { get; set; }

        /// <summary></summary>
        Int32 status { get; set; }

        /// <summary></summary>
        String remark { get; set; }

        /// <summary></summary>
        Int32 sort_order { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}