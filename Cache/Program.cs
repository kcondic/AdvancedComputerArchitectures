using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            for (var size = 256; size <= 64 * 1024 * 1024; size *= 2)
            {
                Console.Write($"{(float)size/256} kB "); //it is 256 because every int has 4 bytes -> 256 * 4 = 1024
                TryCache(size);
            }
            Console.WriteLine("Done");
        }

        static void TryCache(int size)
        {
            var array = new int[size];
            const int steps = 64 * 1024 * 1024; // 256MB
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (var i = 0; i < steps; i++)
                array[i * 16 % size]++;

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
        }
    }
}