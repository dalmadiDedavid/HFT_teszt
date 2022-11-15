using HFT_tesz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Logic.Interfaces
{
    public interface IGameLogic
    {
        //crud
        void Create(Game game);
        void Delete(int id);
        IEnumerable<Game> ReadAll();
        Game ReadOne(int id);
        void Update(Game game);
        //non-crud

        IEnumerable<KeyValuePair<string, int>> MostProductedDevTeam();
        IEnumerable<KeyValuePair<string, double>>AvgPriceByPublisher();
        IEnumerable<KeyValuePair<string, int>>PopularVideoGameCountryList();
        IEnumerable<KeyValuePair<string, int>>PopularPlatform();
        IEnumerable<KeyValuePair<string, int>> CountOfEachPublisherGame();
        IEnumerable<KeyValuePair<string, int>> ListOfMostPopularTypeOfGame();

        double AverageAgeLimit();





    }
}
