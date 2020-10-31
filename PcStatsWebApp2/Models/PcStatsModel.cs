using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcStatsWebApp2.Models
{
    public class PcStatsModel
    {
        public PcStatsModel(string cpuUsagePercent, string memoryUsagePercent)
        {
            CpuUsagePercent = cpuUsagePercent;
            MemoryUsagePercent = memoryUsagePercent;
        }

        public string CpuUsagePercent { get; }
        public string MemoryUsagePercent { get; }
    }
}
