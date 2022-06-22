using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Security.Claims;

namespace WeChat.Shared
{
    public class AuthCommon
    {
        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="uuid"></param>
        /// <param name="permValue"></param>
        /// <param name="expiresTime"></param>
        /// <returns></returns>
        public static string CreateToken(string username, string uuid, string roleId, DateTime expiresTime)
        {
            var SecretKey = ConfigCommon.Configuration["JWT:SecretKey"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //获取实例
                Subject = new ClaimsIdentity(GetClaims(uuid, username, roleId)),
                Expires = expiresTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 验证 Jwt 令牌是否正确 (防止篡改)
        /// </summary>
        /// <param name="encodeJwt"></param>
        /// <returns></returns>
        public static bool ValidJwtToken(string encodeJwt)
        {
            var SecretKey = ConfigCommon.Configuration["JWT:SecretKey"];
            var success = true;
            var jwtArr = encodeJwt.Split('.');

            if (jwtArr.Length < 0) return false;//数据格式都不对直接pass

            //var header = JsonConvert.DeserializeObject<Dictionary<string, string>>(Base64UrlEncoder.Decode(jwtArr[0]));
            //var payLoad = JsonConvert.DeserializeObject<Dictionary<string, string>>(Base64UrlEncoder.Decode(jwtArr[1]));

            //配置文件中取出来的签名秘钥
            var hs256 = new HMACSHA256(Encoding.UTF8.GetBytes(SecretKey));
            //验证签名是否正确（把用户传递的签名部分取出来和服务器生成的签名匹配即可）
            success = string.Equals(jwtArr[2], Base64UrlEncoder.Encode(hs256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(jwtArr[0], ".", jwtArr[1])))));
            return success;
        }




        /// <summary>
        /// 判断当前用户id不是admin用户或admin角色
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="func">当前用户所拥有的角色id集合</param>
        /// <returns></returns>
        public static bool CheckNotAdmin(int userId, Func<int, List<int>> func)
        {
            //先判断admin用户
            var isNotAdmin = ConfigCommon.GetConfig<int>("Conf:AdminId") != userId;
            if (!isNotAdmin) return isNotAdmin;
            //判断admin角色
            if (func != null)
            {
                //_userRelationService.GetRolesByRedis(userId);
                var roles = func(userId);
                var adminRoleId = ConfigCommon.GetConfig<int>("Conf:AdminRoleId");
                isNotAdmin = !roles.Contains(adminRoleId);
            }
            return isNotAdmin;
        }

        public static Claim[] GetClaims(string UserId, string UserName, string roleId)
        {
            int refreshTime = ConfigCommon.GetConfig<int>("ClaimConf:RefreshTime");
            int expireTime = ConfigCommon.GetConfig<int>("ClaimConf:ExpireTime");
            return new[] {
                new Claim("RefreshTime",DateTime.Now.AddMinutes(refreshTime).ToString()),
                new Claim("ExpireTime",DateTime.Now.AddMinutes(expireTime).ToString()),
                new Claim(AbpClaimTypes.UserId, UserId),
                new Claim(AbpClaimTypes.UserName,UserName),
                new Claim(AbpClaimTypes.Role,roleId)
            };
        }

        public static Guid GetUserId(ClaimsPrincipal user)
        {
            //应该要先验证token的可用性
            var claimsIdentity = user.Identity as ClaimsIdentity;
            var value = claimsIdentity.FindFirst(AbpClaimTypes.UserId)?.Value;
            var userId = value != null ? Guid.Parse(value) : Guid.Empty;
            return userId;
        }

        public static void AddBlackList(string token)
        {
            var tokens = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = tokens.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            var expireTime = tokens.Claims.FirstOrDefault(x => x.Type == "expireTime")?.Value;
            // var key = DataCommon.PRE_TOKEN_BLACKLIST + userId + expireTime;
            var time = (DateTime.Parse(expireTime) - DateTime.Now).TotalHours * 1.1;
            if (time > 0)
            {
                var hour = Math.Round(time, 2);
                //RedisService.SetTValue(key, token, hour);
            }
        }
    }
}
