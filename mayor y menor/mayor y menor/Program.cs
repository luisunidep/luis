using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mayor_y_menor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            Console.WriteLine("Dame el primer numero");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el segundo numero");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el tercer numero");
            num3 = Convert.ToInt32(Console.ReadLine());
            NumeroMayor(num1, num2, num3);
            NumeroMenor(num1, num2, num3);

            Console.ReadLine();
        }
        private static void NumeroMayor(int num1, int num2, int num3)
        {
            if (num1 > num2)
            {
                if (num1 > num3)
                {
                    Console.WriteLine(" el primer numero es mayor");
                }
                else
                {
                    Console.WriteLine(" el tercer numero es mayor");
                }

            }
            else if (num2 > num1)
            {
                if (num2 > num3)
                {
                    Console.WriteLine(" el segundo numero es mayor");
                }
                else
                {
                    Console.WriteLine(" el tercer numero es mayor");
                }
            }
            Console.ReadLine();
        }
        private static void NumeroMenor(int num1, int num2, int num3)
        {
            if (num1 < num2)
            {
                if (num1 < num3)
                {
                    Console.WriteLine(" el primer numero es menor");
                }
                else
                {
                    Console.WriteLine(" el tercer numero es menor");
                }

            }
            else if (num2 < num1)
            {
                if (num2 < num3)
                {
                    Console.WriteLine(" el segundo numero es menor");
                }
                else
                {
                    Console.WriteLine(" el tercer numero es menor");
                }
            }
            Console.ReadLine();
        }
    }
}