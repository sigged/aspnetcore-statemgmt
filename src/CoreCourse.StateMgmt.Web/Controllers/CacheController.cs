using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreCourse.StateMgmt.Web.Models.Cache;
using CoreCourse.StateMgmt.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CoreCourse.StateMgmt.Web.Controllers
{
    public class CacheController : Controller
    {
        const int DIGITS_TO_CALCULATE = 70 * 9;
        const int SECONDS_TO_CACHE = 10;

        IMemoryCache _cache;
        PICalculator _calc = new PICalculator();

        public CacheController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewPi()
        {
            PIResult piResult;


            Stopwatch sw = Stopwatch.StartNew();

            // Look for cache key.
            if (!_cache.TryGetValue("PIResult", out piResult))
            {
                // Key not in cache, so get data.
                List<int> digits = await calculatePI();

                //create new object to cache
                piResult = new PIResult
                {
                    PiDecimals = digits,
                    Digits = DIGITS_TO_CALCULATE,
                    CacheTime = DateTime.Now
                };

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(SECONDS_TO_CACHE));

                // Save data in cache.
                _cache.Set("PIResult", piResult, cacheEntryOptions);
            }
            sw.Stop();

            var vm = new ViewPiVm
            {
                Result = piResult,
                CacheDuration = SECONDS_TO_CACHE,
                ElapsedTime = sw.Elapsed
            };

            return View(vm);
        }

        private async Task<List<int>> calculatePI()
        {
            List<int> allDigits = new List<int>();

            for (int i = 0; i <= DIGITS_TO_CALCULATE; i += 9)
            {
                allDigits.Add(await _calc.GetNineDigits(i));
            }

            return allDigits;
        }
    }
}