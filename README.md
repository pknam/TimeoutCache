# TimeoutCache
[C#] Cache implementation with Timeout

## Example
```csharp
static void Main(string[] args)
{
    // set timeout as 3 sec
    TimeSpan cacheTimeout = new TimeSpan(0, 0, 3);

    // KEY_TYPE : string
    // VALUE_TYPE : int
    TimeoutCache<string, int?> cache = new TimeoutCache<string, int?>(cacheTimeout);

    // set value
    cache["hihi"] = 10;

    while(true)
    {
        int? val = cache["hihi"];

        if(val == null)
            Console.WriteLine("Cache miss");
        else
            Console.WriteLine("Cache hit. value : {0}", val);

        Thread.Sleep(200);
    }
}
```

* if cache MISS, it returns `default(VALUE_TYPE)`
 * `default(int)` == 0
 * `default(string)` == null
* using nullable type in VALUE_TYPE is recommended
 * like `TimeoutCache<string, int?>`
