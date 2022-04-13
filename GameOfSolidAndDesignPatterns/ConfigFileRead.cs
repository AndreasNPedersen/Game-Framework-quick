
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameOfSolidAndDesignPatterns
{
    /// <summary>
    /// The Configuration file read class, that read a file, which is a Singleton
    /// </summary>
    public sealed class ConfigFileRead
    {
        private static ConfigFileRead _instance;
        TraceSource ts = new TraceSource("TraceGame");
        private ConfigFileRead() { }

        public static ConfigFileRead GetConfigFileReadInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigFileRead();
            }
            return _instance;
        }
        /// <summary>
        /// Read the file and return 4 integers in the list
        /// </summary>
        /// <returns>A list with 4 integers</returns>
        public List<int> ReadConfig()
        {
            
            ts.Switch = new SourceSwitch("ReadConfig", "All");
           
            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Information, 1, "Config File reading");
            
            List<int> values = new List<int>();
            try
            {
                XmlDocument configDoc = new XmlDocument();
                string path = Directory.GetCurrentDirectory();
                List<string> pathxml = Directory.GetFiles(path).ToList<string>();
                if (pathxml.Exists(c => c.Contains("configSettings.xml")))
                {
                    IEnumerable<string> paths = pathxml.Where(c => c.Contains("configSettings.xml"));
                    path = paths.ToArray()[0];
                }

                configDoc.Load(path);


                values.Add(ReadNodeValue("X", configDoc));
              
                values.Add(ReadNodeValue("Y", configDoc));
           
                values.Add(ReadNodeValue("ChanceOfEnemy", configDoc)); // out of 10 positive direction, ChanceOfEnemy = 4. it's 4 out of 10 chance the position would have an enemy
        
                values.Add(ReadNodeValue("ChanceOfItem", configDoc)); // out of 10 negative direction
                                                                      // ex. the chance of hitting 8 negative direction would be 2: ChanceOfItem = 8
                if (values.Count != 4 && values[3] !>10 && values[3] !<0&&values[4] !>10 && values[4] !<0) {
                    ts.TraceEvent(TraceEventType.Critical, 6, "Config File Exception");
                    throw new ArgumentException("To few values in config file"); 
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                ts.TraceEvent(TraceEventType.Critical, 7, "Config File Exception: " + ex.Message);
            }
            ts.Flush();
            return values;
        }
        /// <summary>
        /// Read each node of the configuration file
        /// </summary>
        /// <param name="searchString">the name of the node</param>
        /// <param name="document">the XML document</param>
        /// <returns>an int of the read value</returns>
        private int ReadNodeValue(string searchString, XmlDocument document)
        {
            ts.Switch = new SourceSwitch("ReadNodeConfig", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            XmlNode configNode = document.DocumentElement.SelectSingleNode(searchString);
            if (configNode != null)
            {
                String valueString = configNode.InnerText.Trim();
                try
                {
                    return Convert.ToInt32(valueString);
                    
                }
                catch (Exception ex)
                {
                    ts.TraceEvent(TraceEventType.Critical, 7, "Config File reading node failure");
                }
            }
            return 1;
        }
        

        
    }
}
