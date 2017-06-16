﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>角色表</summary>
    [Serializable]
    [DataObject]
    [Description("角色表")]
    [BindIndex("PK_Role", true, "roleId")]
    [BindTable("Roles", Description = "角色表", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Roles : IRoles
    {
        #region 属性
        private Int64 _roleId;
        /// <summary></summary>
        [DisplayName("roleId")]
        [Description("")]
        [DataObjectField(true, false, false, 19)]
        [BindColumn(1, "roleId", "", null, "bigint", 19, 0, false)]
        public virtual Int64 roleId
        {
            get { return _roleId; }
            set { if (OnPropertyChanging(__.roleId, value)) { _roleId = value; OnPropertyChanged(__.roleId); } }
        }

        private String _roleName;
        /// <summary>角色名称</summary>
        [DisplayName("角色名称")]
        [Description("角色名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "roleName", "角色名称", null, "varchar(50)", 0, 0, false)]
        public virtual String roleName
        {
            get { return _roleName; }
            set { if (OnPropertyChanging(__.roleName, value)) { _roleName = value; OnPropertyChanged(__.roleName); } }
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
                    case __.roleId : return _roleId;
                    case __.roleName : return _roleName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.roleId : _roleId = Convert.ToInt64(value); break;
                    case __.roleName : _roleName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field roleId = FindByName(__.roleId);

            ///<summary>角色名称</summary>
            public static readonly Field roleName = FindByName(__.roleName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得角色表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String roleId = "roleId";

            ///<summary>角色名称</summary>
            public const String roleName = "roleName";

        }
        #endregion
    }

    /// <summary>角色表接口</summary>
    public partial interface IRoles
    {
        #region 属性
        /// <summary></summary>
        Int64 roleId { get; set; }

        /// <summary>角色名称</summary>
        String roleName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}