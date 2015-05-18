using System;
using System.Collections.Generic;

namespace dp215
{
    class Program
    {
        static void Main(string[] args) {
            string power;
            string baseNumber;
            
            double currentNumber;
            
            bool cycleComplete = false;
            List<double> numbersList = new List<double>();


            Console.Write("Enter power: ");
            power = Console.ReadLine();
            Console.Write("Enter starting number: ");
            baseNumber = Console.ReadLine();
            currentNumber = Convert.ToDouble(baseNumber);
            // get starting number

            

            Console.WriteLine("Starting number: {0}", baseNumber);
            Console.WriteLine("=====================================");
            
            do {
                
                currentNumber = addUpNumber(currentNumber, power);
                
                if (!numbersList.Contains(currentNumber))
                    numbersList.Add(currentNumber);
                else {
                    cycleComplete = true;
                    numbersList.RemoveRange(0, numbersList.IndexOf(currentNumber));
                }
 
            } while ((!cycleComplete) && (currentNumber != 1));

            printCycle(numbersList, baseNumber, power);
            Console.ReadLine();
        }

        static char[] getCurrentNumber(double currentNumber) {
            return currentNumber.ToString().ToCharArray();
        }

        static double getDigitValue(char digit, string power) {
            return Math.Pow(Convert.ToDouble(digit.ToString()), Convert.ToDouble(power));
        }

        static double addUpNumber(double number, string power) {
            double currentNumber = 0;
            char[] charNumber = getCurrentNumber(number);
            foreach (char digit in charNumber) {
                currentNumber += getDigitValue(digit, power);
            }
            return currentNumber;
        }

        static void printCycle(List<double> sadCycle, string baseNumber, string power) {
            Console.WriteLine("Sad cycle:");
            Console.WriteLine("Power: {0}", power);
            Console.WriteLine("Basenumber: {0}", baseNumber);
            Console.WriteLine("Numbers in cycle: {0}", sadCycle.Count);
            Console.WriteLine("=====================================");
            foreach (double num in sadCycle) {
                Console.Write(num + " ");
            }   
        }

        static double sumNumber(double number, double power) {
            ulong sum = 0;
            ulong num = (ulong)number;
            do {
                ulong n = num % 10;
                num /= 10;
                sum += (ulong)Math.Pow(n, power);

            } while (num != 0);

            return (double)sum;
        }
    }
}
