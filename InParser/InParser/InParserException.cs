using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InParser
{
    public class InParserException : System.Exception
    {
        public InParserException(string message)
            : base(message)
        {
        }
    }

}
