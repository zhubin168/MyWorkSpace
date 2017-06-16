﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>活动管理</summary>
    [Serializable]
    [DataObject]
    [Description("活动管理")]
    [BindIndex("PK_ACTIVE", true, "Id")]
    [BindTable("Active", Description = "活动管理", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Active : IActive
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

        private String _ImageUrl;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(2, "ImageUrl", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ImageUrl
        {
            get { return _ImageUrl; }
            set { if (OnPropertyChanging(__.ImageUrl, value)) { _ImageUrl = value; OnPropertyChanged(__.ImageUrl); } }
        }

        private String _ContentUrl;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(3, "ContentUrl", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ContentUrl
        {
            get { return _ContentUrl; }
            set { if (OnPropertyChanging(__.ContentUrl, value)) { _ContentUrl = value; OnPropertyChanged(__.ContentUrl); } }
        }

        private String _Title;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(4, "Title", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private DateTime _CreatedOn;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(5, "CreatedOn", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { if (OnPropertyChanging(__.CreatedOn, value)) { _CreatedOn = value; OnPropertyChanged(__.CreatedOn); } }
        }

        private String _CreatedByName;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(6, "CreatedByName", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String CreatedByName
        {
            get { return _CreatedByName; }
            set { if (OnPropertyChanging(__.CreatedByName, value)) { _CreatedByName = value; OnPropertyChanged(__.CreatedByName); } }
        }

        private DateTime _ModifiedOn;
        /// <summary>修改时间</summary>
        [DisplayName("修改时间")]
        [Description("修改时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(7, "ModifiedOn", "修改时间", null, "datetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging(__.ModifiedOn, value)) { _ModifiedOn = value; OnPropertyChanged(__.ModifiedOn); } }
        }

        private String _ModifiedByName;
        /// <summary>修改者名称</summary>
        [DisplayName("修改者名称")]
        [Description("修改者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(8, "ModifiedByName", "修改者名称", null, "nvarchar(150)", 0, 0, true)]
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
                    case __.ImageUrl : return _ImageUrl;
                    case __.ContentUrl : return _ContentUrl;
                    case __.Title : return _Title;
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
                    case __.ImageUrl : _ImageUrl = Convert.ToString(value); break;
                    case __.ContentUrl : _ContentUrl = Convert.ToString(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
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
        /// <summary>取得活动管理字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID(自增列)</summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>创建者名称</summary>
            public static readonly Field ImageUrl = FindByName(__.ImageUrl);

            ///<summary>创建者名称</summary>
            public static readonly Field ContentUrl = FindByName(__.ContentUrl);

            ///<summary>创建者名称</summary>
            public static readonly Field Title = FindByName(__.Title);

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

        /// <summary>取得活动管理字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID(自增列)</summary>
            public const String Id = "Id";

            ///<summary>创建者名称</summary>
            public const String ImageUrl = "ImageUrl";

            ///<summary>创建者名称</summary>
            public const String ContentUrl = "ContentUrl";

            ///<summary>创建者名称</summary>
            public const String Title = "Title";

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

    /// <summary>活动管理接口</summary>
    public partial interface IActive
    {
        #region 属性
        /// <summary>主键ID(自增列)</summary>
        Int64 Id { get; set; }

        /// <summary>创建者名称</summary>
        String ImageUrl { get; set; }

        /// <summary>创建者名称</summary>
        String ContentUrl { get; set; }

        /// <summary>创建者名称</summary>
        String Title { get; set; }

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