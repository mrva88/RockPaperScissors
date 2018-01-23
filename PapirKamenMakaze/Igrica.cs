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
            Console.WriteLine("Dobrodosli!!!");
            Console.Write("Unesite vase ime: ");

            var name = Console.ReadLine();
            string izbor;
            Console.WriteLine(DBkomunikacija.Welcome(name));
            Console.WriteLine();



                //Loops until valid choice is entered
                do { izbor = Selections.GetPlayerChoice(); }
                while (!(izbor == Selections.Outcomes.papir.ToString() || izbor == Selections.Outcomes.kamen.ToString() || izbor == Selections.Outcomes.makaze.ToString()));
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

