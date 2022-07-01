using KMS.IssueTracker.Issues;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Volo.Abp.Specifications;
using Xunit;

namespace KMS.IssueTracker.Specifications
{
    public class IssueSpecificationsTests : IssueTrackerDomainTestBase
    {
        private readonly IGuidGenerator _guidGenerator;

        public IssueSpecificationsTests()
        {
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public void IsClosedIssueSpecification_Should_Return_False_For_Open_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());

            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeFalse();
        }
        
        
        [Fact]
        public void IsClosedIssueSpecification_Should_Return_True_For_Closed_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());
            issue.Close(IssueCloseReason.NotPlanned);

            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
        }


        [Fact]
        public void CompletedIssueSpecification_Should_Return_True_For_Completed_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());
            issue.Close(IssueCloseReason.Completed);

            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
            new CompletedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
            new IsClosedIssueSpecification().And(new CompletedIssueSpecification()).IsSatisfiedBy(issue).ShouldBeTrue();
        }

        [Fact]
        public void IsClosedWithReasonIssueSpecification_Should_Return_False_For_Open_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());

            new IsClosedWithReasonIssueSpecification(issue.CloseReason).IsSatisfiedBy(issue).ShouldBeFalse();
            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeFalse();
        }

        [Fact]
        public void IsClosedWithReasonIssueSpecification_Should_Return_True_For_Completed_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());
            issue.Close(IssueCloseReason.Completed);

            new IsClosedWithReasonIssueSpecification(issue.CloseReason).IsSatisfiedBy(issue).ShouldBeTrue();
            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
            new CompletedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
        }

        [Fact]
        public void IsClosedWithReasonIssueSpecification_Should_Return_True_For_NotPlanned_Issues()
        {
            var issue = new Issue("Contracts", "Price is not correctly calculated", _guidGenerator.Create(), _guidGenerator.Create());
            issue.Close(IssueCloseReason.NotPlanned);

            new IsClosedWithReasonIssueSpecification(issue.CloseReason).IsSatisfiedBy(issue).ShouldBeTrue();
            new IsClosedIssueSpecification().IsSatisfiedBy(issue).ShouldBeTrue();
            new CompletedIssueSpecification().IsSatisfiedBy(issue).ShouldBeFalse();
        }

    }
}
