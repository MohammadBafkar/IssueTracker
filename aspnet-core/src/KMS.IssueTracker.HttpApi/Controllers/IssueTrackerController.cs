using KMS.IssueTracker.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace KMS.IssueTracker.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IssueTrackerController : AbpControllerBase
{
    protected IssueTrackerController()
    {
        LocalizationResource = typeof(IssueTrackerResource);
    }
}
