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
            SortedList<int,KeyValuePair<string, int>> giveawayList = new SortedList<int, KeyValuePair<string, int>>();
            int position = 1;
            foreach(string line in File.ReadLines("C:\\Users\\nolic0321\\Desktop\\Giveaway List.txt"))
            {
                giveawayList.Add(position, new KeyValuePair<string,int>(line, 0));
                position++;
            }
            Generator gen = new Generator(1,giveawayList.Count);

            Console.Write(String.Format("Loaded {0} users!  Enter number of picks: ",giveawayList.Count));
            int run = Int32.Parse(Console.ReadLine());
            for(int i = 1; i <= run; i++)
            {
                Console.Write(String.Format("\rRunning {0} of {1}    ", i, run));
                int key = gen.Generate();
                KeyValuePair<string, int> entry = (KeyValuePair<string,int>)giveawayList[key];
                entry = new KeyValuePair<string, int>(entry.Key, entry.Value + 1);
                giveawayList[key] = entry;
            }
            Console.WriteLine();
            
            Dictionary<int,KeyValuePair<string, int>> result = giveawayList.OrderByDescending(x => x.Value.Value).ToDictionary();

            Console.WriteLine("*******************Displaying results!*******************");
            int rank = 1;
            foreach(int sub in result)
            {
                Console.WriteLine(String.Format("{0}. {1} | {2} picks", rank, sub, result[sub]));
                rank++;
            }
            Console.WriteLine("CONGRATS TO THE WINNERS!!!");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
