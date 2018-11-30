using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Common
{
    public class EntityBaseWithGuid : EntityBase
    {
        public Guid Id { get; set; }
    }
}
