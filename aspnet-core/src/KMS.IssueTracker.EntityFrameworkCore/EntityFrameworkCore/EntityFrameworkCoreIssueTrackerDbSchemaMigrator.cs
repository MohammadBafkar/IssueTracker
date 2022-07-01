using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KMS.IssueTracker.Data;
using Volo.Abp.DependencyInjection;

namespace KMS.IssueTracker.EntityFrameworkCore;

public class EntityFrameworkCoreIssueTrackerDbSchemaMigrator
    : IIssueTrackerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIssueTrackerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IssueTrackerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<IssueTrackerDbContext>()
            .Database
            .MigrateAsync();
    }
}
