using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Repository
{
    public class NetcnblogsRepository : INetcnblogsRepository
    {
        private readonly IRepository<Netcnblogs, Guid> _netcnblogsRepository;

        public NetcnblogsRepository(IRepository<Netcnblogs, Guid> netcnblogsRepository)
        {
            _netcnblogsRepository = netcnblogsRepository;
        }

        public async Task<List<Netcnblogs>> GetAllAsync(AnalyzingEnum? analyzingEnum = null)
        {
            if (analyzingEnum is null) return await _netcnblogsRepository.GetListAsync();
            return await _netcnblogsRepository.GetListAsync(x => x.AnalyzingType == analyzingEnum);
        }

        public async Task<Netcnblogs> CreateNetcnblogsAsync(Netcnblogs netcnblogs)
        {
            return await _netcnblogsRepository.InsertAsync(netcnblogs);
        }

        public async Task<List<Netcnblogs>> CreateNetcnblogsAsync(List<Netcnblogs> netcnblogs)
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
