using HFT_tesz2.Logic.Interfaces;
using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HFT_tesz2.Logic
{
    public class GameLogic : IGameLogic
    {
        IGameRepository G_rep;
        IPublisherRepository P_rep;
        IDevelopersTeamRepository D_rep;

        public GameLogic(IGameRepository gRep, IPublisherRepository pRep, IDevelopersTeamRepository dRep)
        {
            this.G_rep = gRep;
            this.P_rep = pRep;
            this.D_rep = dRep;
        }

        public IEnumerable<KeyValuePair<string, double>> AvgPriceByPublisher()
        {
            return from g in G_rep.ReadAll().ToList()                 
                   group g by g.Publisher.Name into b
                   orderby b.Average(pri => pri.Price) descending
                   select new KeyValuePair<string, double>
                   (b.Key, b.Average(pri => pri.Price));
        
        }

        public IEnumerable<KeyValuePair<string, int>> MostProductedDevTeam()
        {
            return from g in G_rep.ReadAll().ToList()                 
                   group g by g.Developers.Name into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());

        }
        public IEnumerable<KeyValuePair<string, int>> PopularVideoGameCountryList()
        {
            return from g in G_rep.ReadAll().ToList()                 
                   group g by g.Developers.Country into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());



        }
        public IEnumerable<KeyValuePair<string, int>> PopularPlatform()
        {
            return from g in G_rep.ReadAll().ToList()
                   group g by g.Publisher.Platform into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());


        }
        public IEnumerable<KeyValuePair<string, int>> ListOfMostPopularTypeOfGame()
        {
            return from g in G_rep.ReadAll().ToList()
                   group g by g.Type into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        
        }

        public IEnumerable<KeyValuePair<string, int>> CountOfEachPublisherGame()
        {
            return from g in G_rep.ReadAll().ToList()
                   group g by g.Publisher.Name into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());

        }

        public double AverageAgeLimit()
        {
            return G_rep.ReadAll().ToList().Average(g => g.AgeLimit);
    
        }


        IGameRepository gameRepo;
        public GameLogic(IGameRepository gameRepo)
        {
            this.gameRepo = gameRepo;
        }
        public void Create(Game game)
        {
            gameRepo.Create(game);
        }

        public void Delete(int id)
        {
            gameRepo.Delete(id);
        }

        public Game ReadOne(int id)
        {
            Game game = gameRepo.ReadOne(id);
            if (game == null)
                throw new ArgumentException("Game with the specified id does not exists.");
            return game;
        }

        public IEnumerable<Game> ReadAll()
        {
            return gameRepo.ReadAll();
        }

        public void Update(Game game)
        {
            gameRepo.Update(game);
        }


    }
}
