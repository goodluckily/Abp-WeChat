using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Shared;
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

        /// <summary>
        /// 判断登陆用户 是否存在
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> CheckUserByName(string LoginName);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="role"></param>
        /// <param name="userAndroleMap"></param>
        Task<bool> AddUserInfoRoleMap(UserInfo userInfo, Role role, UserAndRoleMap userAndroleMap);
    }
}
