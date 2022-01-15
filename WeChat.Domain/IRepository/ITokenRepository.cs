using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.Shared;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.IRepository
{
    public interface ITokenRepository : ITransientDependency
    {
        Task<Token> GetTokenByType(WeiChatEnum weiChatEnum = WeiChatEnum.CodeShare, TokenEnum tokenEnum = TokenEnum.Token);
        Task<Token> CreateTokenAsync(Token token);

        Task DeleteAsync(Guid id);

        Task<List<Token>> GetAllAsync();

        IEnumerable<Token> GetAll();

        Task<Token> GetTokenAsync(Guid id);

        Task<Token> UpdateAsync(Token token);
    }
}
