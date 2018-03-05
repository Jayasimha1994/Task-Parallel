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
    /// Class for Parallel foreach loop.
    /// </summary>
    class TaskParallelClass
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void ParallelForEach()
        {
            string[] colors = { "1. Red", "2.Green", "3.Blue", "4.Yellow", "5.White", "6.Black", "7. violet" };
            log.Info("using Parallel.Foreach");
            Stopwatch s = Stopwatch.StartNew();
            Parallel.ForEach(colors, color =>
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            log.InfoFormat("Parallel.ForEach() execution time={0} seconds", s.Elapsed.TotalSeconds);
            log.Info("Traditional forEach Loop");
            Stopwatch s1 = Stopwatch.StartNew();
            foreach (string color in colors)
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
            log.InfoFormat("foreach loop execution time ={0} seconds\n", s1.Elapsed.TotalSeconds);
        }
        static void Main(string[] args)
        {
            ParallelForEach();
            Console.Read();
        }
    }
}
