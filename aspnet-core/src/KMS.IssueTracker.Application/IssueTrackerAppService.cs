using System;
using System.Collections.Generic;
using System.Text;
using KMS.IssueTracker.Localization;
using Volo.Abp.Application.Services;

namespace KMS.IssueTracker;

/* Inherit your application services from this class.
 */
public abstract class IssueTrackerAppService : ApplicationService
{
    protected IssueTrackerAppService()
    {
        LocalizationResource = typeof(IssueTrackerResource);
    }
}
