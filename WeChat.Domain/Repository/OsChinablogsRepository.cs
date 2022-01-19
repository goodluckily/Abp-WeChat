using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class OsChinablogsRepository : IOsChinablogsRepository
    {
        private readonly IRepository<OsChinablogs, Guid> _osChinablogsRepository;

        public OsChinablogsRepository(IRepository<OsChinablogs, Guid> osChinablogsRepository)
        {
            _osChinablogsRepository = osChinablogsRepository;
        }
        public async Task<List<OsChinablogs>> CreateOsChinablogsAsync(List<OsChinablogs> osChinablogs)
        {
            await _osChinablogsRepository.InsertManyAsync(osChinablogs);
            return osChinablogs;
        }

        public async Task<OsChinablogs> CreateOsChinablogsAsync(OsChinablogs osChinablogs)
        {
            return await _osChinablogsRepository.InsertAsync(osChinablogs);
        }

        public async Task<List<OsChinablogs>> GetOsChinablogsAll()
        {
            return await _osChinablogsRepository.ToListAsync();
        }

    }
}
