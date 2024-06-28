using mdoule.Services;
using System;
using System.Collections.Generic;

namespace WeightedStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a function to run:");
                Console.WriteLine("1. Weighted Strings");
                Console.WriteLine("2. Balanced Bracket Checker");
                Console.WriteLine("3. Highest Palindrome");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunWeightedStrings();
                        break;
                    case "2":
                        RunBracketBalancer();
                        break;
                    case "3":
                        RunHighestPalindrome();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        static void RunWeightedStrings()
        {
            var weightedStringsService = new WeightedStringsService();

            Console.WriteLine("Enter the string for weighted strings:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter the number of queries:");
            int numQueries;
            while (!int.TryParse(Console.ReadLine(), out numQueries) || numQueries <= 0)
            {
                Console.WriteLine("Please enter a valid number:");
            }

            int[] queries = new int[numQueries];
            Console.WriteLine("Enter the queries (comma separated or continuous string):");
            string queryInput = Console.ReadLine();

            if (queryInput.Contains(","))
            {
                string[] queryStrings = queryInput.Split(',');
                if (queryStrings.Length != numQueries)
                {
                    Console.WriteLine($"You entered {queryStrings.Length} queries, but expected {numQueries}.");
                    return;
                }

                for (int i = 0; i < numQueries; i++)
                {
                    if (!int.TryParse(queryStrings[i].Trim(), out queries[i]))
                    {
                        Console.WriteLine($"Invalid query at position {i + 1}: '{queryStrings[i]}'");
                        return;
                    }
                }
            }
            else
            {
                if (queryInput.Length != numQueries)
                {
                    Console.WriteLine($"You entered {queryInput.Length} queries, but expected {numQueries}.");
                    return;
                }

                for (int i = 0; i < numQueries; i++)
                {
                    if (!int.TryParse(queryInput[i].ToString(), out queries[i]))
                    {
                        Console.WriteLine($"Invalid query at position {i + 1}: '{queryInput[i]}'");
                        return;
                    }
                }
            }

            List<string> result1 = weightedStringsService.CheckQueries(input1, queries);

            Console.WriteLine("Weighted Strings Result:");
            Console.WriteLine(string.Join(", ", result1));
        }

        static void RunBracketBalancer()
        {
            var bracketBalancerService = new BalancedBracketService();

            Console.WriteLine("Enter the string for bracket balancer:");
            string input2 = Console.ReadLine();

            string result2 = bracketBalancerService.IsBalanced(input2);

            Console.WriteLine("\nBracket Balancer Result:");
            Console.WriteLine($"Input: {input2} -> Output: {result2}");
        }

        static void RunHighestPalindrome()
        {
            var highestPalindromeService = new HighestPalindromeService();

            Console.WriteLine("Enter the string for highest palindrome:");
            string input3 = Console.ReadLine();

            Console.WriteLine("Enter the value of k:");
            int k;
            while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
            {
                Console.WriteLine("Please enter a valid non-negative number for k:");
            }

            string result3 = highestPalindromeService.FindHighestPalindrome(input3, k);

            Console.WriteLine("\nHighest Palindrome Result:");
            Console.WriteLine($"Input: {input3} with k = {k} -> Output: {result3}");
        }
    }
}
