using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain.WeChat
{
    public class Role:Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid EditUserId { get; set; }

        public DateTime? EditTime { get; set; }
        public bool Active { get; set; } = true;
        public bool IsDel { get; set; } = false;

        public ICollection<UserAndRoleMap> userAndRoleMap { get; set; }
        public ICollection<UserInfo> UserInfos { get; set; }
    }
}
