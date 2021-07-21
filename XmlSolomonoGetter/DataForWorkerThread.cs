using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace XmlSolomonoGetter
{
    class DataForWorkerThread
    {
        private Object objectForLock = new Object();
        private bool isNowPause = false;

        public String CsvFilePath { get; set; }
        public String SqlConnectionString { get; set; }
        public String[] UrlStrings { get; set; }

        public bool IsNowPause
        {
            get
            {
                lock (objectForLock)
                {
                    return isNowPause;
                }
            }
            set
            {
                lock (objectForLock)
                {
                    isNowPause = value;
                }
            }
        }
    }
}
