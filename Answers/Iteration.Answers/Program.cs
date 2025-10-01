
using System.Text;

int limit = 1000;

IList<int> primes = Sieve(limit);

Console.WriteLine($"Primes under {limit}: {PrettyPrint(primes)}");

static string PrettyPrint<T>(IList<T> items)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("[");
    sb.Append(string.Join(", ", items));
    sb.Append("]");
    return sb.ToString();
}


static IList<int> Sieve(int n)
{
    List<int> candidates = Enumerable.Range(2, n - 1).ToList();
    int counter = 0;
    while (counter <= n / 2)
    {
        if (candidates[counter] > 0)
        {
            for (int i = counter + candidates[counter]; i < candidates.Count; i += candidates[counter])
            {
                candidates[i] = 0;
            }
        }
        ++counter;
    }
    return candidates.Where(c => c != 0).ToList();
}