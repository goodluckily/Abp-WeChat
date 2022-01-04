using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain.WeChat
{
    public class Log:Entity<Guid>
    {
        public Guid? UserId { get; set; }
        public string? LogLevel { get; set; }
        public string? LogType { get; set; }
        public string? Logger { get; set; }
        public string? Message { get; set; }
        public string? MachineName { get; set; }
        public string? MachineIp { get; set; }
        public string? NetRequestMethod { get; set; }
        public string? NetRequestUrl { get; set; }
        public string? Exception { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
