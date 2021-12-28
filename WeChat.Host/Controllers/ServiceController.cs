using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Application.Contracts.IServices;

namespace WeChat.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ITokenLapse _tokenLapse;

        public ServiceController(ITokenLapse tokenLapse)
        {
            _tokenLapse = tokenLapse;
        }

        [HttpGet("testIndex")]
        public IActionResult Index() 
        {
            var aaa = _tokenLapse.GetAll();
            return Ok("");
        }

        [HttpPost("createTokenLapse")]
        public async Task<IActionResult> CreateTokenLapseAsync([FromBody]TokenLapseDto tokenLapse)
        {
            tokenLapse.OperationTime = DateTime.Now;
            var dbTokenModel = await _tokenLapse.CreateTokenLapseAsync(tokenLapse);
            return Ok(dbTokenModel);
        }
    }
}
