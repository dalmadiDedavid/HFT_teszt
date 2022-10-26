using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> ReadAll();
        T ReadOne(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int itemID);
    }
}
