using KMS.IssueTracker.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Repositories
{
    public interface IIssueRepository : IRepository<Issue, Guid>
    {
        Task<long> GetAllClosedIssuesCountAsync(CancellationToken cancellationToken = default);
        Task<List<Issue>> GetClosedIssuesAsync(IssueCloseReason? closeReason = null, bool includeDetails = false, CancellationToken cancellationToken = default);
    }
}
