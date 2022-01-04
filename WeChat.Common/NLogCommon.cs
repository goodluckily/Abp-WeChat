using NLog;
using NLog.Config;
using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using WeChat.Domain.Shared.Enum;

namespace WeChat.Common
{
    public class NLogCommon
    {
        public static Logger dbLogger = LogManager.GetLogger("logdb");
        public static Logger fileLogger = LogManager.GetLogger("logfile");

        /// <summary>
        /// 写日志到数据库
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="logType">日志类型</param>
        /// <param name="message">信息</param>
        /// <param name="exception">异常</param>
        public static void WriteDBLog(LogLevel logLevel, LogType logType, string message,string OptionUserId = null, Exception exception = null)
        {
            LogEventInfo theEvent = new LogEventInfo(logLevel, dbLogger.Name, message);
            theEvent.Properties["Id"] = Guid.NewGuid().ToString();
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Properties["UserId"] = string.IsNullOrWhiteSpace(OptionUserId) ? Guid.Empty : OptionUserId;
            theEvent.Exception = exception;
            dbLogger.Log(theEvent);
        }

        /// <summary>
        /// 写日志到文件
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="logType">日志类型</param>
        /// <param name="message">信息</param>
        /// <param name="exception">异常</param>
        public static void WriteFileLog(LogLevel logLevel, LogType logType, string message, string OptionUserId = null, Exception exception = null)
        {
            LogEventInfo theEvent = new LogEventInfo(logLevel, fileLogger.Name, message);
            theEvent.Properties["Id"] = Guid.NewGuid().ToString();
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Properties["UserId"] = string.IsNullOrWhiteSpace(OptionUserId) ? Guid.Empty : OptionUserId;
            theEvent.Exception = exception;
            fileLogger.Log(theEvent);
        }

        /// <summary>
        /// 确保NLog配置文件sql连接字符串正确
        /// </summary>
        /// <param name="nlogPath"></param>
        /// <param name="sqlConnectionStr"></param>
        public static void EnsureNlogConfig(string nlogPath, string sqlConnectionStr)
        {
            XDocument xd = XDocument.Load(nlogPath);
            if (xd.Root.Elements().FirstOrDefault(a => a.Name.LocalName == "targets")
                is XElement targetsNode && targetsNode != null &&
                targetsNode.Elements().FirstOrDefault(a => a.Name.LocalName == "target" && a.Attribute("name").Value == "log_database")
                is XElement targetNode && targetNode != null)
            {
                if (!targetNode.Attribute("connectionString").Value.Equals(sqlConnectionStr))//不一致则修改
                {
                    //这里暂时没有考虑dbProvider的变动
                    targetNode.Attribute("connectionString").Value = sqlConnectionStr;
                    xd.Save(nlogPath);
                    //编辑后重新载入配置文件（不依靠NLog自己的autoReload，有延迟）
                    LogManager.Configuration = new XmlLoggingConfiguration(nlogPath);
                }
            }
        }
    }
}
