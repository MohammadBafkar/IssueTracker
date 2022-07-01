using AutoMapper;
using KMS.IssueTracker.Issues;

namespace KMS.IssueTracker;

public class IssueTrackerApplicationAutoMapperProfile : Profile
{
    public IssueTrackerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Comment, CommentDto>();
        CreateMap<IssueLabel, IssueLabelDto>();
        CreateMap<Issue, IssueDto>();
    }
}
