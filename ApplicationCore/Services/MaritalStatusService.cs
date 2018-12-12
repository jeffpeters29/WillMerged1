using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly List<MaritalStatus> _maritalStatuses = new List<MaritalStatus>()
            {
                new MaritalStatus { Id = new Guid("633976ac-1367-42cc-812e-cbfcbbefc789"), Description = "Married" },
                new MaritalStatus { Id = new Guid("f01436ec-ef7b-4ec0-bb58-58c5ce6932d8"), Description = "Civil Partnership" },
                new MaritalStatus { Id = new Guid("b2d98283-9bb5-4fcf-a584-2728c4c7c757"), Description = "Single" },
                new MaritalStatus { Id = new Guid("7cd83800-507f-4160-a216-a6d92fd1edb6"), Description = "Divorced" },
                new MaritalStatus { Id = new Guid("97acd8f0-e48a-4adf-8957-0f869f64a587"), Description = "Separated" },
                new MaritalStatus { Id = new Guid("cfa9cd37-2267-4b9d-ae41-eb88c8e89881"), Description = "Widowed" }
            };

        public MaritalStatus Get(Guid? id)
        {
            return _maritalStatuses.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MaritalStatus> GetAll()
        {
            return _maritalStatuses;
        }
    }
}
