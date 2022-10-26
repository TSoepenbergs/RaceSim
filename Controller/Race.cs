/*using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;



namespace Controller
{
    public class Race
    {
        public delegate void onDriversChanged(object Sender, DriversChangedEventArgs dirversChangedEventArgs);
        private Random _random;
        public Track Track { get; set; }
        public List<IParticipants> Participants { get; set; }
        public DateTime StarTime { get; set; }
        private Dictionary<Section, SectionData> _positions;
        private  System.Timers.Timer timer;
        public event onDriversChanged DriversChanged;
        public SectionData GetSectionData(Section section)
        {
            
            if (_positions.TryGetValue(section, out SectionData sectionData)) { return sectionData; }

            sectionData = new SectionData();
            sectionData.Section = section;
            _positions.Add(section, sectionData);
            return sectionData;
        }

        public void RandomizeEquipment()
        {
            foreach (var participant in Participants)
            {
                participant.Equipment.Performance = _random.Next(Car.min_performance, Car.max_performance);
                participant.Equipment.Quality = _random.Next(Car.min_quality, Car.max_quality);
                participant.Equipment.Speed = _random.Next(Car.min_speed, Car.max_speed);
            }
        }

        public void PlaceParticipants(Track track, List<IParticipants> participants)
        {
            int participantsCount = 0;
            foreach (Section section in Track.Sections)
            {
                if(section.SectionType == Section.SectionTypes.StartGrid)
                {
                   if(participants.Count > 0)
                    {
                        SectionData sData = GetSectionData(section);
                        for (int i = 0; i <= 2; i++)
                        {
                            if (sData.Left == null)
                            {
                                if (participants.Count - participantsCount - 1 >= 0)
                                {
                                    sData.Left = participants[participants.Count - participantsCount - 1];
                                    Console.WriteLine($"{participants[participants.Count - participantsCount - 1].Name} staat links");
                                    Console.WriteLine($"{sData.Left.Name}");
                                    participantsCount++;
                                }
                            }
                            else if(sData.Right == null)
                            {
                                if (participants.Count - participantsCount - 1 >= 0)
                                {
                                    sData.Right = participants[participants.Count - participantsCount - 1];
                                    Console.WriteLine($"{participants[participants.Count - participantsCount - 1].Name} staat rechts");
                                    participantsCount++;
                                }
                            }
                        
                        }


                    }
                    }
                  
                }

            //Check of er 2 per startgrid staan
        }
        
        private void OnTimedEvent(Object source, EventArgs args)
        {
            
            DriversChanged?.Invoke(this, new DriversChangedEventArgs(Data.CurrentRace.Track));

           
            MoveParticipants();
        }
        public void MoveParticipants()
        {
            foreach(Section section in Data.CurrentRace.Track.Sections)
            {
                SectionData sData = GetSectionData(section);
                int meters;
                if(sData.Left != null)
                {
                    meters = sData.Left.Equipment.Performance * sData.Left.Equipment.Speed;
                    sData.DistanceLeft += meters;
                   
                }

                if(sData.Right != null)
                {
                    meters = sData.Right.Equipment.Performance * sData.Right.Equipment.Speed;
                    sData.DistanceRight += meters;
                }
                if (sData.DistanceLeft >= 100 && sData.DistanceRight >= 100)
                {
                    //check who is faster and put them first
                    if(sData.DistanceLeft >= sData.DistanceRight)
                    {
                        MoveToNext(section, sData.Left);
                        MoveToNext(section, sData.Right);
                    }
                    else
                    {
                        MoveToNext(section, sData.Right);
                        MoveToNext(section, sData.Left);
                    }
                }
                else if(sData.DistanceLeft >= 100)
                {
                    MoveToNext(section, sData.Left);
                }
                else if (sData.DistanceRight >= 100)
                {
                    MoveToNext(section, sData.Right);
                }
            }
        }
        public void MoveToNext(Section section, IParticipants particpant)
        {
            Section nextSection = Track.NextSection(section);
            SectionData sData = GetSectionData(nextSection);
            SectionData sDataOld = GetSectionData(section);

            if(sData.Left == null)
            {
                if (sDataOld.Left.Equals(particpant))
                {
                    sDataOld.Left = null;
                }
                else if (sDataOld.Right.Equals(particpant))
                {
                    sDataOld.Right = null;
                }
               
                sData.Left = particpant;
                
            }
            else if(sData.Right == null)
            {
                if (sDataOld.Left != null)
                {
                    if (sDataOld.Left.Equals(particpant))
                    {
                        sDataOld.Left = null;
                    }
                }
                else if (sDataOld.Right.Equals(particpant))
                {
                    sDataOld.Right = null;
                }

                sData.Right = particpant;
                
            }
            else
            {
                throw new Exception("No place on next section");
            }
        }
        private void Start()
        {
           
            timer.Enabled = true;
        }

            public Race(Track track, List<IParticipants> participants)
            {
            Participants = participants;
            Track = track;
            _positions = new Dictionary<Section, SectionData>();
            _random = new Random(DateTime.Now.Millisecond);
            timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimedEvent;
            PlaceParticipants(track, participants);
            Start();
        }

    }
}
*/


