using System;
using System.Collections.Generic;
using System.Linq;

namespace fighters_api.Data
{
    public class SqlFighterData : IFighterData
    {
        private FighterContext _fighterContext;
        public SqlFighterData(FighterContext fighterContext)
        {
            _fighterContext = fighterContext;
        }

        public Fighter AddFighter(Fighter fighter)
        {
            fighter.id = 0;
            _fighterContext.Fighters.Add(fighter);
            _fighterContext.SaveChanges();
            return fighter;
        }

        public void DeleteFighter(Fighter fighter)
        {
            _fighterContext.Remove(fighter);
            _fighterContext.SaveChanges();
        }

        public Fighter EditFighter(Fighter fighter)
        {
            var existingFighter = _fighterContext.Fighters.Find(fighter.id);
            if (existingFighter != null)
            {
                _fighterContext.Fighters.Update(existingFighter);
                _fighterContext.SaveChanges();
            }
            return fighter;
        }

        public Fighter GetFighter(int id)
        {
            var fighter = _fighterContext.Fighters.Find(id);
            return fighter;
        }

        public List<Fighter> GetFighters()
        {
            var fighterList = _fighterContext.Fighters.ToList();
            return fighterList;
        }
    }
}