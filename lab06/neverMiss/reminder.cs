using System;
using System.Collections.Generic;
using System.Text;

namespace neverMiss
{
    public class reminder
    {
        public int id { get; set; }
        public string message { get; set; }
        public string datetime { get; set; }
        public int interval { get; set; }
        public int count { get; set; }
        public int keeping { get; set; }
        public int important { get; set; }
        public string path { get; set; }
        public int finish { get; set; }
    }
}

