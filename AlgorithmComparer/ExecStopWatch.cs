using System;
using System.Diagnostics;

namespace AlgorithmComparer
{
    public class ExecStopWatch
    {
        Stopwatch _stopwatch;

        public ExecStopWatch()
        {
            _stopwatch = new Stopwatch();
        }

        public TimeSpan CountExecTime(Action action)
        {
            _stopwatch.Start();
            action.Invoke();
            _stopwatch.Stop();

            var execTime = _stopwatch.Elapsed;
            _stopwatch.Reset();

            return execTime;
        }
    }
}
