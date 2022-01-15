using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }



        public ICollection<UserAndRoleMap> UserAndRoleMaps { get; set; }
        public ICollection<UserInfo> UserInfos { get; set; }
        public Role(Guid id) : base(id)
        {

        }
    }
}
