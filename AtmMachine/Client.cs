using System;
using System.Collections.Generic;

namespace AtmMachine
{
    class Client
    {

        public long CardNumber { get; private set; }
        public int Pin { get; private set; }
        public float Balance { get; private set; }

        public List<Transaction> Transactions = new List<Transaction>();


       

        public Client(long cardNumber, int pin)
        {
            this.CardNumber = cardNumber;
            this.Pin = pin;
            Balance = 58.250F;

        }

        public void Widhdrawl(float moneyToWidhraw)
        {
            if(moneyToWidhraw <= Balance && moneyToWidhraw <= 1000f)
            {
                System.Console.WriteLine("Here's your money. Don't forget your card!");
                Balance -= moneyToWidhraw;
                Transaction transaction = new Transaction(moneyToWidhraw, DateTime.Now);
                Transactions.Add(transaction);
                
            }else if(moneyToWidhraw > Balance)
            {
                System.Console.WriteLine("No suffcient funds in your account.");
            }
            else if (moneyToWidhraw > 1000f)
            {
                System.Console.WriteLine("Limit is $1000");
            }
            
        }

        public void History()
        {
            Console.Clear();
            if (Transactions.Count == 0)
            {
                Console.WriteLine("You made no transactions.");
            }else
            {
                foreach (var transaction in Transactions)
                {
                    Console.WriteLine("Funds withdrew: ${0} | Date: {1} ", transaction.MoneyWithdrew, transaction.Date);
                }

                
            }

        }

    }
}
