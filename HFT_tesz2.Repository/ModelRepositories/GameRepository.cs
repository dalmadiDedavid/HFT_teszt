using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(GameDbContext ctx) : base(ctx)
        {

        }

        public void NameSet(int id, string newName)
        {
            Game old = ReadOne(id);
            old.GName = newName;
            ctx.SaveChanges();
        }
    }
}
