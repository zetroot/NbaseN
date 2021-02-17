using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Cambia.BaseN;

namespace NbaseN.Tests.Benchmarking
{
    [MemoryDiagnoser]
    public class Int32ArrToStringsBenchmark
    {
        [Params(10, 1000, 100000)]
        public int ArraySize { get; set; }
        
        private List<int> srcInts;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Random();
            srcInts = Enumerable.Repeat(0, ArraySize).Select(_ => rnd.Next(Int32.MaxValue/3, Int32.MaxValue)).ToList();
        }
        
        [Benchmark]
        public string[] NbaseN_2 () => srcInts.Select(srcInt => NbaseN<Base2>.ConvertToString(srcInt)).ToArray();

        [Benchmark]
        public string[] Cambia_2() => srcInts.Select(srcInt =>BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base2)).ToArray();
        
        [Benchmark]
        public string[] NbaseN_16 () => srcInts.Select(srcInt =>NbaseN<Base16>.ConvertToString(srcInt)).ToArray();

        [Benchmark]
        public string[] Cambia_16() => srcInts.Select(srcInt =>BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base16)).ToArray();
        
        [Benchmark]
        public string[] NbaseN_36 () => srcInts.Select(srcInt =>NbaseN<Base36>.ConvertToString(srcInt)).ToArray();

        [Benchmark]
        public string[] Cambia_36() => srcInts.Select(srcInt =>BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base36)).ToArray();
        
        [Benchmark]
        public string[] NbaseN_64 () => srcInts.Select(srcInt =>NbaseN<Base64>.ConvertToString(srcInt)).ToArray();

        [Benchmark]
        public string[] Cambia_64() => srcInts.Select(srcInt =>BaseConverter.ToBaseN(srcInt, BaseNAlphabet.Base64)).ToArray();
    }
}