using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Contracts.DtoModels;

namespace WeChat.Application.Contracts.IServices
{
    public interface ITokenLapseService
    {
        Task<TokenLapseDto> CreateTokenLapseAsync(TokenLapseDto tokenLapse);

        Task DeleteAsync(Guid id);

        Task<List<TokenLapseDto>> GetAllAsync();

        Task<TokenLapseDto> GetTokenLapseAsync(Guid id);

        Task<TokenLapseDto> UpdateAsync(TokenLapseDto tokenLapse);
    }
}
