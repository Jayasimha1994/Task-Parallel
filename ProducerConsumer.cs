using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelProject
{
    /// <summary>
    /// Producer and consumer example class
    /// </summary>
    class ProducerConsumer
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// method which producer producing the things into queue 
        /// Consumer who takes that produced things.
        /// </summary>
        static void ProducerAndConsumer()
        {
            var queue = new BlockingCollection<int>();
            var producers = Enumerable.Range(1, 10)
                .Select(_ => Task.Factory.StartNew(() =>
                {
                    Enumerable.Range(1, 100)
                    .ToList()
                    .ForEach(i =>
                    {
                        queue.Add(i);
                        Thread.Sleep(100);
                    });
                }))
                .ToArray();
            var consumers = Enumerable.Range(1, 10)
                .Select(_ => Task.Factory.StartNew(() =>
                {
                    foreach (var item in queue.GetConsumingEnumerable())
                    {
                        log.Info("consumer :" + item);
                    }
                }))
                .ToArray();
            Task.WaitAll(producers);
            queue.CompleteAdding();
            Task.WaitAll(consumers);
        }
        static void Main(string[] args)
        {
            ProducerAndConsumer();
            Console.Read();
        }
    }
}
