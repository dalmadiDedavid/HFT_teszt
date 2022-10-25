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

            
            var item = ctx.DevTeam.ToArray();
            ;
        }
    }
}
