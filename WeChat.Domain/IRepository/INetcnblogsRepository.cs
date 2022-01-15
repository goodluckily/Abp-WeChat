using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WeChat.Shared;
using WeChat.Domain;

namespace WeChat.Domain.IRepository
{
    public interface INetcnblogsRepository : ITransientDependency
    {
        Task<Cnblogs> CreateNetcnblogsAsync(Cnblogs netcnblogs);
        Task<List<Cnblogs>> CreateNetcnblogsAsync(List<Cnblogs> netcnblogs);
        Task DeleteNetcnblogsAsync(Guid netcnblogsId);

        /// <summary>
        /// 获取全部 .NET 博客文章列表
        /// </summary>
        /// <returns></returns>
        Task<List<Cnblogs>> GetAllAsync(AnalyzingEnum? analyzingEnum = null);
    }
}
