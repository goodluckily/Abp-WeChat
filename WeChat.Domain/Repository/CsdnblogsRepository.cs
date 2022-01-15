using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class CsdnblogsRepository : ICsdnblogsRepository
    {
        private readonly IRepository<Csdnblogs, Guid> _csdnblogsRepository;

        public CsdnblogsRepository(IRepository<Csdnblogs, Guid> csdnblogsRepository)
        {
            _csdnblogsRepository = csdnblogsRepository;
        }

        public async Task<List<Csdnblogs>> CreateCsdnblogsAsync(List<Csdnblogs> csdnblogs)
        {
            await _csdnblogsRepository.InsertManyAsync(csdnblogs);
            return csdnblogs;
        }

        public async Task<Csdnblogs> CreateCsdnblogssync(Csdnblogs csdnblogs)
        {
            return await _csdnblogsRepository.InsertAsync(csdnblogs);
        }

        public async Task<List<Csdnblogs>> GetCsdnblogsAll()
        {
            return await _csdnblogsRepository.ToListAsync();
        }
    }
}
