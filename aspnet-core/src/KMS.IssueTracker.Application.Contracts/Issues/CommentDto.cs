using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace KMS.IssueTracker.Issues
{
    public class CommentDto : EntityDto<Guid>
    {
        [Required] public Guid UserId { get; set; }
        [Required] public string Text { get; set; }
    }
}
