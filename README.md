# TimeoutCache
[C#] Cache implementation with Timeout

## Example
```csharp
static void Main(string[] args)
{
    // set timeout as 3 sec
    TimeSpan cacheTimeout = new TimeSpan(0, 0, 3);
    TimeoutCache<string, int> cache = new TimeoutCache<string, int>(cacheTimeout);

    // set value
    cache["hihi"] = 10;

    while(true)
    {
        Console.WriteLine(cache["hihi"]);
        Thread.Sleep(200);
    }
}
```

* if cache MISS, it returns `default(VALUE_TYPE)`
* `default(int)` == 0
* `default(string)` == null