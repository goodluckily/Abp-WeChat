using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Common;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared.Enum;
using WeChat.Domain.Shared.Setting;

namespace WeChat.Application.Services
{
    [Route("User")]
    public class UserService : BaseService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserAndRoleMapsRepository _userAndRoleMapsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserInfoRepository userInfoRepository, IRoleRepository roleRepository, IUserAndRoleMapsRepository userAndRoleMapsRepository, IHttpContextAccessor httpContextAccessor)//
        {
            _userInfoRepository = userInfoRepository;
            _roleRepository = roleRepository;
            _userAndRoleMapsRepository = userAndRoleMapsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<DataResult> Login([FromBody] LoginDto login)
        {
            var user = await _userInfoRepository.GetUserLogin(login.LoginName, login.PassWord);
            if (user is not null)
            {
                var ExpireTime = ConfigCommon.GetConfig<int>("JWT:ExpireTime");

                //时效时间
                var expiresTime = DateTime.Now.AddMinutes(ExpireTime);

                //得到角色Ids
                var userAndRoles = _userAndRoleMapsRepository.getRolesByUserId(user.Id);
                var rolesStr = string.Join(",", userAndRoles.Select(x => x.RoleId).ToArray());
                //成功则生成token，将token返回
                var token = AuthCommon.CreateToken(user.LoginName, user.Id.ToString(), rolesStr, expiresTime);
                
                //添加到cookie 配置
                var cOptions = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = expiresTime
                };
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Authtoken", token, cOptions);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("RoleValue", rolesStr, cOptions);
                NLogCommon.WriteFileLog(NLog.LogLevel.Info, LogType.Web, "登陆成功", user.Id.ToString());
                return Json(token);
            }
            return Error("用户登录失败，账号密码错误");
        }

        [HttpGet("GetUserList")]
        public async Task<DataResult> GetUserList()
        {
            var users = await _userInfoRepository.GetAllAsync();
            return Json(users);
        }

        [HttpGet("GetRoleList")]
        public async Task<DataResult> GetRoleList()
        {
            var users = await _roleRepository.GetAllAsync();
            return Json(users);
        }

        [HttpGet("GetUserAndRoleMapsList")]
        public async Task<DataResult> GetUserAndRoleMapsList()
        {
            var users = await _userAndRoleMapsRepository.GetAllAsync();
            return Json(users);
        }


    }
}
