using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns
{
    /// <summary>
    /// A Singleton class to manage the open StreamWriter object
    /// to write to a TraceGame.txt file.
    /// </summary>
    public class TraceListenerSingleton
    {
        private static TraceListenerSingleton _instance;
        private TraceListener fileLog;
        private TraceListenerSingleton() {
            fileLog = new TextWriterTraceListener(new StreamWriter("TraceGame.txt"));
        }
        /// <summary>
        /// Get The Singleton instance
        /// </summary>
        /// <returns>the instance</returns>
        public static TraceListenerSingleton GetTrace()
        {
            if (_instance == null)
            {
                _instance = new TraceListenerSingleton();
            }
            return _instance;
        }
        /// <summary>
        /// Get the Text Write Trace Listener object
        /// </summary>
        /// <returns>TraceListener</returns>
        public TraceListener Trace()
        {    
            return fileLog;
        }
    }
}
