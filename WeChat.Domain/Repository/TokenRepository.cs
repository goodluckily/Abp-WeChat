using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared;
using WeChat.Domain.WeChat;

namespace WeChat.Domain.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IRepository<Token> _tokenLapsesRepository;

        #region DL
        public TokenRepository(IRepository<Token> tokenLapsesRepository)
        {
            _tokenLapsesRepository = tokenLapsesRepository;
        }
        #endregion

        public async Task<Token> CreateTokenAsync(Token tokenLapse)
        {
            if (await _tokenLapsesRepository.AnyAsync(x => x.Id == tokenLapse.Id))
            {
                throw new BusinessException(WeChatExceptionCodes.CodeAlreadyExist).WithData("Id", tokenLapse.Id);
            }
            var insertModel = await _tokenLapsesRepository.InsertAsync(tokenLapse);
            return insertModel;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _tokenLapsesRepository.DeleteAsync(x => x.Id == id);
        }

        public IEnumerable<Token> GetAll()
        {
            return _tokenLapsesRepository.GetListAsync(x => true).Result;
        }

        public async Task<List<Token>> GetAllAsync()
        {
            return await _tokenLapsesRepository.GetListAsync(x => true);
        }

        public Task<Token> GetTokenAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> GetTokenByType(WeiChatEnum weiChatEnum = WeiChatEnum.CodeShare, TokenEnum tokenEnum = TokenEnum.Token)
        {
            return await _tokenLapsesRepository.FirstOrDefaultAsync(x => x.WeiChatType == weiChatEnum && x.TokenType == tokenEnum);
        }

        public async Task<Token> GetTokenLapseAsync(Guid id)
        {
            return await _tokenLapsesRepository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Token> UpdateAsync(Token tokenLapse)
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
