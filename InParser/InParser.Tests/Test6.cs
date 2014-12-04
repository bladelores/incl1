using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using InParser;
using NUnit.Framework;

namespace InParserTest
{
    public class Test6
    {
        [Test]
        public void Test()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("6.GIN");
            InParserException myEx = Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
            if (myEx != null) Assert.Fail(myEx.Message);
            else Assert.Pass();
        }
    }
}
