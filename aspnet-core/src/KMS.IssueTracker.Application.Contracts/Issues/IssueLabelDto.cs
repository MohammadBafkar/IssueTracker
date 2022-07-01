using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace KMS.IssueTracker.Issues
{
    public class IssueLabelDto : EntityDto<Guid>
    {
        [Required] public Guid LabelId { get; set; }
    }
}
