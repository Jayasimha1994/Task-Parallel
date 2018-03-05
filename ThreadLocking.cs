using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// lock concept implemented class.
    /// </summary>
    class ThreadLocking
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Display()
        {
            lock (this)
            {
                log.Info("Csharp is an");
                Thread.Sleep(2000);
                log.Info(" object oriented programming");
            }
        }
        public static void CreateThread()
        {
            ThreadLocking obj = new ThreadLocking();
            Thread t1 = new Thread(obj.Display);
            Thread t2 = new Thread(obj.Display);
            Thread t3 = new Thread(obj.Display);
            t1.Start(); t2.Start(); t3.Start();
        }
        static void Main(string[] args)
        {
            CreateThread();
            Console.Read();
        }
    }
}
