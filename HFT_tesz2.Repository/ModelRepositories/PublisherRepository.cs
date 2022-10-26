using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Repository.ModelRepositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameDbContext ctx) : base(ctx)
        {
        }


    }
}
