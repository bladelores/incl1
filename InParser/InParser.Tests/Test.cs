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
            Assert.AreEqual(a.Data.Attributes.Count,7);
            Assert.AreEqual(a.Data.Attributes[0].Title, "#NAME");
            Assert.AreEqual(a.Data.Attributes[0].Data, "INCL Данные инклинометpии");
            Assert.AreEqual(a.Data.Attributes[1].Title, "#TYPE");
            Assert.AreEqual(a.Data.Attributes[1].Data, "INCL");
            Assert.AreEqual(a.Data.Attributes[2].Title, "DEPTH");
            Assert.AreEqual(a.Data.Attributes[2].Data, "20.0 1320.0");
            Assert.AreEqual(a.Data.Attributes[3].Title, "#ALTITUDE");
            Assert.AreEqual(a.Data.Attributes[3].Data, "312.43");
            Assert.AreEqual(a.Data.Attributes[4].Title, "#MAGCORR");
            Assert.AreEqual(a.Data.Attributes[4].Data, "11.50");
            Assert.AreEqual(a.Data.Attributes[5].Title, "#SERVICE");
            Assert.AreEqual(a.Data.Attributes[5].Data, "AOTНГФ~УГРАзнакаевское");
            Assert.AreEqual(a.Data.Attributes[6].Title, "#TOOL");
            Assert.AreEqual(a.Data.Attributes[6].Data, " ");
            Assert.AreEqual(a.Data.Curves.Count,10);
            Assert.AreEqual(a.Data.Curves[0].Title, "DEPTH");
            Assert.AreEqual(a.Data.Curves[0].Hint, "Глубина");
            Assert.AreEqual(a.Data.Curves[1].Title, "WANGLE");
            Assert.AreEqual(a.Data.Curves[1].Hint, "Зенитный угол наклона ствола скважины  гpад");
            Assert.AreEqual(a.Data.Curves[2].Title, "WAZIM");
            Assert.AreEqual(a.Data.Curves[2].Hint, "Азимутальный угол ствола скважины  гpад");
            Assert.AreEqual(a.Data.Curves[3].Title, "WELONG");
            Assert.AreEqual(a.Data.Curves[3].Hint, "Удлинение  м");
            Assert.AreEqual(a.Data.Curves[4].Title, "WDEPTH");
            Assert.AreEqual(a.Data.Curves[4].Hint, "Абсолютная глубина(с обpатным знаком)  м");
            Assert.AreEqual(a.Data.Curves[5].Title, "WCOORX");
            Assert.AreEqual(a.Data.Curves[5].Hint, "Кооpдината X  м");
            Assert.AreEqual(a.Data.Curves[6].Title, "WCOORY");
            Assert.AreEqual(a.Data.Curves[6].Hint, "Кооpдината Y  м");
            Assert.AreEqual(a.Data.Curves[7].Title, "WOFFSET");
            Assert.AreEqual(a.Data.Curves[7].Hint, "Смещение  м");
            Assert.AreEqual(a.Data.Curves[8].Title, "WDIRA");
            Assert.AreEqual(a.Data.Curves[8].Hint, "Диpекционный угол смещения гpад");
            Assert.AreEqual(a.Data.Curves[9].Title, "WDIRP");
            Assert.AreEqual(a.Data.Curves[9].Hint, "Интенсивность искpивления ствола скважины гpад/10м");

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
