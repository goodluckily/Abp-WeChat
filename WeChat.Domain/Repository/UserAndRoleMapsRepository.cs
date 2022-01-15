using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared;
using WeChat.Domain;

namespace WeChat.Domain.Repository
{
    public class UserAndRoleMapsRepository : IUserAndRoleMapsRepository
    {
        private readonly IRepository<UserAndRoleMap> _userAndRoleMapsRepository;

        public UserAndRoleMapsRepository(IRepository<UserAndRoleMap> userAndRoleMapsRepository)
        {
            _userAndRoleMapsRepository = userAndRoleMapsRepository;
        }

        public async Task<List<UserAndRoleMap>> GetAllAsync()
        {
            return await _userAndRoleMapsRepository.GetListAsync();
        }

        public async Task<List<UserAndRoleMap>> getRolesByUserId(Guid userId)
        {
            return await _userAndRoleMapsRepository.GetListAsync(x => x.UserId == userId);
        }

        public async Task<List<UserAndRoleMap>> getUserAndRoleMapByUserId(Guid userId)
        {
            //得到关联Role数据
            var queryable = await _userAndRoleMapsRepository.WithDetailsAsync(x => x.Role, x => x.UserInfo);
            //筛选条件
            var query = queryable.Where(x => x.UserId == userId).ToList();
            return query;
        }

        public async Task<List<UserAndRoleMap>> getUserAndRoleMapByRoleId(Guid roleId)
        {
            //得到关联Role数据
            var queryable = await _userAndRoleMapsRepository.WithDetailsAsync(x => x.Role, x => x.UserInfo);
            //筛选条件
            var query = queryable.Where(x => x.RoleId == roleId).ToList();
            return query;
        }
    }
}
