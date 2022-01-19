using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface IOsChinablogsRepository : ITransientDependency
    {
        Task<List<OsChinablogs>> CreateOsChinablogsAsync(List<OsChinablogs> osChinablogs);
        Task<OsChinablogs> CreateOsChinablogsAsync(OsChinablogs osChinablogs);
        Task<List<OsChinablogs>> GetOsChinablogsAll();
    }
}
