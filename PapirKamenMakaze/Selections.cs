using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapirKamenMakaze
{
    public class Node
    {
        public Selections.Outcomes data;
        public Node next;

        public Node()
        {
        }

        public Node(Selections.Outcomes d, Node node)
        {
            data = d;
            next = node;
        }

    }

    public class Selections
    {
        public enum Outcomes
        {
            papir,
            kamen,
            makaze
        };

        public static string GetPlayerChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Izaberite Papir, Kamen ili Makaze: ");
            string izbor_ = Console.ReadLine();
            string izbor = izbor_.ToLower();
            return izbor;
        }

        public static void DecideWinner(string name, Outcomes human, Outcomes cpu)
        {
            Node stone = new Node();
            Node paper = new Node(Outcomes.papir, stone);
            Node scissors = new Node(Outcomes.makaze, paper);
            stone.data = Outcomes.kamen; stone.next = scissors;
            Node current = paper;
            for (int i = 0; i<3; i++)
            {
                if (current.data == cpu) { break; }
                else { current = current.next; }
            }

            if (human == current.data) { Console.WriteLine("Nereseno"); }
            if (human == current.next.data)
            {
                var i = DBkomunikacija.NumberofVictories(name);
                int k = i + 1;
                Console.WriteLine("Cestitamo, pobedili ste! Vas broj pobeda sada iznosi: " + k);
                DBkomunikacija.InsertDataIntoDB(name, k);
            }
            if (human == current.next.next.data) { Console.WriteLine("Izgubili ste, pojma nemate!"); }

        }

    }


}
