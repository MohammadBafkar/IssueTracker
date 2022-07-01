using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Shouldly;
using KMS.IssueTracker.Specifications;

namespace KMS.IssueTracker.Services
{
    public class IssueLabelUsageCheckerTests : IssueTrackerDomainTestBase
    {
        [Fact]
        public async Task GetUsedRedLabels_Should_Return_One()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var issueLabelUsageChecker = GetRequiredService<IssueLabelUsageChecker>();
                var result = await issueLabelUsageChecker.GetUsedRedLabelsAsync();

                result.ShouldAllBe(new RedLabelSpecification());
                return Task.CompletedTask;
            });
        }
    }
}
