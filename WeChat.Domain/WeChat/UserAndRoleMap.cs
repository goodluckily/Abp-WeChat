using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain
{
    public class UserAndRoleMap : Entity
    {
        public Guid UserId { get; set; }
        public UserInfo UserInfo { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid? CreateUserId { get; set; }
        public DateTime? CreateTime { get; set; }

        public override object[] GetKeys()
        {
            throw new NotImplementedException("GetKeys 暂时未实现");
        }
    }
}
