    using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    [TestFixture]
    internal class Model_Competition_NextTrackShould
    {
        private Competition _competition;
        private Track result;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
          result = _competition.NextTrack();
            Assert.IsNull(result);
        }
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            Track track = new Track("Racebaan Amsterdam", new[] {
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Finish,
            });
            _competition.Tracks.Enqueue(track);
           result =  _competition.NextTrack();
            Assert.AreEqual(track, result);
        }

        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track trackZwolle = new Track("Racebaan Zwolle", new[] {
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Finish,
            });
            _competition.Tracks.Enqueue(trackZwolle);
            result = _competition.NextTrack();
            result = _competition.NextTrack();
            Assert.IsNull(result);

        }
    }
}
