﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>产品表</summary>
    [Serializable]
    [DataObject]
    [Description("产品表")]
    [BindIndex("PK_Product", true, "pid")]
    [BindIndex("IX_Product_productName", false, "productName")]
    [BindIndex("IX_Product_productType", false, "productType")]
    [BindIndex("IX_Product_companyId", false, "companyId")]
    [BindIndex("IX_Product_companyName", false, "companyName")]
    [BindRelation("pid", true, "Order", "productId")]
    [BindRelation("productName", false, "Order", "productName")]
    [BindRelation("productType", false, "Order", "productType")]
    [BindRelation("companyId", false, "Company", "Id")]
    [BindRelation("companyName", false, "Company", "CompanyName")]
    [BindTable("Product", Description = "产品表", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Product : IProduct
    {
        #region 属性
        private Int64 _pid;
        /// <summary>产品ID</summary>
        [DisplayName("产品ID")]
        [Description("产品ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "pid", "产品ID", null, "bigint", 19, 0, false)]
        public virtual Int64 pid
        {
            get { return _pid; }
            set { if (OnPropertyChanging(__.pid, value)) { _pid = value; OnPropertyChanged(__.pid); } }
        }

        private String _productName;
        /// <summary>产品名称</summary>
        [DisplayName("产品名称")]
        [Description("产品名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "productName", "产品名称", null, "varchar(50)", 0, 0, false)]
        public virtual String productName
        {
            get { return _productName; }
            set { if (OnPropertyChanging(__.productName, value)) { _productName = value; OnPropertyChanged(__.productName); } }
        }

        private String _productType;
        /// <summary>产品类型</summary>
        [DisplayName("产品类型")]
        [Description("产品类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "productType", "产品类型", null, "varchar(50)", 0, 0, false)]
        public virtual String productType
        {
            get { return _productType; }
            set { if (OnPropertyChanging(__.productType, value)) { _productType = value; OnPropertyChanged(__.productType); } }
        }

        private Int64 _companyId;
        /// <summary>所属机构</summary>
        [DisplayName("所属机构")]
        [Description("所属机构")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(4, "companyId", "所属机构", null, "bigint", 19, 0, false)]
        public virtual Int64 companyId
        {
            get { return _companyId; }
            set { if (OnPropertyChanging(__.companyId, value)) { _companyId = value; OnPropertyChanged(__.companyId); } }
        }

        private String _companyName;
        /// <summary>所属机构名称</summary>
        [DisplayName("所属机构名称")]
        [Description("所属机构名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "companyName", "所属机构名称", null, "varchar(50)", 0, 0, false)]
        public virtual String companyName
        {
            get { return _companyName; }
            set { if (OnPropertyChanging(__.companyName, value)) { _companyName = value; OnPropertyChanged(__.companyName); } }
        }

        private String _companyLogo;
        /// <summary>所属机构Logo</summary>
        [DisplayName("所属机构Logo")]
        [Description("所属机构Logo")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(6, "companyLogo", "所属机构Logo", null, "varchar(500)", 0, 0, false)]
        public virtual String companyLogo
        {
            get { return _companyLogo; }
            set { if (OnPropertyChanging(__.companyLogo, value)) { _companyLogo = value; OnPropertyChanged(__.companyLogo); } }
        }

        private String _description;
        /// <summary>产品亮点</summary>
        [DisplayName("产品亮点")]
        [Description("产品亮点")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "description", "产品亮点", null, "varchar(50)", 0, 0, false)]
        public virtual String description
        {
            get { return _description; }
            set { if (OnPropertyChanging(__.description, value)) { _description = value; OnPropertyChanged(__.description); } }
        }

        private String _content;
        /// <summary>产品详情</summary>
        [DisplayName("产品详情")]
        [Description("产品详情")]
        [DataObjectField(false, false, false, 2147483647)]
        [BindColumn(8, "content", "产品详情", null, "text", 0, 0, false)]
        public virtual String content
        {
            get { return _content; }
            set { if (OnPropertyChanging(__.content, value)) { _content = value; OnPropertyChanged(__.content); } }
        }

        private String _docUrl;
        /// <summary>产品文档url</summary>
        [DisplayName("产品文档url")]
        [Description("产品文档url")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(9, "docUrl", "产品文档url", null, "varchar(500)", 0, 0, false)]
        public virtual String docUrl
        {
            get { return _docUrl; }
            set { if (OnPropertyChanging(__.docUrl, value)) { _docUrl = value; OnPropertyChanged(__.docUrl); } }
        }

        private Int32 _proAge;
        /// <summary>承保年龄</summary>
        [DisplayName("承保年龄")]
        [Description("承保年龄")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "proAge", "承保年龄", null, "int", 10, 0, false)]
        public virtual Int32 proAge
        {
            get { return _proAge; }
            set { if (OnPropertyChanging(__.proAge, value)) { _proAge = value; OnPropertyChanged(__.proAge); } }
        }

        private Decimal _price;
        /// <summary>产品价格</summary>
        [DisplayName("产品价格")]
        [Description("产品价格")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(11, "price", "产品价格", null, "decimal", 18, 0, false)]
        public virtual Decimal price
        {
            get { return _price; }
            set { if (OnPropertyChanging(__.price, value)) { _price = value; OnPropertyChanged(__.price); } }
        }

        private String _demoContent;
        /// <summary>投保示例</summary>
        [DisplayName("投保示例")]
        [Description("投保示例")]
        [DataObjectField(false, false, false, 2147483647)]
        [BindColumn(12, "demoContent", "投保示例", null, "text", 0, 0, false)]
        public virtual String demoContent
        {
            get { return _demoContent; }
            set { if (OnPropertyChanging(__.demoContent, value)) { _demoContent = value; OnPropertyChanged(__.demoContent); } }
        }

        private String _reasonContent;
        /// <summary>选择原因</summary>
        [DisplayName("选择原因")]
        [Description("选择原因")]
        [DataObjectField(false, false, false, 2147483647)]
        [BindColumn(13, "reasonContent", "选择原因", null, "text", 0, 0, false)]
        public virtual String reasonContent
        {
            get { return _reasonContent; }
            set { if (OnPropertyChanging(__.reasonContent, value)) { _reasonContent = value; OnPropertyChanged(__.reasonContent); } }
        }

        private String _guideContent;
        /// <summary>理赔指引</summary>
        [DisplayName("理赔指引")]
        [Description("理赔指引")]
        [DataObjectField(false, false, false, 2147483647)]
        [BindColumn(14, "guideContent", "理赔指引", null, "text", 0, 0, false)]
        public virtual String guideContent
        {
            get { return _guideContent; }
            set { if (OnPropertyChanging(__.guideContent, value)) { _guideContent = value; OnPropertyChanged(__.guideContent); } }
        }

        private String _problemContent;
        /// <summary>常见问题</summary>
        [DisplayName("常见问题")]
        [Description("常见问题")]
        [DataObjectField(false, false, false, 2147483647)]
        [BindColumn(15, "problemContent", "常见问题", null, "text", 0, 0, false)]
        public virtual String problemContent
        {
            get { return _problemContent; }
            set { if (OnPropertyChanging(__.problemContent, value)) { _problemContent = value; OnPropertyChanged(__.problemContent); } }
        }

        private String _detailTopUrl;
        /// <summary>详情顶部图片</summary>
        [DisplayName("详情顶部图片")]
        [Description("详情顶部图片")]
        [DataObjectField(false, false, false, 500)]
        [BindColumn(16, "detailTopUrl", "详情顶部图片", null, "varchar(500)", 0, 0, false)]
        public virtual String detailTopUrl
        {
            get { return _detailTopUrl; }
            set { if (OnPropertyChanging(__.detailTopUrl, value)) { _detailTopUrl = value; OnPropertyChanged(__.detailTopUrl); } }
        }

        private Int32 _position;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(17, "position", "位置", null, "int", 10, 0, false)]
        public virtual Int32 position
        {
            get { return _position; }
            set { if (OnPropertyChanging(__.position, value)) { _position = value; OnPropertyChanged(__.position); } }
        }

        private Int32 _hotPosition;
        /// <summary>热门位置</summary>
        [DisplayName("热门位置")]
        [Description("热门位置")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(18, "hotPosition", "热门位置", null, "int", 10, 0, false)]
        public virtual Int32 hotPosition
        {
            get { return _hotPosition; }
            set { if (OnPropertyChanging(__.hotPosition, value)) { _hotPosition = value; OnPropertyChanged(__.hotPosition); } }
        }

        private Int32 _status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(19, "status", "状态", null, "int", 10, 0, false)]
        public virtual Int32 status
        {
            get { return _status; }
            set { if (OnPropertyChanging(__.status, value)) { _status = value; OnPropertyChanged(__.status); } }
        }

        private DateTime _publishTime;
        /// <summary>发布时间</summary>
        [DisplayName("发布时间")]
        [Description("发布时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(20, "publishTime", "发布时间", null, "datetime", 3, 0, false)]
        public virtual DateTime publishTime
        {
            get { return _publishTime; }
            set { if (OnPropertyChanging(__.publishTime, value)) { _publishTime = value; OnPropertyChanged(__.publishTime); } }
        }

        private DateTime _createTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(21, "createTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime createTime
        {
            get { return _createTime; }
            set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
        }

        private DateTime _updateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(22, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime updateTime
        {
            get { return _updateTime; }
            set { if (OnPropertyChanging(__.updateTime, value)) { _updateTime = value; OnPropertyChanged(__.updateTime); } }
        }

        private Int64 _createUid;
        /// <summary>创建者,用户表的uid</summary>
        [DisplayName("创建者,用户表的uid")]
        [Description("创建者,用户表的uid")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(23, "createUid", "创建者,用户表的uid", null, "bigint", 19, 0, false)]
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
        [BindColumn(24, "modifyUid", "修改者，用户表的uid", null, "bigint", 19, 0, false)]
        public virtual Int64 modifyUid
        {
            get { return _modifyUid; }
            set { if (OnPropertyChanging(__.modifyUid, value)) { _modifyUid = value; OnPropertyChanged(__.modifyUid); } }
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
                    case __.pid : return _pid;
                    case __.productName : return _productName;
                    case __.productType : return _productType;
                    case __.companyId : return _companyId;
                    case __.companyName : return _companyName;
                    case __.companyLogo : return _companyLogo;
                    case __.description : return _description;
                    case __.content : return _content;
                    case __.docUrl : return _docUrl;
                    case __.proAge : return _proAge;
                    case __.price : return _price;
                    case __.demoContent : return _demoContent;
                    case __.reasonContent : return _reasonContent;
                    case __.guideContent : return _guideContent;
                    case __.problemContent : return _problemContent;
                    case __.detailTopUrl : return _detailTopUrl;
                    case __.position : return _position;
                    case __.hotPosition : return _hotPosition;
                    case __.status : return _status;
                    case __.publishTime : return _publishTime;
                    case __.createTime : return _createTime;
                    case __.updateTime : return _updateTime;
                    case __.createUid : return _createUid;
                    case __.modifyUid : return _modifyUid;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.pid : _pid = Convert.ToInt64(value); break;
                    case __.productName : _productName = Convert.ToString(value); break;
                    case __.productType : _productType = Convert.ToString(value); break;
                    case __.companyId : _companyId = Convert.ToInt64(value); break;
                    case __.companyName : _companyName = Convert.ToString(value); break;
                    case __.companyLogo : _companyLogo = Convert.ToString(value); break;
                    case __.description : _description = Convert.ToString(value); break;
                    case __.content : _content = Convert.ToString(value); break;
                    case __.docUrl : _docUrl = Convert.ToString(value); break;
                    case __.proAge : _proAge = Convert.ToInt32(value); break;
                    case __.price : _price = Convert.ToDecimal(value); break;
                    case __.demoContent : _demoContent = Convert.ToString(value); break;
                    case __.reasonContent : _reasonContent = Convert.ToString(value); break;
                    case __.guideContent : _guideContent = Convert.ToString(value); break;
                    case __.problemContent : _problemContent = Convert.ToString(value); break;
                    case __.detailTopUrl : _detailTopUrl = Convert.ToString(value); break;
                    case __.position : _position = Convert.ToInt32(value); break;
                    case __.hotPosition : _hotPosition = Convert.ToInt32(value); break;
                    case __.status : _status = Convert.ToInt32(value); break;
                    case __.publishTime : _publishTime = Convert.ToDateTime(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    case __.createUid : _createUid = Convert.ToInt64(value); break;
                    case __.modifyUid : _modifyUid = Convert.ToInt64(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得产品表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>产品ID</summary>
            public static readonly Field pid = FindByName(__.pid);

            ///<summary>产品名称</summary>
            public static readonly Field productName = FindByName(__.productName);

            ///<summary>产品类型</summary>
            public static readonly Field productType = FindByName(__.productType);

            ///<summary>所属机构</summary>
            public static readonly Field companyId = FindByName(__.companyId);

            ///<summary>所属机构名称</summary>
            public static readonly Field companyName = FindByName(__.companyName);

            ///<summary>所属机构Logo</summary>
            public static readonly Field companyLogo = FindByName(__.companyLogo);

            ///<summary>产品亮点</summary>
            public static readonly Field description = FindByName(__.description);

            ///<summary>产品详情</summary>
            public static readonly Field content = FindByName(__.content);

            ///<summary>产品文档url</summary>
            public static readonly Field docUrl = FindByName(__.docUrl);

            ///<summary>承保年龄</summary>
            public static readonly Field proAge = FindByName(__.proAge);

            ///<summary>产品价格</summary>
            public static readonly Field price = FindByName(__.price);

            ///<summary>投保示例</summary>
            public static readonly Field demoContent = FindByName(__.demoContent);

            ///<summary>选择原因</summary>
            public static readonly Field reasonContent = FindByName(__.reasonContent);

            ///<summary>理赔指引</summary>
            public static readonly Field guideContent = FindByName(__.guideContent);

            ///<summary>常见问题</summary>
            public static readonly Field problemContent = FindByName(__.problemContent);

            ///<summary>详情顶部图片</summary>
            public static readonly Field detailTopUrl = FindByName(__.detailTopUrl);

            ///<summary>位置</summary>
            public static readonly Field position = FindByName(__.position);

            ///<summary>热门位置</summary>
            public static readonly Field hotPosition = FindByName(__.hotPosition);

            ///<summary>状态</summary>
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

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得产品表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>产品ID</summary>
            public const String pid = "pid";

            ///<summary>产品名称</summary>
            public const String productName = "productName";

            ///<summary>产品类型</summary>
            public const String productType = "productType";

            ///<summary>所属机构</summary>
            public const String companyId = "companyId";

            ///<summary>所属机构名称</summary>
            public const String companyName = "companyName";

            ///<summary>所属机构Logo</summary>
            public const String companyLogo = "companyLogo";

            ///<summary>产品亮点</summary>
            public const String description = "description";

            ///<summary>产品详情</summary>
            public const String content = "content";

            ///<summary>产品文档url</summary>
            public const String docUrl = "docUrl";

            ///<summary>承保年龄</summary>
            public const String proAge = "proAge";

            ///<summary>产品价格</summary>
            public const String price = "price";

            ///<summary>投保示例</summary>
            public const String demoContent = "demoContent";

            ///<summary>选择原因</summary>
            public const String reasonContent = "reasonContent";

            ///<summary>理赔指引</summary>
            public const String guideContent = "guideContent";

            ///<summary>常见问题</summary>
            public const String problemContent = "problemContent";

            ///<summary>详情顶部图片</summary>
            public const String detailTopUrl = "detailTopUrl";

            ///<summary>位置</summary>
            public const String position = "position";

            ///<summary>热门位置</summary>
            public const String hotPosition = "hotPosition";

            ///<summary>状态</summary>
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

        }
        #endregion
    }

    /// <summary>产品表接口</summary>
    public partial interface IProduct
    {
        #region 属性
        /// <summary>产品ID</summary>
        Int64 pid { get; set; }

        /// <summary>产品名称</summary>
        String productName { get; set; }

        /// <summary>产品类型</summary>
        String productType { get; set; }

        /// <summary>所属机构</summary>
        Int64 companyId { get; set; }

        /// <summary>所属机构名称</summary>
        String companyName { get; set; }

        /// <summary>所属机构Logo</summary>
        String companyLogo { get; set; }

        /// <summary>产品亮点</summary>
        String description { get; set; }

        /// <summary>产品详情</summary>
        String content { get; set; }

        /// <summary>产品文档url</summary>
        String docUrl { get; set; }

        /// <summary>承保年龄</summary>
        Int32 proAge { get; set; }

        /// <summary>产品价格</summary>
        Decimal price { get; set; }

        /// <summary>投保示例</summary>
        String demoContent { get; set; }

        /// <summary>选择原因</summary>
        String reasonContent { get; set; }

        /// <summary>理赔指引</summary>
        String guideContent { get; set; }

        /// <summary>常见问题</summary>
        String problemContent { get; set; }

        /// <summary>详情顶部图片</summary>
        String detailTopUrl { get; set; }

        /// <summary>位置</summary>
        Int32 position { get; set; }

        /// <summary>热门位置</summary>
        Int32 hotPosition { get; set; }

        /// <summary>状态</summary>
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
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}