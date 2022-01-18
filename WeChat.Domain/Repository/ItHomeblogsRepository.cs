using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class ItHomeblogsRepository : IItHomeblogsRepository
    {
        private readonly IRepository<ItHomeblogs, Guid> _itHomeblogsRepository;

        public ItHomeblogsRepository(IRepository<ItHomeblogs, Guid> itHomeblogsRepository)
        {
            _itHomeblogsRepository = itHomeblogsRepository;
        }

        public async Task<ItHomeblogs> CreateItHomeblogsAsync(ItHomeblogs itHomeblogs)
        {
            return await _itHomeblogsRepository.InsertAsync(itHomeblogs);
        }

        public async Task<List<ItHomeblogs>> CreateItHomeblogsAsync(List<ItHomeblogs> itHomeblogs)
        {
            await _itHomeblogsRepository.InsertManyAsync(itHomeblogs);
            return itHomeblogs;
        }

        public async Task<List<ItHomeblogs>> GetItHomeblogsAll()
        {
            return await _itHomeblogsRepository.GetListAsync();
        }
    }

}
