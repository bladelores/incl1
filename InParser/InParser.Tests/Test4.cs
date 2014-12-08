using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using InParser;
using NUnit.Framework;

namespace InParserTest
{
    public class Test4
    {
        [Test]
        public void Test()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("4.GIN");
            InParserException ex = Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
            if (ex == null) Assert.Fail();
        }
    }
}
