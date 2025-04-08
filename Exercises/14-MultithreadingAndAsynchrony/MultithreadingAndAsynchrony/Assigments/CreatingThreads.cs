using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAndAsynchrony.Assigments
{
    internal class CreatingThreads
    {
        public static void RunThreads()
        {
            Thread thread1 = new Thread(ThreadMethod);
            Thread thread2 = new Thread(ThreadMethod);
            Thread thread3 = new Thread(ThreadMethod);

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
        private static void ThreadMethod()
        {
            Console.WriteLine($"Hello from thread with ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
