using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared.Enum;
using WeChat.Domain.Shared.ExceptionCodes;
using WeChat.Domain.WeChat;

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

        public List<UserAndRoleMap> getRolesByUserId(Guid userId)
        {
            return _userAndRoleMapsRepository.Where(x => x.UserId == userId).ToList();
        }
    }
}
