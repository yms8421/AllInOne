using System;
using System.Collections.Generic;
using System.Text;

namespace Perque.Contracts
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
        public class ConnectionString
        {
            public string MainDatabase { get; set; }
        }
    }
}
