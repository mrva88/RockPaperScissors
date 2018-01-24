using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapirKamenMakaze
{
    class Igrica
    {


        static void Main(string[] args)
        {
            //Data input and welcome information
            Console.WriteLine("Welcome!!!");
            Console.Write("Enter Your name please: ");

            var name = Console.ReadLine();
            string izbor = "11";
            string quit = "quit";
            Console.WriteLine(DBkomunikacija.Welcome(name));
            Console.WriteLine();

            while (!(izbor.Equals(quit)))
            {

            

            //Loops until valid choice is entered
            do { izbor = Selections.GetPlayerChoice(); }
            while (!(izbor == Selections.Outcomes.paper.ToString() || izbor == Selections.Outcomes.rock.ToString() || izbor == Selections.Outcomes.scissors.ToString()));
            //Coverts Humans and CPU's choice to Enum
            Selections.Outcomes Human;
            Enum.TryParse(izbor, out Human);
            Selections.Outcomes CPU;
            Enum.TryParse(ComputerPKM.GetSelection(), out CPU);
            //Decites winner
            Selections.DecideWinner(name, Human, CPU);
            }
         }
    }

}


