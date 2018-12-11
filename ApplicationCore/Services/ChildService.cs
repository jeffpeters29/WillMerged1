using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;

namespace ApplicationCore.Services
{
    public class ChildService : IChildService
    {
        private readonly IRepository<Child> _repository;
        private readonly IAppLogger<ChildService> _logger;

        public ChildService(IRepository<Child> repository, IAppLogger<ChildService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Guid? AddOrUpdate(Child child)
        {
            try
            {
                if (child.Id.IsGuidEmpty())
                {
                    //Add
                    var resultChild = _repository.Add(child);

                    return resultChild?.Id;
                }
                else
                {
                    //Update
                    _repository.Update(child);
                    return child.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"ChildService : Error saving {child.Id}", ex.Message);

                return null;
            }
        }

        public Child Get(Guid id)
        {
            var spec = new ChildSpecification(id);
            return _repository.GetSingleBySpec(spec);
        }
    }
}
