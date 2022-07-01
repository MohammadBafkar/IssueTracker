using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace KMS.IssueTracker.Projects
{
    public class Project : AggregateRoot<Guid>
    {
        protected Project()
        {
        }

        public Project(string name)
        {
            Check.NotNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public virtual string Name { get; private set; }
    }
}
