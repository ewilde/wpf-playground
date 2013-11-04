using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic.wpf.Statistics
{
    using System.Diagnostics;

    public static class Monitor
    {
        private static ILog Log;

        [ThreadStatic]
        private static Stopwatch watch;

        [ThreadStatic]
        private static long lastSplit;

        static Monitor()
        {
            Log = new DebugLog(); 
        }

        public static void Start()
        {
            watch = new Stopwatch();
            watch.Start();
        }

        public static void Split(string @event)
        {
            if (watch == null)
            {
                Start();
            }
            var gap = new TimeSpan(watch.ElapsedTicks - lastSplit);
            Log.Debug(string.Format("{0} took {1}ms", @event, gap.TotalMilliseconds));

            lastSplit = watch.ElapsedTicks;
        }

        public static void Stop()
        {
            watch.Stop();
            Log.Debug(string.Format("Timed process took {0}ms", watch.ElapsedMilliseconds));
        }
    }

    public interface ILog
    {
        void Debug(string value);
    }

    public class DebugLog : ILog
    {
        public void Debug(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }
    }
}
