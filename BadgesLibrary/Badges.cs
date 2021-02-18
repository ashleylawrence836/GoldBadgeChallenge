using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badges() { }
        public Badges( int badgeId, List<string> doorNames)
        {
            BadgeID = badgeId;
            DoorNames = doorNames;
        }
    }
}
