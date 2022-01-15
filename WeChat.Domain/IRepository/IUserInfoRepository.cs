using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.Shared;
using WeChat.Domain;

namespace WeChat.Domain.IRepository
{
    public interface IUserInfoRepository : ITransientDependency
    {
        Task<List<UserInfo>> GetAllAsync();
        Task<UserInfo> GetUserLogin(string loginName, string passWord);
        Task<UserInfo> GetUserForRolesLogin(string loginName, string passWord);
        Task<UserInfo> GetUserInfoAsyncById(Guid userId);
        UserInfo GetUserInfoById(Guid userId);
    }
}
