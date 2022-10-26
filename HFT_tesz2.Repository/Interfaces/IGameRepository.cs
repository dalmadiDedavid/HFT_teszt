using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        void NameSet(int id, string newName);
    }
}
