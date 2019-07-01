using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var threads = new List<Thread>();
            var stopWatch = new Stopwatch();
            var sum = 0;
            var numberOfThreads = 1;
            var sizeOfArray = 100000000;


            Console.WriteLine("1 thread:");
            var randomArray = GenerateRandomArray(sizeOfArray);
            for (var i = 0; i < 5; i++)
            {
                stopWatch.Start();
                var array = randomArray;
                for (var j = 0; j < numberOfThreads; j++)
                {
                    var tempJ = j;
                    var ofThreads = numberOfThreads;
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, CalculateSum(array.Skip(tempJ * array.Length / ofThreads).Take(array.Length / ofThreads)))));
                }
                foreach (var thread in threads)
                    thread.Start();
                foreach (var thread in threads)
                    thread.Join();
                stopWatch.Stop();

                Console.WriteLine($"Pass number: {i + 1}, average: { sum / sizeOfArray }, time: {stopWatch.ElapsedMilliseconds}ms");
                threads.Clear();
                stopWatch.Reset();
                sum = 0;
            }
            Console.WriteLine($"Real average: {randomArray.Average()}");

            /*** ***/
            Console.WriteLine("2 threads:");
            randomArray = GenerateRandomArray(sizeOfArray);
            numberOfThreads = 2;

            for (var i = 0; i < 5; i++)
            {
                stopWatch.Start();
                var array = randomArray;
                for (var j = 0; j < numberOfThreads; j++)
                {
                    var tempJ = j;
                    var ofThreads = numberOfThreads;
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, CalculateSum(array.Skip(tempJ * array.Length / ofThreads).Take(array.Length / ofThreads)))));
                }
                foreach (var thread in threads)
                    thread.Start();
                foreach (var thread in threads)
                    thread.Join();
                stopWatch.Stop();

                Console.WriteLine($"Pass number: {i + 1}, average: { sum / sizeOfArray }, time: {stopWatch.ElapsedMilliseconds}ms");
                threads.Clear();
                stopWatch.Reset();
                sum = 0;
            }
            Console.WriteLine($"Real average: {randomArray.Average()}");

            /*** ***/
            Console.WriteLine("4 threads:");
            randomArray = GenerateRandomArray(sizeOfArray);
            numberOfThreads = 4;

            for (var i = 0; i < 5; i++)
            {
                stopWatch.Start();
                var array = randomArray;
                for (var j = 0; j < numberOfThreads; j++)
                {
                    var tempJ = j;
                    var ofThreads = numberOfThreads;
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, CalculateSum(array.Skip(tempJ * array.Length / ofThreads).Take(array.Length / ofThreads)))));
                }
                foreach (var thread in threads)
                    thread.Start();
                foreach (var thread in threads)
                    thread.Join();
                stopWatch.Stop();

                Console.WriteLine($"Pass number: {i + 1}, average: { sum / sizeOfArray }, time: {stopWatch.ElapsedMilliseconds}ms");
                threads.Clear();
                stopWatch.Reset();
                sum = 0;
            }
            Console.WriteLine($"Real average: {randomArray.Average()}");

            /*** ***/
            Console.WriteLine("8 threads:");
            randomArray = GenerateRandomArray(sizeOfArray);
            numberOfThreads = 8;

            for (var i = 0; i < 5; i++)
            {
                stopWatch.Start();
                var array = randomArray;
                for (var j = 0; j < numberOfThreads; j++)
                {
                    var tempJ = j;
                    var ofThreads = numberOfThreads;
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, CalculateSum(array.Skip(tempJ * array.Length / ofThreads).Take(array.Length / ofThreads)))));
                }
                foreach (var thread in threads)
                    thread.Start();
                foreach (var thread in threads)
                    thread.Join();
                stopWatch.Stop();

                Console.WriteLine($"Pass number: {i + 1}, average: { sum / sizeOfArray }, time: {stopWatch.ElapsedMilliseconds}ms");
                threads.Clear();
                stopWatch.Reset();
                sum = 0;
            }
            Console.WriteLine($"Real average: {randomArray.Average()}");

            /*** ***/
            Console.WriteLine("16 threads:");
            randomArray = GenerateRandomArray(sizeOfArray);
            numberOfThreads = 16;

            for (var i = 0; i < 5; i++)
            {
                stopWatch.Start();
                var array = randomArray;
                for (var j = 0; j < numberOfThreads; j++)
                {
                    var tempJ = j;
                    threads.Add(new Thread(() => Interlocked.Add(ref sum, CalculateSum(array.Skip(tempJ * array.Length / numberOfThreads).Take(array.Length / numberOfThreads)))));
                }
                foreach (var thread in threads)
                    thread.Start();
                foreach (var thread in threads)
                    thread.Join();
                stopWatch.Stop();

                Console.WriteLine($"Pass number: {i + 1}, average: { sum / sizeOfArray }, time: {stopWatch.ElapsedMilliseconds}ms");
                threads.Clear();
                stopWatch.Reset();
                sum = 0;
            }
            Console.WriteLine($"Real average: {randomArray.Average()}");
        }

        static int[] GenerateRandomArray(int size)
        {
            var array = new int[size];
            var random = new Random();
            const int maxNumber = 20;

            for (var i = 0; i < array.Length; i++)
                array[i] = random.Next(maxNumber);

            return array;
        }

        static int CalculateSum(IEnumerable<int> array)
        {
            return array.Sum();
        }
    }
}