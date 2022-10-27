using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Domain;
using WeChat.Shared.Enums;

namespace WeChat.Domain.Repository
{
    public class NetcnblogsRepository : INetcnblogsRepository
    {
        private readonly IRepository<Cnblogs, Guid> _netcnblogsRepository;

        public NetcnblogsRepository(IRepository<Cnblogs, Guid> netcnblogsRepository)
        {
            _netcnblogsRepository = netcnblogsRepository;
        }

        public async Task<List<Cnblogs>> GetAllAsync(AnalyzingEnum? analyzingEnum = null)
        {
            if (analyzingEnum is null) return await _netcnblogsRepository.GetListAsync();
            return await _netcnblogsRepository.GetListAsync(x => x.AnalyzingType == analyzingEnum);
        }

        public async Task<Cnblogs> CreateNetcnblogsAsync(Cnblogs netcnblogs)
        {
            return await _netcnblogsRepository.InsertAsync(netcnblogs);
        }

        public async Task<List<Cnblogs>> CreateNetcnblogsAsync(List<Cnblogs> netcnblogs)
        {
            await _netcnblogsRepository.InsertManyAsync(netcnblogs);

            return netcnblogs;
        }

        public async Task DeleteNetcnblogsAsync(Guid netcnblogsId)
        {
            await _netcnblogsRepository.DeleteAsync(netcnblogsId);
        }
    }
}
