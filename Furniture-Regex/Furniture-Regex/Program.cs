using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>\w+)<<(?<price>\d+(.\d+)?)!(?<quant>\d+)";
            string furniturePriceAndQuant;
            List<string> furnitureList = new List<string>();
            double sumPrice = 0;
            while ((furniturePriceAndQuant = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(furniturePriceAndQuant, pattern);
                if (match.Success)
                {
                    string furniture = match.Groups["name"].Value;
                    furnitureList.Add(furniture);
                    double price = double.Parse(match.Groups["price"].Value);
                    double quant = double.Parse(match.Groups["quant"].Value);
                    sumPrice += price * quant;
                }
            }
            Console.WriteLine("Bought furniture:");
            if (furnitureList.Count > 0)
            {
                Console.WriteLine(String.Join("\n", furnitureList));
            }
            Console.WriteLine($"Total money spend: {sumPrice:F2}");
        }
    }
}
