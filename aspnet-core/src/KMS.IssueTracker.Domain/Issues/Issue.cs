using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Timing;

namespace KMS.IssueTracker.Issues
{
    public class Issue : AggregateRoot<Guid>, IHasCreationTime
    {
        protected Issue()
        {
        }

        public Issue([NotNull] string title, string text, Guid projectId, Guid assignedUserId)
        {
            SetTitle(title);
            Text = text;
            ProjectId = projectId;
            AssignedUserId = assignedUserId;
            Comments = new Collection<Comment>();
            Labels = new Collection<IssueLabel>();
        }

        public Issue(Guid id, [NotNull] string title, string text, Guid projectId, Guid assignedUserId) : base(id)
        {
            SetTitle(title);
            Text = text;
            ProjectId = projectId;
            AssignedUserId = assignedUserId;
            Comments = new Collection<Comment>();
            Labels = new Collection<IssueLabel>();
        }

        public virtual string Title { get; private set; }
        public virtual string Text { get; private set; }
        public virtual bool IsClosed { get; private set; }
        public virtual IssueCloseReason? CloseReason { get; private set; }
        public virtual DateTime CreationTime { get; private set; }
        public virtual Guid ProjectId { get; private set; }
        public virtual Guid AssignedUserId { get; private set; }

        public virtual ICollection<IssueLabel> Labels { get; private set; }
        public virtual ICollection<Comment> Comments { get; private set; }

        public virtual Issue SetTitle([NotNull] string title)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Title = title;
            return this;
        }

        public virtual Issue AddComment(string text, Guid userId)
        {
            Comments.Add(new Comment(text, Id, userId));
            return this;
        }

        public virtual Issue RemoveComment(Guid commentId)
        {
            Comments.RemoveAll(x => x.Id == commentId);
            return this;
        }


        public virtual Issue AddLabel(Guid labelId)
        {
            if (Labels.Any(l => l.LabelId == labelId))
            {
                return this;
            }

            Labels.Add(new IssueLabel(Id, labelId));
            return this;
        }

        public virtual Issue RemoveLabel(Guid labelId)
        {
            Labels.RemoveAll(l => l.LabelId == labelId);
            return this;
        }

        public virtual Issue Close(IssueCloseReason closeReason)
        {
            IsClosed = true;
            CloseReason = closeReason;
            return this;
        }


        public virtual Issue ReOpen()
        {
            IsClosed = false;
            CloseReason = null;
            return this;
        }

    }
}
