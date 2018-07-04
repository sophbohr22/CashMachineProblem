using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachineProblem
{
    class CashMachine
    {
        static void Main(string[] args)
        {
            String choice = "";
            Currency cash = new Currency();

            Console.WriteLine("Welcome to the SafeNet cash machine!");
            Console.WriteLine("Menu options:");
            Console.WriteLine("R - Restocks the cash machine");
            Console.WriteLine("W $<amount> - Withdraws that amount");
            Console.WriteLine("I <denominations> - Displays number of bills");
            Console.WriteLine("Q - Quit");

            while (!choice.Equals("Q") && !choice.Equals("q"))
            {
                choice = Console.ReadLine();
                menuOptions(choice, cash);
            }

        }

        public static void menuOptions(String choice, Currency cash)
        {
            Console.WriteLine("");

            if (choice.Equals("r") || choice.Equals("R"))
            {
                cash.restock();
            }

            else if (choice.Contains("w $") || choice.Contains("W $"))
            {
                String cashAmount = choice.Substring(3);
                cash.withdrawal(cashAmount);
            }

            else if (choice.Contains("i") || choice.Contains("I"))
            {
                choice = choice.Substring(1); //gets rid of the I
                choice = choice.Trim();
                String[] denoms = choice.Split(' ');

                for (int i = 0; i < denoms.Length; i++)
                {
                    denoms[i] = denoms[i].Substring(1);
                }

                cash.getDenominations(denoms);
            }

            else if (choice.Equals("q") || choice.Equals("Q"))
            {
                return;
            }

            else
            {
                Console.WriteLine("Failure: Invalid Command");
            }
        }
    }
}
