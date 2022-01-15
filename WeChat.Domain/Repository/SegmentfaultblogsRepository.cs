using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class SegmentfaultblogsRepository : ISegmentfaultblogsRepository
    {
        private readonly IRepository<Segmentfaultblogs, Guid> _segmentfaultblogsRepository;

        public SegmentfaultblogsRepository(IRepository<Segmentfaultblogs, Guid> segmentfaultblogsRepository)
        {
            _segmentfaultblogsRepository = segmentfaultblogsRepository;
        }

        public async Task<Segmentfaultblogs> CreateSegmentfaultblogsAsync(Segmentfaultblogs segmentfault)
        {
            return await _segmentfaultblogsRepository.InsertAsync(segmentfault);
        }

        public async Task<List<Segmentfaultblogs>> CreateSegmentfaultblogsAsync(List<Segmentfaultblogs> segmentfaults)
        {
            await _segmentfaultblogsRepository.InsertManyAsync(segmentfaults);
            return segmentfaults;
        }

        public async Task<List<Segmentfaultblogs>> GetSegmentfaultblogsAll()
        {
            return await _segmentfaultblogsRepository.ToListAsync();
        }
    }

}
