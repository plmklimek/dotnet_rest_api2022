using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace fighters_api.Data
{
    public class SqlFightData: IFightData
    {
        private FightContext _fightContext;
        public SqlFightData(FightContext fightContext)
        {
            _fightContext = fightContext;
        }

        public Fight AddFight(Fight fight)
        {
            fight.id = 0;
            _fightContext.Fights.Add(fight);
            _fightContext.SaveChanges();
            return fight;
        }

        public void DeleteFight(Fight fight)
        {
            _fightContext.Remove(fight);
            _fightContext.SaveChanges();
        }

        public Fight EditFight(Fight fight)
        {
            var existingFight = _fightContext.Fights.Find(fight.id);
            if(existingFight != null)
            {
                existingFight.id = fight.id;
                existingFight.blue_fighterid = fight.blue_fighterid;
                existingFight.red_fighterid = fight.red_fighterid;
                existingFight._date = fight._date;
                _fightContext.SaveChanges();
            }
            return fight;
        }

        public Fight GetFight(int id)
        {
            var fight = _fightContext.Fights.Find(id);
            return fight;
        }

        public List<Fight> GetFights()
        {

            var fightList = _fightContext.Fights.Include(s => s.blue_fighter).Include(s => s.red_fighter).ToList();
            return fightList;
        }
    }
}
