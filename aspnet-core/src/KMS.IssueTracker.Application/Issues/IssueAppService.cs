using KMS.IssueTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace KMS.IssueTracker.Issues
{
    public class IssueAppService : IssueTrackerAppService, IIssueAppService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueAppService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task CloseIssueAsync(CloseIssueInput input)
        {
            var issue = await _issueRepository.GetAsync(input.IssueId);
            issue.Close(input.CloseReason);
        }

        public async Task<PagedResultDto<IssueDto>> GetClosedIssuesAsync(GetClosedIssueInput input)
        {
            var totalCount = await _issueRepository.GetAllClosedIssuesCountAsync();
            var closedIssues = await _issueRepository.GetClosedIssuesAsync(input.CloseReason);
            return new PagedResultDto<IssueDto>(totalCount, ObjectMapper.Map<List<Issue>, IReadOnlyList<IssueDto>>(closedIssues));
        }
    }
}
