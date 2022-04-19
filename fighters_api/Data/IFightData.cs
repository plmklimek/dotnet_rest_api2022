using System;
using System.Collections.Generic;

namespace fighters_api.Data
{
    public interface IFightData
    {
        List<Fight> GetFights();

        Fight GetFight(int id);

        Fight AddFight(Fight fight);

        void DeleteFight(Fight fight);

        Fight EditFight(Fight fight);
    }
}
