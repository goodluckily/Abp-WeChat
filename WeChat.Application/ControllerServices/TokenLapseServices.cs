using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using WeChat.Application.Contracts.IServices;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Domain.Manager;
using WeChat.Domain.WeChat;

namespace WeChat.Application.ControllerServices
{
    [Route("Token")]
    [RemoteService]
    public class TokenLapseServices : ApplicationService, ITokenLapseService
    {
        private readonly ITokenLapseManager _tokenLapseManager;

        public TokenLapseServices(ITokenLapseManager tokenLapseManager)
        {
            _tokenLapseManager = tokenLapseManager;
        }

        [HttpPost("createToken")]
        public async Task<TokenLapseDto> CreateTokenLapseAsync(TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var tokenDb = new TokenLapse(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);

            var dbTokenModel = await  _tokenLapseManager.CreateTokenLapseAsync(tokenDb);
            var dto = ObjectMapper.Map<TokenLapse, TokenLapseDto>(dbTokenModel);
            return dto;
        }

        [HttpDelete("del")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        [HttpGet("getAll")]
        public Task<List<TokenLapseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        [HttpGet("GetTokenLapse")]
        public Task<TokenLapseDto> GetTokenLapseAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        [HttpPost("update")]
        public Task<TokenLapseDto> UpdateAsync(TokenLapseDto tokenLapse)
        {
            throw new NotImplementedException();
        }
    }
}
