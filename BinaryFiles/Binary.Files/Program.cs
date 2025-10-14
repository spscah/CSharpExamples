using System.Diagnostics;

byte[] logo = File.ReadAllBytes("sps.bmp");
byte first = logo[0];
byte second = logo[1];

char b = 'B';
char m = 'M';

int res1 = first ^ (byte)b;
int res2 = second ^ (byte)m;

Debug.Assert(res1 == 0 && res2 == 0);
Console.WriteLine("all ok.");
