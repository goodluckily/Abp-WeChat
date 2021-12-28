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

    public class TokenLapse : ApplicationService, ITokenLapse
    {
        private readonly ITokenLapseRepository _tokenLapseManager;
        public TokenLapse(ITokenLapseRepository tokenLapseManage)
        {
            _tokenLapseManager = tokenLapseManage;
        }

        public async Task<TokenLapseDto> CreateTokenLapseAsync(TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var tokenDb = new Domain.WeChat.TokenLapse(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);

            var dbTokenModel = await _tokenLapseManager.CreateTokenLapseAsync(tokenDb);
            var dto = ObjectMapper.Map<Domain.WeChat.TokenLapse, TokenLapseDto>(dbTokenModel);
            return dto;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TokenLapseDto> GetAll()
        {
            var dbTokenModel = _tokenLapseManager.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.WeChat.TokenLapse>, List<TokenLapseDto>>(dbTokenModel);
            return dto;
        }


        public Task<TokenLapseDto> GetTokenLapseAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<TokenLapseDto> UpdateAsync(TokenLapseDto tokenLapse)
        {
            throw new NotImplementedException();
        }

    }
}
