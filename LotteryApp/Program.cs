using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RNG;

namespace LotteryApp

{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList giveawayList = new ArrayList();

            foreach(string line in File.ReadLines("C:\\Users\\nolic0321\\Desktop\\Giveaway List.txt"))
            {
                giveawayList.Add(new KeyValuePair<string,int>(line, 0));
            }
            Generator gen = new Generator(giveawayList.Count);

            Console.Write(String.Format("Loaded {0} users!  Enter number of picks: ",giveawayList.Count));
            int run = Int32.Parse(Console.ReadLine());
            for(int i = 1; i <= run; i++)
            {
                Console.Write(String.Format("\rRunning {0} of {1}    ", i, run));
                KeyValuePair<string, int> entry = (KeyValuePair<string,int>)giveawayList[gen.Generate()];
                entry.Value
            }
            Console.WriteLine();
            
            giveawayList.OrderByDescending(x => x.Value);

            Console.WriteLine("*******************Displaying results!*******************");
            int rank = 1;
            foreach(string sub in giveawayList.Keys)
            {
                Console.WriteLine(String.Format("{0}. {1} | {2} picks", rank, sub, giveawayList[sub]));
                rank++;
            }
            Console.WriteLine("CONGRATS TO THE WINNERS!!!");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
