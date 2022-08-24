using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        
        private List<string> laps { get; }

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => this.laps;

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Start();
        }

        public string Lap()
        {
            string result = GetTime;
            this.laps.Add(result);
            return result;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.laps.Clear();
        }
    }
}
