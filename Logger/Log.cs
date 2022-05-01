using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{ 
    
        public sealed class Log : ILog
        {

            private static readonly object obj = new object();

            // Private property initialized with null in which it ensures that only one instance of the object is created, based on null condition
            private static Log instance = null;

            // public property is used to return only one instance of the class, leveraging on the private property
            public static Log GetInstance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (obj)// lock would limit the access of the instance until it would finish the creation of instance, even if multithread. or basically after checking it would only make one instacne if there is already one
                        {
                            if (instance == null)
                                instance = new Log();

                        }
                    }
                    return instance;
                }
            }

            // private constructure ensures that object is not instantiated other than within the class itself
            private Log()
            {

            }

            public void LogExceptions(string messages)
            {
                string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.Year); // Filename Format, Flat type 
                string logFilePath = string.Format(@"{0}_\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("----------------------");
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine(messages);
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                  {
                     writer.Write(sb.ToString());
                     writer.Flush();

                  }

            }
        }
    
}
