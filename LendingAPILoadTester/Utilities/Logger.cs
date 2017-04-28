using System;
using System.Collections.Concurrent;

namespace LendingAPILoadTester
{
    public class Logger
    {
        private SubLog overviewLog;
        private ConcurrentDictionary<string, SubLog> callLog;

        public Logger() {
            overviewLog = new SubLog();
            callLog = new ConcurrentDictionary<string, SubLog>();
        }

        public void UpdateStatistics(string callName, double callTime, bool hadError)
        {
            var call = GetCall(callName);
            call.UpdateSubLog(callTime, hadError);
            overviewLog.UpdateSubLog(callTime, hadError);
        }

        private SubLog GetCall(string callName)
        {
            var subLogDict = new SubLog();
            return callLog.GetOrAdd(callName, subLogDict);
        }

        public override string ToString()
        {
            var result = "";

            result += "Overview:";
            result += "\n\tNumber of calls: " + overviewLog.NumberOfCalls;
            result += "\n\tTotal Time: " + overviewLog.TotalTime;
            result += "\n\tAverage Time per Call: " + overviewLog.AverageTimePerCall;
            result += "\n\tStandard Deviation: " + overviewLog.StandardDeviation;
            result += "\n\tTotal Errors: " + overviewLog.Errors;
            result += "\n\tPercent of Errors: " + overviewLog.PercentErrors + "%";

            result += "\n\nCalls Made: ";

            foreach (var key in callLog.Keys)
            {
                result += "\n\t" + key;
                
                result += "\n\t\tNumber of calls: " + callLog[key].NumberOfCalls;
                result += "\n\t\tTotal Time: " + callLog[key].TotalTime;
                result += "\n\t\tAverage Time per Call: " + callLog[key].AverageTimePerCall;
                result += "\n\t\tStandard Deviation: " + callLog[key].StandardDeviation;
                result += "\n\t\tTotal Errors: " + callLog[key].Errors;
                result += "\n\t\tPercent of Errors: " + callLog[key].PercentErrors + "%";
            }

            return result;
        }
    }

    public class SubLog
    {
        public int NumberOfCalls { get { return _numberOfCalls; }  }
        public double TotalTime { get { return _totalTime; } }
        public double AverageTimePerCall { get { return _averageTimePerCall; } }
        public double StandardDeviation { get { return _standardDeviation; } }
        public int Errors { get { return _errors; } }
        public double PercentErrors { get { return _percentErrors; } }

        private int _numberOfCalls;
        private double _totalTime;
        private double _averageTimePerCall;
        private double _standardDeviation;
        private int _errors;
        private double _percentErrors;

        public SubLog()
        {
            _numberOfCalls = 0;
            _totalTime = 0.0;
            _averageTimePerCall = 0.0;
            _standardDeviation = 0.0;
            _errors = 0;
            _percentErrors = 0.0;
        }

        public void UpdateSubLog(double timeTaken, bool hasError)
        {
            var oldAverage = _averageTimePerCall;
            _numberOfCalls++;
            _totalTime += timeTaken;
            _averageTimePerCall = _totalTime / _numberOfCalls;
            CalculateStandardDeviation(oldAverage, timeTaken);
            _errors = (hasError) ? _errors + 1 : _errors;
            _percentErrors = (_errors * 1.0 / _numberOfCalls) * 100;
        }

        private void CalculateStandardDeviation(double oldAverage, double timeTaken)
        {
            if (NumberOfCalls < 2)
            {
                _standardDeviation = 0;
                return;
            }
            //This is based off of: https://math.stackexchange.com/questions/775391/can-i-calculate-the-new-standard-deviation-when-adding-a-value-without-knowing-t
            var oldStandardDeviationSquared = _standardDeviation * _standardDeviation;
            var a = (_numberOfCalls - 2) * oldStandardDeviationSquared;
            var b = (timeTaken - _averageTimePerCall) * (timeTaken - oldAverage);
            var c = _numberOfCalls - 1;
            var variance = (a + b) / c;
            _standardDeviation = Math.Sqrt(variance);
        }
    }
}
