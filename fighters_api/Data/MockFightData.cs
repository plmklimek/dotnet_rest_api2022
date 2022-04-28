using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace fighters_api.Data
{
    public class MockFightData : IFightData
    {
        private static Fighters fighter = new Fighters()
        {
            id = 0,
            name = "Tadeusz",
            surname = "Sur",
            age = 1
        };
        private List<Fight> fights = new List<Fight>()
        {
            new Fight()
            {
                id = 0,
                blue_fighter = fighter,
                red_fighter = fighter,
                _date = DateTime.Now
            },
            new Fight()
            {
                id = 1,
                blue_fighter = fighter,
                red_fighter = fighter,
                _date = DateTime.Now
            }
        };
        public Fight AddFight(Fight fight)
        {
            fight.id = 3;
            fights.Add(fight);
            return fight;
        }

        public void DeleteFight(Fight fight)
        {
            fights.Remove(fight);
        }

        public Fight EditFight(Fight fight)
        {
            var existingFight = GetFight(fight.id);
            existingFight.blue_fighter = fight.blue_fighter;
            existingFight.red_fighter = fight.red_fighter;
            existingFight._date = fight._date;
            return existingFight;
        }

        public Fight GetFight(int id)
        {
            return fights.SingleOrDefault(x => x.id == id);
        }

        public List<Fight> GetFights()
        {
            return fights;
        }
    }
}
