using System;

namespace Qwill.ViewModels
{
    public class ChildVm
    {
        public Guid WillId { get; set; }

        public Guid? ChildId { get; set; }

        public string ChildName { get; set; }

        public bool Over18 { get; set; }
    }
}
