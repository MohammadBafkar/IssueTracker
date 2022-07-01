using KMS.IssueTracker.EntityFrameworkCore;
using KMS.IssueTracker.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KMS.IssueTracker.Repositories
{
    public class LabelRepository : EfCoreRepository<IssueTrackerDbContext, Label, Guid>, ILabelRepository
    {
        public LabelRepository(IDbContextProvider<IssueTrackerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
