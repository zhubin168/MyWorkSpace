﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Dafy.OnlineTran.Entity.Models
{
    /// <summary>用户表</summary>
    [Serializable]
    [DataObject]
    [Description("用户表")]
    [BindIndex("PK_User", true, "uid")]
    [BindTable("Users", Description = "用户表", ConnName = "Lomark", DbType = DatabaseType.SqlServer)]
    public partial class Users : IUsers
    {
        #region 属性
        private Int64 _uid;
        /// <summary>用户ID</summary>
        [DisplayName("用户ID")]
        [Description("用户ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn(1, "uid", "用户ID", null, "bigint", 19, 0, false)]
        public virtual Int64 uid
        {
            get { return _uid; }
            set { if (OnPropertyChanging(__.uid, value)) { _uid = value; OnPropertyChanged(__.uid); } }
        }

        private String _uname;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "uname", "用户名", null, "varchar(50)", 0, 0, false)]
        public virtual String uname
        {
            get { return _uname; }
            set { if (OnPropertyChanging(__.uname, value)) { _uname = value; OnPropertyChanged(__.uname); } }
        }

        private String _nickName;
        /// <summary>用户昵称</summary>
        [DisplayName("用户昵称")]
        [Description("用户昵称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "nickName", "用户昵称", null, "varchar(50)", 0, 0, false)]
        public virtual String nickName
        {
            get { return _nickName; }
            set { if (OnPropertyChanging(__.nickName, value)) { _nickName = value; OnPropertyChanged(__.nickName); } }
        }

        private String _password;
        /// <summary>登陆密码</summary>
        [DisplayName("登陆密码")]
        [Description("登陆密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "password", "登陆密码", null, "varchar(50)", 0, 0, false)]
        public virtual String password
        {
            get { return _password; }
            set { if (OnPropertyChanging(__.password, value)) { _password = value; OnPropertyChanged(__.password); } }
        }

        private String _weixinId;
        /// <summary>微信ID</summary>
        [DisplayName("微信ID")]
        [Description("微信ID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "weixinId", "微信ID", null, "varchar(50)", 0, 0, false)]
        public virtual String weixinId
        {
            get { return _weixinId; }
            set { if (OnPropertyChanging(__.weixinId, value)) { _weixinId = value; OnPropertyChanged(__.weixinId); } }
        }

        private Int32 _roleId;
        /// <summary>所属角色ID</summary>
        [DisplayName("所属角色ID")]
        [Description("所属角色ID")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "roleId", "所属角色ID", null, "int", 10, 0, false)]
        public virtual Int32 roleId
        {
            get { return _roleId; }
            set { if (OnPropertyChanging(__.roleId, value)) { _roleId = value; OnPropertyChanged(__.roleId); } }
        }

        private String _rank;
        /// <summary>职级</summary>
        [DisplayName("职级")]
        [Description("职级")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "rank", "职级", null, "varchar(50)", 0, 0, false)]
        public virtual String rank
        {
            get { return _rank; }
            set { if (OnPropertyChanging(__.rank, value)) { _rank = value; OnPropertyChanged(__.rank); } }
        }

        private String _phone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "phone", "电话", null, "varchar(50)", 0, 0, false)]
        public virtual String phone
        {
            get { return _phone; }
            set { if (OnPropertyChanging(__.phone, value)) { _phone = value; OnPropertyChanged(__.phone); } }
        }

        private String _headerUrl;
        /// <summary>头像地址</summary>
        [DisplayName("头像地址")]
        [Description("头像地址")]
        [DataObjectField(false, false, false, 1000)]
        [BindColumn(9, "headerUrl", "头像地址", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String headerUrl
        {
            get { return _headerUrl; }
            set { if (OnPropertyChanging(__.headerUrl, value)) { _headerUrl = value; OnPropertyChanged(__.headerUrl); } }
        }

        private Int32 _status;
        /// <summary>用户状态</summary>
        [DisplayName("用户状态")]
        [Description("用户状态")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "status", "用户状态", null, "int", 10, 0, false)]
        public virtual Int32 status
        {
            get { return _status; }
            set { if (OnPropertyChanging(__.status, value)) { _status = value; OnPropertyChanged(__.status); } }
        }

        private Int32 _auditStatus;
        /// <summary>审核状态</summary>
        [DisplayName("审核状态")]
        [Description("审核状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "auditStatus", "审核状态", null, "int", 10, 0, false)]
        public virtual Int32 auditStatus
        {
            get { return _auditStatus; }
            set { if (OnPropertyChanging(__.auditStatus, value)) { _auditStatus = value; OnPropertyChanged(__.auditStatus); } }
        }

        private DateTime _regTime;
        /// <summary>注册时间</summary>
        [DisplayName("注册时间")]
        [Description("注册时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "regTime", "注册时间", null, "datetime", 3, 0, false)]
        public virtual DateTime regTime
        {
            get { return _regTime; }
            set { if (OnPropertyChanging(__.regTime, value)) { _regTime = value; OnPropertyChanged(__.regTime); } }
        }

        private DateTime _updateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "updateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime updateTime
        {
            get { return _updateTime; }
            set { if (OnPropertyChanging(__.updateTime, value)) { _updateTime = value; OnPropertyChanged(__.updateTime); } }
        }

        private DateTime _upgradeTime;
        /// <summary>成为理财师的时间</summary>
        [DisplayName("成为理财师的时间")]
        [Description("成为理财师的时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "upgradeTime", "成为理财师的时间", null, "datetime", 3, 0, false)]
        public virtual DateTime upgradeTime
        {
            get { return _upgradeTime; }
            set { if (OnPropertyChanging(__.upgradeTime, value)) { _upgradeTime = value; OnPropertyChanged(__.upgradeTime); } }
        }

        private Int32 _isHasAllowance;
        /// <summary>是否有任务津贴</summary>
        [DisplayName("是否有任务津贴")]
        [Description("是否有任务津贴")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "isHasAllowance", "是否有任务津贴", null, "int", 10, 0, false)]
        public virtual Int32 isHasAllowance
        {
            get { return _isHasAllowance; }
            set { if (OnPropertyChanging(__.isHasAllowance, value)) { _isHasAllowance = value; OnPropertyChanged(__.isHasAllowance); } }
        }

        private String _idNumber;
        /// <summary>身份证号</summary>
        [DisplayName("身份证号")]
        [Description("身份证号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "idNumber", "身份证号", null, "varchar(50)", 0, 0, false)]
        public virtual String idNumber
        {
            get { return _idNumber; }
            set { if (OnPropertyChanging(__.idNumber, value)) { _idNumber = value; OnPropertyChanged(__.idNumber); } }
        }

        private String _bankNumber;
        /// <summary>银行卡号</summary>
        [DisplayName("银行卡号")]
        [Description("银行卡号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "bankNumber", "银行卡号", null, "varchar(50)", 0, 0, false)]
        public virtual String bankNumber
        {
            get { return _bankNumber; }
            set { if (OnPropertyChanging(__.bankNumber, value)) { _bankNumber = value; OnPropertyChanged(__.bankNumber); } }
        }

        private String _bankName;
        /// <summary></summary>
        [DisplayName("bankName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "bankName", "", null, "varchar(50)", 0, 0, false)]
        public virtual String bankName
        {
            get { return _bankName; }
            set { if (OnPropertyChanging(__.bankName, value)) { _bankName = value; OnPropertyChanged(__.bankName); } }
        }

        private Int32 _companyId;
        /// <summary>所属公司</summary>
        [DisplayName("所属公司")]
        [Description("所属公司")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(19, "companyId", "所属公司", null, "int", 10, 0, false)]
        public virtual Int32 companyId
        {
            get { return _companyId; }
            set { if (OnPropertyChanging(__.companyId, value)) { _companyId = value; OnPropertyChanged(__.companyId); } }
        }

        private Int32 _loginPC;
        /// <summary>能否能登陆后台</summary>
        [DisplayName("能否能登陆后台")]
        [Description("能否能登陆后台")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(20, "loginPC", "能否能登陆后台", null, "int", 10, 0, false)]
        public virtual Int32 loginPC
        {
            get { return _loginPC; }
            set { if (OnPropertyChanging(__.loginPC, value)) { _loginPC = value; OnPropertyChanged(__.loginPC); } }
        }

        private DateTime _loginTime;
        /// <summary>最近登陆时间</summary>
        [DisplayName("最近登陆时间")]
        [Description("最近登陆时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(21, "loginTime", "最近登陆时间", null, "datetime", 3, 0, false)]
        public virtual DateTime loginTime
        {
            get { return _loginTime; }
            set { if (OnPropertyChanging(__.loginTime, value)) { _loginTime = value; OnPropertyChanged(__.loginTime); } }
        }

        private String _bankPerson;
        /// <summary></summary>
        [DisplayName("bankPerson")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "bankPerson", "", null, "varchar(50)", 0, 0, false)]
        public virtual String bankPerson
        {
            get { return _bankPerson; }
            set { if (OnPropertyChanging(__.bankPerson, value)) { _bankPerson = value; OnPropertyChanged(__.bankPerson); } }
        }

        private String _remark;
        /// <summary></summary>
        [DisplayName("remark")]
        [Description("")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn(23, "remark", "", null, "nvarchar(1000)", 0, 0, true)]
        public virtual String remark
        {
            get { return _remark; }
            set { if (OnPropertyChanging(__.remark, value)) { _remark = value; OnPropertyChanged(__.remark); } }
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
                    case __.uid : return _uid;
                    case __.uname : return _uname;
                    case __.nickName : return _nickName;
                    case __.password : return _password;
                    case __.weixinId : return _weixinId;
                    case __.roleId : return _roleId;
                    case __.rank : return _rank;
                    case __.phone : return _phone;
                    case __.headerUrl : return _headerUrl;
                    case __.status : return _status;
                    case __.auditStatus : return _auditStatus;
                    case __.regTime : return _regTime;
                    case __.updateTime : return _updateTime;
                    case __.upgradeTime : return _upgradeTime;
                    case __.isHasAllowance : return _isHasAllowance;
                    case __.idNumber : return _idNumber;
                    case __.bankNumber : return _bankNumber;
                    case __.bankName : return _bankName;
                    case __.companyId : return _companyId;
                    case __.loginPC : return _loginPC;
                    case __.loginTime : return _loginTime;
                    case __.bankPerson : return _bankPerson;
                    case __.remark : return _remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.uid : _uid = Convert.ToInt64(value); break;
                    case __.uname : _uname = Convert.ToString(value); break;
                    case __.nickName : _nickName = Convert.ToString(value); break;
                    case __.password : _password = Convert.ToString(value); break;
                    case __.weixinId : _weixinId = Convert.ToString(value); break;
                    case __.roleId : _roleId = Convert.ToInt32(value); break;
                    case __.rank : _rank = Convert.ToString(value); break;
                    case __.phone : _phone = Convert.ToString(value); break;
                    case __.headerUrl : _headerUrl = Convert.ToString(value); break;
                    case __.status : _status = Convert.ToInt32(value); break;
                    case __.auditStatus : _auditStatus = Convert.ToInt32(value); break;
                    case __.regTime : _regTime = Convert.ToDateTime(value); break;
                    case __.updateTime : _updateTime = Convert.ToDateTime(value); break;
                    case __.upgradeTime : _upgradeTime = Convert.ToDateTime(value); break;
                    case __.isHasAllowance : _isHasAllowance = Convert.ToInt32(value); break;
                    case __.idNumber : _idNumber = Convert.ToString(value); break;
                    case __.bankNumber : _bankNumber = Convert.ToString(value); break;
                    case __.bankName : _bankName = Convert.ToString(value); break;
                    case __.companyId : _companyId = Convert.ToInt32(value); break;
                    case __.loginPC : _loginPC = Convert.ToInt32(value); break;
                    case __.loginTime : _loginTime = Convert.ToDateTime(value); break;
                    case __.bankPerson : _bankPerson = Convert.ToString(value); break;
                    case __.remark : _remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>用户ID</summary>
            public static readonly Field uid = FindByName(__.uid);

            ///<summary>用户名</summary>
            public static readonly Field uname = FindByName(__.uname);

            ///<summary>用户昵称</summary>
            public static readonly Field nickName = FindByName(__.nickName);

            ///<summary>登陆密码</summary>
            public static readonly Field password = FindByName(__.password);

            ///<summary>微信ID</summary>
            public static readonly Field weixinId = FindByName(__.weixinId);

            ///<summary>所属角色ID</summary>
            public static readonly Field roleId = FindByName(__.roleId);

            ///<summary>职级</summary>
            public static readonly Field rank = FindByName(__.rank);

            ///<summary>电话</summary>
            public static readonly Field phone = FindByName(__.phone);

            ///<summary>头像地址</summary>
            public static readonly Field headerUrl = FindByName(__.headerUrl);

            ///<summary>用户状态</summary>
            public static readonly Field status = FindByName(__.status);

            ///<summary>审核状态</summary>
            public static readonly Field auditStatus = FindByName(__.auditStatus);

            ///<summary>注册时间</summary>
            public static readonly Field regTime = FindByName(__.regTime);

            ///<summary>更新时间</summary>
            public static readonly Field updateTime = FindByName(__.updateTime);

            ///<summary>成为理财师的时间</summary>
            public static readonly Field upgradeTime = FindByName(__.upgradeTime);

            ///<summary>是否有任务津贴</summary>
            public static readonly Field isHasAllowance = FindByName(__.isHasAllowance);

            ///<summary>身份证号</summary>
            public static readonly Field idNumber = FindByName(__.idNumber);

            ///<summary>银行卡号</summary>
            public static readonly Field bankNumber = FindByName(__.bankNumber);

            ///<summary></summary>
            public static readonly Field bankName = FindByName(__.bankName);

            ///<summary>所属公司</summary>
            public static readonly Field companyId = FindByName(__.companyId);

            ///<summary>能否能登陆后台</summary>
            public static readonly Field loginPC = FindByName(__.loginPC);

            ///<summary>最近登陆时间</summary>
            public static readonly Field loginTime = FindByName(__.loginTime);

            ///<summary></summary>
            public static readonly Field bankPerson = FindByName(__.bankPerson);

            ///<summary></summary>
            public static readonly Field remark = FindByName(__.remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得用户表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>用户ID</summary>
            public const String uid = "uid";

            ///<summary>用户名</summary>
            public const String uname = "uname";

            ///<summary>用户昵称</summary>
            public const String nickName = "nickName";

            ///<summary>登陆密码</summary>
            public const String password = "password";

            ///<summary>微信ID</summary>
            public const String weixinId = "weixinId";

            ///<summary>所属角色ID</summary>
            public const String roleId = "roleId";

            ///<summary>职级</summary>
            public const String rank = "rank";

            ///<summary>电话</summary>
            public const String phone = "phone";

            ///<summary>头像地址</summary>
            public const String headerUrl = "headerUrl";

            ///<summary>用户状态</summary>
            public const String status = "status";

            ///<summary>审核状态</summary>
            public const String auditStatus = "auditStatus";

            ///<summary>注册时间</summary>
            public const String regTime = "regTime";

            ///<summary>更新时间</summary>
            public const String updateTime = "updateTime";

            ///<summary>成为理财师的时间</summary>
            public const String upgradeTime = "upgradeTime";

            ///<summary>是否有任务津贴</summary>
            public const String isHasAllowance = "isHasAllowance";

            ///<summary>身份证号</summary>
            public const String idNumber = "idNumber";

            ///<summary>银行卡号</summary>
            public const String bankNumber = "bankNumber";

            ///<summary></summary>
            public const String bankName = "bankName";

            ///<summary>所属公司</summary>
            public const String companyId = "companyId";

            ///<summary>能否能登陆后台</summary>
            public const String loginPC = "loginPC";

            ///<summary>最近登陆时间</summary>
            public const String loginTime = "loginTime";

            ///<summary></summary>
            public const String bankPerson = "bankPerson";

            ///<summary></summary>
            public const String remark = "remark";

        }
        #endregion
    }

    /// <summary>用户表接口</summary>
    public partial interface IUsers
    {
        #region 属性
        /// <summary>用户ID</summary>
        Int64 uid { get; set; }

        /// <summary>用户名</summary>
        String uname { get; set; }

        /// <summary>用户昵称</summary>
        String nickName { get; set; }

        /// <summary>登陆密码</summary>
        String password { get; set; }

        /// <summary>微信ID</summary>
        String weixinId { get; set; }

        /// <summary>所属角色ID</summary>
        Int32 roleId { get; set; }

        /// <summary>职级</summary>
        String rank { get; set; }

        /// <summary>电话</summary>
        String phone { get; set; }

        /// <summary>头像地址</summary>
        String headerUrl { get; set; }

        /// <summary>用户状态</summary>
        Int32 status { get; set; }

        /// <summary>审核状态</summary>
        Int32 auditStatus { get; set; }

        /// <summary>注册时间</summary>
        DateTime regTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime updateTime { get; set; }

        /// <summary>成为理财师的时间</summary>
        DateTime upgradeTime { get; set; }

        /// <summary>是否有任务津贴</summary>
        Int32 isHasAllowance { get; set; }

        /// <summary>身份证号</summary>
        String idNumber { get; set; }

        /// <summary>银行卡号</summary>
        String bankNumber { get; set; }

        /// <summary></summary>
        String bankName { get; set; }

        /// <summary>所属公司</summary>
        Int32 companyId { get; set; }

        /// <summary>能否能登陆后台</summary>
        Int32 loginPC { get; set; }

        /// <summary>最近登陆时间</summary>
        DateTime loginTime { get; set; }

        /// <summary></summary>
        String bankPerson { get; set; }

        /// <summary></summary>
        String remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}