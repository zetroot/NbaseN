# NbaseN

Simple library to string representation in n-base.

## Getting started
Starting to use is extremly simple.
Reference namespace by 
```cs
using NbaseN;
```

Then just call static conversion method:
```cs
string converted =  NbaseN<Base16>.ConvertToString(123456);
```
## Wanna own alphabet?
No problem. Just implement an inheritor of `Base` abstract class with parameterless constructor (`new()`) and use it as a type parameter:

```cs
public class EmojiBase : Base
{
    public override IReadOnlyList<char> BaseChars { get; } = new[]
    {
        '\u2193', '\u2191'
    };    
}
```
Alphabet may contain any Unicode chars

# Speed
NbaseN is extremly fast. It is up to more than 20 times faster than alphabet-rich [Cambia.BaseN](https://www.cambiaresearch.com/articles/969077/cambia.basen-documentation-and-code-samples) converter. Just see the stats for single conversion:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.804 (2004/?/20H1)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|    Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|  NbaseN_2 |   448.36 ns |  1.327 ns |  1.036 ns | 0.0277 |     - |     - |      88 B |
|  Cambia_2 | 2,930.08 ns | 15.433 ns | 14.436 ns | 0.3052 |     - |     - |     960 B |
| NbaseN_16 |   125.84 ns |  1.204 ns |  1.005 ns | 0.0126 |     - |     - |      40 B |
| Cambia_16 | 1,495.31 ns | 23.110 ns | 21.617 ns | 0.5322 |     - |     - |    1672 B |
| NbaseN_36 |    98.56 ns |  0.347 ns |  0.308 ns | 0.0126 |     - |     - |      40 B |
| Cambia_36 | 2,061.29 ns | 18.773 ns | 17.560 ns | 0.9270 |     - |     - |    2912 B |
| NbaseN_64 |    96.42 ns |  0.622 ns |  0.551 ns | 0.0126 |     - |     - |      40 B |
| Cambia_64 | 2,866.08 ns | 54.231 ns | 53.262 ns | 1.6098 |     - |     - |    5056 B |


Or for array conversion:

|    Method | ArraySize |           Mean |         Error |        StdDev |       Gen 0 |      Gen 1 |     Gen 2 |   Allocated |
|---------- |---------- |---------------:|--------------:|--------------:|------------:|-----------:|----------:|------------:|
|  NbaseN_2 |        10 |       4.267 μs |     0.0203 μs |     0.0180 μs |      0.3357 |          - |         - |      1056 B |
|  Cambia_2 |        10 |      29.891 μs |     0.2843 μs |     0.2659 μs |      3.0823 |          - |         - |      9752 B |
| NbaseN_16 |        10 |       1.287 μs |     0.0067 μs |     0.0063 μs |      0.1831 |          - |         - |       576 B |
| Cambia_16 |        10 |      15.311 μs |     0.1335 μs |     0.1249 μs |      5.4016 |          - |         - |     16952 B |
| NbaseN_36 |        10 |       1.081 μs |     0.0076 μs |     0.0067 μs |      0.1831 |          - |         - |       576 B |
| Cambia_36 |        10 |      20.840 μs |     0.3997 μs |     0.3926 μs |      9.2773 |          - |         - |     29144 B |
| NbaseN_64 |        10 |       1.037 μs |     0.0065 μs |     0.0060 μs |      0.1793 |          - |         - |       568 B |
| Cambia_64 |        10 |      29.569 μs |     0.5828 μs |     0.6236 μs |     16.2659 |          - |         - |     51104 B |
|  NbaseN_2 |      1000 |     435.409 μs |     2.7564 μs |     2.5784 μs |     25.3906 |     8.3008 |         - |     96096 B |
|  Cambia_2 |      1000 |   3,012.519 μs |    12.8126 μs |    11.9849 μs |    300.7813 |    11.7188 |         - |    966520 B |
| NbaseN_16 |      1000 |     127.334 μs |     1.3323 μs |     1.2462 μs |     15.1367 |     3.6621 |         - |     48096 B |
| Cambia_16 |      1000 |   1,661.626 μs |    18.0512 μs |    16.8851 μs |    541.0156 |     1.9531 |         - |   1701800 B |
| NbaseN_36 |      1000 |     101.981 μs |     0.4105 μs |     0.3840 μs |     15.2588 |     1.4648 |         - |     48096 B |
| Cambia_36 |      1000 |   2,206.059 μs |    28.9034 μs |    27.0362 μs |    925.7813 |          - |         - |   2908448 B |
| NbaseN_64 |      1000 |     104.297 μs |     0.6696 μs |     0.5936 μs |     14.6484 |          - |         - |     46112 B |
| Cambia_64 |      1000 |   3,094.699 μs |    19.2399 μs |    17.9970 μs |   1621.0938 |          - |         - |   5090840 B |
|  NbaseN_2 |    100000 |  55,902.071 μs |   780.1524 μs |   691.5848 μs |   1600.0000 |   700.0000 |  200.0000 |   9600485 B |
|  Cambia_2 |    100000 | 317,607.550 μs | 3,387.8084 μs | 3,003.2039 μs |  15000.0000 |  4000.0000 |         - |  96640936 B |
| NbaseN_16 |    100000 |  19,229.624 μs |   375.5174 μs |   501.3049 μs |    812.5000 |   437.5000 |  187.5000 |   4800192 B |
| Cambia_16 |    100000 | 185,231.631 μs | 3,372.5315 μs | 3,154.6680 μs |  54333.3333 | 17333.3333 | 1000.0000 | 169961669 B |
| NbaseN_36 |    100000 |  17,452.161 μs |   302.2552 μs |   335.9558 μs |    812.5000 |   437.5000 |  187.5000 |   4800352 B |
| Cambia_36 |    100000 | 233,210.874 μs | 2,106.1326 μs | 1,867.0317 μs |  93333.3333 | 23666.6667 | 1000.0000 | 290567464 B |
| NbaseN_64 |    100000 |  16,208.775 μs |   319.4906 μs |   533.7970 μs |    781.2500 |   468.7500 |  187.5000 |   4599707 B |
| Cambia_64 |    100000 | 308,799.079 μs | 4,444.1554 μs | 3,939.6280 μs | 163000.0000 | 41000.0000 | 1000.0000 | 509065696 B |
