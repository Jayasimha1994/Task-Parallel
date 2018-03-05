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
    /// Class which shows the difference between single threaded and multi threaded applications.
    /// </summary>
    class ThreadPerformance
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static int count1, count2;
        static void IncrementCount1()
        {
            for(long i=0;i<10000000;i++)
            {
                count1++;
            }
            Console.WriteLine(count1);
        }
        static void IncrementCount2()
        {
            for (long i = 0; i < 10000000; i++)
            {
                count2++;
            }
            Console.WriteLine(count2);
        }/// <summary>
        /// Single threaded and Multi threaded processing.
        /// </summary>
        static void Performance()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            IncrementCount1();
            IncrementCount2();
            log.Info("Single threaded :" + s.ElapsedMilliseconds);
            s.Stop();
            count1 = count2 = 0;//re-assigning the values to zero.
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            Thread t1 = new Thread(IncrementCount1);
            Thread t2 = new Thread(IncrementCount2);
            t1.Start(); t2.Start();
            s1.Stop();
            t1.Join(); t2.Join();
            log.Info("Multi threaded :" + s1.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            Performance();
            Console.Read();
        }
    }
}
