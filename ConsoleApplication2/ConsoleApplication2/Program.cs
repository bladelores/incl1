using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using InParser;
//using NUnit.Framework;

namespace ConsoleApplication2
{
    //[TestFixture]
    class Program
    {
        //[Test]
        static void Main(string[] args)
        {
            //Assert.IsTrue
            Parser a = new Parser();
            StreamReader sr = new StreamReader("1.GIN");
            a.Parse(sr.BaseStream, Encoding.Default); //корректный файл
            Console.WriteLine();

            sr = new StreamReader("2.GIN");
            a.Parse(sr.BaseStream, Encoding.Default); //убран один аттрибут и его подсказка
            Console.WriteLine();                      //соответственно ошибка "значений больше, чем аттрибутов"

            sr = new StreamReader("3.GIN");
            a.Parse(sr.BaseStream, Encoding.Default); //тут просто набор букв
            Console.WriteLine();                      //ошибка "невозможно прочитать параметры"

            sr = new StreamReader("4.GIN");
            a.Parse(sr.BaseStream, Encoding.Default); //два заголовка аттрибута "слиты" в один, т.е. заголовков аттрибутов на 1 меньше
            Console.WriteLine();                      //ошибка "число заголовков не равно числу подсказок"

            sr = new StreamReader("5.GIN");
            a.Parse(sr.BaseStream, Encoding.Default); //строка "#DATA ..." изменилась на "#DAT ...", следовательно секция с аттрибутами не читается
            Console.WriteLine();                      //ошибка "невозможно прочитать аттрибуты"

            sr = new StreamReader("6.GIN");           //одно из значений аттрибутов введено в неправильном формате, т.е. значений аттрибутам присвоится меньше, чем нужно
            a.Parse(sr.BaseStream, Encoding.Default); //ошибка добавления значения
            Console.WriteLine();

            Console.ReadKey(true);
        }
    }
}
