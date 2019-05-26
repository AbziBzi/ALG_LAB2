using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace ALG_LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            int[] values = new int[] { 250, 750, 2500, 10000, 50000, 150000, 500000, 1000000 };
            TestHashTable(values, seed);
            TestHashTableThread(values, seed);
        }

        public static void TestHashTable(int[] values, int seed)
        {
            Console.WriteLine("Hash Table Test One");
            Console.WriteLine("Elements Count:      Run Time:           Operations Count:");
            Console.WriteLine("------------------------------------------------------");

            foreach (int value in values)
            {
                MyHashTable hashTable = new HashTable();
                string[] keys = GenerateData(value, seed);
                for (int i = 0; i < keys.Length; i++)
                {
                    hashTable.Put(keys[i], double.Parse(keys[i]));
                }

                Stopwatch time = new Stopwatch();
                time.Start();
                for (int i = 0; i < value; i++)
                {
                    hashTable.Contains(keys[i]);
                }
                time.Stop();

                Console.WriteLine("{0,-20}{1,-20}{2,-50}", value, time.Elapsed.TotalMilliseconds, hashTable.operationsCount);
            }
        }

        public static void TestHashTableThread(int[] values, int seed)
        {
            Console.WriteLine("Hash Table Test Two");
            Console.WriteLine("Elements Count:      Run Time:           Operations Count:");
            Console.WriteLine("------------------------------------------------------");

            foreach (int value in values)
            {
                MyHashTable hashTable = new HashTable();
                int threadsCount = 1;
                int sum = 0;
                Thread[] threads = new Thread[threadsCount];
                string[] keys = GenerateData(value, seed);
                for (int i = 0; i < keys.Length; i++)
                {
                    hashTable.Put(keys[i], double.Parse(keys[i]));
                }

                Stopwatch time = new Stopwatch();
                time.Start();
                for (int j = 0; j < threadsCount; j++)
                {
                    int index = j;
                    threads[j] = new Thread(delegate ()
                        {
                            for (int k = (value / threadsCount) * index; k < (value / threadsCount) * (index + 1); k++)
                            {
                                if (hashTable.Contains(keys[k]))
                                    sum++;
                            }


                        }
                    );
                    threads[j].Start();
                }
                foreach(Thread thread in threads)
                {
                    thread.Join();
                }
                time.Stop();

                Console.WriteLine("{0,-20}{1,-20}{2}", value, time.Elapsed.TotalMilliseconds, hashTable.operationsCount);
            }
        }

        public static string[] GenerateData(int value, int seed)
        {
            string[] keys = new string[value];
            Random random = new Random(seed);
            for (int i = 0; i < value; i++)
            {
                string key = random.Next(10000000, 99999999).ToString();
                keys[i] = key;
            }
            return keys;
        }
    }
}