using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boekTitel = { "Les Fleurs du mal", "Don Quichotte", "Monster" };

            int index = Array.IndexOf(boekTitel, "Monster".ToLower());

            Console.WriteLine(index);

            

            Console.ReadLine();
        }
    }
}
