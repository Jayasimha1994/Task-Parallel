using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// class for starting multiple threads.
    /// </summary>
    class StartThread
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void DoTask()
        {
            for (int i = 0; i < 5; i++)
            {
                log.Info("task :" + i);
            }
        }
        static void Task2()
        {
            for (int i = 0; i < 5; i++)
            {
                log.Info("task2 :" + i);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(DoTask);
            Thread t2 = new Thread(Task2);
            t.Start(); t2.Start();
            //t.Join();t2.Join();
            log.Info("main Completed");
            Console.Read();
        }
    }
}
