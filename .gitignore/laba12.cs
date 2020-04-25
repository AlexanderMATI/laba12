using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
class Laba12 :functions
{
   
    static void Main(string[] args)
    {
        Console.WriteLine("Введите имя файла");
        Dictionary<string, int> Words = readFile(Console.ReadLine());
        for (int i = 0; i < Words.Count();i++)
        {
            Console.WriteLine("{0} - {1}", Words.ElementAt(i).Key, Words.ElementAt(i).Value);
        }

        Console.WriteLine("Ваше слово: {0}", findWordInfo(Words));
        Console.WriteLine( maxCountWord(Words));
        Console.ReadKey();
    }
}

