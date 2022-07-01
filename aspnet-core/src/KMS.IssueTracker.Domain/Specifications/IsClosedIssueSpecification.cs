using KMS.IssueTracker.Issues;
using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Specifications
{
    public class IsClosedIssueSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression() =>
            issue => issue.IsClosed;
    }
}
