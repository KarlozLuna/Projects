using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eduwealth_bank
{
    internal class AccountHolder
    {
        public string Name { get; set; }

        public float Balance { get; set; }

        public AccountHolder(string Name, float balance) 
        {
            this.Name = Name;
            Balance = balance;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"{Name} has {Balance} Dollars");  
        }

        public async Task<float> GetBalance()
        {
            await Task.Delay(5000);
            return Balance;
        }
    }
}
