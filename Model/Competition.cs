using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition
    {
        public List<IParticipants> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }

        public Competition()
        {
            Participants = new List<IParticipants>();
            Tracks = new Queue<Track>();
        }
        public Track NextTrack()
        {   
            if (Tracks.Count > 0)
            {
                return Tracks.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}
