using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace KMS.IssueTracker.Issues
{
    public interface IIssueAppService : IApplicationService
    {
        Task CloseIssueAsync(CloseIssueInput input);
        Task<PagedResultDto<IssueDto>> GetClosedIssuesAsync(GetClosedIssueInput input);
    }
}
