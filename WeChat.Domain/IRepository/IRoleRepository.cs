using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.Shared.Enum;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.IRepository
{
    public interface IRoleRepository : ITransientDependency
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<List<Role>> GetAllAsync();
    }
}
