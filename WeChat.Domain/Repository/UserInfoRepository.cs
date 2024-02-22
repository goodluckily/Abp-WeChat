using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Domain;

namespace WeChat.Domain.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        #region DL
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;
        private readonly IRepository<Role, Guid> _roleepository;
        private readonly IRepository<UserAndRoleMap> _userAndRoleMapRepository;

        public UserInfoRepository(IRepository<UserInfo, Guid> userInfoRepository, IRepository<Role, Guid> roleepository, IRepository<UserAndRoleMap> userAndRoleMapRepository)
        {
            _userInfoRepository = userInfoRepository;
            _roleepository = roleepository;
            _userAndRoleMapRepository = userAndRoleMapRepository;
        }
        #endregion

        public async Task<List<UserInfo>> GetAllAsync()
        {
            return await _userInfoRepository.GetListAsync();
        }
        public async Task<UserInfo> GetUserInfoAsyncById(Guid userId)
        {
            return await _userInfoRepository.GetAsync(userId, false);
        }

        public UserInfo GetUserInfoById(Guid userId)
        {
            return _userInfoRepository.FirstOrDefault(x => x.Id == userId);
        }

        public async Task<UserInfo> GetUserLogin(string loginName, string passWord)
        {
            return await _userInfoRepository.FirstOrDefaultAsync(x => x.LoginName == loginName && x.PassWrod == passWord);
        }

        public async Task<UserInfo> GetUserForRolesLogin(string loginName, string passWord)
        {
            var queryable = await _userInfoRepository.WithDetailsAsync(x => x.Roles);
            return queryable.FirstOrDefault(x => x.LoginName == loginName && x.PassWrod == passWord);
        }

        public async Task<bool> CheckUserByName(string LoginName)
        {
            return await _userInfoRepository.AnyAsync(x => x.LoginName == LoginName);
        }

        public async Task<bool> AddUserInfoRoleMap(UserInfo userInfo, Role role, UserAndRoleMap userAndroleMap)
        {
            await _userInfoRepository.InsertAsync(userInfo);
            await _roleepository.InsertAsync(role);
            await _userAndRoleMapRepository.InsertAsync(userAndroleMap);
            return await Task.FromResult(true);
        }
    }
}
