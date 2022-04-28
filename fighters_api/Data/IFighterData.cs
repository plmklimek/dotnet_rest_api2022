using System;
using System.Collections.Generic;

namespace fighters_api.Data
{
    public interface IFighterData
    {
        List<Fighters> GetFighters();

        Fighters GetFighter(int id);

        Fighters AddFighter(Fighters fighter);

        void DeleteFighter(Fighters fighter);

        Fighters EditFighter(Fighters fighter);
    }
}
