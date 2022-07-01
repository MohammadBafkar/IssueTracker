using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.IssueTracker.Issues
{
    public class CloseIssueInput
    {
        public Guid IssueId { get; set; }
        public IssueCloseReason CloseReason { get; set; }
    }
}
