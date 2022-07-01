using System.Threading.Tasks;

namespace KMS.IssueTracker.Data;

public interface IIssueTrackerDbSchemaMigrator
{
    Task MigrateAsync();
}
