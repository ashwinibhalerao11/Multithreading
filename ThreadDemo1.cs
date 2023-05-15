using DotNet.Multithreading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Multithreading
{
    public class ThreadDemo1
    {
        public void Task1()
        {
            lock (this) // this refers to current thread
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(i);
                }
            }

        }
        public void Task2()
        {
            lock (this)
            {
                for (int i = 10; i <= 15; i++)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
    public class Program2
    {
        static void Main(string[] args)
        {
            ThreadDemo threadDemo = new ThreadDemo();
            Thread t1 = new Thread(new ThreadStart(threadDemo.Task1));
            Thread t2 = new Thread(new ThreadStart(threadDemo.Task2));
            Thread t3 = new Thread(new ThreadStart(threadDemo.Task1));

            t1.Start();
            t2.Start();
            t3.Start();
        }



    }
}
