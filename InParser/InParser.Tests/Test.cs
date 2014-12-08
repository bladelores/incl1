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
    public class Test
    {
        [Test]
        public void Test1()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("1.GIN");
            Assert.DoesNotThrow(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
            if (a.Data.WellName == null ||
                    a.Data.OilArea == null ||
                    a.Data.Attributes.Count == 0 ||
                    a.Data.Curves.Count == 0)
                Assert.Fail();
            else
            {
                foreach (InParser.Attribute attr in a.Data.Attributes)
                    if (attr.Title == null || attr.Data == null) 
                        Assert.Fail();
                foreach (Curve curve in a.Data.Curves)
                    if (curve.Title == null || curve.Hint == null || curve.Values.Count == 0)
                        Assert.Fail();
            }

        }

        [Test]
        public void Test2()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("2.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void Test3()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("3.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void Test4()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("4.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void Test5()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("5.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void Test6()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("6.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

    }
}
