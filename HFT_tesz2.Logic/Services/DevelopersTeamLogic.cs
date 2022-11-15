using HFT_tesz2.Logic.Interfaces;
using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Logic.Services
{
    public class DevelopersTeamLogic : IDevelopersTeamLogic
    {
        IDevelopersTeamRepository devteamRepo;
      
        public DevelopersTeamLogic(IDevelopersTeamRepository devteamRepo)
        {
            this.devteamRepo = devteamRepo;
        }
        

        public void Create(DevelopersTeam devteam)
        {
            devteamRepo.Create(devteam);
        }

        public void Delete(int id)
        {
            devteamRepo.Delete(id);
        }

        public IEnumerable<DevelopersTeam> ReadAll()
        {
            return devteamRepo.ReadAll();
        }

        public DevelopersTeam ReadOne(int id)
        {
            DevelopersTeam devteam = devteamRepo.ReadOne(id);
            if (devteam == null)
                throw new ArgumentException("DevelopersTeam with the specified id does not exists..");
            return devteam;
        }

        public void Update(DevelopersTeam devteam)
        {
            devteamRepo.Update(devteam);
        }
    }
}
