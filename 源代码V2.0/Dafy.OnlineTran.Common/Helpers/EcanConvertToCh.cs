using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Helpers
{
    /// <summary>
    /// 转换汉子为拼音类
    /// </summary>
    public class EcanConvertToCh
    {
        /// <summary>  
        /// 转换  
        /// </summary>  
        /// <param name="chineseStr"></param>  
        /// <param name="?"></param>  
        /// <returns></returns>  
        public static string HzToCode(string chineseStr)//typeStr是指拼音还是五笔码  
        {
            try
            {
                var resultStr = "";
                var arrCn = Encoding.Default.GetBytes(chineseStr);
                if (arrCn.Length <= 1) return resultStr;
                int area = arrCn[0];
                int pos = arrCn[1];
                var code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614,
                    48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387,
                    51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (var i = 0; i < 26; i++)
                {
                    var max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] > code || code >= max) continue;
                    resultStr = Encoding.Default.GetString(new[] { (byte)(65 + i) });
                    break;
                }

                return resultStr;
            }
            catch (Exception ex)
            {
                throw new Exception("错误:", ex);
            }
        }

        /// <summary>
        /// 得到汉字拼音首字母
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <returns></returns>
        public static string HztoPySimple(string chineseStr)
        {
            try
            {
                var b = Encoding.Default.GetBytes(chineseStr);
                var res = "";
                for (var i = 0; i < b.Length; )
                {
                    if (i == b.Length - 1)
                    {
                        if (char.IsNumber((char)b[i]) || char.IsLetter((char)b[i]))
                            res += (char)b[i++];
                        else
                        {
                            i++;
                        }
                    }
                    else if (Convert.ToByte(b[i]) > 127)//汉字  
                    {
                        var tmp = Encoding.Default.GetString(b, i, 2);
                        tmp = HzToCode(tmp);
                        if (tmp.Length > 0)
                            res += tmp[0];
                        i += 2;
                    }
                    else
                    {
                        if (char.IsNumber((char)b[i]) || char.IsLetter((char)b[i]))
                            res += (char)b[i++];
                        else
                        {
                            i++;
                        }
                    }
                }
                return res.Substring(0, 1).ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception("错误:", ex);
            }
        }
    }
}
