using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using WeChat.Application.Services;
using WeChat.Domain.IRepository;
using WeChat.EntityFramewoekCore;
using WeChat.Shared;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Domain;
using Senparc.Weixin.Entities;
using System.Data;
using System.Linq.Dynamic.Core;
namespace WeChat.Host
{
    public class InitSeedDataServer : BackgroundService, ITransientDependency
    {
        private readonly ILogger<InitSeedDataServer> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IGuidGenerator _guidGenerator;

        public InitSeedDataServer(ILogger<InitSeedDataServer> logger, IServiceProvider serviceProvider, IHostEnvironment hostEnvironment,IGuidGenerator guidGenerator)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _hostEnvironment = hostEnvironment;
            _guidGenerator = guidGenerator;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var dbContext = _serviceProvider.GetRequiredService<WeChatDbContext>())
            {
                // 使用 dbContext
                var check = dbContext.Set<UserInfo>().Any();
                if (!check)
                {
                    var (userInfo, role, userAndroleMap) = new UserInfo(_guidGenerator.Create()).GetSeedUserData(_guidGenerator.Create());
                    await dbContext.AddAsync(userInfo);
                    await dbContext.AddAsync(role);
                    await dbContext.AddAsync(userAndroleMap);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
