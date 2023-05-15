using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Multithreading
{
    public class Demo1
    {
        public void Task1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }
        }
        public void Task2()
        {
            for (int i = 10; i <= 15; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }
        }
    }
    public class Programm
    {
        static void Main(string[] args)
        {
            Demo1 threadDemo = new Demo1();
            Thread t1 = new Thread(new ThreadStart(threadDemo.Task1));
            Thread t2 = new Thread(new ThreadStart(threadDemo.Task2));
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;
            t1.Start();
            t1.Join(); // block the execution till t1 thread will complete the task
            //OR
            t1.Join(3000); // block the execution of another thread till 3000ms,after  the duration unblock the thread

            t2.Start();

        }
    }
}
