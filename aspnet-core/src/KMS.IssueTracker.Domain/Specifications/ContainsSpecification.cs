using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Specifications
{
    public abstract class ContainsSpecification<T, TKey> : Specification<T>
        where T : IEntity<TKey>
    {
        public IEnumerable<TKey> Collection { get; }

        protected ContainsSpecification(IEnumerable<TKey> collection)
        {
            Collection = collection;
        }

        public sealed override Expression<Func<T, bool>> ToExpression()
        {
            return x => Collection.Contains(x.Id);
        }
    }
}
