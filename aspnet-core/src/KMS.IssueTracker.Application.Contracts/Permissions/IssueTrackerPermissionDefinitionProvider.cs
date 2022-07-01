using KMS.IssueTracker.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace KMS.IssueTracker.Permissions;

public class IssueTrackerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IssueTrackerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(IssueTrackerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssueTrackerResource>(name);
    }
}
