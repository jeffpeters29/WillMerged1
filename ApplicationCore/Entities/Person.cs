using ApplicationCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Person : EntityBaseWithGuid
    {
        public string FirstName { get; set; }
    }
}
