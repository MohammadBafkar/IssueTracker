using KMS.IssueTracker.EntityFrameworkCore;
using KMS.IssueTracker.Issues;
using KMS.IssueTracker.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Repositories
{
    public class IssueRepository : EfCoreRepository<IssueTrackerDbContext, Issue, Guid>, IIssueRepository
    {
        public IssueRepository(IDbContextProvider<IssueTrackerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<long> GetAllClosedIssuesCountAsync(CancellationToken cancellationToken = default)
        {
            var queryable = await GetQueryableAsync();
            return await queryable.LongCountAsync(new IsClosedIssueSpecification(), cancellationToken);
        }

        public async Task<List<Issue>> GetClosedIssuesAsync(IssueCloseReason? closeReason = null, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var queryable = includeDetails ? await WithDetailsAsync() : await GetQueryableAsync();      
            return await queryable
                .Where(new IsClosedWithReasonIssueSpecification(closeReason))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
