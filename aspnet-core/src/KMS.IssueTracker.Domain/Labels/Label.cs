using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace KMS.IssueTracker.Labels
{
    public class Label : AggregateRoot<Guid>
    {
        protected Label()
        {
        }

        public Label(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public Label(Guid id, string name, string color) : base(id)
        {
            Name = name;
            Color = color;
        }

        public virtual string Name { get; private set; }
        public virtual string Color { get; private set; }
    }
}
