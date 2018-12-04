using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class WillsService : IWillsService
    {
        private readonly IRepository<Will> _repository;
        private readonly IAppLogger<WillsService> _logger;

        public WillsService(IRepository<Will> willRepository, IAppLogger<WillsService> logger)
        {
            _repository = willRepository;
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

                    //return new Result
                    //{
                    //    Success = result != null 
                    //};
                }
                else
                {
                    //Update
                    _repository.Update(will);
                    return will.Id;
                }

                //return new Result
                //{
                //    Success = true
                //};
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"WillsService : Error saving {will.Id}", ex.Message);
                //return new Result
                //{
                //    Success = false,
                //    ErrorMessage = ex.Message
                //};

                return null;
            }
        }

        public Will GetWill(Guid id)
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
