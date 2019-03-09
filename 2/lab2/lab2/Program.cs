using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.AccessControl;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            String[] phrases = new[] { "Please, don't give up, ", "What doesn't kill you makes you stronger, ",
                "Come on, dude, come on, ", "One more try, dear " };
            List<String> history = new List<string>();

            Console.WriteLine("What's your name?");
            String name = Console.ReadLine();
            Random rand = new Random();
            int answer = rand.Next(51);

            Console.WriteLine("Ok, " + name + ", can you guess my number from 0 to 50?");
            //Console.WriteLine(answer);

            DateTime start = DateTime.Now;
            int counter = 1;
            int number = 0;
            String s = Console.ReadLine();
            
                try
                {
                    number = Int32.Parse(s);
                    while (answer != number)
                    {
                        if (answer > number)
                        {
                            Console.WriteLine("My number is bigger");
                            history.Add(s + " less");
                        }
                        else if (answer < number)
                        {
                            Console.WriteLine("My number is less");
                            history.Add(s + " bigger");
                        }

                        if (counter % 4 == 0)
                        {
                            int phraseNext = rand.Next(phrases.Length);
                            Console.WriteLine(phrases[phraseNext] + name);
                        }

                        s = Console.ReadLine();
                        if (s.Equals("q"))
                        {
                            Console.WriteLine("See you soon");
                            break;
                        }
                        number = Int32.Parse(s);
                        counter++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Number expected");
                }

                if (answer == number)
                {
                    DateTime finish = DateTime.Now;
                    TimeSpan interval = finish - start;
                    Console.WriteLine("Easy win");
                    history.Add(s + " is equal");
                    Console.WriteLine("You used " + counter + " attempts");
                    foreach (String current in history)
                    {
                        Console.WriteLine(current);
                    }
                Console.WriteLine("You've spent " + interval.ToString());
                }
            }
        
    }
}