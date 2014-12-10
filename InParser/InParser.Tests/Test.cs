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
        public void TestNoError()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("1.GIN");
            Assert.DoesNotThrow(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
            Assert.AreEqual(a.Data.WellName, "26854");
            Assert.AreEqual(a.Data.OilArea, "905");
            Assert.IsTrue(a.Data.Attributes.Count == 7);
            Assert.AreEqual(a.Data.Attributes[4].Title, "#MAGCORR");
            Assert.AreEqual(a.Data.Attributes[2].Data, "20.0 1320.0");
            Assert.IsTrue(a.Data.Curves.Count == 10);
        }

        [Test]
        public void TestError1()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("2.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void TestError2()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("3.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void TestError3()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("4.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void TestError4()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("5.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

        [Test]
        public void TestError5()
        {
            InParser.Parser a = new InParser.Parser();
            StreamReader sr = new StreamReader("6.GIN");
            Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
        }

    }
}
