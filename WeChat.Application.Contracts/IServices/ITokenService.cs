using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WeChat.Application.Contracts.DtoModels;

namespace WeChat.Application.Contracts.IServices
{
    public interface ITokenService //: ITransientDependency 指定特殊的生命周期的时候使用 不常用
    {
        Task<TokenLapseDto> CreateTokenLapseAsync(TokenLapseDto tokenLapse);

        Task DeleteAsync(Guid id);

        IEnumerable<TokenLapseDto> GetAll();

        Task<TokenLapseDto> GetTokenLapseAsync(Guid id);

        Task<TokenLapseDto> UpdateAsync(TokenLapseDto tokenLapse);
    }
}
