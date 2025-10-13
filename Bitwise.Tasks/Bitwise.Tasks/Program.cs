
using System.Diagnostics;

uint x;
try
{
    x = Convert.ToUInt32("0b111001", 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

x = Convert.ToUInt32("111001", 2);

int value = 3;
while(value != 0)
{
    value = value << 1;
    Console.WriteLine(value);
}


// Some extra https://sites.google.com/stpaulsschool.org.uk/c-sharp/topics/bitwise-manipulation-and-binary-files

bool IsBitSet(int x, int n)
{
    return ((x >> n) & 1) == 1;
}

Debug.Assert(IsBitSet(79, 0));
Debug.Assert(IsBitSet(3, 1));
Debug.Assert(IsBitSet(10, 3));

