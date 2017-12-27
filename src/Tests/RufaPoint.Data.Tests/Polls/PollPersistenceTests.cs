using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Polls
{

    public class PollPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_poll()
        {
            var poll = this.GetTestPoll();
            poll.Language = this.GetTestLanguage();

            var fromDb = SaveAndLoadEntity(poll);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestPoll());

            fromDb.Language.ShouldNotBeNull();
            fromDb.Language.PropertiesShouldEqual(this.GetTestLanguage());
        }

        [Fact]
        public void Can_save_and_load_poll_with_answers()
        {
            var poll = this.GetTestPoll();
            poll.Language = this.GetTestLanguage();

            poll.PollAnswers.Add(this.GetTestPollAnswer());
            var fromDb = SaveAndLoadEntity(poll);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestPoll());

            fromDb.PollAnswers.ShouldNotBeNull();
            (fromDb.PollAnswers.Count == 1).ShouldBeTrue();
            fromDb.PollAnswers.First().PropertiesShouldEqual(this.GetTestPollAnswer());
        }

        [Fact]
        public void Can_save_and_load_poll_with_answer_and_votingrecord()
        {
            var poll = this.GetTestPoll();
            poll.Language = this.GetTestLanguage();

            poll.PollAnswers.Add(this.GetTestPollAnswer());
            poll.PollAnswers.First().PollVotingRecords.Add(this.GetTestPollVotingRecord());
            var fromDb = SaveAndLoadEntity(poll);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestPoll());

            fromDb.PollAnswers.ShouldNotBeNull();
            (fromDb.PollAnswers.Count == 1).ShouldBeTrue();

            fromDb.PollAnswers.First().PollVotingRecords.ShouldNotBeNull();
            (fromDb.PollAnswers.First().PollVotingRecords.Count == 1).ShouldBeTrue();
        }
    }
}
