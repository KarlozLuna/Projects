using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduwealth_bank
{
    internal class CreditCompany
    {
        public async Task<int> GetCreditScore(AccountHolder accountHolder)
        {
            Console.WriteLine($"Checking credit score for {accountHolder.Name}");
            await Task.Delay(5000);
            var randomNumberGenerator = new Random();
            return randomNumberGenerator.Next(300, 850);
        }
    }
}
