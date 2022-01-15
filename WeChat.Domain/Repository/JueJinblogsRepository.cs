using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain;

namespace WeChat.Domain.Repository
{
    public class JueJinblogsRepository : IJueJinblogsRepository
    {
        private readonly IRepository<JueJinblogs, Guid> _jueJinblogsRepository;

        public JueJinblogsRepository(IRepository<JueJinblogs, Guid> jueJinblogsRepository)
        {
            _jueJinblogsRepository = jueJinblogsRepository;
        }

        public async Task<List<JueJinblogs>> GetJueJinblogsAll()
        {
            return await _jueJinblogsRepository.ToListAsync();
        }

        public async Task<JueJinblogs> CreateJueJinblogsAsync(JueJinblogs jueJinblogs)
        {
            return await _jueJinblogsRepository.InsertAsync(jueJinblogs);
        }

        public async Task<List<JueJinblogs>> CreateJueJinblogsAsync(List<JueJinblogs> jueJinblogs)
        {
            await _jueJinblogsRepository.InsertManyAsync(jueJinblogs);
            return jueJinblogs;
        }
    }
}
