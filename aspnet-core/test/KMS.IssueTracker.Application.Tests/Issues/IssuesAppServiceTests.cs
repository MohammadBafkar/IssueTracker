using KMS.IssueTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Shouldly;
using KMS.IssueTracker.Specifications;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using Volo.Abp.DependencyInjection;

namespace KMS.IssueTracker.Issues
{
    public class IssuesAppServiceTests : IssueTrackerApplicationTestBase
    {
        private readonly IIssueAppService _issueAppService;
        private readonly IGuidGenerator _guidGenerator;

        public IssuesAppServiceTests()
        {
            _issueAppService = GetRequiredService<IIssueAppService>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task GetClosedIssuesAsync_Should_Return_One_For_User2Id_Fake()
        {
            //Arrange
            var closeReason = IssueCloseReason.Completed;
            var fakeIssue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), TestData.User2Id).Close(closeReason);
            var fakeIssues = new List<Issue> { fakeIssue };
            var fakeIssueRepository = GetFakeIssueRepository();
            var fakeServiceProvider = GetFakeServiceProvider();
            var issueAppService = new IssueAppService(fakeIssueRepository)
            {
                LazyServiceProvider = fakeServiceProvider
            };

            // Act
            var result = await issueAppService.GetClosedIssuesAsync(new GetClosedIssueInput { CloseReason = closeReason });

            // Assert
            await fakeIssueRepository.Received(1).GetAllClosedIssuesCountAsync();
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(1);
            result.Items.ShouldAllBe(i => i.IsClosed && i.CloseReason == closeReason);



            IIssueRepository GetFakeIssueRepository()
            {
                var fakeIssueRepository = Substitute.For<IIssueRepository>();
                fakeIssueRepository.GetAllClosedIssuesCountAsync().Returns(2);
                fakeIssueRepository.GetClosedIssuesAsync(fakeIssue.CloseReason).Returns(fakeIssues);
                return fakeIssueRepository;
            }

            IAbpLazyServiceProvider GetFakeServiceProvider()
            {
                var fakeObjectMapper = GetFakeObjectMapper();
                var fakeServiceProvider = Substitute.For<IAbpLazyServiceProvider>();
                fakeServiceProvider.LazyGetService<IObjectMapper>(Arg.Any<Func<IServiceProvider, object>>()).Returns(fakeObjectMapper);
                return fakeServiceProvider;
            }

            IObjectMapper GetFakeObjectMapper()
            {
                var fakeObjectMapper = Substitute.For<IObjectMapper>();
                fakeObjectMapper.Map<List<Issue>, IReadOnlyList<IssueDto>>(fakeIssues)
                    .Returns(new List<IssueDto>
                    {
                        new IssueDto
                        {
                            IsClosed = fakeIssue.IsClosed,
                            CloseReason = fakeIssue.CloseReason,
                        }
                    });
                return fakeObjectMapper;
            }
        }

        [Fact]
        public async Task GetClosedIssuesAsync_Should_Return_One_For_User2Id()
        {
            var closeReason = IssueCloseReason.Completed;
            var result = await _issueAppService.GetClosedIssuesAsync(new GetClosedIssueInput { CloseReason =  closeReason});

            result.TotalCount.ShouldBe(1);
            result.Items.Count.ShouldBe(1);
            result.Items.ShouldAllBe(i => i.IsClosed && i.CloseReason == closeReason);
        }
    }
}
