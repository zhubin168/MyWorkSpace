using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Helpers
{
    /// <summary>
    /// 排期计算公共方法
    /// 创建人：朱斌
    /// 创建时间：2016-10-21
    /// </summary>
    public class ScheduleHelper
    {
        public static string dateFormat = "MM-dd";
        public static string dateFormat2 = "yyyy-MM-dd";

        /// <summary>
        /// 获取时间区间内的日期集合
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>日期集合</returns>
        public static List<string> DiffDays(DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;
            DateTime dtTemp;
            List<string> lstDiffDays = new List<string>();

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
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="lstMonths">输出跨越的月份集合</param>
        /// <returns>日期集合</returns>
        public static List<string> DiffDays(string startDate, string endDate, out List<string> lstMonths)
        {
            //获取月份集合
            lstMonths = DiffMonth(startDate, endDate);
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            TimeSpan ts = end - start;
            DateTime dtTemp;
            List<string> lstDiffDays = new List<string>();

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
        /// 计算两个日期中间的月份值集合
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

        /// <summary>
        /// 数字转中文
        /// </summary>
        /// <param name="number">eg: 22</param>
        /// <returns></returns>
        public static string NumberToChinese(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                res += NumberToChinese(int.Parse(str.Substring(1, str.Length - 1)));
            }
            return res;
        }
    }
}
