﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using WeChat.Domain.WeChat;
using WeChat.Domain.Shared;

namespace WeChat.Application.Mapping
{
    public class WeChatMappingProfile : Profile
    {
        //配置实体之间的映射关系
        public WeChatMappingProfile()
        {
            CreateMap<Token, TokenLapseDto>().ReverseMap();
            CreateMap<Netcnblogs, NetcnblogsDto>().ReverseMap();

            CreateMap<JueJinblogs, JueJinblogsDto>().ReverseMap();
        }
    }
}
