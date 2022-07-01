using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace KMS.IssueTracker;

[Dependency(ReplaceServices = true)]
public class IssueTrackerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IssueTracker";
}
