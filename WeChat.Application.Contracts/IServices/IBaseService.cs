using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Application.Contracts.IServices
{
    public interface IBaseService
    {
        Task<string> GetTokenAsync();

        string GetJsToken();

        string GetContent(string path);
    }
}
