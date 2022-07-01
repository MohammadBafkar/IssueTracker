using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace KMS.IssueTracker.Issues
{
    public class IssueDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsClosed { get; set; }
        public IssueCloseReason? CloseReason { get; set; }

        public List<CommentDto> Comments { get; set; }
        public List<IssueLabelDto> Labels { get; set; }
    }
}
