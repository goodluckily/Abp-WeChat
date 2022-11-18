### Abp-WeChat




##### WeChat.EntityFramewoekCore 仓储实现层,领域的充血模型 DbSet<>, IEfCoreDbContext,AbpDbContext 会在里面 

- 依赖 `WeChat.Domain `

- `private readonly IRepository<Warehouse, Guid> _warehouseRepository;`

  

##### WeChat.Application.Domain 领域层 (核心就是 充血模型Model)   里面定义了 IReponstory 和 Reponstory 

- 依赖 `WeChat.Shared`

  

##### Warehouse.Domain.Shared (领域Model共享层,这一层可以被其他任何都可以引用)

- 包含一些常量,枚举,变量这些

  

##### WeChat.Application.Contracts 合约层 （相当于定义 IService 和Dtom ViewModel 用的）

- 依赖 `WeChat.Shared`

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

  

#### 现在数据库采用的是MySql



#### Api项目-目前规划以及进度

1. 用户模块
   - 简单的==JWT用户授权登陆==的接口验证已经完成, 默认登陆Admin,123456 ==暂未处理用户权限相关==
2. Job定时任务模块
   - 采用的是==Hangfire== 采用MySql作为任务存储,自带UI管理页面,后台开启==泛型Host==,AddHostService处理Job任务
   - 特需说明,本来想动态反射特性去处理Job任务的,后台过于麻烦,使用的Api方式的HttpPost请求,采用ActionFilter去每一个请求进行ServiceKey的md5进行验证,增加安全保护,相当于自己调用自己
3. 系统其他相关设置
   - Code-First 集成种子数据,默认生成 用户--角色之间的关系
   - MySql数据库,Abp里面的Guid相关设置
   - 微信Token获取,以及刷新之间的关系处理
   - 统一封装Api的返回结果
   - 异常自定义Filter,全局统一检测并把异常消息通过NLog保到MySql数据库
   - Nlog的集成,日志消息持久化到数据库
 
 
 #### Web项目-目前规划以及进度
 1.正在学习React中,还差三天的视频学习吧
 2.查找网上现有的React Admin后台管理系统,作为参考 Ant前端框架
 3.慢慢学习介入后端Api
 
  #### 实际中使用Vue相关的东西,越来越熟悉了
 
  #### 动态多语言的模块已经完成
  
  ``#### 目标框架已经升级为.net6``
  
  ``#### 目标框架已经 退回.net5了 应为内部的数据库调用包,会出现问题`
  
  
  
   ## 准备之后进行如下的拆分
  ### 可以参考Abp那一套项目框架结构 重新升级最新版本,进行开发



###### 框架版本 .net 6

- Api 库

- 定时任务库

- Blazor WebAssembly (前端 UI 设计库)  期待采用UI框架 (https://blazor.radzen.com/)
