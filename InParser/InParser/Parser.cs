using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;


namespace InParser
{
    public class Parser
    {
        private const string paramsNumAndSquare = @"(.+)\s+(\d+)\s+(.+)\s+(\d+)";
        private const string paramsOther = @"(#?[A-Z]\w+)\s+(.+)";
        private const string attrHint = @"(\w+)\s+-\s+(\w+.+)";
        private const string attrValue = @"-?\d+\.\d+";
        private enum State { start, param, attribute };
        public List<Param> Params;
        public List<Attribute> Attributes;
        public Parser() {
        }
        public void Parse(Stream Stream, System.Text.Encoding Encoding)
        {
            StreamReader sr = new StreamReader(Stream, System.Text.Encoding.GetEncoding(1251), false);
            State state = State.start;

            Regex rParamsNumAndSquare = new Regex(paramsNumAndSquare);
            Regex rParams = new Regex(paramsOther);
            Regex rAttrHint = new Regex(attrHint);
            Regex rAttrValue = new Regex(attrValue);

            string str;
            int hintIndex = 0;
            while ((str = sr.ReadLine()) != null)
            {
                switch (state) 
                {
                    case State.start:
                        Match mParamsNumAndSquare = rParamsNumAndSquare.Match(str);
                        if (mParamsNumAndSquare.Success)
                        {
                            Params = new List<Param>();
                            Params.Add(new Param(mParamsNumAndSquare.Groups[1].Value.Trim(), mParamsNumAndSquare.Groups[2].Value));
                            Params.Add(new Param(mParamsNumAndSquare.Groups[3].Value, mParamsNumAndSquare.Groups[4].Value));
                            state = State.param;    
                        }
                        break;

                    case State.param:
                        Match mParams = rParams.Match(str);
                        if (mParams.Success)
                        {
                            if (mParams.Groups[1].Value != "#DATA")
                                Params.Add(new Param(mParams.Groups[1].Value, mParams.Groups[2].Value));
                            else
                            {
                                List<string> listParams = new List<string>(mParams.Groups[2].Value.Split(' '));
                                listParams.RemoveAt(listParams.Count - 2);
                                listParams.RemoveAt(listParams.Count - 1);
                                Attributes = new List<Attribute>();
                                foreach (string param in listParams)
                                {
                                        Attributes.Add(new Attribute(param));
                                }
                                state = State.attribute;
                            }
                        }
                        break;

                    case State.attribute:
                        Match mAttrHint = rAttrHint.Match(str);
                        if (mAttrHint.Success)
                        {
                            try
                            {
                                Attributes[hintIndex].Hint = mAttrHint.Groups[2].Value;
                                Attributes[hintIndex].Values = new List<float>();
                                hintIndex++;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Ошибка добавления подсказки аттрибута! Возможно число заголовков аттрибутов не соответствует числу строк-подсказок в файле!");
                                return;
                            }
                        }
                        else
                        {
                            Match mAttrValue = rAttrValue.Match(str);
                            if (mAttrValue.Success)
                            {
                                try
                                {
                                    int current = 0;
                                    foreach (Match match in rAttrValue.Matches(str))
                                    {
                                        string x = match.Value;
                                        x = x.Replace('.', ',');
                                        float value = System.Single.Parse(x);
                                        Attributes[current].Values.Add(value);
                                        current++;
                                    }
                                    if (current != Attributes.Count)
                                    {
                                        Console.WriteLine("Ошибка добавления значения! Число столбцов значений в файле не соответствует числу аттрибутов!");
                                        return;            
                                    }
                                }
                                catch (ArgumentOutOfRangeException) {
                                    Console.WriteLine("Ошибка добавления значения! Возможно число аттрибутов не соответствует числу столбцов значений в файле!");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
            switch (state) {
                case State.start:
                    Console.WriteLine("Ошибка чтения! Невозможно прочитать параметры!");    
                    break;
                case State.param:
                    Console.WriteLine("Параметры прочитаны успешно!");
                    Console.WriteLine("Ошибка чтения! Возможно секция аттрибутов неправильно отформатирована!");
                    break;
                case State.attribute:
                    Console.WriteLine("Параметры прочитаны успешно!");
                    Console.WriteLine("Аттрибуты прочитаны успешно!");
                    break;
            }
        }
    }
}
