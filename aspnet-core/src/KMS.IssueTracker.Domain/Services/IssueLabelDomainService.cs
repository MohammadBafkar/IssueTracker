using KMS.IssueTracker.Issues;
using KMS.IssueTracker.Labels;
using KMS.IssueTracker.Repositories;
using KMS.IssueTracker.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Abp.Specifications;

namespace KMS.IssueTracker.Services
{
    public class IssueLabelUsageChecker : DomainService, ITransientDependency
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ILabelRepository _labelRepository;

        public IssueLabelUsageChecker(IIssueRepository issueRepository, ILabelRepository labelRepository)
        {
            _issueRepository = issueRepository;
            _labelRepository = labelRepository;
        }

        public async Task<List<Label>> GetUsedRedLabelsAsync()
        {
            var issueQueryable = await _issueRepository.WithDetailsAsync(x => x.Labels);
            var labelIdsUsedInIssues = issueQueryable.SelectMany(x => x.Labels.Select(l => l.LabelId));
            return await _labelRepository.GetListAsync(new RedLabelSpecification().And(new ContainsLabelSpecification(labelIdsUsedInIssues)).ToExpression());
        }
    }
}
