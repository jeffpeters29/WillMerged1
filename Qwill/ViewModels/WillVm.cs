﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qwill.ViewModels
{
    public class WillVm
    {
        public Guid Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Your e-mail")]
        [Required(ErrorMessage = "An email address is required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string Email { get; set; }
    }
}