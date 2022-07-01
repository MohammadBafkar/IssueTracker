using KMS.IssueTracker.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace KMS.IssueTracker;

[DependsOn(
    typeof(IssueTrackerEntityFrameworkCoreTestModule)
    )]
public class IssueTrackerDomainTestModule : AbpModule
{
}
