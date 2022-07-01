using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KMS.IssueTracker.Data;

/* This is used if database provider does't define
 * IIssueTrackerDbSchemaMigrator implementation.
 */
public class NullIssueTrackerDbSchemaMigrator : IIssueTrackerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
