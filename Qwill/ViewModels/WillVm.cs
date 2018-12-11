using ApplicationCore.Entities;
using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qwill.ViewModels
{
    public class WillVm
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public WillStatus WillStatus { get; set; }

        //public CustomerVm Customer { get; set; }

        //public List<Child> Children { get; set; }
    }
}
