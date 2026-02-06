using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.Core.Models
{
    public class Heart
    {
        public int BeatsPerMinute { get; set; }

        public void Pump()
        {
            Console.WriteLine($"The heart is pumping at {BeatsPerMinute} BPM.");
        }
    }
}
