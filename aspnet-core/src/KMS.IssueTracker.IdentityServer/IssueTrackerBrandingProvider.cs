using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace KMS.IssueTracker;

[Dependency(ReplaceServices = true)]
public class IssueTrackerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IssueTracker";
}
