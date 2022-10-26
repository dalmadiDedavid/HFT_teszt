using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository.ModelRepositories
{
    class DevelopersTeamRepository : Repository<DevelopersTeam>, IDevelopersTeamRepository
    {
        public DevelopersTeamRepository(GameDbContext ctx) : base(ctx)
        {

        }

        public void CMchange(int id, int newSUM)
        {
            DevelopersTeam old = ReadOne(id);
            old.CountofMembers = newSUM;
            ctx.SaveChanges();
        }
    }
}
