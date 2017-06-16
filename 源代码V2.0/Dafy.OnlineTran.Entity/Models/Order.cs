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
    [BindIndex("PK__Order__C2FFCF130CBAE877", true, "oid")]
    [BindIndex("IX_Order_productId", false, "productId")]
    [BindIndex("IX_Order_productName", false, "productName")]
    [BindIndex("IX_Order_productType", false, "productType")]
    [BindRelation("productId", false, "Product", "pid")]
    [BindRelation("productName", false, "Product", "productName")]
    [BindRelation("productType", false, "Product", "productType")]
    [BindTable("Order", Description = "", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Order : IOrder
    {
        #region 属性
        private Int64 _oid;
        /// <summary>预约号</summary>
        [DisplayName("预约号")]
        [Description("预约号")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "oid", "预约号", null, "bigint", 19, 0, false)]
        public virtual Int64 oid
        {
            get { return _oid; }
            set { if (OnPropertyChanging(__.oid, value)) { _oid = value; OnPropertyChanged(__.oid); } }
        }

        private Int64 _uid;
        /// <summary>理财师ID</summary>
        [DisplayName("理财师ID")]
        [Description("理财师ID")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(2, "uid", "理财师ID", null, "bigint", 19, 0, false)]
        public virtual Int64 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private String _uname;
        /// <summary>理财师姓名</summary>
        [DisplayName("理财师姓名")]
        [Description("理财师姓名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "uname", "理财师姓名", null, "varchar(50)", 0, 0, false)]
        public virtual String uname
        {
            get { return _uname; }
            set { if (OnPropertyChanging(__.uname, value)) { _uname = value; OnPropertyChanged(__.uname); } }
        }

        private Int64 _productId;
        /// <summary>产品ID</summary>
        [DisplayName("产品ID")]
        [Description("产品ID")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(4, "productId", "产品ID", null, "bigint", 19, 0, false)]
        public virtual Int64 productId
        {
            get { return _productId; }
            set { if (OnPropertyChanging(__.productId, value)) { _productId = value; OnPropertyChanged(__.productId); } }
        }

        private String _productName;
        /// <summary>产品名称</summary>
        [DisplayName("产品名称")]
        [Description("产品名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "productName", "产品名称", null, "varchar(50)", 0, 0, false)]
        public virtual String productName
        {
            get { return _productName; }
            set { if (OnPropertyChanging(__.productName, value)) { _productName = value; OnPropertyChanged(__.productName); } }
        }

        private String _productType;
        /// <summary>产品类型</summary>
        [DisplayName("产品类型")]
        [Description("产品类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "productType", "产品类型", null, "varchar(50)", 0, 0, false)]
        public virtual String productType
        {
            get { return _productType; }
            set { if (OnPropertyChanging(__.productType, value)) { _productType = value; OnPropertyChanged(__.productType); } }
        }

        private Decimal _prodcutPrice;
        /// <summary>产品价格</summary>
        [DisplayName("产品价格")]
        [Description("产品价格")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(7, "prodcutPrice", "产品价格", null, "money", 19, 4, false)]
        public virtual Decimal prodcutPrice
        {
            get { return _prodcutPrice; }
            set { if (OnPropertyChanging(__.prodcutPrice, value)) { _prodcutPrice = value; OnPropertyChanged(__.prodcutPrice); } }
        }

        private Int64 _clientUid;
        /// <summary>客户ID</summary>
        [DisplayName("客户ID")]
        [Description("客户ID")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(8, "clientUid", "客户ID", null, "bigint", 19, 0, false)]
        public virtual Int64 clientUid
        {
            get { return _clientUid; }
            set { if (OnPropertyChanging(__.clientUid, value)) { _clientUid = value; OnPropertyChanged(__.clientUid); } }
        }

        private String _clientName;
        /// <summary>客户姓名</summary>
        [DisplayName("客户姓名")]
        [Description("客户姓名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "clientName", "客户姓名", null, "varchar(50)", 0, 0, false)]
        public virtual String clientName
        {
            get { return _clientName; }
            set { if (OnPropertyChanging(__.clientName, value)) { _clientName = value; OnPropertyChanged(__.clientName); } }
        }

        private String _clientPhone;
        /// <summary>客户电话</summary>
        [DisplayName("客户电话")]
        [Description("客户电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "clientPhone", "客户电话", null, "varchar(50)", 0, 0, false)]
        public virtual String clientPhone
        {
            get { return _clientPhone; }
            set { if (OnPropertyChanging(__.clientPhone, value)) { _clientPhone = value; OnPropertyChanged(__.clientPhone); } }
        }

        private Int32 _total;
        /// <summary>购买数量</summary>
        [DisplayName("购买数量")]
        [Description("购买数量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "total", "购买数量", null, "int", 10, 0, false)]
        public virtual Int32 total
        {
            get { return _total; }
            set { if (OnPropertyChanging(__.total, value)) { _total = value; OnPropertyChanged(__.total); } }
        }

        private Int32 _status;
        /// <summary>预约状态</summary>
        [DisplayName("预约状态")]
        [Description("预约状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "status", "预约状态", null, "int", 10, 0, false)]
        public virtual Int32 status
        {
            get { return _status; }
            set { if (OnPropertyChanging(__.status, value)) { _status = value; OnPropertyChanged(__.status); } }
        }

        private DateTime _createTime;
        /// <summary>订单时间</summary>
        [DisplayName("订单时间")]
        [Description("订单时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "createTime", "订单时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(14, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime updateTime
        {
            get { return _updateTime; }
            set { if (OnPropertyChanging(__.updateTime, value)) { _updateTime = value; OnPropertyChanged(__.updateTime); } }
        }

        private String _record;
        /// <summary>操作记录</summary>
        [DisplayName("操作记录")]
        [Description("操作记录")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(15, "record", "操作记录", null, "text", 0, 0, false)]
        public virtual String record
        {
            get { return _record; }
            set { if (OnPropertyChanging(__.record, value)) { _record = value; OnPropertyChanged(__.record); } }
        }

        private Int32 _sex;
        /// <summary>1:男;0:女</summary>
        [DisplayName("1:男;0:女")]
        [Description("1:男;0:女")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(16, "sex", "1:男;0:女", null, "int", 10, 0, false)]
        public virtual Int32 sex
        {
            get { return _sex; }
            set { if (OnPropertyChanging(__.sex, value)) { _sex = value; OnPropertyChanged(__.sex); } }
        }

        private Decimal _income;
        /// <summary></summary>
        [DisplayName("income")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(17, "income", "", null, "money", 19, 4, false)]
        public virtual Decimal income
        {
            get { return _income; }
            set { if (OnPropertyChanging(__.income, value)) { _income = value; OnPropertyChanged(__.income); } }
        }

        private Decimal _rate1;
        /// <summary></summary>
        [DisplayName("rate1")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(18, "rate1", "", null, "money", 19, 4, false)]
        public virtual Decimal rate1
        {
            get { return _rate1; }
            set { if (OnPropertyChanging(__.rate1, value)) { _rate1 = value; OnPropertyChanged(__.rate1); } }
        }

        private Decimal _rate2;
        /// <summary></summary>
        [DisplayName("rate2")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(19, "rate2", "", null, "money", 19, 4, false)]
        public virtual Decimal rate2
        {
            get { return _rate2; }
            set { if (OnPropertyChanging(__.rate2, value)) { _rate2 = value; OnPropertyChanged(__.rate2); } }
        }

        private Decimal _rate3;
        /// <summary></summary>
        [DisplayName("rate3")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(20, "rate3", "", null, "money", 19, 4, false)]
        public virtual Decimal rate3
        {
            get { return _rate3; }
            set { if (OnPropertyChanging(__.rate3, value)) { _rate3 = value; OnPropertyChanged(__.rate3); } }
        }

        private Decimal _rate4;
        /// <summary></summary>
        [DisplayName("rate4")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(21, "rate4", "", null, "money", 19, 4, false)]
        public virtual Decimal rate4
        {
            get { return _rate4; }
            set { if (OnPropertyChanging(__.rate4, value)) { _rate4 = value; OnPropertyChanged(__.rate4); } }
        }

        private Decimal _rate5;
        /// <summary></summary>
        [DisplayName("rate5")]
        [Description("")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(22, "rate5", "", null, "money", 19, 4, false)]
        public virtual Decimal rate5
        {
            get { return _rate5; }
            set { if (OnPropertyChanging(__.rate5, value)) { _rate5 = value; OnPropertyChanged(__.rate5); } }
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
                    case __.oid : return _oid;
                    case __.uid : return _uid;
                    case __.uname : return _uname;
                    case __.productId : return _productId;
                    case __.productName : return _productName;
                    case __.productType : return _productType;
                    case __.prodcutPrice : return _prodcutPrice;
                    case __.clientUid : return _clientUid;
                    case __.clientName : return _clientName;
                    case __.clientPhone : return _clientPhone;
                    case __.total : return _total;
                    case __.status : return _status;
                    case __.createTime : return _createTime;
                    case __.updateTime : return _updateTime;
                    case __.record : return _record;
                    case __.sex : return _sex;
                    case __.income : return _income;
                    case __.rate1 : return _rate1;
                    case __.rate2 : return _rate2;
                    case __.rate3 : return _rate3;
                    case __.rate4 : return _rate4;
                    case __.rate5 : return _rate5;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.oid : _oid = Convert.ToInt64(value); break;
                    case __.uid : _uid = Convert.ToInt64(value); break;
                    case __.uname : _uname = Convert.ToString(value); break;
                    case __.productId : _productId = Convert.ToInt64(value); break;
                    case __.productName : _productName = Convert.ToString(value); break;
                    case __.productType : _productType = Convert.ToString(value); break;
                    case __.prodcutPrice : _prodcutPrice = Convert.ToDecimal(value); break;
                    case __.clientUid : _clientUid = Convert.ToInt64(value); break;
                    case __.clientName : _clientName = Convert.ToString(value); break;
                    case __.clientPhone : _clientPhone = Convert.ToString(value); break;
                    case __.total : _total = Convert.ToInt32(value); break;
                    case __.status : _status = Convert.ToInt32(value); break;
                    case __.createTime : _createTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    case __.record : _record = Convert.ToString(value); break;
                    case __.sex : _sex = Convert.ToInt32(value); break;
                    case __.income : _income = Convert.ToDecimal(value); break;
                    case __.rate1 : _rate1 = Convert.ToDecimal(value); break;
                    case __.rate2 : _rate2 = Convert.ToDecimal(value); break;
                    case __.rate3 : _rate3 = Convert.ToDecimal(value); break;
                    case __.rate4 : _rate4 = Convert.ToDecimal(value); break;
                    case __.rate5 : _rate5 = Convert.ToDecimal(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>预约号</summary>
            public static readonly Field oid = FindByName(__.oid);

            ///<summary>理财师ID</summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary>理财师姓名</summary>
            public static readonly Field uname = FindByName(__.uname);

            ///<summary>产品ID</summary>
            public static readonly Field productId = FindByName(__.productId);

            ///<summary>产品名称</summary>
            public static readonly Field productName = FindByName(__.productName);

            ///<summary>产品类型</summary>
            public static readonly Field productType = FindByName(__.productType);

            ///<summary>产品价格</summary>
            public static readonly Field prodcutPrice = FindByName(__.prodcutPrice);

            ///<summary>客户ID</summary>
            public static readonly Field clientUid = FindByName(__.clientUid);

            ///<summary>客户姓名</summary>
            public static readonly Field clientName = FindByName(__.clientName);

            ///<summary>客户电话</summary>
            public static readonly Field clientPhone = FindByName(__.clientPhone);

            ///<summary>购买数量</summary>
            public static readonly Field total = FindByName(__.total);

            ///<summary>预约状态</summary>
            public static readonly Field status = FindByName(__.status);

            ///<summary>订单时间</summary>
            public static readonly Field createTime = FindByName(__.createTime);

            ///<summary>更新时间</summary>
            public static readonly Field updateTime = FindByName(__.updateTime);

            ///<summary>操作记录</summary>
            public static readonly Field record = FindByName(__.record);

            ///<summary>1:男;0:女</summary>
            public static readonly Field sex = FindByName(__.sex);

            ///<summary></summary>
            public static readonly Field income = FindByName(__.income);

            ///<summary></summary>
            public static readonly Field rate1 = FindByName(__.rate1);

            ///<summary></summary>
            public static readonly Field rate2 = FindByName(__.rate2);

            ///<summary></summary>
            public static readonly Field rate3 = FindByName(__.rate3);

            ///<summary></summary>
            public static readonly Field rate4 = FindByName(__.rate4);

            ///<summary></summary>
            public static readonly Field rate5 = FindByName(__.rate5);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>预约号</summary>
            public const String oid = "oid";

            ///<summary>理财师ID</summary>
            public const String uid = "uid";

            ///<summary>理财师姓名</summary>
            public const String uname = "uname";

            ///<summary>产品ID</summary>
            public const String productId = "productId";

            ///<summary>产品名称</summary>
            public const String productName = "productName";

            ///<summary>产品类型</summary>
            public const String productType = "productType";

            ///<summary>产品价格</summary>
            public const String prodcutPrice = "prodcutPrice";

            ///<summary>客户ID</summary>
            public const String clientUid = "clientUid";

            ///<summary>客户姓名</summary>
            public const String clientName = "clientName";

            ///<summary>客户电话</summary>
            public const String clientPhone = "clientPhone";

            ///<summary>购买数量</summary>
            public const String total = "total";

            ///<summary>预约状态</summary>
            public const String status = "status";

            ///<summary>订单时间</summary>
            public const String createTime = "createTime";

            ///<summary>更新时间</summary>
            public const String updateTime = "updateTime";

            ///<summary>操作记录</summary>
            public const String record = "record";

            ///<summary>1:男;0:女</summary>
            public const String sex = "sex";

            ///<summary></summary>
            public const String income = "income";

            ///<summary></summary>
            public const String rate1 = "rate1";

            ///<summary></summary>
            public const String rate2 = "rate2";

            ///<summary></summary>
            public const String rate3 = "rate3";

            ///<summary></summary>
            public const String rate4 = "rate4";

            ///<summary></summary>
            public const String rate5 = "rate5";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IOrder
    {
        #region 属性
        /// <summary>预约号</summary>
        Int64 oid { get; set; }

        /// <summary>理财师ID</summary>
        Int64 uid { get; set; }

        /// <summary>理财师姓名</summary>
        String uname { get; set; }

        /// <summary>产品ID</summary>
        Int64 productId { get; set; }

        /// <summary>产品名称</summary>
        String productName { get; set; }

        /// <summary>产品类型</summary>
        String productType { get; set; }

        /// <summary>产品价格</summary>
        Decimal prodcutPrice { get; set; }

        /// <summary>客户ID</summary>
        Int64 clientUid { get; set; }

        /// <summary>客户姓名</summary>
        String clientName { get; set; }

        /// <summary>客户电话</summary>
        String clientPhone { get; set; }

        /// <summary>购买数量</summary>
        Int32 total { get; set; }

        /// <summary>预约状态</summary>
        Int32 status { get; set; }

        /// <summary>订单时间</summary>
        DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime updateTime { get; set; }

        /// <summary>操作记录</summary>
        String record { get; set; }

        /// <summary>1:男;0:女</summary>
        Int32 sex { get; set; }

        /// <summary></summary>
        Decimal income { get; set; }

        /// <summary></summary>
        Decimal rate1 { get; set; }

        /// <summary></summary>
        Decimal rate2 { get; set; }

        /// <summary></summary>
        Decimal rate3 { get; set; }

        /// <summary></summary>
        Decimal rate4 { get; set; }

        /// <summary></summary>
        Decimal rate5 { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}