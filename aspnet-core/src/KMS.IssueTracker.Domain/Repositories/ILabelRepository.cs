using KMS.IssueTracker.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace KMS.IssueTracker.Repositories
{
    public interface ILabelRepository : IRepository<Label, Guid>
    {
    }
}
