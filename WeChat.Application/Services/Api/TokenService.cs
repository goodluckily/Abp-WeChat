using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using Microsoft.AspNetCore.Cors;
using Volo.Abp.ObjectMapping;
using AutoMapper;
using Volo.Abp.Guids;
using WeChat.Shared;

namespace WeChat.Application.Services
{
    [Route("Token")]
    public class TokenService : BaseService //ITokenService 
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IGuidGenerator _guidGenerator;

        //private readonly IBaseService _baseService;

        public TokenService(ITokenRepository tokenRepository, IGuidGenerator guidGenerator)// : base(tokenRepository)
        {
            _tokenRepository = tokenRepository;
            _guidGenerator = guidGenerator;
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

        /// <summary>
        /// 创建微信 Token
        /// </summary>
        /// <param name="tokenLapse"></param>
        /// <returns></returns>
        [HttpPost("createToken")]
        public async Task<DataResult> CreateTokenAsync([FromBody] TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var tokenDb = new Domain.Token(tokenLapse.Access_Token, tokenLapse.Expires_In, tokenLapse.OperationTime);

            var dbTokenModel = await _tokenRepository.CreateTokenAsync(tokenDb);
            var dto = ObjectMapper.Map<Domain.Token, TokenLapseDto>(dbTokenModel);
            return Json(dto);
        }

        [HttpGet("getDBTokenAll")]
        public DataResult GetDbTokenAll()
        {
            var guid = _guidGenerator.Create();
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.Token>, List<TokenLapseDto>>(dbTokenModel);
            return Json(dto);
        }

        #region 自定义封装返回 测试

        /// <summary>
        /// 异常测试
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet("ExTest")]
        public DataResult ExTest()
        {
            throw new ArgumentNullException("数据空异常");
        }

        /// <summary>
        /// 直接 list
        /// </summary>
        /// <returns></returns>
        [HttpGet("test1")]
        public DataResult test1()
        {
            var dbTokenModel = _tokenRepository.GetAll().ToList();
            var dto = ObjectMapper.Map<List<Domain.Token>, List<TokenLapseDto>>(dbTokenModel);
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
            var dto = ObjectMapper.Map<List<Domain.Token>, List<TokenLapseDto>>(dbTokenModel);
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
