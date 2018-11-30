using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Child : Person
    {
        public bool Over18 { get; set; }

        public Will Will { get; set; }
    }
}
