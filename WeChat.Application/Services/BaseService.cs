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
    [RemoteService(false)]
    public class BaseService:ApplicationService,IBaseService
    {
        public ITokenRepository  _tokenRepository { get; init; }

        public BaseService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<string> GetTokenAsync()
        {
            var tokenDB =  await _tokenRepository.GetTokenByType();
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

        private (string access_token, double expires_in) GetAccessTokenAndTime()
        {
            var accessDynamic = BasicAPI.GetAccessToken(WeChatAppSetting.Appid, WeChatAppSetting.AppSecret);
            var val = (string)accessDynamic.ToString();
            if (val.Contains("errcode"))
            {
                throw new Exception(val);
            }
            var access_token = accessDynamic.access_token;
            var expires_in = accessDynamic.expires_in;
            return (access_token, expires_in);
        }

        public string GetJsToken()
        {
            return "";
        }

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
    }
}
