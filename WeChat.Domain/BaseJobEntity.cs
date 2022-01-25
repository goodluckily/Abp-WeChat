using System;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain
{
    public class BaseJobEntity : Entity<Guid>
    {

        public DateTime? CreateTime { get; set; }

        public bool? IsDel { get; set; } = false;

        //public BaseJobEntity()
        //{

        //}
        //public BaseJobEntity(Guid id) : base(id)
        //{

        //}
    }
}
