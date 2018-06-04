using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace parallelLab2
{
    class Program
    {
        static int a, b, c, b2, fac, D;
        static double u1, u2, x1, x2;
        static EventWaitHandle w1 = new AutoResetEvent(false);
        static EventWaitHandle w2 = new AutoResetEvent(false);
        static EventWaitHandle w3 = new AutoResetEvent(false);
        static EventWaitHandle w4 = new AutoResetEvent(false);
        static EventWaitHandle w5 = new AutoResetEvent(false);
        static EventWaitHandle w6 = new AutoResetEvent(false);

        static void bSqr()
        {
            
            Console.WriteLine("b^2");
            b2 = b * b;
            Console.WriteLine(b2);
            Console.WriteLine('\n');
            w1.Set();
            
        }
        
        static void fourac()
        {
                Console.WriteLine("4ac");
            fac = 4 * a * c;
                Console.WriteLine(fac);
                Console.WriteLine('\n');
            w2.Set();
            
        }

        static void third()
        {
            w1.WaitOne();
            w2.WaitOne();
                Console.WriteLine("D");
                D = b2 - fac;
                Console.WriteLine(D);
                Console.WriteLine('\n');
            w3.Set();
            w4.Set();
            
        }

        static void fourth()
        {
            w3.WaitOne();
                Console.WriteLine("-b + sqrt(D)");
            u1 = -b + Math.Sqrt(D);
                Console.WriteLine(u1);
                Console.WriteLine('\n');
            w5.Set();
        }

        static void fifth()
        {
            w4.WaitOne();
                Console.WriteLine("-b - sqrt(D)");
            u2 = -b - Math.Sqrt(D);
                Console.WriteLine(u2);
                Console.WriteLine('\n');
            w6.Set();
        }

        static void sixth()
        {
            w5.WaitOne();
                Console.WriteLine("x1");
            x1 = u1 / (2 * a);
                Console.WriteLine(x1);
                Console.WriteLine('\n');
            
        }

        static void seventh()
        {
            w6.WaitOne();
                Console.WriteLine("x2");
            x2 = u2 / (2 * a);
            Console.WriteLine(x2);
                Console.WriteLine('\n');
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input c: ");
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine('\n');
            Thread t1 = new Thread(bSqr);
            t1.Start();
            Thread t2 = new Thread(fourac);
            t2.Start();
            Thread t3 = new Thread(third);
            t3.Start();
            Thread t4 = new Thread(fourth);
            t4.Start();
            Thread t5 = new Thread(fifth);
            t5.Start();
            Thread t6 = new Thread(sixth);
            t6.Start();
            Thread t7 = new Thread(seventh);
            t7.Start();
            Console.ReadLine();
        }
    }
}
