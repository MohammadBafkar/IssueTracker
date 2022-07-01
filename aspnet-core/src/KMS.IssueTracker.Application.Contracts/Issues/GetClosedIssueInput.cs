using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.IssueTracker.Issues
{
    public class GetClosedIssueInput
    {
        public IssueCloseReason? CloseReason { get; set; }
    }
}
