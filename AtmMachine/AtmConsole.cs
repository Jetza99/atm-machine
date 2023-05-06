using System;
using System.Collections.Generic;

namespace AtmMachine
{

    class AtmConsole 
    {
        Client client;

       

        //public double cardNumber { get; set; }
        //public int pin { get; set; }

        private string _cardNumberString;
        private string _pinString;
        private string moneyToWithrawString;
        private float enteredFunds;




        public AtmConsole(Client client)
        {
            this.client = client;
        }

        public void Controle()
        {

            EnterScreen();
            if (VerifyPin())
            {
                Menu(false);

            }

        }

        private void Menu(bool getBack)
        {
             

            while (getBack)
            {
                Console.WriteLine(@"To get back to the previous screen. Type b.
                    To Exit. Type 0.");
                string getBackKey = Console.ReadLine();

                if(getBackKey.ToLower() == "b" )
                {
                    getBack = false;
                    Menu(getBack);
                }else if(getBackKey == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter the correct key.");
                    getBackKey = Console.ReadLine();
                    Menu(true);
                }
            }

            Console.Clear();


            Console.WriteLine(@"Welcome to your account, Omar!

            Please select an option to move forward:
            1. Widhdraw funds
            2. Consult balance
            3. Check history

            0. Exit");


            int option = int.Parse(Console.ReadLine());


            do
            {

                switch (option)
                {
                    case 1:
                        WidhrawlMenu();
                        Menu(true);
                        
                        break;
                    case 2:
                        ConsultBalance();
                        
                        break;
                    case 3:
                        client.History();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a correct option (1 OR 2 OR 3 OR 0");
                        break;

                }

            } while (option < 0 || option > 3);
        }

        private void ConsultBalance()
        {
            Console.Clear();
            Console.WriteLine("Your current balance: $" + client.Balance);
        }

        public void WidhrawlMenu()
        {
            Console.Clear();

            Console.WriteLine("Enter the funds to withdraw. No more than $1000.");

            do
            {
              moneyToWithrawString = Console.ReadLine();
                
            } while (!float.TryParse(moneyToWithrawString, out enteredFunds));

            client.Widhdrawl(enteredFunds);

        }

        public bool VerifyPin()
        {
            int attempts = 0;

            do
            {
                if (attempts == 3)
                {
                    Console.WriteLine("Your last attempt or your session will be shut down");
                }
                else if (attempts > 3)
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("Enter your private pin");
                _pinString = Console.ReadLine();
                attempts++;



            } while (int.Parse(_pinString) != client.Pin);

            return true;
        }

        public void EnterScreen()
        {
            long number;
            do
            {
                Console.WriteLine("Hello, please enter your 16-digit card number.");
                _cardNumberString = Console.ReadLine();


            } while (long.Parse(_cardNumberString) != client.CardNumber);
        }
    }
}
