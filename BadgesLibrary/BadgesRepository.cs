using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class BadgesRepository
    {
        private readonly Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        // CREATE
        public bool AddBadge(Badges badge)
        {
            int startCount = _dictionary.Count;
            _dictionary.Add(badge.BadgeID, badge.DoorNames);

            bool wasAdded = _dictionary.Count > startCount;
            return wasAdded;
        }

        public bool AddDoors(int badgeId, string newDoor)
        {
            foreach(KeyValuePair<int, List<string>> pair in _dictionary)
            {
                if (badgeId == pair.Key)
                {
                    pair.Value.Add(newDoor);
                    return true;
                }
            }
            return false;
        }

        //READ
        public Dictionary<int, List<string>> ShowBadges()
        {
            return _dictionary;
        }

        //UPDATE

        public Badges GetBadgeById(int badgeId)
        {

            foreach (KeyValuePair<int, List<string>> badge in _dictionary)
            {
                if (badge.Key == badgeId)
                {
                    return new Badges(badge.Key, badge.Value);
                }
            }
            return null;
        }

        //DELETE
        public bool DeleteDoorsFromBadge(int badgeId, string doorNames)
        {
            foreach (KeyValuePair<int, List<string>> pair in _dictionary)
            {
                if (badgeId == pair.Key)
                {
                    pair.Value.Remove(doorNames);
                    if (pair.Value.Contains(doorNames))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
