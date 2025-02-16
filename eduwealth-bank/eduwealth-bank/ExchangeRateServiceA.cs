using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduwealth_bank
{
    public static class ExchangeRateServiceA
    {
        public static async Task GetExchangeRateAsync(string currency)
        {
            Console.WriteLine("Getting the exchangeRate from Service A");
            throw new Exception();
            var watch = Stopwatch.StartNew();

            var randomNumberGenerator = new Random();
            var randomTimeToReturn = randomNumberGenerator.Next(1000,10000);
            await Task.Delay(randomTimeToReturn);

            var exchangeRate = randomNumberGenerator.Next(100, 200);
            watch.Stop();
            Console.WriteLine($"It took {watch.ElapsedMilliseconds}as to get the ExchangeRate");
            Console.WriteLine($"The exchange rate from USD to ${currency} is 1 USD to {exchangeRate:#,##} {currency}");
        }
    }
}
