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
    class PublisherLogic : IPublisherLogic
    {
        IPublisherRepository publisherRepo;
        public PublisherLogic(IPublisherRepository publisherRepo)
        {
            this.publisherRepo = publisherRepo;
        }


       

        public void Create(Publisher publisher)
        {
            publisherRepo.Create(publisher);
        }

        public void Delete(int id)
        {
            publisherRepo.Delete(id);
        }

        public IEnumerable<Publisher> ReadAll()
        {
            return publisherRepo.ReadAll();
        }

        public Publisher ReadOne(int id)
        {
            Publisher publisher = publisherRepo.ReadOne(id);
            if (publisher == null)
                throw new ArgumentException("Publisher with the specified id does not exists..");
            return publisher;
        }

        public void Update(Publisher publisher)
        {
            publisherRepo.Update(publisher);
        }
    }
}
