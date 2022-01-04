using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        #region DL
        private readonly IRepository<UserInfo> _userInfoRepository;

        public UserInfoRepository(IRepository<UserInfo> userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        } 
        #endregion

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            return await _userInfoRepository.GetListAsync();
        }
    }
}
