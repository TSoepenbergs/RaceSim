using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller 
{
    public static class Data
    {
        public static Competition competition;
        public static Race CurrentRace { get; set; }
        public static event EventHandler<NextRaceEventArgs> NextRaceEvent;
        public static void Initialize()
        {
            competition = new Competition();
            AddParticipants();
            AddTracks();
        }

        public static void AddParticipants()
        {
            competition.Participants.Add(new Driver("Thijs Soepenberg", 0, new Car(3, 3, 200, false), IParticipants.TeamColors.Red));
            competition.Participants.Add(new Driver("Max Verstappen", 0, new Car(2, 4, 210, false), IParticipants.TeamColors.Blue));
        }

        public static void AddTracks()
        {
            competition.Tracks.Enqueue(new Track("Zandvoort", new[] {
                                       Section.SectionTypes.Straight,
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.RightCorner,
                    Section.SectionTypes.Finish,
            }
            ));
            competition.Tracks.Enqueue(new Track("Zandvoort 2", new[] {
                    Section.SectionTypes.StartGrid,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Straight,
                    Section.SectionTypes.Finish,
            }
          ));
        }
        public static void NextRace()
        {
            CurrentRace?.CleanUp();
            Track currentTrack = competition.NextTrack();
            if (currentTrack != null)
            {
                CurrentRace = new Race(currentTrack, competition.Participants);
                NextRaceEvent?.Invoke(null, new NextRaceEventArgs() { Race = CurrentRace });
                CurrentRace.Start();
            }
        }
    }
}
