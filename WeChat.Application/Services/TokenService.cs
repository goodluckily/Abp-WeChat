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
using WeChat.Domain.WeChat;
using WeChat.Domain.IRepository;
using Microsoft.AspNetCore.Cors;
using Volo.Abp.ObjectMapping;
using AutoMapper;

namespace WeChat.Application.Services
{
    public class TokenService : ApplicationService, ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IBaseService _baseService;

        public TokenService(ITokenRepository tokenRepository,IBaseService baseService)
        {
            _tokenRepository = tokenRepository;
            _baseService = baseService;
        }

        [HttpPost("CreateTokenLapseAsync1")]
        public async Task<TokenLapseDto> CreateTokenLapseAsync([FromBody]TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var tokenDb = new Domain.WeChat.Token(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);

            var dbTokenModel = await _tokenRepository.CreateTokenAsync(tokenDb);
            var dto = ObjectMapper.Map<Domain.WeChat.Token, TokenLapseDto>(dbTokenModel);
            return dto;
        }

        [RemoteService(true)]
        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            throw new ArgumentNullException("删除无效Null");
        }

        [HttpGet("GetAll")]
        public IEnumerable<TokenLapseDto> GetAll()
        {
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.WeChat.Token>, List<TokenLapseDto>>(dbTokenModel);
            return dto;
        }

        [RemoteService(false)]
        public Task<TokenLapseDto> GetTokenLapseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public Task<TokenLapseDto> UpdateAsync(TokenLapseDto tokenLapse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("GetTokenAsync")]
        public async Task<string> GetTokenAsync() 
        {
            var token = await _baseService.GetTokenAsync();
            return token;
        }
    }
}
