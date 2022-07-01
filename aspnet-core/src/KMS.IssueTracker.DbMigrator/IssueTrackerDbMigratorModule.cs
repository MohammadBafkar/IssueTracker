using KMS.IssueTracker.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace KMS.IssueTracker.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IssueTrackerEntityFrameworkCoreModule),
    typeof(IssueTrackerApplicationContractsModule)
    )]
public class IssueTrackerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
