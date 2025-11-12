using System.Diagnostics;

List<string> listOfStrings = new List<string> { "Candy", "Mike myers"};

int NextOnAThursday()
{
    //set starting year to 2025
    int year = 2026;
    for(; ; ++year)
    {
        //check if date is thursday, and if not then add 1 to year
        int date = (int)(new DateTime(year, 11, 6).DayOfWeek);
        if (date == 4)
        {
            return year;
        }
    }
}

bool ComputeSweets(List<int> pileSizes, int numHours, int sweetsPerHour)
{
    while (numHours != 0)
    {
        pileSizes = pileSizes.OrderDescending().ToList();

        if (pileSizes[0] < sweetsPerHour) pileSizes[0] = 0;
        else pileSizes[0] -= sweetsPerHour;

        numHours--;
    }

    if (pileSizes.Sum() != 0) return false; // If there are sweets left over, this SPH is invalid.
    return true;
}

int EatingSweets(List<int> pileSizes, int numHours)
{
    int minSweetsPerHour = 1;

    while (!ComputeSweets(pileSizes, numHours, minSweetsPerHour)) minSweetsPerHour += 1;

    return minSweetsPerHour;
}


int CuttingChocolate(int cuts)
{
    int horizontal = cuts;
    int vertical = 0;
    int maxPieces = 0;
    // Iterate through pairs of factors of the number of cuts
    for (int i = 0; horizontal >= vertical; i++)
    {
        horizontal--;
        vertical++;
        // Compare the new number of pieces with the previous max number of pieces
        if (horizontal * vertical > maxPieces)
        {
            maxPieces = horizontal * vertical;
        }
    }
    return maxPieces;
}

bool ValidatePassword(string candidate)
{
 const int MIN_LEN = 8;
    const int MAX_LEN = 32;
    const int SUM_MULT = 11;
    List<char> chars = candidate.ToList();


    if (candidate.Length < MIN_LEN || candidate.Length > MAX_LEN) { return false; }

    if (!chars.Any(char.IsUpper)) { return false; }
    if (!chars.Any(char.IsLower)) { return false; }
    if (!chars.Any(char.IsDigit)) { return false; }

    if (!chars.GroupBy(s => s).All(group => group.Count() == 1)) { return false; } // Ensure no element appears more than once
    if (chars.Sum(c => (int)c) % SUM_MULT != 0) { return false; } //Ensure the sum of the ascii codes is a multiple of 11

    return true;

}

Debug.Assert(NextOnAThursday() == 2031);

List<int> pileSizes = new List<int> { 4, 9, 11, 17 };
int numHours = 8;
Debug.Assert(EatingSweets(pileSizes, numHours) == 6);

Debug.Assert(CuttingChocolate(5) == 6);
Debug.Assert(CuttingChocolate(6) == 9);
Debug.Assert(CuttingChocolate(7) == 12);
Debug.Assert(CuttingChocolate(8) == 16);

// Note the exclamation marks showing not, so False 
Debug.Assert(!ValidatePassword("ABCdef")); // too short
Debug.Assert(!ValidatePassword("ABCABC12!")); // duplicates, doesn't divide by 11
Debug.Assert(!ValidatePassword("ABCabcde!")); // no digit 
Debug.Assert(!ValidatePassword("ABCdef12!")); // doesn't divide by 11 
Debug.Assert(ValidatePassword("ABCdef12&")); // should succeed 

//If program runs to here, that means that all cases are successful
Console.WriteLine("All Cases Passed!");