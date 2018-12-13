using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qwill.ViewModels
{
    public class MaritalStatusVm
    {
        [Required(ErrorMessage = "Marital status is required")]
        [Display(Name = "Marital Status")]
        public Guid? SelectedMaritalStatus { get; set; }
        public List<MaritalStatus> DdlMaritalStatuses { get; set; }
    }

    //public class SelectedMaritalStatusVm
    //{
    //    public Guid? SelectedMaritalStatus { get; set; }
    //}
}
