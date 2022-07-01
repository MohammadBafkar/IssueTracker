using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace KMS.IssueTracker.Issues
{
    public class Comment : Entity<Guid>, IHasCreationTime
    {
        protected Comment()
        {
        }

        public Comment(string text, Guid issueId, Guid userId)
        {
            Text = text;
            IssueId = issueId;
            UserId = userId;
        }
        public virtual string Text { get; private set; }
        public virtual DateTime CreationTime { get; private set; }
        public virtual Guid IssueId { get; private set; }
        public virtual Guid UserId { get; private set; }
    }
}
