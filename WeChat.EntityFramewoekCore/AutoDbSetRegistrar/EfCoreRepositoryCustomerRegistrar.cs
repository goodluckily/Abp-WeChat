using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace WeChat.EntityFramewoekCore
{
    public class EfCoreRepositoryCustomerRegistrar : EfCoreRepositoryRegistrar
    {
        public EfCoreRepositoryCustomerRegistrar(AbpDbContextRegistrationOptions abpDbContextRegistrationOptions) : base(abpDbContextRegistrationOptions)
        {

        }

        public override void AddRepositories()
        {
            foreach (var entityType in GetEntityType())
            {
                RegisterDefaultRepository(entityType);
            }
        }
        private IEnumerable<Type> GetEntityType()
        {
            var types = Assembly.Load("WeChat.Domain").GetTypes();
            return types.Where(s => typeof(IEntity).IsAssignableFrom(s)).ToList();
        }
    }
}
