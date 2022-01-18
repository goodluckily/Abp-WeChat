using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WeChat.Domain.IRepository
{
    public interface IItHomeblogsRepository : ITransientDependency
    {
        Task<List<ItHomeblogs>> CreateItHomeblogsAsync(List<ItHomeblogs> itHomeblogs);
        Task<ItHomeblogs> CreateItHomeblogsAsync(ItHomeblogs itHomeblogs);
        Task<List<ItHomeblogs>> GetItHomeblogsAll();
    }
}
