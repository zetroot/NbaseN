using System;
using System.Collections;
using BenchmarkDotNet.Running;

namespace NbaseN.Tests.Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            //_ = BenchmarkRunner.Run<Int32ToStringBenchmark>();
            _ = BenchmarkRunner.Run<Int32ArrToStringsBenchmark>();
            Console.ReadKey();
        }
    }
}