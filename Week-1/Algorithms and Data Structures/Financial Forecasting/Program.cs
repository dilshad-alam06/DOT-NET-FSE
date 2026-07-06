using System;
using System.Collections.Generic;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double principal = 10000;
            double growthRate = 0.10;
            int years = 5;

            Console.WriteLine($"Initial Amount: {principal}");
            Console.WriteLine($"Growth Rate: {growthRate:P0}");
            Console.WriteLine($"Years: {years}");

            double forecast = FinancialForecast.RecursiveForecast(principal, growthRate, years);
            Console.WriteLine($"Forecasted Value: {forecast:F2}");
        }
    }
}
