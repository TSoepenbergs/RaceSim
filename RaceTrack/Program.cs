using System;
using System.Threading;
using Controller;
using Model;

namespace RaceTrack
{
    class Program
    {


        static void Main(string[] args)
        {
            

            Data.Initialize();
            Data.NextRaceEvent += Visuals.OnNextRaceEvent;
            Data.NextRace();
            
           /* Data.CurrentRace.Place(Data.CurrentRace.Track, Data.CurrentRace.Participants);*/
/*            Visuals.Initialize(Data.CurrentRace);
*/            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}