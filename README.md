### Abp-WeChat

##### WeChat.EntityFramewoekCore 仓储实现层,领域的充血模型 DbSet<>, IEfCoreDbContext,AbpDbContext 会在里面 

- 依赖 `WeChat.Domain `

- `private readonly IRepository<Warehouse, Guid> _warehouseRepository;`

##### WeChat.Application.Domain 领域层 (核心就是 充血模型Model)   里面定义了 IReponstory 和 Reponstory 

- 依赖 `Warehouse.Domain.Shared`

##### Warehouse.Domain.Shared (领域Model共享层,这一层可以被其他任何都可以引用,包含一些常量,枚举,变量这些)

##### WeChat.Contracts 合约层

- 主要是 定义一些 Dto(viewModel)类 和生命IService(业务抽象层) 用的

##### WeChat.Application (相当于Bll 业务处理层)

- 依赖 `WeChat.Domain` 领域层(充血Model层) 


##### WeChat.Host API的应用程序

- 依赖 `eChat.Application`层
- 依赖 `WeChat.EntityFrameworkCore`层


### WeChat.Web UI之类的
