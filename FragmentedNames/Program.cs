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

            //var result = findWord(new string[] { "P>E", "E>R", "R>U" }); // PERU
            //Console.WriteLine(result);
            
            //result = findWord(new string[] { "I>N", "A>I", "P>A", "S>P" }); // SPAIN
            //Console.WriteLine(result);

            //result = findWord(new string[] { "U>N", "G>A", "R>Y", "H>U", "N>G", "A>R" }); // HUNGARY
            //Console.WriteLine(result);

            //result = findWord(new string[]{"I>F", "W>I", "S>W", "F>T"}); // SWIFT
            //Console.WriteLine(result);

            var result = findWord(new string[] { "R>T", "A>L", "P>O", "O>R", "G>A", "T>U", "U>G" }); // PORTUGAL
            Console.WriteLine(result);

            //result = findWord(new string[] { "W>I", "R>L", "T>Z", "Z>E", "S>W", "E>R", "L>A", "A>N", "N>D", "I>T" }); // SWITZERLAND
            //Console.WriteLine(result);


            Console.ReadKey();
        }

        private static string findWord(string[] parts)
        {
            string resultWord = "";
            foreach (var part in parts)
            {
                //if (resultWord.Length >= parts.Count())
                //    break;

                var posFirst = resultWord.IndexOf(part[0]);
                var posSecond = resultWord.IndexOf(part[2]);
                
                if (posFirst == -1 && posSecond == -1)
                {
                    resultWord += string.Concat(part[0], part[2]);
                }
                else if (posFirst ==-1)
                {
                    //in -> AI
                    //the first character must be put before the second
                    var startWord = "";
                    if (posSecond>0)
                    {
                        startWord = resultWord.Substring(0, posSecond); 
                    }
                    resultWord = startWord + part[0] + resultWord.Substring(posSecond);
                }
                else if (posSecond ==-1)
                {
                    //the second char must be put after the second afeter the first position
                    resultWord = resultWord.Substring(0, posFirst) + resultWord.Substring(posFirst) + part[2];
                }
            }
            return resultWord;
        }
    }
}