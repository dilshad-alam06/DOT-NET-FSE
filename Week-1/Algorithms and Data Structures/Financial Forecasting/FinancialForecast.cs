using System;

namespace FinancialForecasting
{
    public class FinancialForecast
    {
        // Recursive calculation of future value
        public static double RecursiveForecast(double principal, double growthRate, int years)
        {
            if (years <= 0)
                return principal;
            return RecursiveForecast(principal * (1 + growthRate), growthRate, years - 1);
        }
    }
}
