using ApplicationCore.Entities;
using System;
using System.Linq.Expressions;

namespace ApplicationCore.Specifications
{
    public class WillSpecification : BaseSpecification<Will>
    {
        public WillSpecification(Expression<Func<Will, bool>> criteria) : base(criteria)
        {
        }

        public WillSpecification(Guid id)
            : base(i => i.Id.Equals(id))
        {
        }
    }
}
