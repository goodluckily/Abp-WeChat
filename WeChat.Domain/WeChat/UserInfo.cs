using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain
{
    public class UserInfo : BaseEntity
    {
        public string LoginName { get; set; }
        public string PassWrod { get; set; }
        public string? NickName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }



        public ICollection<UserAndRoleMap> UserAndRoleMaps { get; set; }

        public ICollection<Role> Roles { get; set; }

        public UserInfo(Guid id) : base(id)
        {

        }
    }
}
