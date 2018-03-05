using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// class for Thread priorities.
    /// </summary>
    class ThreadPriorityClass
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static long Count1, Count2;
        public static void IncrementCount1()
        {
            while (true)
                Count1 += 1;
        }
        public static void IncrementCount2()
        {
            while (true)
                Count2 += 1;
        }
        public static void SetPriority()
        {
            Thread t1 = new Thread(IncrementCount1);
            Thread t2 = new Thread(IncrementCount2);
            t1.Priority = ThreadPriority.Lowest;//will get less value due to its lowest priority.
            t2.Priority = ThreadPriority.Highest;//will get high value due to its high priority.
            t1.Start();
            t2.Start();
            log.Info("main thread sleep for 2 sec");
            Thread.Sleep(2000);
            log.Info("main woke up");
            t1.Abort();
            t2.Abort();

            t1.Join();
            t2.Join();
            log.Info("count1 :" + Count1);
            log.Info("count2 :" + Count2);
        }
        static void Main(string[] args)
        {
            SetPriority();
            Console.Read();
        }
    }
}
