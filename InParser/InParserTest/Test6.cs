using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using InParser;
using NUnit.Framework;

namespace InParserTest
{
    [TestFixture]
    public class Test6
    {
        [Test]
        public void Test()
        {
            try
            {
                InParser.Parser a = new InParser.Parser();
                StreamReader sr = new StreamReader("6.GIN");
                a.Parse(sr.BaseStream, Encoding.Default);
                Assert.Pass();
            }
            catch (InParserException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
