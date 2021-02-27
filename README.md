# NbaseN

Simple library to convert integers to n-Base numeric system.

## Getting started
Start is extremely simple.
Install nuget and reference namespace 
```cs
using NbaseN;
```

Then just call static conversion method:
```cs
string converted =  NbaseN<Base16>.ConvertToString(123456);
```

Enjoy the results!

## Wanna own alphabet?
No problem. Just implement `Base` abstract class with parameterless constructor (`new()`) and use it as a type parameter:
```cs
public class EmojiBase : Base
{
    public override IReadOnlyList<char> BaseChars { get; } = new[]
    {
        '\u2193', '\u2191'
    };    
}
```

Alphabet may contain any chars. The length of the alphabet array is the base of numeric system. The first char is for 0, the second - 1 and so on..  

# Speed
NbaseN is extremely fast. It is up to more than 20 times faster than alphabet-rich [Cambia.BaseN](https://www.cambiaresearch.com/articles/969077/cambia.basen-documentation-and-code-samples) converter. Just see the stats from Benchmark.DotNet:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 2400G with Radeon Vega Graphics, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.103
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT


```
|    Method |       Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |-----------:|---------:|---------:|-------:|------:|------:|----------:|
|  NbaseN_2 |   388.0 ns |  1.17 ns |  0.97 ns | 0.0420 |     - |     - |      88 B |
|  Cambia_2 | 3,047.1 ns | 47.88 ns | 44.79 ns | 0.4539 |     - |     - |     960 B |
| NbaseN_16 |   119.3 ns |  0.36 ns |  0.30 ns | 0.0191 |     - |     - |      40 B |
| Cambia_16 | 1,771.3 ns | 28.68 ns | 26.83 ns | 0.7820 |     - |     - |    1640 B |
| NbaseN_36 |   101.8 ns |  0.21 ns |  0.17 ns | 0.0190 |     - |     - |      40 B |
| Cambia_36 | 2,518.2 ns | 38.63 ns | 36.14 ns | 1.3885 |     - |     - |    2912 B |
| NbaseN_64 |   100.4 ns |  0.40 ns |  0.36 ns | 0.0191 |     - |     - |      40 B |
| Cambia_64 | 3,806.0 ns | 54.46 ns | 50.95 ns | 2.4376 |     - |     - |    5112 B |
