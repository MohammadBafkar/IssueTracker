using Volo.Abp.Modularity;

namespace KMS.IssueTracker;

[DependsOn(
    typeof(IssueTrackerApplicationModule),
    typeof(IssueTrackerDomainTestModule)
    )]
public class IssueTrackerApplicationTestModule : AbpModule
{
}
