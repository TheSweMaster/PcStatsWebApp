using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PcStatsWebApp2.Models;

namespace PcStatsWebApp2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPcStats()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            cpuCounter.NextValue(); // Always return 0 at first call
            await Task.Delay(1000); // Need to wait some between calls for cpu % it to be accurate

            var cpuUsagePercent = $"{cpuCounter.NextValue()} %";
            var memoryUsagePercent = $"{ramCounter.NextValue()} %";

            var pcStatsModel = new PcStatsModel(cpuUsagePercent, memoryUsagePercent);
            return PartialView(pcStatsModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
