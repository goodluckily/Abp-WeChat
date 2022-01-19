using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface ICTO51blogsRepository : ITransientDependency
    {
        Task<List<CTO51blogs>> CreateCTO51blogsAsync(List<CTO51blogs> cTO51Blogs);
        Task<CTO51blogs> CreateCTO51blogsAsync(CTO51blogs cTO51Blogs);
        Task<List<CTO51blogs>> GetCTO51blogsAll();
    }
}
