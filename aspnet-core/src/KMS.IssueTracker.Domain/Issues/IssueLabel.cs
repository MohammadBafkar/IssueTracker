using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace KMS.IssueTracker.Issues
{
    public class IssueLabel : Entity<Guid>
    {
        protected IssueLabel()
        {
        }
        public IssueLabel(Guid issueId, Guid labelId)
        {
            IssueId = issueId;
            LabelId = labelId;
        }

        public virtual Guid IssueId { get; private set;}
        public virtual Guid LabelId { get; private set; }
    }
}
