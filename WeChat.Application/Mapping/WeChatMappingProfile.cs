using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using WeChat.Domain;
using WeChat.Shared;

namespace WeChat.Application.Mapping
{
    public class WeChatMappingProfile : Profile
    {
        //配置实体之间的映射关系
        public WeChatMappingProfile()
        {
            CreateMap<Token, TokenLapseDto>().ReverseMap();
            CreateMap<Cnblogs, NetcnblogsDto>().ReverseMap();
            CreateMap<JueJinblogs, JueJinblogsDto>().ReverseMap();
            CreateMap<Csdnblogs, CsdnblogsDto>().ReverseMap();
            CreateMap<Segmentfaultblogs, SegmentfaultblogsDto>().ReverseMap();
            CreateMap<ItHomeblogs, ItHomeblogsDto>().ReverseMap();
            CreateMap<CodeDeaultblogs, CodeDeaultblogsDto>().ReverseMap();
            CreateMap<OsChinablogs, OsChinablogsDto>().ReverseMap();
            CreateMap<CTO51blogs, CTO51blogsDto>().ReverseMap();
        }
    }
}
