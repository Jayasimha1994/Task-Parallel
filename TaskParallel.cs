using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// basic usage of Task Class
    /// </summary>
    class TaskParallel
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Assigning tasks to the Task class
        /// </summary>
        static void Task1()
        {
            Action cal = () => { for (int i = 0; i < 250000; i++) ; };
            var tasks = new[]
            {
                Task.Factory.StartNew(cal),
                Task.Factory.StartNew(cal),
                Task.Factory.StartNew(cal)
            };
            Task.WaitAll(tasks);
        }
        static void Main(string[] args)
        {
            Task1();
            Console.Read();
        }
    }
}
