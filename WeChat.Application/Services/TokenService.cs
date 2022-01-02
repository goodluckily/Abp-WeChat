﻿using System;
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
    public class TokenService : BaseService //ITokenService 
    {
        private readonly ITokenRepository _tokenRepository;
        //private readonly IBaseService _baseService;

        public TokenService(ITokenRepository tokenRepository)// : base(tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        /// <summary>
        /// 手动创建 WeChat Token
        /// </summary>
        /// <param name="tokenLapse"></param>
        /// <returns></returns>

        [HttpGet("getWeChatToken")]
        public async Task<DataResult> GetWeChatToken() 
        {
            return Json(await GetTokenAsync());
        }

        [HttpPost("createToken")]
        public async Task<DataResult> CreateTokenAsync([FromBody] TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var tokenDb = new Domain.WeChat.Token(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);

            var dbTokenModel = await _tokenRepository.CreateTokenAsync(tokenDb);
            var dto = ObjectMapper.Map<Domain.WeChat.Token, TokenLapseDto>(dbTokenModel);
            return Json(dto);
        }

        [HttpGet("getDBTokenAll")]
        public DataResult GetDbTokenAll()
        {
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.WeChat.Token>, List<TokenLapseDto>>(dbTokenModel);
            return Json(dto);
        }

        #region 自定义封装返回 测试

        /// <summary>
        /// 直接 list
        /// </summary>
        /// <returns></returns>
        [HttpGet("test1")]
        public DataResult test1()
        {
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.WeChat.Token>, List<TokenLapseDto>>(dbTokenModel);
            return Json(dto);
        }

        /// <summary>
        /// 分页 list
        /// </summary>
        /// <returns></returns>
        [HttpGet("test2")]
        public DataResult test2()
        {
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.WeChat.Token>, List<TokenLapseDto>>(dbTokenModel);
            return Json(dto.Count, dto);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        [HttpGet("test3")]
        public DataResult test3()
        {
            return Ok("操作成功");
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        [HttpGet("test4")]
        public DataResult test4()
        {
            return Error("操作失败");
        }
        #endregion
    }
}
