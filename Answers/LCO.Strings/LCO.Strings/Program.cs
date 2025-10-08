/* As written by you (sets LCO.1 and LCO.2)
 * presented anonymously
 */


// not all of these were needed! 
// I'll let you off System.Text as StringBuilder was seen quite a bit 
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Security.Permissions;


// Lots of magic numbers - and printing without testing, but there's clearly been understanding 

Char_code("你好！");//the chinese version of exclamation goes to 65281, while the english one is 33
        
static void Char_code(string s)
{
    foreach (char c in s)
    {
        Console.Write((int)c + " ");
    }
}

// testing A using B, testing B using A - be careful of the circular dependency, but it works here 
List<int> charvals(string text)
{
    List<int> Values = [];
    foreach (char c in text) { Values.Add((int)c); }
    return Values;    
}

List<byte> binASCII(string text)
{
    List<int> original = charvals(text);
    List<byte> final = [];
    foreach (int i in original) { final.Add((byte)i); }
    return final;
}

byte byte_of_H = 104; 
Debug.Assert(binASCII("hello")[0] == byte_of_H);//ASCII value of 'h' in byte form
Debug.Assert(binASCII("你好")[1] == charvals("你好")[1]%256);
Console.WriteLine(binASCII("你好")[1] == charvals("你好")[1]); //false as byte value ignores meta data bytes


/* good recognition of the immutability of strings 
*/

List<string> wave = mexicanwave("hello");
Debug.Assert(wave.Count == 5);
Debug.Assert(wave[0] == "Hello");
Debug.Assert(wave[4] == "hellO");

static List<string> mexicanwave(string input)
{
    List<string> results = new List<string>();
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == ' ') continue;
        char[] chars = input.ToCharArray();
        chars[i] = char.ToUpper(chars[i]);
        results.Add(new string(chars));
    }
    return results;
}

/* another way to initialise a string - using the char array method 
*/

Debug.Assert(MexicanWave("hello")[2] == "heLlo");
Debug.Assert(MexicanWave("hello")[3] == "helLo");

static List<string> MexicanWave(string input)
{
    List<string> result = [];
    char[] chars = input.ToCharArray();

    for (int i = 0; i < input.Length; i++)
    {
        if (chars[i] == ' ') { continue; }
        chars[i] = char.ToUpper(chars[i]);
        result.Add(new string(chars));
        chars[i] = input[i];
    }
    return result;
}


/*
Good discovery - the Sequence Equals extension method 
*/
Debug.Assert(charCodes("hello").SequenceEqual(new List<int> { 104, 101, 108, 108, 111 }));
Debug.Assert(charCodes("ABC").SequenceEqual(new List<int> { 65, 66, 67 }));
Debug.Assert(charCodes("123").SequenceEqual(new List<int> { 49, 50, 51 }));
Debug.Assert(charCodes("!@#").SequenceEqual(new List<int> { 33, 64, 35 }));

static List<int> charCodes(string str)
{
    List<int> output = new List<int>();
    char[] temp = str.ToCharArray();
    foreach (char i in temp)
    {
        output.Add((int)i);
    }
    return output;
}


/* Printing!! 
*/

ToCode("Hello");
ToCode("你好");

void ToCode(string s)
{
    List<int> output = new List<int> { };
    foreach (char c in s)
    {
        output.Add((int)c);
    }
    Console.WriteLine($"{s}: {String.Join(' ', output)}");
}

/* **Seems** to work well, but void is not right here. 
*/

PigLatin("The man said \"Hello\". The cat sat on the mat.");

static void PrintList<T>(List<T> n)
{
    Console.WriteLine($"[ {String.Join(", ", n)}]");
}

static void PigLatin(string s)
{
    List<string> words = s.Split(' ').ToList();
    List<string> output = new List<string>();

    foreach (string word in words)
    {

        List<int> punctuation_pos = new List<int>();
        List<string> punctuation = new List<string>();


        string leading_punc = "";
        string trailing_punc = "";

        for (int i = 0; i < word.Length; i++) if (Char.IsPunctuation(word[i]) == true) leading_punc = leading_punc + word[i]; else break;

        for (int i = word.Length - 1; i >= 0; i++) if (Char.IsPunctuation(word[i]) == true) trailing_punc = trailing_punc + word[i]; else break;


        string filtered_word = String.Concat(word.Where(c => Char.IsLetter(c)));
        string new_word = String.Concat(filtered_word.Substring(1), filtered_word[0], "ay");

        for (int i = 0; i < punctuation_pos.Count; i++)
        {
            new_word = new_word.Insert(Math.Min(punctuation_pos[i], new_word.Length), punctuation[i]);
            Console.WriteLine(new_word);
            Console.WriteLine(punctuation_pos[i]);
        }

        output.Add(new_word);
    }

    PrintList<string>(output);
}

/*
*/

List<string> testing = new List<string>() {"elloh", "sh", "hello", "hhelo"};
Debug.Assert((AnagramNumber("hello", testing)) == 2);

static int AnagramNumber(string word, List<string> anagrams)
{
    int output = 0;
    string sortedWord = String.Concat(word.OrderBy(c => c));

    foreach (string anagram in anagrams)
    {
        if (anagram.Length != word.Length) continue;

        string sortedAnagram = String.Concat(anagram.OrderBy(c => c));

        if (sortedAnagram == sortedWord) output++;
    }
    return output;
}

Debug.Assert(Anagram("star", ["rats", "arts", "arc"]) == 2);

int Anagram(string word, List<string> potentialAnagrams)
{
    int anagrams = 0;
    foreach (string potentialAnagram in potentialAnagrams)
    {
        if (String.Concat(potentialAnagram.OrderBy(c => c)).Equals(String.Concat(word.OrderBy(c => c)) )){
            anagrams++;
        }
    }
    return anagrams;
}


/* a different approach with no tests, because you didn't test this either
*/

int Anagram2(string main, List<string> list)
{
    int total = 0;
    int counter = 0;
    foreach (string i in list)
    {
        counter = 0;
        List<char> charlist = i.ToCharArray().ToList();
        foreach (char k in main)
        {
            if (charlist.Contains(k))
            {
                charlist.Remove(k);
                counter += 1;
            }
            else
            {
                break;
            }
            if (counter == main.Length)
            {
                total += 1;
            }
        }
    }
    return total;
}
