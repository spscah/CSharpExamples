

IList<string> lines = File.ReadAllLines("stations.txt").ToList();
IList<string> stations = AllTheStations(lines, true);

foreach (string s in new List<string> { "mackerel", "sturgeon", "piranha", "bacteria" })
{
    Console.WriteLine(PrettyFormat(DoesNotContain(s, stations)));
}

// Functions

// Contains - takes a string and a list of strings, returns any of the list does not overlap with the string
IList<string> DoesNotContain(string target, IList<string> names)
{
    return names.Where(n => !Intersection(n, target)).ToList();    
}

string PrettyFormat<T>(IList<T> items)
{
    return $"[{string.Join(", ", items)}]";
}

IList<string> AllTheStations(IEnumerable<string> lines, bool IncludeDLR)
{
    IList<string> stations;
    if (IncludeDLR)
    {
        stations = lines
            .Select(l =>
                l.Split(",")[0].Trim().ToLowerInvariant())
            .ToList();
    }
    else
    {
        stations = lines
            .Where(l => (l.Split(",").Count() > 2) || (l.Split(",")[1].Trim() != "Docklands Light Railway"))
            .Select(l =>
                l.Split(",")[0].Trim().ToLowerInvariant())
            .ToList();

    }
    return stations;
}



bool Intersection(string s1, string s2)
{
    foreach (char c in s1)
        if (s2.Contains(c))
            return true;
    return false;
}