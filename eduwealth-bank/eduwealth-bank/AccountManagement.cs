using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace eduwealth_bank
{
    internal class AccountManagement
    {
        public async Task AddFunds(AccountHolder accountHolder, float amount) 
        {
            Console.WriteLine($"Adding funds to the account...");
            await Task.Delay(2000);
            accountHolder.Balance += amount;
        }

        public async Task MakeTransfer(AccountHolder sender, AccountHolder receiver, float amount)
        {
            Console.WriteLine($"Initializing a transaction of {amount} from {sender.Name} to {receiver.Name}");
            var senderFunds = sender.GetBalance();
            var receiverFunds = receiver.GetBalance();

            await Task.WhenAll(senderFunds, receiverFunds);

            if (senderFunds.Result < amount)
            {
                throw new Exception("The transaction is imposible, the sender does not have the required amount ");
            }

            sender.Balance = senderFunds.Result - amount;
            receiver.Balance = receiverFunds.Result + amount;  
        }
        public void TakeLoan(AccountHolder accountHolder, float amount)
        {
            var isLoanApproved = IsCreditEnoughToTakeTheLoan(accountHolder, amount);
            Console.WriteLine($"John had his loan request approved? {(isLoanApproved ? "yes" : "no")}");
            if (isLoanApproved)
            { 
                accountHolder.Balance += amount;
            }
        }

        public static bool IsCreditEnoughToTakeTheLoan(AccountHolder accountHolder, float amount)
        { 
            if(amount <= 0)
            {
                throw new Exception("The amount informed is not valid");
            }

            var equimail = new CreditCompany();
            var creditSecure = new CreditCompany();
            var equimailCredit = equimail.GetCreditScore(accountHolder);
            var creditSecureCredit = creditSecure.GetCreditScore(accountHolder);

            Task.WaitAll(equimailCredit, creditSecureCredit);

            var averageCredit = (equimailCredit.Result + creditSecureCredit.Result) / 2;
            Console.WriteLine($"The average credit score for {accountHolder.Name} is {averageCredit}");

            if (amount < 1000)
            {
                return averageCredit > 300;
            }
            else if (amount >= 1000 && amount < 5000)
            {
                return averageCredit > 450;
            }
            else if (amount >= 5000 && amount <= 10000)
            {
                return averageCredit > 600;
            }
            else if (amount > 10000)
            {
                return averageCredit > 800;
            }
            else
            {
                return false;
            }

        }

        public async Task GetTheBestFixedIncomeOption(AccountHolder accountHolder)
        {
            Console.WriteLine("Checking for options...");
            var fixedIncomeOptions = await Task.WhenAll(
                FixedIncomeSource.GetFixedIncomeMontlyRate("Invest Core"),
                FixedIncomeSource.GetFixedIncomeMontlyRate("Global Fill"),
                FixedIncomeSource.GetFixedIncomeMontlyRate("World bond")
            );
            
            var bestInvestment = fixedIncomeOptions
                .OrderByDescending(fixedIncomeOption => fixedIncomeOption.MonthlyRate)
                .First();
            Console.WriteLine($"The best fixed income option for {accountHolder.Name} is {bestInvestment.Name} with a monthly rate of {bestInvestment.MonthlyRate:#.##}%");
        }
    }


}
