using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository
{
    public class Repository<T>: IRepository<T> where T : Entity
    {
        protected GameDbContext ctx;

        public Repository(GameDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));

        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();

        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(ReadOne(id));
            ctx.SaveChanges();
        }

        public virtual T ReadOne(int id)
        {
            return ctx.Set<T>().FirstOrDefault(item => item.Id.Equals(id));
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public virtual void Update(T item)
        {
            var old = ReadOne(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();


        }

    }
}
