using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachineProblem
{

    public class Currency
    {
        private int hundreds = 10;
        private int fifties = 10;
        private int twenties = 10;
        private int tens = 10;
        private int fives = 10;
        private int ones = 10;

        public void restock()
        {
            hundreds = 10;
            fifties = 10;
            twenties = 10;
            tens = 10;
            fives = 10;
            ones = 10;

            currentBalanceList();
        }

        public int currentBalanceSum()
        {
            int balance = (100 * hundreds) + (50 * fifties) + (20 * twenties) + (10 * tens) + (5 * fives) + (1 * ones);
            return balance;
        }

        public void currentBalanceList()
        {
            Console.WriteLine("Machine Balance:");
            Console.WriteLine("$100 - " + hundreds);
            Console.WriteLine("$50 - " + fifties);
            Console.WriteLine("$20 - " + twenties);
            Console.WriteLine("$10 - " + tens);
            Console.WriteLine("$5 - " + fives);
            Console.WriteLine("$1 - " + ones);
        }

        public void getDenominations(String[] denoms)
        {
            for (int i = 0; i < denoms.Length; i++)
            {
                switch (denoms[i])
                {
                    case "100":
                        Console.WriteLine("$100 - " + hundreds);
                        break;
                    case "50":
                        Console.WriteLine("$50 - " + fifties);
                        break;
                    case "20":
                        Console.WriteLine("$20 - " + twenties);
                        break;
                    case "10":
                        Console.WriteLine("$10 - " + tens);
                        break;
                    case "5":
                        Console.WriteLine("$5 - " + fives);
                        break;
                    case "1":
                        Console.WriteLine("$1 - " + ones);
                        break;
                }
            }
        }

        public void withdrawal(String cashAmount)
        {
            int amount = Convert.ToInt16(cashAmount);

            int prevHundreds = hundreds;
            int prevFifties = fifties;
            int prevTwenties = twenties;
            int prevTens = tens;
            int prevFives = fives;
            int prevOnes = ones;

            if (amount <= currentBalanceSum())
            {
                while (amount >= 100 && hundreds > 0)
                {
                    amount -= 100;
                    hundreds--;
                }

                while (amount >= 50 && fifties > 0)
                {
                    amount -= 50;
                    fifties--;
                }

                while (amount >= 20 && twenties > 0)
                {
                    amount -= 20;
                    twenties--;
                }

                while (amount >= 10 && tens > 0)
                {
                    amount -= 10;
                    tens--;
                }

                while (amount >= 5 && fives > 0)
                {
                    amount -= 5;
                    fives--;
                }

                while (amount >= 1 && ones > 0)
                {
                    amount -= 1;
                    ones--;
                }

                if (amount == 0)
                {
                    Console.WriteLine("Success: Dispensed $" + cashAmount);
                    currentBalanceList();
                }
                else
                {
                    Console.WriteLine("Failure: insufficient funds");
                    hundreds = prevHundreds;
                    fifties = prevFifties;
                    twenties = prevTwenties;
                    tens = prevTens;
                    fives = prevFives;
                    ones = prevOnes;
                }
            }
            else
            {
                Console.WriteLine("Failure: insufficient funds");
            }
        }
    }

}
