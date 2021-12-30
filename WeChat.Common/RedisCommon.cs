using CSRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Common
{
    public class RedisCommon
    {
        private static string _instanceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="instanceName"></param>
        public RedisCommon(string connectionString, string instanceName)
        {
            _instanceName = instanceName;
            RedisHelper.Initialization(new CSRedisClient(connectionString));
        }

        public static string InitKeyName(string key)
        {
            return _instanceName + "." + key;
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T">尽量是字符串和数值类型，不要传对象或数组</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ExprireTime"></param>
        /// <returns></returns>
        public static bool SetTValue<T>(string key, T value, double exprireTime = 24, bool isHour = true)
        {
            if (exprireTime <= 0) throw new Exception("请提供正确的存储时间");
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value.ToString())) throw new Exception("请提供正确key和value");
            exprireTime = isHour ? Math.Round(60 * 60 * exprireTime) : exprireTime;
            return RedisHelper.Set(InitKeyName(key), value, (int)exprireTime);
        }

        /// <summary>
        /// 获取string数据
        /// </summary>
        /// <typeparam name="T">尽量是字符串和数值类型，不要传对象或数组</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetTValue<T>(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new Exception("请提供正确key");
            return RedisHelper.Get<T>(InitKeyName(key));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void Incr(string key, int value = 1)
        {
            if (string.IsNullOrEmpty(key)) throw new Exception("请提供正确key");
            RedisHelper.IncrBy(InitKeyName(key), value);
        }



        /// <summary>
        /// 添加string数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="ExprireTime">过期时间 单位小时</param>
        /// <returns></returns>
        public static bool SetJsonValue(string key, object value, int ExprireTime = 24)
        {
            if (string.IsNullOrEmpty(key) || value == null) return false;
            return RedisHelper.Set(InitKeyName(key), JsonCommon.GetJsonStringSerializeObject(value), 60 * 60 * ExprireTime);
        }

        /// <summary>
        /// 获取数据（对象）
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            string value = GetTValue<string>(key);
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }
            var obj = JsonCommon.GetJObjectDeserialize<T>(value);
            return obj;
        }


        /// <summary>
        /// 添加列表List数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>

        public static bool SetLPushValue<T>(string key, bool IsNew, IEnumerable<T> listSoure)
        {
            var soureCount = listSoure.Count();
            if (string.IsNullOrEmpty(key) || soureCount <= 0) return false;

            //获取数量 存在则删除 缓存最新的 且允许保存是始终最新的
            //RedisHelper.LLen(key) > 0 && 
            if (IsNew) DelForKey(key);

            foreach (var item in listSoure)
            {
                RedisHelper.LPush(key, item);
            }
            return soureCount > 0 ? true : false;
        }

        /// <summary>
        /// 获取列表 依据key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start">开始</param>
        /// <param name="stop">停止</param>
        /// <returns></returns>
        public static List<T> GetLPushData<T>(string key, long start, long stop)
        {
            //获取内容 列表
            return RedisHelper.LRange<T>(key, start, stop).ToList();
        }

        /// <summary>
        /// 移除列表值 依据key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<long> LRemAsync(string key, object value)
        {
            //0 0表示全部
            return await RedisHelper.LRemAsync(key, 0, value);
        }

        /// <summary>
        /// 添加有序集合数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>

        public static bool SetZAddValue<T>(string key, List<T> listSoure)
        {
            var soureCount = listSoure.Count();
            if (string.IsNullOrEmpty(key) || soureCount <= 0) return false;

            //获取有序集合数量 存在则删除 缓存最新的
            if (RedisHelper.ZCard(key) > 0) DelForKey(key);

            var addCount = 0;
            foreach (var item in listSoure)
            {
                RedisHelper.ZAdd(key, (addCount, item));
                addCount++;
            }
            return addCount == soureCount ? true : false;
        }

        /// <summary>
        /// 获取有序集合 依据Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start">开始分值</param>
        /// <param name="stop">停止分值</param>
        /// <returns></returns>
        public static List<T> GetZAddData<T>(string key, long start, long stop)
        {
            //获取内容 集合
            return RedisHelper.ZRange<T>(key, start, stop).ToList();
        }

        /// <summary>
        /// 依据Key 删除对应Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long DelForKey(string key)
        {
            key = InitKeyName(key);
            return RedisHelper.Del(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>r
        public static void ExpireAt(string key, DateTime dateTime)
        {
            RedisHelper.ExpireAt(key, dateTime);
        }

        /// <summary>
        /// 检查 Key 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExistsKey(string key)
        {
            key = InitKeyName(key);
            return RedisHelper.Exists(key);
        }
    }
}
