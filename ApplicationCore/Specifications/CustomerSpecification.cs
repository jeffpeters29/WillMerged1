using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        public CustomerSpecification(Expression<Func<Customer, bool>> criteria) : base(criteria)
        {
        }

        public CustomerSpecification(Guid id) : base(i => i.Id.Equals(id))
        {
        }

        public CustomerSpecification(Will will) : base(c => c.Will.Id.Equals(will.Id))
        {
        }
    }
}
