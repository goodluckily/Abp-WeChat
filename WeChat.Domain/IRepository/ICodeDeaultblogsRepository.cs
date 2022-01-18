using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface ICodeDeaultblogsRepository : ITransientDependency
    {
        Task<CodeDeaultblogs> CreateCodeDeaultblogsAsync(CodeDeaultblogs codeDeaultblogs);
        Task<List<CodeDeaultblogs>> CreateCodeDeaultblogsAsync(List<CodeDeaultblogs> codeDeaultblogs);
        Task<List<CodeDeaultblogs>> GetCodeDeaultblogsAll();
    }
}
