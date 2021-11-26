### Abp-WeChat




##### WeChat.EntityFramewoekCore 仓储实现层,领域的充血模型 DbSet<>, IEfCoreDbContext,AbpDbContext 会在里面 

- 依赖 `WeChat.Domain `

- `private readonly IRepository<Warehouse, Guid> _warehouseRepository;`

  

##### WeChat.Application.Domain 领域层 (核心就是 充血模型Model)   里面定义了 IReponstory 和 Reponstory 

- 依赖 `WeChat.Domain.Shared`

  

##### Warehouse.Domain.Shared (领域Model共享层,这一层可以被其他任何都可以引用)

- 包含一些常量,枚举,变量这些

  

##### WeChat.Application.Contracts 合约层 （相当于定义 IService 和Dtom ViewModel 用的）

- 依赖 `WeChat.Domain.Shared`

- 主要是 定义一些 Dto(viewModel)类 和生命IService(业务抽象层) 用的



##### WeChat.Application (实现`Contracts` 合约层里面的 Service ，做一些业务处理 BLL的作用

- 依赖 `WeChat.Domain` 领域层(充血Model层) 
- 依赖 `WeChat.Applicatiopn.Contracts` 合约层




##### WeChat.Host API的应用程序

- 依赖 `eChat.Application`层
- 依赖 `WeChat.EntityFrameworkCore`层   （感觉主要就是为了 DL 注入仓储用的）



##### WeChat.Web UI之类的

- React
- Vue
- JQ
