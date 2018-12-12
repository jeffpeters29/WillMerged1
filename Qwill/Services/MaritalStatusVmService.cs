using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Linq;

namespace Qwill.Services
{
    public class MaritalStatusVmService : IMaritalStatusVmService
    {
        private readonly IMaritalStatusService _maritalStatusService;

        public MaritalStatusVmService(IMaritalStatusService maritalStatusService)
        {
            _maritalStatusService = maritalStatusService;
        }

        public MaritalStatus Get(Guid? id) => _maritalStatusService.Get(id);

        public MaritalStatusVm GetAll() => new MaritalStatusVm
        {
            DdlMaritalStatuses = _maritalStatusService.GetAll().ToList()
        };
    }
}
