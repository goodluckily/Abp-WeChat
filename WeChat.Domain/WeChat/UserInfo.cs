using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain.WeChat
{
    public class UserInfo : Entity<Guid>
    {
        public string LoginName { get; set; }
        public string PassWrod { get; set; }
        public string? NickName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Guid? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }
        public Guid? EditUserId { get; set; }

        public DateTime? EditTime { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDel { get; set; } = false;

        public ICollection<UserAndRoleMap> userAndRoleMap { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
