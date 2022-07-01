using Volo.Abp.Settings;

namespace KMS.IssueTracker.Settings;

public class IssueTrackerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IssueTrackerSettings.MySetting1));
    }
}
