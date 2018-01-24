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
            paper,
            rock,
            scissors
        };

        public static string GetPlayerChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Choose Rock, Paper or Scissors: ");
            string izbor_ = Console.ReadLine();
            string izbor = izbor_.ToLower();
            return izbor;
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("empty string!!!!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static void DecideWinner(string name, Outcomes human, Outcomes cpu)
        {
            Node stone = new Node();
            Node paper = new Node(Outcomes.paper, stone);
            Node scissors = new Node(Outcomes.scissors, paper);
            stone.data = Outcomes.rock; stone.next = scissors;
            Node current = paper;
            for (int i = 0; i<3; i++)
            {
                if (current.data == cpu) { break; }
                else { current = current.next; }
            }

            if (human == current.data) { Console.WriteLine("It's a tie!"); }
            if (human == current.next.data)
            {
                var i = DBkomunikacija.NumberofVictories(name);
                int k = i + 1;
                Console.WriteLine($"Congratulations, You won! Your opponent chose {FirstCharToUpper(cpu.ToString())}. Your number of wins is: " + k);
                DBkomunikacija.InsertDataIntoDB(name, k);
            }
            if (human == current.next.next.data) { Console.WriteLine($"Too bad, the opponent chose {FirstCharToUpper(cpu.ToString())}. You lost..."); }

        }

    }


}
