using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;

namespace WeChat.Domain.Repository
{
    public class CodeDeaultblogsRepository : ICodeDeaultblogsRepository, ITransientDependency
    {
        private readonly IRepository<CodeDeaultblogs, Guid> _codeDeaultblogsRepository;

        public CodeDeaultblogsRepository(IRepository<CodeDeaultblogs, Guid> codeDeaultblogsRepository)
        {
            _codeDeaultblogsRepository = codeDeaultblogsRepository;
        }

        public async Task<CodeDeaultblogs> CreateCodeDeaultblogsAsync(CodeDeaultblogs codeDeaultblogs)
        {
            return await _codeDeaultblogsRepository.InsertAsync(codeDeaultblogs);
        }

        public async Task<List<CodeDeaultblogs>> CreateCodeDeaultblogsAsync(List<CodeDeaultblogs> codeDeaultblogs)
        {
            await _codeDeaultblogsRepository.InsertManyAsync(codeDeaultblogs);
            return codeDeaultblogs;
        }

        public async Task<List<CodeDeaultblogs>> GetCodeDeaultblogsAll()
        {
            return await _codeDeaultblogsRepository.GetListAsync();
        }
    }

}
