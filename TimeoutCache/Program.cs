using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeoutCache
{
    class Program
    {
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
    }
}
