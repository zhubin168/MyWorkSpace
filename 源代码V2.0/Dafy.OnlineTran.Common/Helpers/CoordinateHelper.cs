using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Helpers
{
    public class CoordinateHelper
    {
        public double X { get; set; }

        public double Y { get; set; }

        public CoordinateHelper(double a, double b)
        {
            X = a;
            Y = b;
        }

        public static double CalculationDistance(CoordinateHelper a, CoordinateHelper b)
        {
            double m = (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
            return Math.Sqrt(m);
        }


        public static int HaversineInM(double lat1, double long1, double lat2, double long2)
        {
            return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
        }

        public static double HaversineInKM(double lat1, double long1, double lat2, double long2)
        {

            double _eQuatorialEarthRadius = 6378.1370D;
            double _d2r = (Math.PI / 180D);
            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            return d;
        }
    }

    public class CreditEnum
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetStateName(int state)
        {
            switch (state)
            {
                case 1:
                    {
                        return "未分配";
                    }
                case 2:
                    {
                        return "已到访";
                    }
                case 3:
                    {
                        return "还款结案";
                    }
                case 4:
                    {
                        return "人工结案";
                    }
                case 5:
                    {
                        return "已分配";
                    }
                default:
                    return "";
            }
        }
    }
}
