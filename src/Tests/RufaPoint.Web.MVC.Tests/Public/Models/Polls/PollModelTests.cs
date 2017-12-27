using RufaPoint.Tests;
using RufaPoint.Web.Models.Polls;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Models.Polls
{

    public class PollModelTests
    {
        [Fact]
        public void Can_clone()
        {	    
            //create
            var model1 = new PollModel
            {
                Id = 1,
                Name = "Name 1",
                AlreadyVoted = true,
                TotalVotes = 2,
            };
            model1.Answers.Add(new PollAnswerModel
                               {
                                   Id = 3, 
                                   Name = "answer 1", 
                                   NumberOfVotes = 4, 
                                   PercentOfTotalVotes = 5
                               });

            //clone
            var model2 = (PollModel)model1.Clone();
            model2.Id.ShouldEqual(1);
            model2.Name.ShouldEqual("Name 1");
            model2.AlreadyVoted.ShouldEqual(true);
            model2.TotalVotes.ShouldEqual(2);
            model2.Answers.ShouldNotBeNull();
            model2.Answers.Count.ShouldEqual(1);
            model2.Answers[0].Id.ShouldEqual(3);
            model2.Answers[0].Name.ShouldEqual("answer 1");
            model2.Answers[0].NumberOfVotes.ShouldEqual(4);
            model2.Answers[0].PercentOfTotalVotes.ShouldEqual(5);
        }
    }
}
