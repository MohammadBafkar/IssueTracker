using KMS.IssueTracker.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Specifications
{
    public class RedLabelSpecification : Specification<Label>
    {
        public override Expression<Func<Label, bool>> ToExpression()
        {
            return label => label.Color.ToLower() == "red";
        }
    }
}
