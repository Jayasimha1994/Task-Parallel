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
    /// class for parallel for usage
    /// </summary>
    class ParallelFor
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Compareing traditional for and Parallel.for
        /// </summary>
        static void ParallelMethod()
        {
            log.Info("Using C# For Loop \n");
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i <= 100; i++)
            {
                log.InfoFormat("i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
            }
            s.Stop();
            log.Info("\nUsing Parallel.For \n");
            Stopwatch s1 = Stopwatch.StartNew();
            Parallel.For(0, 100, i =>
            {
                log.InfoFormat("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
            });
            s1.Stop();
        }
        static void Main(string[] args)
        {
            ParallelMethod();
            Console.ReadLine();
        }
    }
}
