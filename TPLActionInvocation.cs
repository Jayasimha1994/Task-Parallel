using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskParallelProject
{
    /// <summary>
    /// Class for Task Execution with Action Delegate
    /// </summary>
    class TPLActionInvocation
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void ActionTask()
        {
            Action<Action> measure = (body) =>
            {
                var startTime = DateTime.Now;
                body();
                log.InfoFormat("{0} {1}", DateTime.Now - startTime, Thread.CurrentThread.ManagedThreadId);
            };
            Action cal = () => { for (int i = 0; i < 250000000; i++) ; };
            measure(() =>
            {
                var tasks = new[]
                {
                Task.Factory.StartNew(()=>measure(cal)),
                Task.Factory.StartNew(()=>measure(cal)),
                Task.Factory.StartNew(()=>measure(cal)),
                Task.Factory.StartNew(()=>measure(cal)),
                Task.Factory.StartNew(()=>measure(cal)),
                Task.Factory.StartNew(()=>measure(cal))
                };
                Task.WaitAll(tasks);
            });
        }
        static void Main(string[] args)
        {
            ActionTask();
            Console.Read();
        }
    }
}
