using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;

namespace WeChat.Domain
{
    public class UserInfo : BaseServiceEntity
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

        public (UserInfo userInfo, Role role, UserAndRoleMap userAndroleMap) GetSeedUserData(Guid _guidGenerator)
        {
            var userInfo = new UserInfo(_guidGenerator)
            {
                LoginName = "admin",
                PassWrod = "123456",
                NickName = "管理员",
                IsActive = true,
                IsDel = true,
                CreateTime = DateTime.Now,
            };
            var role = new Role(_guidGenerator)// 这里如何切换成  IGuidGenerator   _guidGenerator.Create() ???
            {
                Name = "管理者",
                Description = "最高权限管理者",
                CreateUserId = userInfo.Id,
                CreateTime = DateTime.Now,
                IsActive = true,
                IsDel = false
            };

            var userAndroleMap = new UserAndRoleMap()
            {
                UserId = userInfo.Id,
                RoleId = role.Id,
                CreateUserId = userInfo.Id,
                CreateTime = DateTime.Now
            };

            return (userInfo, role, userAndroleMap);
        }
    }
}
