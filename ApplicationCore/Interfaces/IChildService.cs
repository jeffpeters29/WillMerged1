﻿using ApplicationCore.Entities;
using System;

namespace ApplicationCore.Interfaces
{
    public interface IChildService
    {
        Guid? AddOrUpdate(Child child);
        Child GetChild(Guid id);
    }
}
