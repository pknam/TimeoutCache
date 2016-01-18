# TimeoutCache
[C#] Cache implementation with Timeout

## Example
### Source
```csharp
static void Main(string[] args)
{
    // set timeout as 3 sec
    TimeSpan cacheTimeout = new TimeSpan(0, 0, 3);

    // KEY_TYPE : string
    // VALUE_TYPE : int
    TimeoutCache<string, int> cache = new TimeoutCache<string, int>(cacheTimeout);

    // set value
    cache["hihi"] = 10;

    while (true)
    {
        try
        {
            int val = cache["hihi"];
            Console.WriteLine("Cache hit. value : {0}", val);
        }
        catch (TimeoutCacheMissException)
        {
            Console.WriteLine("Cache miss");
        }
        catch (TimeoutCacheKeyNotFoundException)
        {
            Console.WriteLine("Key not found");
            break;
        }

        // sleep 1 sec
        Thread.Sleep(1000);
    }
}
```

### Result
```
Cache hit. value : 10
Cache hit. value : 10
Cache hit. value : 10
Cache miss
Key not found
```