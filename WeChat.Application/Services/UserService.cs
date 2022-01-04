using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain.IRepository;

namespace WeChat.Application.Services
{
    [Route("User")]
    public class UserService : BaseService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }


        [HttpGet("GetUserList")]
        public async Task<DataResult> GetUserList()
        {
            var users = await _userInfoRepository.GetAllAsync();
            return Json(users);
        }
    }
}
