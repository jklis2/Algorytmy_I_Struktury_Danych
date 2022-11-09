using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class Bonus_SPOJ_CODFURY_Megatron_and_his_rage
{
    private Bonus_SPOJ_CODFURY_Megatron_and_his_rage(int humanCount, int stationCount)
    {
        HumansSeen = humanCount;
        StationsPassed = stationCount;
    }

    public int HumansSeen { get; }
    public int StationsPassed { get; }

    public static Bonus_SPOJ_CODFURY_Megatron_and_his_rage Solve(int stationCount, int humanLimit, int[] stationHumanCounts)
    {
        int optimalHumansSeen = 0,
            optimalStationsPassed = 0;
        int humansSeen = stationHumanCounts[0],
            stationsPassed = 1;
        int startStation = 0,
            endStation = 0;

        while (true)
        {
            if (humansSeen <= humanLimit && stationsPassed > optimalStationsPassed)
            {
                optimalHumansSeen = humansSeen;
                optimalStationsPassed = stationsPassed;
            }
            else if (humansSeen < optimalHumansSeen && stationsPassed == optimalStationsPassed)
            {
                optimalHumansSeen = humansSeen;
            }

            if (endStation == stationCount - 1
                || stationCount - startStation < optimalStationsPassed)
                return new Bonus_SPOJ_CODFURY_Megatron_and_his_rage(optimalHumansSeen, optimalStationsPassed);

            humansSeen += stationHumanCounts[++endStation];
            ++stationsPassed;

            while (humansSeen > humanLimit && startStation < endStation)
            {
                humansSeen -= stationHumanCounts[startStation++];
                --stationsPassed;
            }
        }
    }
}

public static class Program
{
    private static void Main()
    {
        int remainingTestCases = FastIO.ReadNonNegativeInt();
        while (remainingTestCases-- > 0)
        {
            int stationCount = FastIO.ReadNonNegativeInt();
            int humanLimit = FastIO.ReadNonNegativeInt();

            int[] stationHumanCounts = new int[stationCount];
            for (int s = 0; s < stationCount; ++s)
            {
                stationHumanCounts[s] = FastIO.ReadNonNegativeInt();
            }

            var solution = Bonus_SPOJ_CODFURY_Megatron_and_his_rage.Solve(stationCount, humanLimit, stationHumanCounts);

            FastIO.WriteNonNegativeInt(solution.HumansSeen);
            FastIO.WriteSpace();
            FastIO.WriteNonNegativeInt(solution.StationsPassed);
            FastIO.WriteLine();
        }

        FastIO.Flush();
    }
}

public static class FastIO
{
    private const byte _null = (byte)'\0';
    private const byte _space = (byte)' ';
    private const byte _newLine = (byte)'\n';
    private const byte _minusSign = (byte)'-';
    private const byte _zero = (byte)'0';
    private const int _inputBufferLimit = 8192;
    private const int _outputBufferLimit = 8192;

    private static readonly Stream _inputStream = Console.OpenStandardInput();
    private static readonly byte[] _inputBuffer = new byte[_inputBufferLimit];
    private static int _inputBufferSize = 0;
    private static int _inputBufferIndex = 0;

    private static readonly Stream _outputStream = Console.OpenStandardOutput();
    private static readonly byte[] _outputBuffer = new byte[_outputBufferLimit];
    private static readonly byte[] _digitsBuffer = new byte[11];
    private static int _outputBufferSize = 0;

    private static byte ReadByte()
    {
        if (_inputBufferIndex == _inputBufferSize)
        {
            _inputBufferIndex = 0;
            _inputBufferSize = _inputStream.Read(_inputBuffer, 0, _inputBufferLimit);
            if (_inputBufferSize == 0)
                return _null;
        }

        return _inputBuffer[_inputBufferIndex++];
    }

    public static int ReadNonNegativeInt()
    {
        byte digit;

        do
        {
            digit = ReadByte();
        }
        while (digit < _minusSign);

        int result = digit - _zero;
        while (true)
        {
            digit = ReadByte();
            if (digit < _zero) break;
            result = result * 10 + (digit - _zero);
        }

        return result;
    }

    public static void WriteNonNegativeInt(int value)
    {
        int digitCount = 0;
        do
        {
            int digit = value % 10;
            _digitsBuffer[digitCount++] = (byte)(digit + _zero);
            value /= 10;
        } while (value > 0);

        if (_outputBufferSize + digitCount > _outputBufferLimit)
        {
            _outputStream.Write(_outputBuffer, 0, _outputBufferSize);
            _outputBufferSize = 0;
        }

        while (digitCount > 0)
        {
            _outputBuffer[_outputBufferSize++] = _digitsBuffer[--digitCount];
        }
    }

    private static void WriteByte(byte @byte)
    {
        if (_outputBufferSize == _outputBufferLimit)
        {
            _outputStream.Write(_outputBuffer, 0, _outputBufferSize);
            _outputBufferSize = 0;
        }

        _outputBuffer[_outputBufferSize++] = @byte;
    }

    public static void WriteSpace()
        => WriteByte(_space);

    public static void WriteLine()
        => WriteByte(_newLine);

    public static void Flush()
    {
        _outputStream.Write(_outputBuffer, 0, _outputBufferSize);
        _outputBufferSize = 0;
        _outputStream.Flush();
    }
}