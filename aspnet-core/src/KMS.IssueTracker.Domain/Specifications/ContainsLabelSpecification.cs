using KMS.IssueTracker.Labels;
using System;
using System.Collections.Generic;

namespace KMS.IssueTracker.Specifications
{
    public class ContainsLabelSpecification : ContainsSpecification<Label, Guid>
    {
        public ContainsLabelSpecification(IEnumerable<Guid> collection) : base(collection)
        {
        }
    }
}
