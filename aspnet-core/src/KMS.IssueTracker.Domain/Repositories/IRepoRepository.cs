using KMS.IssueTracker.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace KMS.IssueTracker.Repositories
{
    public interface IProjectRepository : IRepository<Project, Guid>
    {
    }
}
