﻿using System;

namespace Qwill.ViewModels
{
    public class ChildVm
    {
        public Guid WillId { get; set; }

        public Guid? ChildId { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
