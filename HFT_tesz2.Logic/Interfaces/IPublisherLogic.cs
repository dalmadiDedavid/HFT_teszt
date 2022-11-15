using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Logic.Interfaces
{
    public interface IPublisherLogic
    {
        //crud
        void Create(Publisher publisher);
        void Delete(int id);
        IEnumerable<Publisher> ReadAll();
        Publisher ReadOne(int id);
        void Update(Publisher publisher);
        //non-crud

      

    }
}
