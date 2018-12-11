using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class WillService : IWillService
    {
        private readonly IRepository<Will> _repository;
        private readonly IAppLogger<WillService> _logger;

        public WillService(IRepository<Will> repository, IAppLogger<WillService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Guid? AddOrUpdate(Will will)
        {
            try
            {
                if (will.Id.IsGuidEmpty())
                {
                    //Add
                    var resultWill = _repository.Add(will);
                    return resultWill?.Id;
                }
                else
                {
                    //Update
                    _repository.Update(will);
                    return will.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"WillsService : Error saving {will.Id}", ex.Message);
                return null;
            }
        }

        public Will Get(Guid id)
        {
            var spec = new WillSpecification(id);
            return _repository.GetSingleBySpec(spec);
        }

        public IEnumerable<Will> GetWills()
        {
            throw new NotImplementedException();
        }
    }
}
