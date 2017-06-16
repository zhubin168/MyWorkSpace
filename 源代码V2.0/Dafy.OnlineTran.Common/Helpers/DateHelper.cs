using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Helpers
{
    /// <summary>
    /// 获取日期公共方法
    /// 创建人：朱斌
    /// 创建时间：2014-02-20
    /// </summary>
    public class DateHelper
    {
        public static string dateFormat = "MM-dd";
        public static string dateFormat2 = "yyyy-MM-dd";
        public static string dateFormat3 = "MM/dd";

        /// <summary>
        /// 获取时间区间内的日期集合
        /// 创建人：朱斌
        /// 创建时间：2014-02-20
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>日期集合</returns>
        public static List<string> ConditionDays(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            TimeSpan ts = end - start;
            DateTime dtTemp;
            List<string> lstDiffDays = new List<string>();
            List<string> lstTempMons = new List<string>();

            lstDiffDays.Add(start.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            for (int i = 1; i < ts.Days; i++)
            {
                dtTemp = start.AddDays(i);
                lstDiffDays.Add(dtTemp.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            if (start != end)
            {
                lstDiffDays.Add(end.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            return lstDiffDays;
        }

        /// <summary>
        /// 获取时间区间内的日期集合
        /// 创建人：朱斌
        /// 创建时间：2014-02-20
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>日期集合</returns>
        public static List<string> DiffDays(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            TimeSpan ts = end - start;
            DateTime dtTemp;
            List<string> lstDiffDays = new List<string>();
            List<string> lstTempMons = new List<string>();

            lstDiffDays.Add(start.ToString(dateFormat3, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            for (int i = 1; i < ts.Days; i++)
            {
                dtTemp = start.AddDays(i);
                lstDiffDays.Add(dtTemp.ToString(dateFormat3, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            if (start != end)
            {
                lstDiffDays.Add(end.ToString(dateFormat3, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            return lstDiffDays;
        }

        /// <summary>
        /// 获取时间区间内的日期集合
        /// 创建人：朱斌
        /// 创建时间：2014-02-20
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="lstMonths">输出跨越的月份集合</param>
        /// <param name="lsCounts">输出跨越的月份每月天数集合</param>
        /// <returns>日期集合</returns>
        public static List<string> DiffDays(string startDate, string endDate, out List<string> lstMonths, out List<int> lsCounts)
        {
            lsCounts = new List<int>();
            //获取月份集合
            lstMonths = DiffMonth(startDate, endDate);
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            TimeSpan ts = end - start;
            DateTime dtTemp;
            List<string> lstDiffDays = new List<string>();
            List<string> lstTempMons = new List<string>();

            lstDiffDays.Add(start.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            for (int i = 1; i < ts.Days; i++)
            {
                dtTemp = start.AddDays(i);
                lstDiffDays.Add(dtTemp.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            if (start != end)
            {
                lstDiffDays.Add(end.ToString(dateFormat2, System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }
            //遍历月份集合，从日期集合中匹配输入这个月份的天数，并添加到天数数组中
            foreach (string mon in lstMonths)
            {
                lsCounts.Add(Array.FindAll(lstDiffDays.ToArray(), (s) => s.Contains(mon)).Length);
            }
            return lstDiffDays;
        }

        /// <summary>
        /// 计算两个日期中间的月份值集合
        /// 创建人：朱斌
        /// 创建时间：2014-02-20
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>月份集合</returns>
        public static List<string> DiffMonth(string startDate, string endDate)
        {
            List<string> lstMonths = new List<string>();

            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            int startMonth = start.Month;
            int endMonth = end.Month;

            //同一年
            if (start.Year == end.Year)
            {
                //同一年同一个月份
                if (startMonth == end.Month)
                {
                    lstMonths.Add(start.Year.ToString() + "-" + FormatMonth(startMonth));
                    return lstMonths;
                }
                //同一年不同月份
                if (endMonth > startMonth)
                {
                    lstMonths.Add(start.Year.ToString() + "-" + FormatMonth(startMonth));
                    for (int i = 1; i < endMonth - startMonth; i++)
                    {
                        lstMonths.Add(start.Year.ToString() + "-" + FormatMonth(startMonth + i));
                    }
                    lstMonths.Add(end.Year.ToString() + "-" + FormatMonth(endMonth));
                }
            }
            else
            {
                //获取年份差
                int nYearCha = end.Year - start.Year;

                //添加第一年
                for (var j = startMonth; j <= 12; j++)
                {
                    lstMonths.Add(start.Year.ToString() + "-" + FormatMonth(j));
                }
                //添加中间几年(全月)
                for (int i = 1; i < nYearCha; i++)
                {
                    int nCurrentYear = start.Year + i;
                    for (var j = 1; j <= 12; j++)
                    {
                        lstMonths.Add(nCurrentYear.ToString() + "-" + FormatMonth(j));
                    }
                }
                //添加最后一年
                for (var j = 1; j <= endMonth; j++)
                {
                    lstMonths.Add(end.Year.ToString() + "-" + FormatMonth(j));
                }
                return lstMonths;
            }
            return lstMonths;
        }

        /// <summary>
        /// 格式化月份，不足10的十位补0
        /// 创建人：朱斌
        /// 创建时间：2014-02-20
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private static string FormatMonth(int month)
        {
            if (month > 9)
            {
                return month.ToString();
            }
            else
            {
                return "0" + month.ToString();
            }
        }
    }
}
