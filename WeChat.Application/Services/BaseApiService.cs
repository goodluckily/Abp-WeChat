using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WeiChatApi;
using Microsoft.AspNetCore.Mvc;

namespace WeChat.Application.Services
{
    [Authorize]
    [NonController]
    public class BaseApiService : ApplicationService
    {
        /// <summary>
        /// token仓储
        /// </summary>
        public ITokenRepository _tokenRepository { get; init; }
        /// <summary>
        /// http统一
        /// </summary>
        public IHttpContextAccessor _httpContextAccessor { get; init; }
        /// <summary>
        /// user仓储
        /// </summary>
        public IUserInfoRepository _userInfoRepository { get; init; }
        /// <summary>
        /// 返回结果统一
        /// </summary>
        public IResultService Result { get; init; }

        public ICodeDeaultblogsRepository _codeDeaultblogsRepository;
        public BaseApiService()
        {

        }

        #region 用户相关
        /// <summary>
        /// 获取当前用户Id
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public Guid CurrentUserId()
        {
            var claimsUser = _httpContextAccessor.HttpContext?.User;
            var userId = AuthCommon.GetUserId(claimsUser);
            return userId;
        }

        /// <summary>
        /// 获取当前用户 信息
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public UserInfo CurrentUserInfo()
        {
            var userId = CurrentUserId();
            var userinfo = _userInfoRepository.GetUserInfoById(userId);
            return userinfo;
        }

        #endregion

        #region Token
        /// <summary>
        /// 获取token 过期则自动刷新token
        /// </summary>
        /// <param name="weiChatEnum"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<string> GetTokenAsync(WeiChatEnum weiChatEnum = WeiChatEnum.CodeShare)
        {
            var tokenDB = await _tokenRepository.GetTokenByType(weiChatEnum);
            string tokenStr = string.Empty;
            var locaTime = DateTime.Now;
            if (tokenDB != null)
            {
                //开始时间比较是否过期 修改
                var thisTime = DateTime.Now;
                var dbExTime = tokenDB.OperationTime?.AddSeconds(tokenDB.Expires_In.GetValueOrDefault());
                if (thisTime < dbExTime) return tokenDB.Access_Token;

                //Edit
                var result = GetAccessTokenAndTime();
                tokenDB.Access_Token = result.access_token;
                tokenDB.Expires_In = result.expires_in;
                tokenDB.OperationTime = locaTime.AddMinutes(-10);//10分钟
                var editToken = _tokenRepository.UpdateAsync(tokenDB).Result;
                return tokenDB.Access_Token;
            }
            else
            {
                var result = GetAccessTokenAndTime();
                var addToken = await _tokenRepository.CreateTokenAsync(new Token()
                {
                    WeiChatType = weiChatEnum,
                    TokenType = TokenEnum.Token,
                    Access_Token = result.access_token,
                    Expires_In = result.expires_in,
                    OperationTime = locaTime.AddMinutes(-10)//10分钟
                });
                tokenStr = addToken.Access_Token;
            }
            return tokenStr;
        }

        /// <summary>
        /// 私有
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private (string access_token, double expires_in) GetAccessTokenAndTime()
        {
            var appid = ConfigCommon.Configuration["WeChatConfig:Appid"];
            var AppSecret = ConfigCommon.Configuration["WeChatConfig:AppSecret"];
            var accessDynamic = WeChatApi.GetAccessToken(appid, AppSecret);
            var val = (string)accessDynamic.ToString();
            if (val.Contains("errcode"))
            {
                throw new Exception(val);
            }
            var access_token = accessDynamic.access_token;
            var expires_in = accessDynamic.expires_in;
            return (access_token, expires_in);
        }

        #endregion
    }
}
