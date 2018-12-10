using System;

namespace Qwill.ViewModels
{
    public class ChildVm
    {
        public Guid WillId { get; set; }

        public Guid? ChildId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
