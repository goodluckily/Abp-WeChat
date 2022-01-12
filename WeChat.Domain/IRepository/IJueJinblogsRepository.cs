using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.IRepository
{
    public interface IJueJinblogsRepository : ITransientDependency
    {
        Task<JueJinblogs> CreateJueJinblogsAsync(JueJinblogs jueJinblogs);
        Task<List<JueJinblogs>> CreateJueJinblogsAsync(List<JueJinblogs> jueJinblogs);
        Task<List<JueJinblogs>> GetJueJinblogsAll();
    }
}
