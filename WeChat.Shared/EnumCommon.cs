using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace WeChat.Shared
{
    public static class EnumCommon
    {
        private static ConcurrentDictionary<string, Assembly> AssemblyList = new ConcurrentDictionary<string, Assembly>();
        /// <summary>
        /// 通过key 获取 Value
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetValueByName(Type type, string name)
        {
            bool flag = Enum.TryParse(type, name, out object val);
            if (flag) return val;
            return null;
        }
        /// <summary>
        /// 通过Value 获取 Name
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetNameByValue(Type type, object value)
        {
            if (value == null) return "";
            var name = Enum.GetName(type, value);
            return name;
        }

        /// <summary>
        /// 判断枚举是否包含 name或value red=22   可传red或22
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nameOrValue"></param>
        /// <returns></returns>
        public static bool HasEnum(Type type, object nameOrValue)
        {
            bool flag = Enum.IsDefined(type, nameOrValue);
            return flag;
        }

        /// <summary>
        /// 获取枚举名称集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] GetNamesArr<T>()
        {
            return Enum.GetNames(typeof(T));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetEnumList<T>()
        {
            var listT = new List<T>();
            var arrys = Enum.GetValues(typeof(T));
            foreach (T item in arrys)
            {
                listT.Add(item);
            }
            return listT;
        }

        /// <summary>
        /// 将枚举转换成字典集合
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> getEnumDic<T>()
        {

            Dictionary<int, string> resultList = new Dictionary<int, string>();
            Type type = typeof(T);
            var strList = GetNamesArr<T>().ToList();
            foreach (string key in strList)
            {
                string val = Enum.Format(type, Enum.Parse(type, key), "d");
                resultList.Add(val.TryParseToInt(), key);
            }
            return resultList;
        }

        /// <summary>
        /// 将枚举转换成字典
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>(value,name)</returns>
        public static Dictionary<int, string> GetDicName<TEnum>()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Type t = typeof(TEnum);
            var arr = Enum.GetValues(t);
            foreach (var item in arr)
            {
                dic.Add((int)item, item.ToString());
            }
            return dic;
        }

        /// <summary>
        /// 将枚举转换成字典
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>(name,value)</returns>
        public static Dictionary<string, int> GetDicValue<TEnum>()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            Type t = typeof(TEnum);
            var arr = Enum.GetValues(t);
            foreach (var item in arr)
            {
                dic.Add(item.ToString(), (int)item);
            }
            return dic;
        }

        /// <summary>
        /// 依据Enum 得到说明
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description;
        }


        /// <summary>
        /// get all information of enum,include value,name and description
        /// </summary>
        /// <param name="enumName">the type of enumName</param>
        /// <returns></returns>
        public static List<(int Id, string Value, string Name)> GetAllItems<T>()
        {
            Type typEnum = typeof(T);
            List<(int Id, string Value, string Name)> list = new List<(int Id, string Value, string Name)>();
            // get enum fileds
            FieldInfo[] fields = typEnum.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                {
                    continue;
                }
                // get enum value
                int value = (int)typEnum.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string text = field.Name;
                string description = string.Empty;
                object[] array = field.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (array.Length > 0)
                {
                    description = ((EnumMemberAttribute)array[0]).Value;
                }
                else
                {
                    description = ""; //none description,set empty
                }
                //add to list
                list.Add((value, text, description));
            }
            return list;
        }

        /// <summary>
        /// 获取枚举项上的<see cref="DescriptionAttribute"/>特性的文字描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)    //当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }


        /// <summary>
        /// 根据枚举代码获取枚举列表
        /// </summary>
        /// <param name="assembly">程序集名称集合</param>
        /// <param name="namespaces">命名空间名称集合</param>
        /// <param name="code">枚举名称</param>
        /// <returns></returns>
        public static List<(int Key, string Value, string Description)> GetEnumListByEnumName(IEnumerable<string> assemblys, IEnumerable<string> namespaces, string EnumCode)
        {
            assemblys = assemblys.Distinct();
            namespaces = namespaces.Distinct();
            var Inexistentassembly = assemblys.Except(AssemblyList?.Select(o => o.Key));
            foreach (var assembly in Inexistentassembly)
                AssemblyList.TryAdd(assembly, System.Reflection.Assembly.Load(assembly));
            List<Type> enumlist = new List<Type>();
            List<string> enumNamespanList = new List<string>();
            foreach (var enumNamespace in namespaces)
            {
                foreach (var assembly in AssemblyList)
                {
                    var enumInfo = assembly.Value.CreateInstance($"{enumNamespace}.{EnumCode}", false);
                    if (enumInfo != null)
                    {
                        enumNamespanList.Add(enumNamespace);
                        enumlist.Add(enumInfo.GetType());
                    }
                }
            }
            if (enumlist.Count == 0) return default;
            if (enumlist.Count > 1)
                throw new Exception($"枚举【{EnumCode}】存在多个，请检查命名空间【{string.Join(',', enumNamespanList)}】");
            var enums = Enum.GetValues(enumlist.FirstOrDefault());
            var enumDic = new List<(int Key, string Value, string Description)>();
            foreach (Enum item in enums)
            {
                enumDic.Add(new(Convert.ToInt32(item), item.ToString(), item.ToDescription()));
            }
            return enumDic;
        }
    }
}
