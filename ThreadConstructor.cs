using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// Class for different types of constructors available for threads.
    /// </summary>
    class ThreadConstructor
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                log.Info("Iteration of :"+i);
            }
        }
        static void CreateThread()
        {
            ThreadStart del = new ThreadStart(Test);
            //ThreadStart obj = Test;
            //ThreadStart obj1 = delegate () { Test(); };
            //ThreadStart obj2 = () => Test();
            Thread t = new Thread(del);
            t.Start();
        }
        static void Main(string[] args)
        {
            CreateThread();
            Console.Read();
        }
    }
}
