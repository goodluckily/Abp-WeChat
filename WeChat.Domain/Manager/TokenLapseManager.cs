using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.Shared.ExceptionCodes;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Manager
{
    public class TokenLapseManager : ITokenLapseManager
    {
        private readonly IRepository<TokenLapse, Guid> _tokenLapsesRepository;
        #region DL
        public TokenLapseManager(IRepository<TokenLapse, Guid> tokenLapsesRepository)
        {
            _tokenLapsesRepository = tokenLapsesRepository;
        }
        #endregion
        public async Task<TokenLapse> CreateTokenLapseAsync(TokenLapse tokenLapse)
        {
            if (await _tokenLapsesRepository.AnyAsync(x => x.Id == tokenLapse.Id))
            {
                throw new BusinessException(WeChatExceptionCodes.CodeAlreadyExist).WithData("Id", tokenLapse.Id);
            }
            return await _tokenLapsesRepository.InsertAsync(tokenLapse);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _tokenLapsesRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<List<TokenLapse>> GetAllAsync()
        {
            return await _tokenLapsesRepository.GetListAsync(x => true);
        }

        public async Task<TokenLapse> GetTokenLapseAsync(Guid id)
        {
            return await _tokenLapsesRepository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TokenLapse> UpdateAsync(TokenLapse tokenLapse)
        {
            if (tokenLapse.Id == Guid.Empty)
                throw new BusinessException(WeChatExceptionCodes.IdIsNullOrEmpty);

            if (string.IsNullOrWhiteSpace(tokenLapse.Access_Token))
                throw new BusinessException(WeChatExceptionCodes.TokenIsEmpty);

            var warehouse = await _tokenLapsesRepository.FirstOrDefaultAsync(t => t.Id == tokenLapse.Id)
               ?? throw new BusinessException(WeChatExceptionCodes.NotFound).WithData("id", tokenLapse.Id);

            warehouse.UpdateTokenLapse(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);
            await _tokenLapsesRepository.UpdateAsync(warehouse);

            return warehouse;
        }
    }
}
