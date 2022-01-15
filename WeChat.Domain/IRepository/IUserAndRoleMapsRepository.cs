using System;
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
    public interface IUserAndRoleMapsRepository : ITransientDependency
    {
        Task<List<UserAndRoleMap>> GetAllAsync();
        Task<List<UserAndRoleMap>> getRolesByUserId(Guid userId);

        /// <summary>
        /// 依据用户Id 得到相关角色数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<UserAndRoleMap>> getUserAndRoleMapByRoleId(Guid roleId);

        /// <summary>
        /// 依据角色Id 得到相关用户数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserAndRoleMap>> getUserAndRoleMapByUserId(Guid userId);
    }
}
