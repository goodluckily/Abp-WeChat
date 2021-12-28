using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Domain.WeChat;

namespace WeChat.Application.Mapping
{
    public class WeChatMappingProfile:Profile
    {
        //配置实体之间的映射关系
        public WeChatMappingProfile()
        {
            CreateMap<TokenLapse, TokenLapseDto>().ReverseMap();
        }
    }
}
