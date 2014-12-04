using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InParser
{
    public class Inclinometry
    {
        public string VelName { get; set; }
        public string OilArea { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Curve> Curves { get; set; }
    }
}
