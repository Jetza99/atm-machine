using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    class Program
    {


        static void Main(string[] args)
        {

            Client client = new Client(1, 1);
            AtmConsole screen = new AtmConsole(client);
            screen.Controle();
           


        }
    }
}
