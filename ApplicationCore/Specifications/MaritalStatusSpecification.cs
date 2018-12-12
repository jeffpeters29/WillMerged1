using ApplicationCore.Entities;
using System;
using System.Linq.Expressions;

namespace ApplicationCore.Specifications
{
    public class MaritalStatusSpecification : BaseSpecification<MaritalStatus>
    {
        public MaritalStatusSpecification(Expression<Func<MaritalStatus, bool>> criteria) : base(criteria)
        {
        }

        public MaritalStatusSpecification(Guid id) : base(i => i.Id.Equals(id))
        {
        }
    }
}
