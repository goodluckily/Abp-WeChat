using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface ICsdnblogsRepository : ITransientDependency
    {
        Task<Csdnblogs> CreateCsdnblogssync(Csdnblogs csdnblogs);
        Task<List<Csdnblogs>> CreateCsdnblogsAsync(List<Csdnblogs> csdnblogs);
        Task<List<Csdnblogs>> GetCsdnblogsAll();
    }


}
