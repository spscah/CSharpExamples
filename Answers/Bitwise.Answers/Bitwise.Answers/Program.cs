
using System.Diagnostics;
using System.Runtime.CompilerServices;

int RightMost(int n)
{
    return n & 1;
}

Debug.Assert(RightMost(79) == 1);
Debug.Assert(RightMost(8) == 0);

int Pattern(int places)
{
    int pattern = 0;
    for (int i = 0; i < places; ++i)
        pattern |= 1 << i;
    return pattern;
}

int Right(int places, int n)
{
    return n & Pattern(places);
}

Debug.Assert(Right(3, 15) == 7);
Debug.Assert(Right(4, 30) == 14);
Debug.Assert(Right(2, 100) == 0);
Debug.Assert(Right(4, 255) == 15);

int Right3(int n)
{
    return Right(3, n);
}

int LeftMost(int n)
{
    int pattern = 1 << 31;
    int anded = pattern & n;
    return anded == pattern ? 1 : 0; 
}

Debug.Assert(LeftMost(56) == 0);
Debug.Assert(LeftMost(-56) == 1);

int Left(int places, int n) => n >>> (32 - places);

Debug.Assert(Left(3, int.MinValue) == 4);
Debug.Assert(Left(3, -1) == 7);
Debug.Assert(Left(7, 7) == 0);

int Left3(int n) => Left(3, n);

int Remove(int places, int n) => n & ~Pattern(places);

Debug.Assert(Remove(3, 15) == 8);
Debug.Assert(Remove(1, 15) == 14);

byte Set(byte b)
{
    return (byte)(b | 1);
}

Debug.Assert(Set(0xAE) == 0xAF);
Debug.Assert(Set(0xAF) == 0xAF);

byte UnSet(byte b)
{
    return (byte)(b & ~1);
}

Debug.Assert(UnSet(0xAE) == 0xAE);
Debug.Assert(UnSet(0xAF) == 0xAE);


Console.WriteLine("all done");