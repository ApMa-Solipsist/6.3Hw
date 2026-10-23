using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._3
{
    internal class Program
    {
        static readonly string[] MonthNames =
        {
            "january", "February", "March", "April", "May", "June",
            "Jule", "August", "September", "October", "November", "December"
        };
        static Dictionary<string, double> AverageTemp(Dictionary<string, sbyte[]> temperature)
        {
            var result = new Dictionary<string, double>();

            foreach (var pair in temperature)
            {
                string month = pair.Key;
                sbyte[] days = pair.Value;

                int sum = 0;
                for (int j = 0; j < days.Length; j++)
                    sum += days[j];

                result[month] = (double)sum / days.Length;
            }

            return result;
        }

        static List<KeyValuePair<string, double>> SortByValue(Dictionary<string, double> dict)
        {
            var list = new List<KeyValuePair<string, double>>(dict);

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j].Value > list[j + 1].Value)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }

        static void Main(string[] args)
        {
            Random ran = new Random();

            var temperature = new Dictionary<string, sbyte[]>();

            foreach (string month in MonthNames)
            {
                sbyte[] days = new sbyte[30];
                for (int j = 0; j < days.Length; j++)
                    days[j] = (sbyte)ran.Next(-50, 66);

                temperature[month] = days;
            }

            Dictionary<string, double> avTemp = AverageTemp(temperature);

            double yearAvg = avTemp.Values.Average();
            Console.WriteLine($"Средняя температура за год: {yearAvg:F2} °C\n");

            var sorted = SortByValue(avTemp);

            Console.WriteLine("Средние температуры по возрастанию:");
            foreach (var pair in sorted)
                Console.WriteLine($"{pair.Key,-10}: {pair.Value,6:F1} °C");
        }
    }
}