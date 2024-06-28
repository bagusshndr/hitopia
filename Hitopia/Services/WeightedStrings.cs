using System;
using System.Collections.Generic;

namespace mdoule.Services
{
    public class WeightedStringsService
    {
        public List<string> CheckQueries(string input, int[] queries)
        {
            var result = new List<string>();
            var weights = CalculateWeights(input);

            foreach (var query in queries)
            {
                if (weights.Contains(query))
                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("No");
                }
            }

            return result;
        }

        private HashSet<int> CalculateWeights(string input)
        {
            var weights = new HashSet<int>();
            int n = input.Length;

            for (int i = 0; i < n; i++)
            {
                int weight = input[i] - 'a' + 1;
                weights.Add(weight);

                for (int j = i + 1; j < n && input[j] == input[i]; j++)
                {
                    weight += input[i] - 'a' + 1;
                    weights.Add(weight);
                    i = j;
                }
            }

            return weights;
        }
    }
}
