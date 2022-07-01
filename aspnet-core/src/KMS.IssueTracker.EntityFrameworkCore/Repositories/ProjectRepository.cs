using KMS.IssueTracker.EntityFrameworkCore;
using KMS.IssueTracker.Projects;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KMS.IssueTracker.Repositories
{
    public class ProjectRepository : EfCoreRepository<IssueTrackerDbContext, Project, Guid>, IProjectRepository
    {
        public ProjectRepository(IDbContextProvider<IssueTrackerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
