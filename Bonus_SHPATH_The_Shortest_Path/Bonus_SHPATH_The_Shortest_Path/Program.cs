using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class SHPATH
{
    public static int Solve(List<KeyValuePair<int, int>>[] cityGraph, int sourceCity, int destinationCity)
    {
        var pathCosts = new BinaryHeap(sourceCity);
        bool[] visitedCities = new bool[cityGraph.Length];

        while (!pathCosts.IsEmpty)
        {
            var cheapestPath = pathCosts.Extract();
            int city = cheapestPath.Key;
            int pathCostToCity = cheapestPath.Value;

            if (city == destinationCity)
                return pathCostToCity;

            var neighboringEdges = cityGraph[city];
            for (int e = 0; e < neighboringEdges.Count; ++e)
            {
                int neighbor = neighboringEdges[e].Key;
                if (visitedCities[neighbor])
                    continue;

                int pathCostToNeighborThroughCity = pathCostToCity + neighboringEdges[e].Value;
                int currentPathCostToNeighbor;

                if (pathCosts.TryGetValue(neighbor, out currentPathCostToNeighbor))
                {
                    if (pathCostToNeighborThroughCity < currentPathCostToNeighbor)
                    {
                        pathCosts.Update(neighbor, pathCostToNeighborThroughCity);
                    }
                }
                else
                {
                    pathCosts.Add(neighbor, pathCostToNeighborThroughCity);
                }
            }

            visitedCities[city] = true;
        }

        throw new NotSupportedException();
    }
}

public sealed class BinaryHeap
{
    private readonly List<KeyValuePair<int, int>> _keyValuePairs = new List<KeyValuePair<int, int>>();
    private readonly Dictionary<int, int> _keyIndices = new Dictionary<int, int>();

    public BinaryHeap(int topKey, int topValue = 0)
    {
        _keyValuePairs.Add(new KeyValuePair<int, int>(topKey, topValue));
        _keyIndices.Add(topKey, 0);
    }

    public int Size => _keyValuePairs.Count;
    public bool IsEmpty => Size == 0;
    public KeyValuePair<int, int> Top => _keyValuePairs[0];

    public void Add(int key, int value)
        => Add(new KeyValuePair<int, int>(key, value));

    public void Add(KeyValuePair<int, int> keyValuePair)
    {
        _keyValuePairs.Add(keyValuePair);
        _keyIndices.Add(keyValuePair.Key, _keyValuePairs.Count - 1);
        SiftUp(_keyValuePairs.Count - 1, keyValuePair);
    }

    public KeyValuePair<int, int> Extract()
    {
        var top = _keyValuePairs[0];
        _keyIndices.Remove(top.Key);

        if (_keyValuePairs.Count == 1)
        {
            _keyValuePairs.RemoveAt(0);
        }
        else
        {
            var bottom = _keyValuePairs[_keyValuePairs.Count - 1];
            _keyValuePairs.RemoveAt(_keyValuePairs.Count - 1);
            _keyValuePairs[0] = bottom;
            _keyIndices[bottom.Key] = 0;
            SiftDown(0, bottom);
        }

        return top;
    }

    public bool Contains(int key)
        => _keyIndices.ContainsKey(key);

    public int GetValue(int key)
        => _keyValuePairs[_keyIndices[key]].Value;

    public bool TryGetValue(int key, out int value)
    {
        int keyIndex;
        if (_keyIndices.TryGetValue(key, out keyIndex))
        {
            value = _keyValuePairs[keyIndex].Value;
            return true;
        }

        value = default(int);
        return false;
    }

    public int Update(int key, int value)
        => Update(new KeyValuePair<int, int>(key, value));

    public int Update(KeyValuePair<int, int> keyValuePair)
    {
        int index = _keyIndices[keyValuePair.Key];
        int oldValue = _keyValuePairs[index].Value;
        _keyValuePairs[index] = keyValuePair;

        if (oldValue > keyValuePair.Value)
        {
            SiftUp(index, keyValuePair);
        }
        else
        {
            SiftDown(index, keyValuePair);
        }

        return oldValue;
    }

    private void SiftUp(int index, KeyValuePair<int, int> keyValuePair)
    {
        if (index == 0) return;

        int parentIndex = (index - 1) / 2;
        var parentKeyValuePair = _keyValuePairs[parentIndex];

        if (parentKeyValuePair.Value > keyValuePair.Value)
        {
            _keyValuePairs[index] = parentKeyValuePair;
            _keyIndices[parentKeyValuePair.Key] = index;
            _keyValuePairs[parentIndex] = keyValuePair;
            _keyIndices[keyValuePair.Key] = parentIndex;
            SiftUp(parentIndex, keyValuePair);
        }
    }

