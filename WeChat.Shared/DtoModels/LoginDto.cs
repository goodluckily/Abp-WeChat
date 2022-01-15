using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared
{
    /// <summary>
    /// 登陆DTO
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 登陆账户
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>

        public string PassWord { get; set; }
    }
}
