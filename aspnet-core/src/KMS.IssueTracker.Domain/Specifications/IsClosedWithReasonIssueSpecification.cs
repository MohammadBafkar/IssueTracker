using KMS.IssueTracker.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Specifications
{
    public class IsClosedWithReasonIssueSpecification : CompositeSpecification<Issue>
    {
        private readonly IssueCloseReason? _closeReason;
        public IsClosedWithReasonIssueSpecification()
            : this(null)
        {
        }
        public IsClosedWithReasonIssueSpecification(IssueCloseReason? closeReason)
            : base(new IsClosedIssueSpecification(), new CompletedIssueSpecification())
        {
            _closeReason = closeReason;
        }

        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return _closeReason switch
            {
                IssueCloseReason.NotPlanned => Left.AndNot(Right).ToExpression(),
                IssueCloseReason.Completed => Left.And(Right).ToExpression(),
                _ => Left.ToExpression(),
            };
        }
    }
}
