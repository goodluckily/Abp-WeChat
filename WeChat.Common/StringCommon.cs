using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WeChat.Common
{
    public static class StringCommon
    {
        private static string StrKeyWord = "select|insert|delete|from|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec|master|net local group administrators|net user|or|and";
        private static string StrSymbol = ";|(|)|[|]|{|}|%|@|*|'|!";
        private static Dictionary<string, int> _timeZones = new Dictionary<string, int>() {{"ECT", +1},
                {"EET", +2},
                {"ART", +2},
                {"EAT", +3},
                {"MET", +3},
                {"NET", +4},
                {"PLT", +5},
                {"IST", +5},
                {"BST", +6},
                {"VST", +7},
                {"CTT", +8},
                {"JST", +9},
                {"ACT", +9},
                {"AET", +0},
                {"SST", +1},
                {"NST", +2},
                {"MIT", -1},
                {"HST", -0},
                {"AST", -9},
                {"PST", -8},
                {"PDT", -7},
                {"PNT", -7},
                {"MST", -7},
                {"CST", -6},
                {"EST", -5},
                {"IET", -5},
                {"PRT", -4},
                {"CNT", -3},
                {"AGT", -3},
                {"BET", -3},
                {"CAT", -1}
            };


        /// <summary>
        /// 判断时间是否有效：小于2000年视为无效
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool IsValid(this DateTime time)
        {
            var t = DateTime.Parse("2000-01-01");
            if (time < t) return false;
            return true;

        }

        /// <summary>
        /// 时间格式转换 统一 "-"
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToyyyyMMdd(this DateTime? time)
        {
            return time?.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 时间格式转换 统一 "-"
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DataTimeFormatToString(this DateTime? time, string forMat = "yyyy-MM-dd HH:mm:ss")
        {
            return time?.ToString(forMat);
        }
        public static string DataTimeFormatToString(this DateTime time, string forMat = "yyyy-MM-dd HH:mm:ss")
        {
            return time.ToString(forMat);
        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        #region DateTime To 时间戳

        public static long GetTimeStamp(DateTime date)
        {
            return (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public static long ToTimeStamp(this DateTime date)
        {
            return (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public static long? ToTimeStamp(this DateTime? date)
        {
            if (date == null) return null;
            return (date?.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        #endregion

        #region
        /// <summary>
        /// 根据时间戳获取时间
        /// </summary>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static DateTime GetDateByStamp(long timeStamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timeStamp).ToLocalTime();
        }
        public static DateTime ToDateByStamp(this long timeStamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timeStamp).ToLocalTime();
        }
        public static DateTime? ToDateByStamp(this long? timeStamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timeStamp ?? 0).ToLocalTime();
        }
        #endregion
        public static int TryParseToInt(this string str, int value = 0)
        {
            var flag = int.TryParse(str, out int strValue);
            if (flag) return strValue;
            else return value;
        }

        public static long TryParseToLong(this string str, long value = 0)
        {
            var flag = long.TryParse(str, out long strValue);
            if (flag) return strValue;
            else return value;
        }

        public static decimal? TryParseToDecimal(this string str)
        {
            var flag = decimal.TryParse(str, out decimal strValue);
            if (flag) return strValue;
            else return null;
        }

        public static decimal TryParseToDecimalZero(this string str)
        {
            var flag = decimal.TryParse(str, out decimal strValue);
            if (flag) return strValue;
            else return 0;
        }
        public static double? TryParseToDouble(this string str)
        {
            var flag = double.TryParse(str, out double strValue);
            if (flag) return strValue;
            else return null;
        }

        public static DateTime? TryParseToDateTime(this string str)
        {
            var flag = DateTime.TryParse(str, out DateTime strValue);
            if (flag) return strValue;
            else return null;
        }

        public static bool TryParseToBool(this string str)
        {
            var flag = bool.TryParse(str, out bool strValue);
            if (flag) return strValue;
            else return flag;
        }

        public static bool IsExistDicAndNotNullOrWhiteSpace(this Dictionary<string, object> paramDic, string str)
        {
            return paramDic.ContainsKey(str) && !string.IsNullOrWhiteSpace(paramDic[str].ToString());
        }



        public static bool IsDate(this string str)
        {
            if (str.IsNullOrWhiteSpace()) return false;
            var flag = DateTime.TryParse(str, out var aa);
            return flag;
        }

        public static string Md5File(Stream stream = null, byte[] bytes = null)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = null;
            if (stream != null)
            {
                retVal = md5.ComputeHash(stream);
            }
            else if (bytes != null)
            {
                retVal = md5.ComputeHash(bytes);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        ///<summary>
        ///检查字符串中是否包含Sql注入关键字
        /// <param name="_key">被检查的字符串</param>
        /// <returns>如果包含sql注入关键字，返回：true;否则返回：false</returns>
        ///</summary>
        public static bool CheckKeyWord(string _key)
        {
            string[] pattenKeyWord = StrKeyWord.Split('|');
            string[] pattenSymbol = StrSymbol.Split('|');
            foreach (string sqlParam in pattenKeyWord)
            {
                if (_key.Contains(sqlParam + " ") || _key.Contains(" " + sqlParam))
                {
                    return true;
                }
            }
            foreach (string sqlParam in pattenSymbol)
            {
                if (_key.Contains(sqlParam))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查字符串是否是纯数字和字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckStringIsNumberOrAbc(string str)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]+$");
            var r = regex.IsMatch(str);
            return r;
        }
        //execl日期转换
        //public static DateTime? ToDateTime(this string datetime)
        //{
        //    if (!string.IsNullOrWhiteSpace(datetime))
        //    {
        //        var b = DateTime.TryParse(datetime, out DateTime outtime);

        //        if (b)
        //        {
        //            return outtime;
        //        }
        //        else
        //        {
        //            b = DateTime.TryParseExact(datetime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out outtime);
        //            if (b)
        //            {
        //                return outtime;
        //            }
        //            else
        //            {
        //                if (datetime.Contains(","))
        //                {
        //                    SimpleDateFormat sdf = new SimpleDateFormat("MMM d, yyyy");
        //                    DateTime d2 = DateTime.MinValue;
        //                    try
        //                    {
        //                        d2 = sdf.Parse(datetime);
        //                        return d2;
        //                    }
        //                    catch (Exception)
        //                    {
        //                        return null;
        //                    }
        //                }
        //                else
        //                {
        //                    if (datetime.Contains("GMT"))
        //                    {
        //                        datetime = datetime.Replace("GMT", "");
        //                        b = DateTime.TryParseExact(datetime, "dd/MM/yyyy HH:mm:ss ", CultureInfo.InvariantCulture, DateTimeStyles.None, out outtime);
        //                        if (b)
        //                        {
        //                            return outtime.AddHours(8);
        //                        }
        //                        else
        //                        {
        //                            return null;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        public static string ToISO8601Time(this DateTime time)
        {
            return time.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        /// <summary>
        /// decimal金额 转为三位','分割 (1.保留两位 2.自动四舍五入)
        /// </summary>
        /// <param name="thisPrice"></param>
        /// <returns></returns>
        public static string decimalToPrice(this decimal? thisPrice)
        {
            var strPrice = thisPrice ?? 0;
            return string.Format("{0:N}", strPrice);
        }
        /// <summary>
        /// 时间转字符串
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="format">字符串格式 默认yyyy-MM-dd</param>
        /// <param name="defaultValue">时间为空时，默认返回</param>
        /// <returns></returns>
        public static string TimeToString(DateTime? time, string format = "yyyy-MM-dd", bool isThrow = true, string defaultValue = "")
        {
            if (time == null && isThrow) throw new Exception("转换时值不可为空");
            else if (time == null) return defaultValue;
            return ((DateTime)time).ToString(format);
        }
        /// <summary>
        /// 整数值转字符串
        /// </summary>
        /// <param name="number">需要转换的值</param>
        /// <param name="format">格式 默认无</param>
        /// <param name="isThrow">若为空值 是否抛出异常，该值为true时，defaultValue无效</param>
        /// <param name="defaultValue">若为空值，默认返回</param>
        /// <returns></returns>
        public static string IntToString(int? number, string format = "", bool isThrow = true, string defaultValue = "")
        {
            if (number == null && isThrow) throw new Exception("转换时值不可为空");
            else if (number == null) return defaultValue;
            return ((decimal)number).ToString(format);
        }
        /// <summary>
        /// （小）数值转字符串
        /// </summary>
        /// <param name="number">需要转换的值</param>
        /// <param name="format">格式 默认无</param>
        /// <param name="isThrow">若为空值 是否抛出异常，该值为true时，defaultValue无效</param>
        /// <param name="defaultValue">若为空值，默认返回</param>
        /// <returns></returns>
        public static string DecimalToString(decimal? number, string format = "", bool isThrow = true, string defaultValue = "")
        {
            if (number == null && isThrow) throw new Exception("转换时值不可为空");
            else if (number == null) return defaultValue;
            return ((decimal)number).ToString(format);
        }

        /// <summary>
        /// decimal金额 转为三位','分割 (1.保留两位 2.自动四舍五入)
        /// </summary>
        /// <param name="thisPrice"></param>
        /// <returns></returns>
        public static string decimalToPrice(this decimal thisPrice)
        {
            return string.Format("{0:N}", thisPrice);
        }

        public static DateTime ToDate(this string str)
        {
            return Convert.ToDateTime(str);
        }
        /// <summary>
        /// DATETIME?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDate(this DateTime? str)
        {
            return Convert.ToDateTime(str);
        }
        public static long ToLong(this string str)
        {
            return Convert.ToInt64(str);
        }

        public static decimal? ToDecimal(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(str);
            }
        }
        public static int? ToInt32(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(str);
            }
        }

        public static int DecimalToInt(this decimal? str)
        {
            return str == null ? 0 : (int)str;
        }

        public static string ToStringByChar(this List<string> str, string ca = "|")
        {
            if (str == null || str.Count == 0)
            {
                return null;
            }
            else
            {
                return string.Join(ca, str);
            }
        }
        /// <summary>
        /// 通过当前时间获取唯一名
        /// </summary>
        /// <returns></returns>
        public static string GetUnionNameByDate(int num = 3)
        {
            var str = "";
            if (num > 0)
            {
                var nums = Enumerable.Range(0, 9).OrderBy(x => Guid.NewGuid()).Take(num);
                str = string.Join("", nums);
            }
            return DateTime.Now.ToString("yyyyMMddHHmmss") + str;
        }

        //public static string ToStr(this object var)
        //{
        //    if (var is decimal?)
        //    {
        //        return (var as decimal?).GetValueOrDefault().ToString("n");
        //    }
        //    else if (var is Int16?)
        //    {
        //        return (var as Int16?).GetValueOrDefault().ToString();
        //    }
        //    else if (var is int?)
        //    {
        //        return (var as int?).GetValueOrDefault().ToString();
        //    }
        //    else if (var is DateTime?)
        //    {
        //        return (var as DateTime?).GetValueOrDefault().ToShortDateString();
        //    }
        //    else if (var is float?)
        //    {
        //        return (var as float?).GetValueOrDefault().ToString("f2");
        //    }
        //    else if (var is double?)
        //    {
        //        return (var as double?).GetValueOrDefault().ToString("f2");
        //    }
        //    else if (var is decimal)
        //    {
        //        return ((decimal)var).ToString("n");
        //    }
        //    else if (var is double)
        //    {
        //        return ((double)var).ToString();
        //    }
        //    else if (var is float)
        //    {
        //        return ((float)var).ToString();
        //    }
        //    else if (var is int)
        //    {
        //        return ((int)var).ToString();
        //    }
        //    else if (var is Int16)
        //    {
        //        return ((Int16)var).ToString();
        //    }
        //    else if (var is DateTime)
        //    {
        //        return ((DateTime)var).ToShortDateString();
        //    }
        //    else if (var != null)
        //    {
        //        return var.ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}




        /// <summary>
        /// 保留小数点2位
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static decimal ToDecimal2(this decimal a)
        {
            return Math.Round(a, 2);
        }


        public static decimal ToDecimal(this decimal? a)
        {
            return a == null ? 0m : (decimal)a;
        }


        #region 金额阿拉伯数字转换为大写
        /// <summary>
        /// 金额阿拉伯数字转换为大写
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ToMoneyText(this decimal value)
        {
            string result = "";         //←定义结果
            int unitPointer = 0;        //←定义单位位置
            //↓格式化金额字符串
            string valueStr = value.ToString("#0.00");
            //↓判断是否超出万亿的限制
            if (valueStr.Length > 16)
            {
                throw new Exception("暂不支持超过万亿级别的数字！");
            }
            //↓遍历字符串，获取金额大写
            for (int i = valueStr.Length - 1; i >= 0; i--)
            {
                //↓判断是否小数点
                if (valueStr[i] != '.')
                {
                    //↓后推方式增加内容
                    result = GetDaXie(valueStr[i]) + moneyUnit[unitPointer] + result;
                    //↓设置单位位置
                    unitPointer++;
                }
            }
            return result;
        }

        public static Dictionary<string, string> GetAllCountry()
        {
            return new Dictionary<string, string>() {
                {"AE","阿联酋" },
                {"AU","澳大利亚" },
                {"BR","巴西" },
                {"CA","加拿大" },
                {"CN","中国" },
                {"DE","德国" },
                {"ES","西班牙" },
                {"FR","法国" },
                {"GB","英国" },
                {"IN","印度" },
                {"IT","意大利" },
                {"JP","日本" },
                {"MX","墨西哥" },
                {"NL","荷兰" },
                {"PL","波兰" },
                {"SA","沙特阿拉伯" },
                {"SE","瑞典" },
                {"SG","新加坡" },
                {"TR","土耳其" },
                {"US","美国" },
            };
        }

        private static string[] moneyUnit = { "分", "角", "元", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "萬" };
        /// <summary>
        /// 获取大写信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string GetDaXie(char c)
        {
            string result = "";
            switch (c)
            {
                case '0':
                    result = "零";
                    break;
                case '1':
                    result = "壹";
                    break;
                case '2':
                    result = "贰";
                    break;
                case '3':
                    result = "叁";
                    break;
                case '4':
                    result = "肆";
                    break;
                case '5':
                    result = "伍";
                    break;
                case '6':
                    result = "陆";
                    break;
                case '7':
                    result = "柒";
                    break;
                case '8':
                    result = "捌";
                    break;
                case '9':
                    result = "玖";
                    break;
            }
            return result;
        }
        #endregion
        /// <summary>
        /// 或判断  判断是否存在空(至少一个)
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceOr(params object[] paramArr)
        {
            var flag = false;
            foreach (var item in paramArr)
            {
                flag = flag || string.IsNullOrWhiteSpace(item?.ToString());
                if (flag) break;
            }
            return flag;
        }
        /// <summary>
        /// 与判断  判断是否都为空
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceAnd(params object[] paramArr)
        {
            var flag = true;
            foreach (var item in paramArr)
            {
                flag = flag && string.IsNullOrWhiteSpace(item?.ToString());
            }
            return flag;
        }
        /// <summary>
        /// 是否包含  或判断
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public static bool IsContainsOr(this string origin, params string[] paramArr)
        {
            var flag = false;
            for (int i = 0; i < paramArr.Length; i++)
            {
                flag = flag || origin.Contains(paramArr[i]);
                if (flag) break;
            }
            return flag;
        }
        /// <summary>
        /// 是否包含  与判断
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public static bool IsContainsAnd(this string origin, params string[] paramArr)
        {
            var flag = true;
            for (int i = 0; i < paramArr.Length; i++)
            {
                flag = flag && origin.Contains(paramArr[i]);
            }
            return flag;
        }


        /// <summary>
        /// 字符串 特殊字符串 ??? 的替换 ' '
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HandleSpecialSpace(this string value)
        {
            byte[] space = new byte[] { 0xc2, 0xa0 };
            string UTFSpace = Encoding.GetEncoding("UTF-8").GetString(space);
            return value.Replace(UTFSpace, " ");//&nbsp;
        }
    }
}
