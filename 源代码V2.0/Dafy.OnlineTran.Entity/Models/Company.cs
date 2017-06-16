﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>公司部门职位表</summary>
    [Serializable]
    [DataObject]
    [Description("公司部门职位表")]
    [BindIndex("PK_COMPANY", true, "Id")]
    [BindIndex("IX_Company_CompanyName", false, "CompanyName")]
    [BindRelation("Id", true, "Product", "companyId")]
    [BindRelation("CompanyName", false, "Product", "companyName")]
    [BindTable("Company", Description = "公司部门职位表", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Company : ICompany
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

        private String _CompanyName;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(2, "CompanyName", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String CompanyName
        {
            get { return _CompanyName; }
            set { if (OnPropertyChanging(__.CompanyName, value)) { _CompanyName = value; OnPropertyChanged(__.CompanyName); } }
        }

        private String _DepartmentName;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(3, "DepartmentName", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String DepartmentName
        {
            get { return _DepartmentName; }
            set { if (OnPropertyChanging(__.DepartmentName, value)) { _DepartmentName = value; OnPropertyChanged(__.DepartmentName); } }
        }

        private String _Postion;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(4, "Postion", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String Postion
        {
            get { return _Postion; }
            set { if (OnPropertyChanging(__.Postion, value)) { _Postion = value; OnPropertyChanged(__.Postion); } }
        }

        private String _CityId;
        /// <summary>创建者名称</summary>
        [DisplayName("创建者名称")]
        [Description("创建者名称")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(5, "CityId", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String CityId
        {
            get { return _CityId; }
            set { if (OnPropertyChanging(__.CityId, value)) { _CityId = value; OnPropertyChanged(__.CityId); } }
        }

        private DateTime _CreatedOn;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "CreatedOn", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(7, "CreatedByName", "创建者名称", null, "nvarchar(150)", 0, 0, true)]
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
        [BindColumn(8, "ModifiedOn", "修改时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(9, "ModifiedByName", "修改者名称", null, "nvarchar(150)", 0, 0, true)]
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
                    case __.CompanyName : return _CompanyName;
                    case __.DepartmentName : return _DepartmentName;
                    case __.Postion : return _Postion;
                    case __.CityId : return _CityId;
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
                    case __.CompanyName : _CompanyName = Convert.ToString(value); break;
                    case __.DepartmentName : _DepartmentName = Convert.ToString(value); break;
                    case __.Postion : _Postion = Convert.ToString(value); break;
                    case __.CityId : _CityId = Convert.ToString(value); break;
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
        /// <summary>取得公司部门职位表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID(自增列)</summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>创建者名称</summary>
            public static readonly Field CompanyName = FindByName(__.CompanyName);

            ///<summary>创建者名称</summary>
            public static readonly Field DepartmentName = FindByName(__.DepartmentName);

            ///<summary>创建者名称</summary>
            public static readonly Field Postion = FindByName(__.Postion);

            ///<summary>创建者名称</summary>
            public static readonly Field CityId = FindByName(__.CityId);

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

        /// <summary>取得公司部门职位表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID(自增列)</summary>
            public const String Id = "Id";

            ///<summary>创建者名称</summary>
            public const String CompanyName = "CompanyName";

            ///<summary>创建者名称</summary>
            public const String DepartmentName = "DepartmentName";

            ///<summary>创建者名称</summary>
            public const String Postion = "Postion";

            ///<summary>创建者名称</summary>
            public const String CityId = "CityId";

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

    /// <summary>公司部门职位表接口</summary>
    public partial interface ICompany
    {
        #region 属性
        /// <summary>主键ID(自增列)</summary>
        Int64 Id { get; set; }

        /// <summary>创建者名称</summary>
        String CompanyName { get; set; }

        /// <summary>创建者名称</summary>
        String DepartmentName { get; set; }

        /// <summary>创建者名称</summary>
        String Postion { get; set; }

        /// <summary>创建者名称</summary>
        String CityId { get; set; }

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