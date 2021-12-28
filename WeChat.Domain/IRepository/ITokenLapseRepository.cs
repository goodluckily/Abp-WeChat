using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.IRepository
{
    public interface ITokenLapseRepository: ITransientDependency
    {
        Task<TokenLapse> CreateTokenLapseAsync(TokenLapse tokenLapse);

        Task DeleteAsync(Guid id);

        Task<List<TokenLapse>> GetAllAsync();

        IEnumerable<TokenLapse> GetAll();

        Task<TokenLapse> GetTokenLapseAsync(Guid id);

        Task<TokenLapse> UpdateAsync(TokenLapse tokenLapse);
    }
}
