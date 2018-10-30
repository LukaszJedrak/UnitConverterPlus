using System;
using UnitConverterPlus;
using Xunit;

namespace UnitConverterTesting
{
    public class UnitConverterTesting
    {
        [Theory]
        [InlineData("1", "0,9144")]
        [InlineData("100", "91,44")]
        [InlineData("5", "4,572")]
        [InlineData("17.96", "16,422624")]
        public void YardsToMetersSingleValueCompare(string input, string expected)
        {
            var converter = new UnitConverter();
            Assert.Equal(expected, converter.Converter(input, "yards"));
        }

        [Theory]
        [InlineData("100;5;1", "91,44;4,572;0,9144")]
        [InlineData("1;2;3;4;5", "0,9144;1,8288;2,7432;3,6576;4,572")]
        public void YardsToMetersMultipleValueCompare(string input, string expected)
        {
            string unit = "yards";
            input = CompareValues(input, expected, unit);
        }

        [Theory]
        [InlineData("1", "2,54")]
        [InlineData("32", "81,28")]
        [InlineData("87", "220,98")]
        public void InchesToCentimitersSingleValueCompare(string input, string expected)
        {
            var converter = new UnitConverter();
            Assert.Equal(expected, converter.Converter(input, "inches"));
        }

        [Theory]
        [InlineData("1;2;3;4;5", "2,54;5,08;7,62;10,16;12,7")]
        [InlineData("89,2;1,75;1984", "226,568;4,445;5039,36")]
        public void InchesToCentimetersMultipleValueCompare(string input, string expected)
        {
            string unit = "inches";
            input = CompareValues(input, expected, unit);

        }

        [Theory]
        [InlineData("1", "1,60934")]
        [InlineData("2", "3,21868")]
        [InlineData("16", "25,74944")]
        public void MilesToKilometersSingleValueCompare(string input, string expected)
        {
            var converter = new UnitConverter();
            Assert.Equal(expected, converter.Converter(input, "miles"));
        }

        [Theory]
        [InlineData("100;5;1", "160,934;8,0467;1,60934")]
        [InlineData("1;2;3;4;5", "1,60934;3,21868;4,82802;6,43736;8,0467")]
        public void MilesToKilometersMultipleValueCompare(string input, string expected)
        {
            string unit = "miles";
            input = CompareValues(input, expected, unit);
        }

        private static string CompareValues(string input, string expected, string unit)
        {
            input = input.Replace(';', ' ');
            var expectedValue = expected.Replace(';', ' ');

            var converter = new UnitConverter();

            var inputConverter = converter.Converter(input, unit);
            inputConverter = inputConverter.Replace(Environment.NewLine, " ");

            Assert.Equal(inputConverter, expectedValue.ToString());
            return input;
        }
    }
}
