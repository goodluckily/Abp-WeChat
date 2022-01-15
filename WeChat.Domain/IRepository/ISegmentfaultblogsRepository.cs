using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface ISegmentfaultblogsRepository : ITransientDependency
    {
        Task<Segmentfaultblogs> CreateSegmentfaultblogsAsync(Segmentfaultblogs segmentfault);
        Task<List<Segmentfaultblogs>> CreateSegmentfaultblogsAsync(List<Segmentfaultblogs> segmentfaults);
        Task<List<Segmentfaultblogs>> GetSegmentfaultblogsAll();
    }
}
