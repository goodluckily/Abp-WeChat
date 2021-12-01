using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Manager
{
    public interface ITokenLapseManager
    {
        Task<TokenLapse> CreateTokenLapseAsync(TokenLapse tokenLapse);

        Task DeleteAsync(Guid id);

        Task<List<TokenLapse>> GetAllAsync();

        Task<TokenLapse> GetTokenLapseAsync(Guid id);

        Task<TokenLapse> UpdateAsync(TokenLapse tokenLapse);
    }
}
