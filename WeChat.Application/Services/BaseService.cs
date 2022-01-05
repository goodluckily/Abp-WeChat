using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WeChat.Application.Contracts.IServices;
using WeChat.Common;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared.Enum;
using WeChat.Domain.Shared.Setting;
using WeChat.Domain.WeChat;

namespace WeChat.Application.Services
{
    [Authorize]
    public class BaseService : ApplicationService
    {
        public ITokenRepository _tokenRepository { get; init; }

        //public BaseService(ITokenRepository tokenRepository)
        //{
        //    _tokenRepository = tokenRepository;
        //}
        public BaseService()
        {

        }

        [RemoteService(false)]
        public async Task<string> GetTokenAsync()
        {
            var tokenDB = await _tokenRepository.GetTokenByType();
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
                    WeiChatType = WeiChatEnum.CodeShare,
                    TokenType = TokenEnum.Token,
                    Access_Token = result.access_token,
                    Expires_In = result.expires_in,
                    OperationTime = locaTime.AddMinutes(-10)//10分钟
                });
                tokenStr = addToken.Access_Token;
            }
            return tokenStr;
        }


        [RemoteService(false)]
        public string GetContent(string path)
        {
            string json = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                using (StreamReader sr = new StreamReader(fs, utf8))
                {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }

        private (string access_token, double expires_in) GetAccessTokenAndTime()
        {
            var appid = ConfigCommon.Configuration["WeChatConfig:Appid"];
            var AppSecret = ConfigCommon.Configuration["WeChatConfig:AppSecret"];
            var accessDynamic = BasicAPI.GetAccessToken(appid, AppSecret);
            var val = (string)accessDynamic.ToString();
            if (val.Contains("errcode"))
            {
                throw new Exception(val);
            }
            var access_token = accessDynamic.access_token;
            var expires_in = accessDynamic.expires_in;
            return (access_token, expires_in);
        }

        private string GetJsToken()
        {
            return "";
        }

        #region 返回值封装

        [RemoteService(false)]
        public DataResult Json(object data, string message = "")
        {
            var result = new DataResult(true, data, message);
            return result;
        }
        [RemoteService(false)]
        public DataResult Json(long total, object data, string message = "")
        {
            var result = new DataResult(true, total, data, message);
            return result;
        }
        [RemoteService(false)]
        public DataResult Ok(string message)
        {
            var result = new DataResult(true, message);
            return result;
        }
        [RemoteService(false)]
        public DataResult Error(string message)
        {
            var result = new DataResult(false, message);
            return result;
        }

        #endregion
    }
}
