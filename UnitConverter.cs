using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConverterPlus
{
    public class UnitConverter
    {
        List<string> resultAfterConvert = new List<string>();
        List<string> multiValuesWithDot = new List<string>();
        public bool exception = false;

        public string Converter(string convert, string type)
        {
            if (convert == null)
            {
                string exception = "Please enter some values.";
                return exception;
            }

            else
            {
                if (convert.Contains(" "))
                {
                    List<string> listOfValues = MultipleValuesWithDot(convert);
                    MultipleValuesCalculator(type, listOfValues);

                    if (exception == true)
                    {
                        string exception = "Please enter a real value!";
                        return exception;
                    }

                    else
                    {
                        var stringResult = string.Join(Environment.NewLine, resultAfterConvert.ToList());
                        return stringResult;
                    }
                    
                }

                else
                {
                    convert = SingleValueWithDot(convert);
                    return SingleValuesCalculator(convert, type);
                }    

            }

        }

        private string SingleValuesCalculator(string convert, string type)
        {
            try
            {
                if (type == "yards")
                {
                    return Math.Round(double.Parse(convert) * 0.9144, 10).ToString();
                }

                else if (type == "meters")
                {
                    return Math.Round(double.Parse(convert) * 1.0936132983, 10).ToString();
                }

                else if (type == "inches")
                {
                    return Math.Round(double.Parse(convert) * 2.54, 10).ToString();
                }

                else if (type == "centimeters")
                {
                    return Math.Round(double.Parse(convert) / 2.54, 10).ToString();
                }

                else if (type == "miles")
                {
                    return Math.Round(double.Parse(convert) * 1.60934, 10).ToString();
                }

                else
                {
                    return Math.Round(double.Parse(convert) / 1.60934, 10).ToString();
                }
            }
            catch (FormatException ex)
            {
                string exception = "Please enter a real value!";
                return exception;
            }
        }

        private string MultipleValuesCalculator(string type, List<string> listOfValues)
        {
            for (int i = 0; i < listOfValues.Count; i++)
            {
                if (resultAfterConvert.Count > listOfValues.Count) break;

                try
                {
                    if (type == "yards")
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) * 0.9144, 10);
                        resultAfterConvert.Add(result.ToString());
                    }

                    else if (type == "meters")
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) * 1.0936132983, 10);
                        resultAfterConvert.Add(result.ToString());
                    }

                    else if (type == "inches")
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) * 2.54, 10);
                        resultAfterConvert.Add(result.ToString());
                    }

                    else if (type == "centimeters")
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) / 2.54, 10);
                        resultAfterConvert.Add(result.ToString());
                    }

                    else if (type == "miles")
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) * 1.60934, 10);
                        resultAfterConvert.Add(result.ToString());
                    }

                    else
                    {
                        var result = Math.Round(double.Parse(listOfValues[i]) / 1.60934, 10);
                        resultAfterConvert.Add(result.ToString());
                    }
                }
                catch (FormatException ex)
                {
                    exception = true;
                }

            }

            return resultAfterConvert.ToString();
        }

        private List<string> MultipleValuesWithDot(string convert)
        {
            var listOfValues = new List<string>();

            for (int i = 0; i < convert.Split(" ").Count(); i++)
            {
                listOfValues.Add(convert.Split(" ")[i]);
            }

            for (int i = 0; i < listOfValues.Count; i++)
            {
                if (listOfValues[i].Contains(".") || listOfValues[i].Contains(","))
                {
                    var result = listOfValues[i].Replace('.', ',');
                    multiValuesWithDot.Add(result);
                    continue;
                }

                else
                {
                    multiValuesWithDot.Add(listOfValues[i]);
                    continue;
                }

            }

            return multiValuesWithDot;
        }

        private string SingleValueWithDot(string convert)
        {
            if (convert.Contains("."))
            {
                var replace = convert.Replace('.', ',');
                return replace;
            }

            else
            {
                return convert;
            }

        }

    }
}
