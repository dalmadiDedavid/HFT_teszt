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

            var item = ctx.Publishers.ToArray();
            for (int i = 0; i < item.Length; i++)
            {
                Console.WriteLine(item[i].Name);
            }

            var cuccok = item[0].Games.ToArray();
            for (int i = 0; i < cuccok.Length; i++)
            {
                Console.WriteLine(cuccok[i].GName);
            }
            
            
        }
    }
}
