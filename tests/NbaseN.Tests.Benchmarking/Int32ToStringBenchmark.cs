using System;
using BenchmarkDotNet.Attributes;
using Cambia.BaseN;

namespace NbaseN.Tests.Benchmarking
{
    [MemoryDiagnoser]
    public class Int32ToStringBenchmark
    {
        private int srcInt;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Random();
            srcInt = rnd.Next(Int32.MaxValue/3, Int32.MaxValue);
        }
        
        [Benchmark]
        public string NbaseN_2 () => NbaseN<Base2>.ConvertToString(srcInt);

        [Benchmark]
        public string Cambia_2() => BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base2);
        
        [Benchmark]
        public string NbaseN_16 () => NbaseN<Base16>.ConvertToString(srcInt);

        [Benchmark]
        public string Cambia_16() => BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base16);
        
        [Benchmark]
        public string NbaseN_36 () => NbaseN<Base36>.ConvertToString(srcInt);

        [Benchmark]
        public string Cambia_36() => BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base36);
        
        [Benchmark]
        public string NbaseN_64 () => NbaseN<Base64>.ConvertToString(srcInt);

        [Benchmark]
        public string Cambia_64() => BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base64);
    }
}