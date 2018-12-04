using ApplicationCore.Entities;
using System;
using System.Linq.Expressions;

namespace ApplicationCore.Specifications
{
    public class ChildSpecification : BaseSpecification<Child>
    {
        public ChildSpecification(Expression<Func<Child, bool>> criteria) : base(criteria)
        {
        }

        public ChildSpecification(Guid id)
            : base(i => i.Id.Equals(id))
        {
        }
    }
}
