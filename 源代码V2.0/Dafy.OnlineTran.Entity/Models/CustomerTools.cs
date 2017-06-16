﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>获客助手</summary>
    [Serializable]
    [DataObject]
    [Description("获客助手")]
    [BindIndex("PK_CUSTOMERTOOLS", true, "Id")]
    [BindTable("CustomerTools", Description = "获客助手", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class CustomerTools : ICustomerTools
    {
        #region 属性
        private Int64 _Id;
        /// <summary>主键ID(自增列)</summary>
        [DisplayName("主键ID自增列")]
        [Description("主键ID(自增列)")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "Id", "主键ID(自增列)", null, "bigint", 19, 0, false)]
        public virtual Int64 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(2, "Title", "标题", null, "nvarchar(150)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private String _ImgType;
        /// <summary>图片类型</summary>
        [DisplayName("图片类型")]
        [Description("图片类型")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(3, "ImgType", "图片类型", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ImgType
        {
            get { return _ImgType; }
            set { if (OnPropertyChanging(__.ImgType, value)) { _ImgType = value; OnPropertyChanged(__.ImgType); } }
        }

        private String _OrderNum;
        /// <summary>排序字段</summary>
        [DisplayName("排序字段")]
        [Description("排序字段")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(4, "OrderNum", "排序字段", null, "nvarchar(150)", 0, 0, true)]
        public virtual String OrderNum
        {
            get { return _OrderNum; }
            set { if (OnPropertyChanging(__.OrderNum, value)) { _OrderNum = value; OnPropertyChanged(__.OrderNum); } }
        }

        private DateTime _PublishTime;
        /// <summary>发布时间</summary>
        [DisplayName("发布时间")]
        [Description("发布时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "PublishTime", "发布时间", null, "datetime", 3, 0, false)]
        public virtual DateTime PublishTime
        {
            get { return _PublishTime; }
            set { if (OnPropertyChanging(__.PublishTime, value)) { _PublishTime = value; OnPropertyChanged(__.PublishTime); } }
        }

        private String _ImageUrl;
        /// <summary>图片地址</summary>
        [DisplayName("图片地址")]
        [Description("图片地址")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(6, "ImageUrl", "图片地址", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ImageUrl
        {
            get { return _ImageUrl; }
            set { if (OnPropertyChanging(__.ImageUrl, value)) { _ImageUrl = value; OnPropertyChanged(__.ImageUrl); } }
        }

        private Int32 _Status;
        /// <summary>状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)</summary>
        [DisplayName("状态0：未激活1：激活失败2：已启用3：已停用4：已删除")]
        [Description("状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "Status", "状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)", "0", "int", 10, 0, false)]
        public virtual Int32 Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private DateTime _CreatedOn;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "CreatedOn", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { if (OnPropertyChanging(__.CreatedOn, value)) { _CreatedOn = value; OnPropertyChanged(__.CreatedOn); } }
        }

        private String _CreatedByName;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(9, "CreatedByName", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String CreatedByName
        {
            get { return _CreatedByName; }
            set { if (OnPropertyChanging(__.CreatedByName, value)) { _CreatedByName = value; OnPropertyChanged(__.CreatedByName); } }
        }

        private DateTime _ModifiedOn;
        /// <summary>修改时间</summary>
        [DisplayName("修改时间")]
        [Description("修改时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "ModifiedOn", "修改时间", null, "datetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging(__.ModifiedOn, value)) { _ModifiedOn = value; OnPropertyChanged(__.ModifiedOn); } }
        }

        private String _ModifiedByName;
        /// <summary>修改者名称</summary>
        [DisplayName("修改者名称")]
        [Description("修改者名称")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(11, "ModifiedByName", "修改者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ModifiedByName
        {
            get { return _ModifiedByName; }
            set { if (OnPropertyChanging(__.ModifiedByName, value)) { _ModifiedByName = value; OnPropertyChanged(__.ModifiedByName); } }
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
                    case __.Id : return _Id;
                    case __.Title : return _Title;
                    case __.ImgType : return _ImgType;
                    case __.OrderNum : return _OrderNum;
                    case __.PublishTime : return _PublishTime;
                    case __.ImageUrl : return _ImageUrl;
                    case __.Status : return _Status;
                    case __.CreatedOn : return _CreatedOn;
                    case __.CreatedByName : return _CreatedByName;
                    case __.ModifiedOn : return _ModifiedOn;
                    case __.ModifiedByName : return _ModifiedByName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt64(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.ImgType : _ImgType = Convert.ToString(value); break;
                    case __.OrderNum : _OrderNum = Convert.ToString(value); break;
                    case __.PublishTime : _PublishTime = Convert.ToDateTime(value); break;
                    case __.ImageUrl : _ImageUrl = Convert.ToString(value); break;
                    case __.Status : _Status = Convert.ToInt32(value); break;
                    case __.CreatedOn : _CreatedOn = Convert.ToDateTime(value); break;
                    case __.CreatedByName : _CreatedByName = Convert.ToString(value); break;
                    case __.ModifiedOn : _ModifiedOn = Convert.ToDateTime(value); break;
                    case __.ModifiedByName : _ModifiedByName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得获客助手字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID(自增列)</summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            ///<summary>图片类型</summary>
            public static readonly Field ImgType = FindByName(__.ImgType);

            ///<summary>排序字段</summary>
            public static readonly Field OrderNum = FindByName(__.OrderNum);

            ///<summary>发布时间</summary>
            public static readonly Field PublishTime = FindByName(__.PublishTime);

            ///<summary>图片地址</summary>
            public static readonly Field ImageUrl = FindByName(__.ImageUrl);

            ///<summary>状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>创建时间</summary>
            public static readonly Field CreatedOn = FindByName(__.CreatedOn);

            ///<summary>创建者名称</summary>
            public static readonly Field CreatedByName = FindByName(__.CreatedByName);

            ///<summary>修改时间</summary>
            public static readonly Field ModifiedOn = FindByName(__.ModifiedOn);

            ///<summary>修改者名称</summary>
            public static readonly Field ModifiedByName = FindByName(__.ModifiedByName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得获客助手字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID(自增列)</summary>
            public const String Id = "Id";

            ///<summary>标题</summary>
            public const String Title = "Title";

            ///<summary>图片类型</summary>
            public const String ImgType = "ImgType";

            ///<summary>排序字段</summary>
            public const String OrderNum = "OrderNum";

            ///<summary>发布时间</summary>
            public const String PublishTime = "PublishTime";

            ///<summary>图片地址</summary>
            public const String ImageUrl = "ImageUrl";

            ///<summary>状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)</summary>
            public const String Status = "Status";

            ///<summary>创建时间</summary>
            public const String CreatedOn = "CreatedOn";

            ///<summary>创建者名称</summary>
            public const String CreatedByName = "CreatedByName";

            ///<summary>修改时间</summary>
            public const String ModifiedOn = "ModifiedOn";

            ///<summary>修改者名称</summary>
            public const String ModifiedByName = "ModifiedByName";

        }
        #endregion
    }

    /// <summary>获客助手接口</summary>
    public partial interface ICustomerTools
    {
        #region 属性
        /// <summary>主键ID(自增列)</summary>
        Int64 Id { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>图片类型</summary>
        String ImgType { get; set; }

        /// <summary>排序字段</summary>
        String OrderNum { get; set; }

        /// <summary>发布时间</summary>
        DateTime PublishTime { get; set; }

        /// <summary>图片地址</summary>
        String ImageUrl { get; set; }

        /// <summary>状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)</summary>
        Int32 Status { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreatedOn { get; set; }

        /// <summary>创建者名称</summary>
        String CreatedByName { get; set; }

        /// <summary>修改时间</summary>
        DateTime ModifiedOn { get; set; }

        /// <summary>修改者名称</summary>
        String ModifiedByName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}