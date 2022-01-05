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
using WeChat.Domain.Shared.Enum;
using WeChat.Domain.Shared.ExceptionCodes;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        #region DL
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;

        public UserInfoRepository(IRepository<UserInfo, Guid> userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        } 
        #endregion

        public async Task<List<UserInfo>> GetAllAsync()
        {
            return await _userInfoRepository.GetListAsync();
        }

        public async Task<UserInfo> GetUserLogin(string loginName, string passWord)
        {
           return await _userInfoRepository.FirstOrDefaultAsync(x => x.LoginName == loginName && x.PassWrod == passWord);
        }
    }
}
