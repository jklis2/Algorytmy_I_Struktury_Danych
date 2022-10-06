using System;
using System.IO;

class Program
{
    static Stream ReadStream;
    static int Idx, Size, BytesRead;
    static byte[] Buffer;

    public static void Initialze()
    {
        ReadStream = Console.OpenStandardInput();
        Idx = BytesRead = 0;
        Size = 1 << 17;
        Buffer = new byte[Size];
    }

    public static int ReadInt()
    {
        byte _ReadByte;
        //For trimming
        do
        {
            _ReadByte = ReadByte();
        }
        while (_ReadByte < '-');
        bool neg = false;
        //Checking sign of number
        if (_ReadByte == '-')
        {
            neg = true;
            _ReadByte = ReadByte();
        }
        int m = _ReadByte - '0';
        while (true)
        {
            _ReadByte = ReadByte();
            if (_ReadByte < '0') break;
            m = m * 10 + (_ReadByte - '0');
        }
        if (neg) return -m;
        return m;
    }

    private static void ReadConsoleInput()
    {
        Idx = 0;
        BytesRead = ReadStream.Read(Buffer, 0, Size);
        if (BytesRead <= 0) Buffer[0] = 32;
    }

    private static byte ReadByte()
    {
        if (Idx == BytesRead) ReadConsoleInput();
        return Buffer[Idx++];
    }

    public static void Dispose()
    {
        ReadStream.Close();
    }

    static void Main(string[] args)
    {
        Initialze();
        int n, d, m, count = 0;
        m = ReadInt();
        d = ReadInt();
        while (m-- > 0)
        {
            n = ReadInt();
            if (n % d == 0)
                count++;
        }
        Dispose();
        Console.WriteLine(count);
    }
}