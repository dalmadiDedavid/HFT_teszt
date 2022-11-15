using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Logic.Interfaces
{
    public interface IDevelopersTeamLogic
    {
        //crud
        void Create(DevelopersTeam devteam);
        void Delete(int id);
        IEnumerable<DevelopersTeam> ReadAll();
        DevelopersTeam ReadOne(int id);
        void Update(DevelopersTeam devteam);

        


    }
}
