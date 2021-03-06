﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;


namespace InParser
{
    public class Parser
    {
        private const string attrNumAndSquare = @"\s+Скважина\s+(\d+)\s+Площадь\s+(\d+)";
        private const string attr = @"(#?[A-Z]\w+)\s+";
        private const string attrWithValue = @"(#?[A-Z]\w+)\s+(.+)";
        private const string curveHint = @"(\w+)\s+-\s+(\w+.+)";
        private const string curveValue = @"-?\d+\.\d+";


        private enum State { Start, Attribute, CurveTitles, CurveHint, CurveValues };
        public Inclinometry Data { set; get; }
        
        public Parser() {
        }

        public void Parse(Stream Stream, System.Text.Encoding Encoding)
        {
            StreamReader sr = new StreamReader(Stream, Encoding, false);
            State state = State.Start;

            Regex rAttrNumAndSquare = new Regex(attrNumAndSquare);
            Regex rAttr = new Regex(attr);
            Regex rAttrWithValue = new Regex(attrWithValue);
            Regex rCurveHint = new Regex(curveHint);
            Regex rCurveValue = new Regex(curveValue);

            string str;
            int hintIndex = 0;
            while ((str = sr.ReadLine()) != null)
            {
                switch (state) 
                {
                    case State.Start:
                        Match mAttrNumAndSquare = rAttrNumAndSquare.Match(str);
                        if (mAttrNumAndSquare.Success)
                        {
                                Data = new Inclinometry();
                                Data.WellName = mAttrNumAndSquare.Groups[1].Value;
                                Data.OilArea = mAttrNumAndSquare.Groups[2].Value;
                                Data.Attributes = new List<Attribute>();
                                state = State.Attribute;                          
                        }
                        else throw new InParserException(@"Ошибка чтения, неправильный формат файла");    
                        break;

                    case State.Attribute:
                        Match mAttributes = rAttr.Match(str);
                        if (mAttributes.Success)
                        {
                            if (mAttributes.Groups[1].Value != "#DATA")
                            {
                                Match mAttributeWithValue = rAttrWithValue.Match(str);
                                if (mAttributeWithValue.Success)
                                {
                                    
                                    Data.Attributes.Add(new Attribute(mAttributeWithValue.Groups[1].Value, mAttributeWithValue.Groups[2].Value));    
                                }
                                else Data.Attributes.Add(new Attribute(mAttributes.Groups[1].Value, string.Empty));                                
                            }
                            else
                            {
                                state = State.CurveTitles;
                                goto case State.CurveTitles;
                            }                            
                        }                       
                    break;    

                    case State.CurveTitles:
                        Match mCurveTitles = rAttrWithValue.Match(str);
                        List<string> listCurves = new List<string>(mCurveTitles.Groups[2].Value.Split(' '));
                        listCurves.RemoveAt(listCurves.Count - 2);
                        listCurves.RemoveAt(listCurves.Count - 1);
                        Data.Curves = new List<Curve>();
                        foreach (string curve in listCurves)
                        {
                            Data.Curves.Add(new Curve(curve));
                        }
                        state = State.CurveHint;
                        break;

                    case State.CurveHint:
                        Match mCurveHint = rCurveHint.Match(str);
                        if (mCurveHint.Success)
                        {
                            try
                            {
                                Data.Curves[hintIndex].Hint = mCurveHint.Groups[2].Value;
                                Data.Curves[hintIndex].Values = new List<float>();
                                hintIndex++;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                throw new InParserException(@"Ошибка добавления подсказки кривой, возможно число заголовков кривых не соответствует числу строк-подсказок в файле");
                            }
                        }
                        if (hintIndex == Data.Curves.Count)
                            state = State.CurveValues;
                        break;

                    case State.CurveValues:
                        Match mCurveValue = rCurveValue.Match(str);
                        if (mCurveValue.Success)
                        {
                            try
                            {
                                int current = 0;
                                foreach (Match match in rCurveValue.Matches(str))
                                {
                                    string x = match.Value;
                                    x = x.Replace('.', ',');
                                    float value = System.Single.Parse(x);
                                    Data.Curves[current].Values.Add(value);
                                    current++;
                                }
                                if (current != Data.Curves.Count)
                                {
                                    throw new InParserException(@"Ошибка добавления значения, число столбцов значений в файле не соответствует числу кривых");         
                                }
                            }
                            catch (ArgumentOutOfRangeException) 
                            {
                                throw new InParserException(@"Ошибка добавления значения, возможно число кривых не соответствует числу столбцов значений в файле"); 
                            }
                        }
                        break;

                }
            }
            if (state == State.Attribute)
                    throw new InParserException(@"Ошибка чтения, возможно секция аттрибутов неправильно отформатирована"); 
        }
    }
}
