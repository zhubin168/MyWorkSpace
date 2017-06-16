using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.IService.Pc;
using Dafy.OnlineTran.Common.Request;
using System.Collections.Generic;
using System.Web;
using Dafy.OnlineTran.Common.Helpers;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 理财师管理
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    [AllowAnonymous]
    public class FinancialController : AuthController
    {
        private readonly IUserService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public FinancialController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// 客户管理列表
        /// </summary>
        [HttpPost]
        public WeixinUserRS GetUsers(WeixinUserRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new WeixinUserRS { total = 0, list = null };
            rq.roleId = 0;
            return _service.GetUsers(rq);
        }

        /// <summary>
        /// 设为理财师
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetUsers(UpdateWeixinUserRQ rq)
        {
            return _service.SetUsers(rq);
        }

        /// <summary>
        /// 理财师管理列表
        /// </summary>
        [HttpPost]
        public WeixinUserRS GetManagers(WeixinUserRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new WeixinUserRS { total = 0, list = null };
            rq.roleId = 1;
            return _service.GetManagers(rq);
        }

        /// <summary>
        /// 理财师详情
        /// </summary>
        [HttpPost]
        public WeixinUserItemRS DetailManager(DetailUserRQ rq)
        {
            rq.roleId = 1;
            return _service.DetailManager(rq);
        }

        /// <summary>
        /// 渠道管理列表
        /// </summary>
        [HttpPost]
        public WeixinUserRS GetChannels(WeixinUserRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new WeixinUserRS { total = 0, list = null };
            rq.roleId = 2;
            return _service.GetChannels(rq);
        }

        /// <summary>
        /// 渠道详情
        /// </summary>
        [HttpPost]
        public WeixinUserItemRS DetailChannel(DetailUserRQ rq)
        {
            rq.roleId = 2;
            return _service.DetailChannel(rq);
        }

        /// <summary>
        /// 编辑任务津贴
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetAllowance(DetailUserRQ rq)
        {
            return _service.SetAllowance(rq);
        }

        /// <summary>
        /// 编辑银行卡信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetBank(DetailUserRQ rq)
        {
            return _service.SetBank(rq);
        }

        /// <summary>
        /// 更改上级
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetRelation(DetailUserRQ rq)
        {
            return _service.SetRelation(rq);
        }

        /// <summary>
        /// 获取绑定操作记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public BindRecordRS GetBindRecord(BindRecordRQ rq)
        {
            return _service.GetBindRecord(rq);
        }

        /// <summary>
        /// 理财师机构修改
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetCompany(DetailUserRQ rq)
        {
            return _service.SetCompany(rq);
        }

        /// <summary>
        /// 客户详情
        /// </summary>
        [HttpPost]
        public CustormerUserRS DetailCustomer(DetailUserRQ rq)
        {
            return _service.DetailCustomer(rq);
        }

        /// <summary>
        /// 团队详情
        /// </summary>
        [HttpPost]
        public DetailMemberRS DetailMember(DetailMemberRQ rq)
        {
            return _service.DetailMember(rq);
        }

        /// <summary>
        /// 公司详情
        /// </summary>
        [HttpPost]
        public CompanyRs DetailCompany(CompanyRQ rq)
        {
            return _service.DetailCompany(rq);
        }

        /// <summary>
        /// 公司列表
        /// </summary>
        [HttpPost]
        public List<CompanyRs> GetCompanys()
        {
            return _service.GetCompanys();
        }

        /// <summary>
        /// 理财师业绩
        /// </summary>
        [HttpPost]
        public AllowanceRs GetAllowances(AllowanceRQ rq)
        {
            return _service.GetAllowances(rq);
        }

        /// <summary>
        /// 导出理财师/渠道业绩(只传roleId)
        /// </summary>
        [HttpGet]
        public HttpResponseMessage AllowancesToExcel(int roleId)
        {
            AllowanceRQ rq = new AllowanceRQ();
            rq.pageIndex = 1;
            rq.pageSize = Int32.MaxValue;
            rq.paraName = string.Empty;
            rq.roleId = roleId;
            var result = _service.GetAllowances(rq);
            var dtView = new DataTable();
            dtView.Columns.Add("ID", typeof(string));
            dtView.Columns.Add("姓名", typeof(string));
            dtView.Columns.Add("电话", typeof(string));
            dtView.Columns.Add("累计销售额", typeof(string));
            dtView.Columns.Add("本月销售额", typeof(string));
            //生成excel内容
            var list = result.list;
            for (int i = 0; i < list.Count; i++)
            {
                DataRow newRow = dtView.NewRow();
                newRow["ID"] = list[i].id;
                newRow["姓名"] = list[i].userName;
                newRow["电话"] = list[i].telphone;
                newRow["累计销售额"] = list[i].salesNums;
                newRow["本月销售额"] = list[i].monthNums;
                dtView.Rows.Add(newRow);
            }
            return ExportToCSV("理财师业绩" + DateTime.Now.ToShortDateString(), dtView, "统计");
        }

        /// <summary>
        /// 导出Excel(Csv格式)
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="dt">数据源DataTable</param>
        /// <param name="filename">导出的文件名</param>
        /// <returns>CSV格式的Excel</returns>
        public HttpResponseMessage ExportToCSV(string subject, DataTable dt, string filename)
        {
            StringBuilder str = new StringBuilder();

            //标题
            str.Append(subject + ",");
            str.Append(Environment.NewLine + ",");
            str.Append(Environment.NewLine);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                str.AppendFormat("{0},", dt.Columns[i].ColumnName);
            }
            str.Append(Environment.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    str.AppendFormat("{0},", string.IsNullOrEmpty(dr[i].ToString()) ? "0" : dr[i].ToString());
                }
                str.Append(Environment.NewLine);
            }

            byte[] strByt = System.Text.Encoding.UTF8.GetBytes(str.ToString());

            byte[] outBuffer = new byte[strByt.Length + 3];
            outBuffer[0] = (byte)0xEF;//有BOM,解决乱码
            outBuffer[1] = (byte)0xBB;
            outBuffer[2] = (byte)0xBF;
            Array.Copy(strByt, 0, outBuffer, 3, strByt.Length);

            MemoryStream ms = new MemoryStream(outBuffer);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(ms);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = filename + ".csv"
            };
            return result;
            //return File(outBuffer, "application/ms-excel");
        }

        /// <summary>
        /// 业绩详情
        /// </summary>
        [HttpPost]
        public AllowanceDetailRs GetDetailAllowances(AllowanceDetailRQ rq)
        {
            return _service.GetDetailAllowances(rq);
        }

        /// <summary>
        /// 理财师收益
        /// </summary>
        [HttpPost]
        public AllowanceRs GetIncomes(AllowanceRQ rq)
        {
            return _service.GetIncomes(rq);
        }

        /// <summary>
        /// 收益详情
        /// </summary>
        [HttpPost]
        public AllowanceDetailRs GetDetailIncomes(AllowanceDetailRQ rq)
        {
            return _service.GetDetailIncomes(rq);
        }

        /// <summary>
        /// 导入理财师收益
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<string> ImportIncomes()
        {
            //获取所有上传文件
            HttpFileCollection files = HttpContext.Current.Request.Files;
            if (files.Count == 0)
            {
                return new ResultModel<string>()
                {
                    state = 0,
                    message = "请选择文件！"
                };
            }
            //1.上传Excel到服务器 
            var data = FileHelper.UploadFile(files);
            var tempFilePath = data.data;
            //2.将Excel转换成DataSet进行解析
            DataSet dsSourceData = ExcelHelper.ExcelToDataSet(tempFilePath);
            //3.遍历并解析DataSet入库
            if (dsSourceData != null && dsSourceData.Tables[0].Rows.Count > 1)
            {
                for (var i = 2; i < dsSourceData.Tables[0].Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dsSourceData.Tables[0].Rows[i][0].ToString()))
                    {
                        continue;
                    }          
                }
                try
                {
                    return new ResultModel<string>()
                    {
                        state = 1,
                        message = "导入成功！"
                    };
                    //var result = _service.ImportEmployeesByExcel(list);
                    //if (result.state == 1)
                    //{
                    //    data.message = "导入成功!";
                    //    data.state = 1;
                    //}
                    //else
                    //{
                    //    return result;
                    //}
                }
                catch (Exception ex)
                {
                    FileHelper.DeleteDocInFolder(tempFilePath);
                    data.message = "导入报错,请调整数据!";
                    data.state = 0;
                    throw;
                }
            }
            //4.入库完毕后删除服务器Excel物理文件
            FileHelper.DeleteDocInFolder(tempFilePath);
            return data;
        }

        /// <summary>
        /// 认证审核
        /// </summary>
        [HttpPost]
        public CheckUsersRS GetCheckUsers(CheckUsersRQ rq)
        {
            return _service.GetCheckUsers(rq);
        }

        /// <summary>
        /// 审核理财师
        /// </summary>
        [HttpPost]
        public ResultModel<string> CheckUser(CheckUserRQ rq)
        {
            rq.auditUid = 100321;//Convert.ToInt32(this.User.Identity.Name);
            return _service.CheckUser(rq);
        }
    }
}
