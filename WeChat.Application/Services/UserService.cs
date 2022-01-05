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
using WeChat.Domain.Shared.Setting;

namespace WeChat.Application.Services
{
    [Route("User")]
    public class UserService : BaseService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserAndRoleMapsRepository _userAndRoleMapsRepository;

        public UserService(IUserInfoRepository userInfoRepository, IRoleRepository roleRepository, IUserAndRoleMapsRepository userAndRoleMapsRepository)//
        {
            _userInfoRepository = userInfoRepository;
            _roleRepository = roleRepository;
            _userAndRoleMapsRepository = userAndRoleMapsRepository;
        }

        [HttpPost("Login")]
        public async Task<DataResult> Login([FromBody] LoginDto login)
        {
            var user = await _userInfoRepository.GetUserLogin(login.LoginName, login.PassWord);
            if (user is not null)
            {
                //时效时间
                var expiresTime = DateTime.Now.AddMinutes(WeChatAppSetting.ExpireTime ?? 60);

                //得到角色Ids
                var userAndRoles = _userAndRoleMapsRepository.getRolesByUserId(user.Id);
                //成功则生成token，将token返回
                var token = AuthCommon.CreateToken(user.LoginName, user.Id.ToString(), string.Join(",", userAndRoles.Select(x => x.RoleId).ToArray()), expiresTime);
                
                //添加到cookie 配置
                var cOptions = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = expiresTime
                };

                //HttpContext.Response.Cookies.Append("authtoken", token, cOptions);
                //HttpContext.Response.Cookies.Append("permValue", user.UPermissionValue, cOptions);
                //NLogHelper.LoginInfo("用户登录成功", new { userId = user.UId, accountName = user.UAccountName, permission = user.UPermissionValue, token = token });
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
