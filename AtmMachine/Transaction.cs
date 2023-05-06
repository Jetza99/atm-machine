using System;

namespace AtmMachine
{
    class Transaction
    {
        public float MoneyWithdrew { get; private set; }
        public DateTime Date { get; private set; }

        public Transaction(float moneyWithdrew, DateTime date)
        {
            this.MoneyWithdrew = moneyWithdrew;
            this.Date = date;
        }

       

    }
}
