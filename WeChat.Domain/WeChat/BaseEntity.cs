using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace WeChat.Domain
{
    public class BaseEntity : Entity<Guid>
    {
        public Guid? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }
        public Guid? EditUserId { get; set; }

        public DateTime? EditTime { get; set; }

        public bool? IsActive { get; set; } = true;
        public bool? IsDel { get; set; } = false;

        public BaseEntity()
        {

        }
        public BaseEntity(Guid id) : base(id)
        {

        }
    }
}
