using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace eduwealth_bank
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            var aggregateTask = Task.WhenAll(ExchangeRateServiceA.GetExchangeRateAsync("JPY"),
                ExchangeRateServiceB.GetExchangeRateAsync("JPY")
             );

            Console.WriteLine("Press enter to exit.... ");
            Console.ReadLine();


        }
    }
}