    private void SiftDown(int index, KeyValuePair<int, int> keyValuePair)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;

        if (rightChildIndex < _keyValuePairs.Count)
        {
            var leftChildKeyValuePair = _keyValuePairs[leftChildIndex];
            var rightChildKeyValuePair = _keyValuePairs[rightChildIndex];

            if (leftChildKeyValuePair.Value < rightChildKeyValuePair.Value)
            {
                if (keyValuePair.Value > leftChildKeyValuePair.Value)
                {
                    _keyValuePairs[index] = leftChildKeyValuePair;
                    _keyIndices[leftChildKeyValuePair.Key] = index;
                    _keyValuePairs[leftChildIndex] = keyValuePair;
                    _keyIndices[keyValuePair.Key] = leftChildIndex;
                    SiftDown(leftChildIndex, keyValuePair);
                }
            }
            else
            {
                if (keyValuePair.Value > rightChildKeyValuePair.Value)
                {
                    _keyValuePairs[index] = rightChildKeyValuePair;
                    _keyIndices[rightChildKeyValuePair.Key] = index;
                    _keyValuePairs[rightChildIndex] = keyValuePair;
                    _keyIndices[keyValuePair.Key] = rightChildIndex;
                    SiftDown(rightChildIndex, keyValuePair);
                }
            }
        }
        else if (leftChildIndex < _keyValuePairs.Count)
        {
            var leftChildKeyValuePair = _keyValuePairs[leftChildIndex];

            if (keyValuePair.Value > leftChildKeyValuePair.Value)
            {
                _keyValuePairs[index] = leftChildKeyValuePair;
                _keyIndices[leftChildKeyValuePair.Key] = index;
                _keyValuePairs[leftChildIndex] = keyValuePair;
                _keyIndices[keyValuePair.Key] = leftChildIndex;
            }
        }
    }
}

public static class Program
{
    private static void Main()
    {
        var output = new StringBuilder();
        int testCount = FastIO.ReadNonNegativeInt();
        for (int t = 0; t < testCount; ++t)
        {
            int cityCount = FastIO.ReadNonNegativeInt();
            var cityIndices = new Dictionary<string, int>(cityCount);
            var cityGraph = new List<KeyValuePair<int, int>>[cityCount];

            for (int c = 0; c < cityCount; ++c)
            {
                cityIndices.Add(FastIO.ReadString(), c);
                cityGraph[c] = new List<KeyValuePair<int, int>>();

                int neighborCount = FastIO.ReadNonNegativeInt();
                for (int n = 0; n < neighborCount; ++n)
                {
                    int neighborIndex = FastIO.ReadNonNegativeInt() - 1;
                    int connectionCost = FastIO.ReadNonNegativeInt();

                    cityGraph[c].Add(new KeyValuePair<int, int>(neighborIndex, connectionCost));
                }
            }

            int pathCount = FastIO.ReadNonNegativeInt();
            for (int p = 0; p < pathCount; ++p)
            {
                int sourceCity = cityIndices[FastIO.ReadString()];
                int destinationCity = cityIndices[FastIO.ReadString()];

                output.Append(
                    SHPATH.Solve(cityGraph, sourceCity, destinationCity));
                output.AppendLine();
            }
        }

        Console.Write(output);
    }
}

public static class FastIO
{
    private const byte _null = (byte)'\0';
    private const byte _newLine = (byte)'\n';
    private const byte _minusSign = (byte)'-';
    private const byte _zero = (byte)'0';
    private const int _inputBufferLimit = 8192;
    private const int _stringLengthLimit = 12;

    private static readonly Stream _inputStream = Console.OpenStandardInput();
    private static readonly byte[] _inputBuffer = new byte[_inputBufferLimit];
    private static int _inputBufferSize = 0;
    private static int _inputBufferIndex = 0;
    private static readonly char[] _stringBuilder = new char[_stringLengthLimit];

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

    public static string ReadString()
    {
        byte letter;

        do
        {
            letter = ReadByte();
        }
        while (letter < _minusSign);

        int stringLength = 0;
        _stringBuilder[stringLength++] = (char)letter;
        while (true)
        {
            letter = ReadByte();
            if (letter < _zero) break;
            _stringBuilder[stringLength++] = (char)letter;
        }

        return new string(_stringBuilder, 0, stringLength);
    }
}