using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAndAsynchrony.Assigments
{
    internal class TasksWaiting
    {
        public static void RunSimpleTask()
        {
            Console.WriteLine("Before task starting.");

            var task1 = Task.Run(() =>
            {

                for(int i = 1; i < 4; i++)
                {
                    Thread.Sleep(1000);

                    Console.WriteLine($"Iteration number {i}");
                }

            });

            task1.Wait();

            Console.WriteLine("The task has finished.");
        }
    }
}
