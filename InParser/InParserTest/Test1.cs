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
    public class Test1
    {
        [Test]
        public void Test()
        {
            try
            {
                InParser.Parser a = new InParser.Parser();
                StreamReader sr = new StreamReader("1.GIN");
                a.Parse(sr.BaseStream, Encoding.Default);
                Assert.Pass();
            }
            catch (InParserException e)
            {
                Assert.Fail(e.Message);
            }
           //ниже код первого решения - на успешном прохождении теста тоже фэйлится из-за того, что throws ждёт эксепшн, а ему возвращается null
           //гугл и nunit'овский хэлп не помог мне с этим
           //сохранил на случай, если не нужно делать так, как сделано выше
           // InParserException myEx = Assert.Throws<InParserException>(delegate { a.Parse(sr.BaseStream, Encoding.Default); });
           //   if (myEx != null) Assert.Fail(myEx.Message);
           //  else Assert.Pass();
        }
    }
}
