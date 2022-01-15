using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Repository
{
    public class RoleRepository : IRoleRepository
    {
        #region DL
        private readonly IRepository<Role, Guid> _roleRepository;

        public RoleRepository(IRepository<Role, Guid> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        #endregion

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetListAsync();
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            return await _roleRepository.InsertAsync(role);
        }
    }
}