using Model;
using System.Timers;
using static Model.Section;
using Timer = System.Timers.Timer;

namespace Controller
{
    internal enum Side
    {
        Left,
        Right
    }

    public class Race
    {
        public Track Track { get; }
        public DateTime StartTime { get; set; }
        public List<IParticipants> Participants { get; }
        internal readonly Dictionary<Section, SectionData> Positions;
        private Dictionary<IParticipants, int> _lapsCompleted;
        private readonly Random _random;
        private readonly Timer _timer;
        private const int TimerInterval = 300;
        internal const int Laps = 2;

        public event EventHandler<DriversChangedEventArgs> DriversChanged;


        public event EventHandler RaceFinished;

        public SectionData GetSectionData(Section section)
        {
            if (Positions.ContainsKey(section))
            {
                return Positions[section];
            }
            else
                Positions.Add(section, new SectionData());
            return Positions[section];
        }

        public Race(Track track, List<IParticipants> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
            Positions = new Dictionary<Section, SectionData>();
            _lapsCompleted = new Dictionary<IParticipants, int>();

            _timer = new Timer(TimerInterval);
            _timer.Elapsed += OnTimedEvent;

            bool side = false;
            int StartGridIndex = 0;
            int participantsToPlace = 0;

            List<Section> startGridSections = Track.Sections.Where(trackSection => trackSection.SectionType == SectionTypes.StartGrid).ToList();
            startGridSections.Reverse();
            List<Section> startGrid = startGridSections;

            if (Participants.Count >= startGrid.Count * 2)
                participantsToPlace = startGrid.Count * 2;
            else if (Participants.Count < startGrid.Count * 2)
                participantsToPlace = Participants.Count;

            for (int i = 0; i < participantsToPlace; i++)
            {
                PlaceParticipantOnTrack(Participants[i], side, startGrid[StartGridIndex]);
                side = !side;
                if (i % 2 == 1)
                    StartGridIndex++;
            }

            foreach (IParticipants participant in Participants)
            {
                participant.Equipment.Quality = _random.Next(6, 17);
                participant.Equipment.Performance = _random.Next(8, 20);
            }

            foreach (IParticipants participant in Participants)
            {
                _lapsCompleted.Add(participant, -1);
            }
        }

