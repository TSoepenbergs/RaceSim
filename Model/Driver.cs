using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver : IParticipants
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public IParticipants.TeamColors TeamColor { get; set; }
        
        public Driver(string name, int points, IEquipment equipment, IParticipants.TeamColors teamColor)
        {
            Name = name;
            Points = points;
            Equipment = equipment;
            TeamColor = teamColor;
        }
    }
}
