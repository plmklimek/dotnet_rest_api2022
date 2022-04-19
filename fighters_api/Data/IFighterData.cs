using System;
using System.Collections.Generic;

namespace fighters_api.Data
{
    public interface IFighterData
    {
        List<Fighter> GetFighters();

        Fighter GetFighter(int id);

        Fighter AddFighter(Fighter fighter);

        void DeleteFighter(Fighter fighter);

        Fighter EditFighter(Fighter fighter);
    }
}
