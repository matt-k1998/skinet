using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            InheritedCriteria = criteria;
        }

        public Expression<Func<T, bool>> ?InheritedCriteria {get; }
        public List<Expression<Func<T, object>>> InheritedIncludes {get; } =
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            InheritedIncludes.Add(includeExpression);
        }
    }
}
