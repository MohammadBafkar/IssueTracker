using KMS.IssueTracker.Issues;
using KMS.IssueTracker.Labels;
using KMS.IssueTracker.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace KMS.IssueTracker;

public class IssueTrackerTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IIssueRepository _issueRepository;
    private readonly ILabelRepository _labelRepository;
    private readonly IGuidGenerator _guidGenerator;

    public IssueTrackerTestDataSeedContributor(IIssueRepository issueRepository, ILabelRepository labelRepository, IGuidGenerator guidGenerator)
    {
        _issueRepository = issueRepository;
        _labelRepository = labelRepository;
        _guidGenerator = guidGenerator;
    }
    public Task SeedAsync(DataSeedContext context)
    {
        /* Seed additional test data... */
        var redLabelGuid = _guidGenerator.Create();
        _labelRepository.InsertManyAsync(new Collection<Label>
        {
            new Label(redLabelGuid, "Urgent", "Red"),
            new Label("Feature", "Blue")
        });

        _issueRepository.InsertManyAsync(new Collection<Issue>
        {
            new Issue(_guidGenerator.Create(), "Issue 1", "Text for issue 1", Guid.NewGuid() , TestData.User1Id)
                .AddLabel(redLabelGuid),
            
            new Issue("Issue 2", "Text for issue 2", Guid.NewGuid(), TestData.User2Id)
                .Close(IssueCloseReason.Completed)
        });
        return Task.CompletedTask;
    }
}
