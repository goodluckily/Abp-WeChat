using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.IRepository
{
    public interface INetcnblogsRepository
    {
        Task<Netcnblogs> CreateNetcnblogsAsync(Netcnblogs netcnblogs);
        Task<List<Netcnblogs>> CreateNetcnblogsAsync(List<Netcnblogs> netcnblogs);
        Task DeleteNetcnblogsAsync(Guid netcnblogsId);

        /// <summary>
        /// 获取全部 .NET 博客文章列表
        /// </summary>
        /// <returns></returns>
        Task<List<Netcnblogs>> GetAllAsync();
    }
}
