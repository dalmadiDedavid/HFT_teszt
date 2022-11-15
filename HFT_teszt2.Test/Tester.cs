using HFT_tesz2.Logic;
using HFT_tesz2.Logic.Interfaces;
using HFT_tesz2.Logic.Services;
using HFT_tesz2.Model;
using HFT_tesz2.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HFT_teszt2.Test
{
    [TestFixture]
    public class Tester
    {
        IGameLogic gameLogic;
        IPublisherLogic publisherLogic;
        IDevelopersTeamLogic devLogic;


        public Tester()
        {
            var mockGameRepo = new Mock<IGameRepository>();
            var mockPubliRepo = new Mock<IPublisherRepository>();
            var mockDevRepo = new Mock<IDevelopersTeamRepository>();


            Publisher p1 = new Publisher() { Id = 1, Name = "Battlenet", Platform = "Windows"};
            Publisher p2 = new Publisher() { Id = 2, Name = "Origin", Platform = "Linux" };

            DevelopersTeam d1 = new DevelopersTeam() { Id = 1, Name = "Activision", Country = "USA", CountofMembers = 500 };
            DevelopersTeam d2 = new DevelopersTeam() { Id = 2, Name = "FrostBite" , Country = "Poland", CountofMembers = 450};

            mockGameRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Game>
                {
                   new Game()
                   {
                       GName = "COD",
                       Price = 8000,
                       PubId = p1.Id,
                       DevId = d1.Id,
                       AgeLimit = 16,
                       Type = "Shooter",
                       Publisher = p1,
                       Developers = d1
                                            

                   },
                   new Game()
                   {
                       GName = "Battlefield",
                       Price = 10000,
                       PubId = p1.Id,
                       DevId = d1.Id,
                       AgeLimit = 16,
                       Type = "Shooter",
                       Publisher = p1,
                       Developers = d1


                   },
                   new Game()
                   {
                       GName = "Fifa",
                       Price = 12000,
                       PubId = p1.Id,
                       DevId = d1.Id,
                       AgeLimit = 12,
                       Type = "Football",
                       Publisher = p1,
                       Developers = d1


                   },
                   new Game()
                   {
                       GName = "Fifa WordCup",
                       Price = 18000,
                       PubId = p2.Id,
                       DevId = d2.Id,
                       AgeLimit = 12,
                       Type = "Shooter",
                       Publisher = p2,
                       Developers = d2
                       


                   },

                }.AsQueryable());
            mockPubliRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Publisher>
                {p1,p2}.AsQueryable());

            mockDevRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<DevelopersTeam>
                {d1,d2}.AsQueryable());

            gameLogic = new GameLogic(mockGameRepo.Object, mockPubliRepo.Object, mockDevRepo.Object);
            
        }
        //non-crudTest
        [Test]
        public void AvgPriceByPublisherTest()
        {

            var result = gameLogic.AvgPriceByPublisher().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("Origin", 18000)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, double>("Battlenet", 10000)));
        }
        //public IEnumerable<KeyValuePair<string, int>> MostProductedDevTeam()
        [Test]
        public void MostProductedDevTeamTest()
        {
            var result = gameLogic.MostProductedDevTeam().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Activision", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("FrostBite", 1)));


        }
        //IEnumerable<KeyValuePair<string, int>> PopularVideoGameCountry();
        [Test]
        public void PopularVideoGameCountryTest()
        {
            var result = gameLogic.PopularVideoGameCountryList().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("USA", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Poland", 1)));

        }
        //IEnumerable<KeyValuePair<string, int>> PopularPlatform()
        [Test]
        public void PopularPlatformTest()
        {
            var result = gameLogic.PopularPlatform().ToArray();

            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Windows", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Linux", 1)));

        }
        //IEnumerable<KeyValuePair<string, int>> CountOfEachPublisherGame()
        [Test]
        public void CountOfEachPublisherGame()
        {
            var result = gameLogic.CountOfEachPublisherGame().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Battlenet", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Origin", 1)));
        
        }

        //non-crudTestEnd
        [Test]
        public void CreateGameTest()
        {
            Assert.That(() => gameLogic.Create(new Game()
            {
                GName = "Need For Speed",
                Price = 12000,
                Type = "CarGame",
                AgeLimit = 12
            }), Throws.Exception);
           
        }
        [Test]
        public void CreatePublisherTest()
        {
            Assert.That(() => publisherLogic.Create(new Publisher()
            {
               Name = "Steam",
               Platform = "Windows",
            }), Throws.Exception);

        }
        [Test]
        public void CreateDevTeamTest()
        {
            Assert.That(() => devLogic.Create(new DevelopersTeam()
            {
                Name = "CD Projekt Red",
                Country = "Poland",
            }), Throws.Exception);

        }
       

        //IEnumerable<KeyValuePair<string, int>> ListOfMostPopularTypeOfGame()
        [Test]
        public void ListOfMostPopularTypeOfGameTest()
        {
            var result = gameLogic.ListOfMostPopularTypeOfGame().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Shooter", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Football", 1)));
        }
        [Test]
        public void AverageAgeLimit()
        {
            var result = gameLogic.AverageAgeLimit();
            Assert.That(result, Is.EqualTo(14));
        
        }
    }
}
