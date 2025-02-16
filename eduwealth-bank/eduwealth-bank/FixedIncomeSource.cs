using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduwealth_bank
{
    public static class FixedIncomeSource
    {
        public static async Task<FixedIncome> GetFixedIncomeMontlyRate(string investmentName)
        {
            await Task.Delay(5000);
            var randomNumberGenerator = new Random();
            var montlyRate = randomNumberGenerator.NextDouble() * 5;
            return new FixedIncome(investmentName, montlyRate);
        }
    }

    public class FixedIncome
    {
        public double MonthlyRate;
        public string Name;

        public FixedIncome(string name, double monthlyRate)
        {
            Name = name;
            MonthlyRate = monthlyRate;
        }

    }
}
