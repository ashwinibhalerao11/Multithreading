using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Multithreading
{
    public class ThreadDemo
    {
        public void Task1()
        {
            try
            {
                Monitor.Enter(this); // applied the lock
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(i);
                }
                Monitor.Wait(this, 5000);
                Monitor.Pulse(this);
                Monitor.PulseAll(this);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Monitor.Exit(this);// release the lock
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
    public class Program1
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
