using System;
using HFT_tesz2.Repository;
using System.Linq;

namespace HFT_teszt2.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameDbContext ctx = new GameDbContext();

            var game = ctx.Game.FirstOrDefault(g => g.Id == 2);
            Console.WriteLine(game.Publisher.Name);

            var item = ctx.Publishers.ToArray();
            for (int i = 0; i < item.Length; i++)
            {
                //Console.WriteLine(item[i].Name);
            }

            var cuccok = item[0].Games.ToArray();
            for (int i = 0; i < cuccok.Length; i++)
            {
                //Console.WriteLine(cuccok[i].GName);
            }

            var item2 = ctx.DevTeam.ToArray();
            for (int i = 0; i < item2.Length; i++)
            {
                //Console.WriteLine(item2[i].Name);
            }
            var cuccok2 = item[0].Games.ToArray();
            for (int i = 0; i < cuccok2.Length; i++)
            {
                //Console.WriteLine(cuccok2[i].GName);
            }

            




        }
    }
}