        public void PlaceParticipantOnTrack(IParticipants p, bool side, Section section)
        {
            if (side)
                GetSectionData(section).Right = p;
            else
                GetSectionData(section).Left = p;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {

            MoveAllParticipants();
            DriversChanged?.Invoke(this, new DriversChangedEventArgs(Data.CurrentRace.Track));

            if (CheckRaceFinished())
            {
                RaceFinished?.Invoke(this, new EventArgs());
            }

            foreach (IParticipants participant in Participants)
            {
                if (participant.Equipment.IsBroken)
                {
                    if (_random.NextDouble() < 0.10)
                    {
                        participant.Equipment.IsBroken = false;
                        if (participant.Equipment.Quality > 2)
                            participant.Equipment.Quality--;
                        if (participant.Equipment.Speed > 3)
                            participant.Equipment.Speed--;
                    }
                }
            }

            List<IParticipants> participantsOnTrack = Positions.Values.Where(a => a.Left != null).Select(a => a.Left)
                .Concat(Positions.Values.Where(a => a.Right != null).Select(a => a.Right)).ToList();
            foreach (IParticipants participant in participantsOnTrack)
            {
                double qualityChance = (11 - (participant.Equipment.Quality * 0.5)) * 0.0005;
                if (_random.NextDouble() < qualityChance)
                {
                    participant.Equipment.IsBroken = true;
                    
                }
            }
        }


        private void MoveAllParticipants()
        {
            LinkedListNode<Section> currentSectionNode = Track.Sections.Last;

            while (currentSectionNode != null)
            {
                MoveParticipantsSectionData(currentSectionNode.Value, currentSectionNode.Next != null ? currentSectionNode.Next.Value : Track.Sections.First?.Value);
                currentSectionNode = currentSectionNode.Previous;
            }
        }

        private void MoveParticipantsSectionData(Section currentSection, Section nextSection)
        {
            SectionData currentSectionData = GetSectionData(currentSection);
            SectionData nextSectionData = GetSectionData(nextSection);
            if (currentSectionData.Left != null && !currentSectionData.Left.Equipment.IsBroken)
            {
                currentSectionData.DistanceLeft += GetSpeedFromParticipant(currentSectionData.Left);
            }

            if (currentSectionData.Right != null && !currentSectionData.Right.Equipment.IsBroken)
            {
                currentSectionData.DistanceRight += GetSpeedFromParticipant(currentSectionData.Right);
            }

            if (currentSectionData.DistanceLeft >= 100 && currentSectionData.DistanceRight >= 100)
            {
                int freePlaces = 0;
                if (nextSectionData.Left == null)
                    freePlaces += 1;
                if (nextSectionData.Right == null)
                    freePlaces += 2;
                if (freePlaces == 0)
                {
                    currentSectionData.DistanceRight = 99;
                    currentSectionData.DistanceLeft = 99;
                }
                else if (freePlaces == 3)
                {
                    MoveSingleParticipant(currentSection, nextSection, Side.Left, Side.Left, false);
                    MoveSingleParticipant(currentSection, nextSection, Side.Right, Side.Right, false);
                }
                else
                {
                    if (currentSectionData.DistanceLeft >= currentSectionData.DistanceRight)
                    {
                        if (freePlaces == 1)
                            MoveSingleParticipant(currentSection, nextSection, Side.Left, Side.Left, true); // left to left
                        else if (freePlaces == 2)
                            MoveSingleParticipant(currentSection, nextSection, Side.Left, Side.Right, true);
                    }
                    else
                    {
                        if (freePlaces == 1)
                            MoveSingleParticipant(currentSection, nextSection, Side.Right, Side.Left, true); // left to left
                        else if (freePlaces == 2)
                            MoveSingleParticipant(currentSection, nextSection, Side.Right, Side.Right, true);
                    }
                }
            }
            else if (currentSectionData.DistanceLeft >= 100)
            {
                int freePlaces = 0;
                if (nextSectionData.Left == null)
                    freePlaces += 1;
                if (nextSectionData.Right == null)
                    freePlaces += 2;
                if (freePlaces == 0)
                    currentSectionData.DistanceLeft = 99;
                else if (freePlaces == 3 || freePlaces == 1)
                    MoveSingleParticipant(currentSection, nextSection, Side.Left, Side.Left, false);
                else if (freePlaces == 2)
                    MoveSingleParticipant(currentSection, nextSection, Side.Left, Side.Right, false);
            }
            else if (currentSectionData.DistanceRight >= 100)
            {
                int freePlaces = 0;
                if (nextSectionData.Left == null)
                    freePlaces += 1;
                if (nextSectionData.Right == null)
                    freePlaces += 2;
                if (freePlaces == 0)
                    currentSectionData.DistanceRight = 99;
                else if (freePlaces == 3 || freePlaces == 2)
                    MoveSingleParticipant(currentSection, nextSection, Side.Right, Side.Right, false);
                else if (freePlaces == 1)
                    MoveSingleParticipant(currentSection, nextSection, Side.Right, Side.Left, false);
            }
        }

        public int GetSpeedFromParticipant(IParticipants iParticipant) => Convert.ToInt32(Math.Ceiling(0.1 * (iParticipant.Equipment.Speed * 0.5) * iParticipant.Equipment.Performance + 18));

        private void MoveSingleParticipant(Section currentSection, Section nextSection, Side start, Side end, bool correctOtherSide)
        {
            SectionData currentSectionData = GetSectionData(currentSection);
            SectionData nextSectionData = GetSectionData(nextSection);
            switch (start)
            {
                case Side.Right:
                    switch (end)
                    {
                        case Side.Right:
                            nextSectionData.Right = currentSectionData.Right;
                            nextSectionData.DistanceRight = currentSectionData.DistanceRight - 100;
                            if (CheckIfFinishSection(nextSection))
                                OnMoveUpdateLapsAndFinish(nextSectionData, Side.Right);
                            break;

                        case Side.Left:
                            nextSectionData.Left = currentSectionData.Right;
                            nextSectionData.DistanceLeft = currentSectionData.DistanceRight - 100;
                            if (CheckIfFinishSection(nextSection))
                                OnMoveUpdateLapsAndFinish(nextSectionData, Side.Left);
                            break;
                    }

                    currentSectionData.Right = null;
                    currentSectionData.DistanceRight = 0;
                    break;

                case Side.Left:
                    switch (end)
                    {
                        case Side.Right:
                            nextSectionData.Right = currentSectionData.Left;
                            nextSectionData.DistanceRight = currentSectionData.DistanceLeft - 100;
                            if (CheckIfFinishSection(nextSection))
                                OnMoveUpdateLapsAndFinish(nextSectionData, Side.Right);
                            break;

                        case Side.Left:
                            nextSectionData.Left = currentSectionData.Left;
                            nextSectionData.DistanceLeft = currentSectionData.DistanceLeft - 100;
                            if (CheckIfFinishSection(nextSection))
                                OnMoveUpdateLapsAndFinish(nextSectionData, Side.Left);
                            break;
                    }

                    currentSectionData.Left = null;
                    currentSectionData.DistanceLeft = 0;
                    break;
            }

            if (start == Side.Right && correctOtherSide)
                currentSectionData.DistanceLeft = 99;
            else if (start == Side.Left && correctOtherSide)
                currentSectionData.DistanceRight = 99;
        }

        internal void UpdateLap(IParticipants participant)
        {
            _lapsCompleted[participant]++;
        }

        internal bool IsFinished(IParticipants participant) => _lapsCompleted[participant] >= Laps;

        internal bool CheckIfFinishSection(Section section)
        {
            return section.SectionType == SectionTypes.Finish;
        }

        private void OnMoveUpdateLapsAndFinish(SectionData sectionData, Side side)
        {
            if (side == Side.Right)
            {
                UpdateLap(sectionData.Right);
                if (!IsFinished(sectionData.Right)) return;
                sectionData.Right = null;
            }
            else if (side == Side.Left)
            {
                UpdateLap(sectionData.Left);
                if (!IsFinished(sectionData.Left)) return;
                sectionData.Left = null;
            }
        }

        internal bool CheckRaceFinished() => Positions.Values.FirstOrDefault(a => a.Left != null || a.Right != null) == null;

        public void Start()
        {
            _timer.Start();
            StartTime = DateTime.Now;
        }

        public void CleanUp()
        {
            DriversChanged = null;
            _timer.Stop();
            RaceFinished = null;
        }
    }
}