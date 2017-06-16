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
    [BindIndex("IX_ProductDoc_productId", false, "productId")]
    [BindRelation("productId", false, "Product", "pid")]
    [BindTable("ProductDoc", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class ProductDoc : IProductDoc
    {
        #region 属性
        private Int64 _productId;
        /// <summary></summary>
        [DisplayName("productId")]
        [Description("")]
        [DataObjectField(true, false, false, 19)]
        [BindColumn(1, "productId", "", null, "bigint", 19, 0, false)]
        public virtual Int64 productId
        {
            get { return _productId; }
            set { if (OnPropertyChanging(__.productId, value)) { _productId = value; OnPropertyChanged(__.productId); } }
        }

        private String _docUrl;
        /// <summary></summary>
        [DisplayName("docUrl")]
        [Description("")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(2, "docUrl", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String docUrl
        {
            get { return _docUrl; }
            set { if (OnPropertyChanging(__.docUrl, value)) { _docUrl = value; OnPropertyChanged(__.docUrl); } }
        }

        private String _fileName;
        /// <summary></summary>
        [DisplayName("fileName")]
        [Description("")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(3, "fileName", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String fileName
        {
            get { return _fileName; }
            set { if (OnPropertyChanging(__.fileName, value)) { _fileName = value; OnPropertyChanged(__.fileName); } }
        }

        private DateTime _createTime;
        /// <summary></summary>
        [DisplayName("createTime")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "createTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime createTime
        {
            get { return _createTime; }
            set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
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
                    case __.productId : return _productId;
                    case __.docUrl : return _docUrl;
                    case __.fileName : return _fileName;
                    case __.createTime : return _createTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.productId : _productId = Convert.ToInt64(value); break;
                    case __.docUrl : _docUrl = Convert.ToString(value); break;
                    case __.fileName : _fileName = Convert.ToString(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
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
            public static readonly Field productId = FindByName(__.productId);

            ///<summary></summary>
            public static readonly Field docUrl = FindByName(__.docUrl);

            ///<summary></summary>
            public static readonly Field fileName = FindByName(__.fileName);

            ///<summary></summary>
            public static readonly Field createTime = FindByName(__.createTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String productId = "productId";

            ///<summary></summary>
            public const String docUrl = "docUrl";

            ///<summary></summary>
            public const String fileName = "fileName";

            ///<summary></summary>
            public const String createTime = "createTime";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IProductDoc
    {
        #region 属性
        /// <summary></summary>
        Int64 productId { get; set; }

        /// <summary></summary>
        String docUrl { get; set; }

        /// <summary></summary>
        String fileName { get; set; }

        /// <summary></summary>
        DateTime createTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}