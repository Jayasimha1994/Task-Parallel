using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// paralle.foreach and foreach performance class
    /// </summary>
    class ParallelForEach
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void ParallelMethod()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Bilberry");
            fruits.Add("Blackberry");
            fruits.Add("Blackcurrant");
            fruits.Add("Blueberry");
            fruits.Add("Cherry");
            fruits.Add("Coconut");
            fruits.Add("Cranberry");
            fruits.Add("Date");
            fruits.Add("Fig");
            fruits.Add("Grape");
            fruits.Add("Guava");
            fruits.Add("Jack-fruit");
            fruits.Add("Kiwi fruit");
            fruits.Add("Lemon");
            fruits.Add("Lime");
            fruits.Add("Lychee");
            fruits.Add("Mango");
            fruits.Add("Melon");
            fruits.Add("Olive");
            fruits.Add("Orange");
            fruits.Add("Papaya");
            fruits.Add("Plum");
            fruits.Add("Pineapple");
            fruits.Add("Pomegranate");
            log.Info("Printing list using foreach loop\n");
            var stopWatch = Stopwatch.StartNew();
            foreach (string fruit in fruits)
            {
                log.InfoFormat("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
            }
            log.Info("Printing list using Parallel.ForEach");
            stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(fruits, fruit =>
            {
                log.InfoFormat("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
            }
            );
            log.InfoFormat("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            log.InfoFormat("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
        }
        static void Main(string[] args)
        {
            ParallelMethod();
            Console.Read();
        }
    }
}
