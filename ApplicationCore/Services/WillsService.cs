using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Entities.Common;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;

namespace ApplicationCore.Services
{
    public class WillsService : IWillsService
    {
        private readonly IRepository<Will> _willRepository;
        private readonly IAppLogger<WillsService> _logger;

        public WillsService(IRepository<Will> willRepository, IAppLogger<WillsService> appLogger)
        {
            _willRepository = willRepository;
            _logger = appLogger;
        }

        public Result AddOrUpdate(Will will)
        {
            try
            {
                if (will.Id.IsGuidEmpty())
                {
                    //Add
                    var result = _willRepository.Add(will);
                    return new Result
                    {
                        Success = result != null 
                    };
                }
                else
                {
                    //Update
                    _willRepository.Update(will);
                }

                return new Result
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"WillsService : Error saving {will.Id}", ex.Message);
                return new Result
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public Will GetWill(Guid id)
        {
            var willSpec = new WillSpecification(id);
            return _willRepository.GetSingleBySpec(willSpec);
        }

        public IEnumerable<Will> GetWills()
        {
            throw new NotImplementedException();
        }
    }
}
