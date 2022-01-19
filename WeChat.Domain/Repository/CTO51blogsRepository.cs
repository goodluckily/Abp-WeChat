using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class CTO51blogsRepository : ICTO51blogsRepository
    {
        private readonly IRepository<CTO51blogs, Guid> _cTO51Repository;

        public CTO51blogsRepository(IRepository<CTO51blogs, Guid> cTO51Repository)
        {
            _cTO51Repository = cTO51Repository;
        }

        public async Task<CTO51blogs> CreateCTO51blogsAsync(CTO51blogs cTO51Blogs)
        {
            return await _cTO51Repository.InsertAsync(cTO51Blogs);
        }

        public async Task<List<CTO51blogs>> CreateCTO51blogsAsync(List<CTO51blogs> cTO51Blogs)
        {
            await _cTO51Repository.InsertManyAsync(cTO51Blogs);
            return cTO51Blogs;
        }

        public async Task<List<CTO51blogs>> GetCTO51blogsAll()
        {
            return await _cTO51Repository.ToListAsync();
        }
    }
}
