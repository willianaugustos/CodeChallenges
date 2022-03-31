using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppToptal
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = getChange(5, 0.99M); // should return [1,0,0,0,0,4]
            printResult(res);

            res = getChange(3.14M, 1.99M);// should return [0,1,1,0,0,1]
            printResult(res);

            res = getChange(3, 0.01M); // should return [4,0,2,1,1,2]
            printResult(res);

            res = getChange(4, 3.14M); // should return [1,0,1,1,1,0]
            printResult(res);

            res = getChange(0.45M, 0.34M); // should return [1,0,1,0,0,0]
            printResult(res);
        }
        private static void printResult(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        private static int[] getChange(decimal M, decimal P)
        {
            var coins = new List<int>() { 100, 50, 25, 10, 5, 1};
            var remaining = (M-P)*100;
            var change = new int[6];
            var position = coins.Count();
            foreach (var item in coins)
            {
                if (remaining >= item) // (5-0.99)*100 = 401 < 100
                {
                    var residual = remaining % item;
                    int qt = (int)(remaining-residual)/ item;
                    remaining = remaining - (qt * item);

                    change[position-1] = qt;
                }
                position--;
            }
            return change;
        }
    }
}
