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
No problem. just implement `IBase` interface in a class that can be `new()` and use it as a type parameter:

```cs
public class EmojiBase : IBase
{
    public IReadOnlyList<char> BaseChars { get; } = new[]
    {
        '\u2193', '\u2191'
    };

    public int TargetBase => 2;
}
```
Alphabet may contain any Unicode chars