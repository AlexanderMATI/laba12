using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


class functions
{
    static public string currentWord;
    static public int count;
    public static Dictionary<string, int> readFile(string filename)
    {
        string text = "";
        try
        {
            text = File.ReadAllText(filename);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("файл не найден {0}", e);
            Console.ReadKey();
            Environment.Exit(1);
        }
        var allwords = text.Split(' ', ',', '-', '.');
        Dictionary<string, int> Words = new Dictionary<string, int>();
        var unique =
           (from word in allwords select word.ToLower()).Distinct().OrderBy(name => name);
        bool temp = false;
        currentWord = "";
        count = 0;
        foreach (var word in unique)
        {
            if (temp == false)
            {
                temp = true;
                continue;
            }
            int tempCount = (from word2 in allwords where word2.ToLower() == word select word2).Count();
            Words.Add(word, tempCount);
            if (tempCount > count)
            {
                count = tempCount;
                currentWord = word;
            }
            else
            if (tempCount == count)
            {
                currentWord = currentWord + ", " + word;
            }
            try
            {
                Words.Add(word, tempCount);
            }
            catch (ArgumentException e)
            {
                continue;
            }
        }
        return Words;

    }

    public static string findWordInfo(Dictionary<string, int> D)
    {
        Console.WriteLine("Введите слово для поиска");
        string findWord = Console.ReadLine();
        try
        {
            return findWord + " - " + D[findWord];
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
            return "Ошибка! Слово не найдено";
        }

    }

    public static string maxCountWord(Dictionary<string, int> D)
    {
        return "Самое встречающееся слово: " + currentWord + " - " + count;


    }



}
