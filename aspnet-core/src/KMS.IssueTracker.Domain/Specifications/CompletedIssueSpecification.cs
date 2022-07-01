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
    public class CompletedIssueSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression() => 
            issue => issue.CloseReason == IssueCloseReason.Completed;
    }
}
