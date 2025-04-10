using System;

class IntHashTable
{
    private int?[] table;
    private int count;
    private double loadFactorThreshold;

    public IntHashTable(int initialSize = 8, double loadFactorThreshold = 0.6)
    {
        table = new int?[initialSize];
        count = 0;
        this.loadFactorThreshold = loadFactorThreshold;
    }

    private int Hash(int value, int size)
    {
        return Math.Abs(value) % size;
    }

    public void Add(int value)
    {
        if ((double)(count + 1) / table.Length > loadFactorThreshold)
        {
            Resize();
        }

        int index = Hash(value, table.Length);

        while (table[index] != null)
        {
            if (table[index] == value)
                return;
            index = (index + 1) % table.Length;
        }
        table[index] = value;
        count++;
    }

    public bool Contains(int value)
    {
        int index = Hash(value, table.Length);
        int startIndex = index;

        while (table[index] != null)
        {
            if (table[index] == value)
                return true;
            index = (index + 1) % table.Length;
            if (index == startIndex)
                break;
        }
        return false;
    }

    private void Resize()
    {
        int newSize = table.Length * 2;
        int?[] newTable = new int?[newSize];

        foreach (var item in table)
        {
            if (item.HasValue)
            {
                int index = Hash(item.Value, newSize);
                while (newTable[index] != null)
                {
                    index = (index + 1) % newSize;
                }
                newTable[index] = item.Value;
            }
        }
        table = newTable;
        Console.WriteLine($"Хеш-таблица расширена до {newSize} элементов.");
    }

    public void Print()
    {
        Console.WriteLine("Содержимое хеш-таблицы:");
        for (int i = 0; i < table.Length; i++)
        {
            Console.WriteLine($"{i}: {(table[i]?.ToString() ?? "пусто")}");
        }
    }
}

class Program
{
    static void Main()
    {
        IntHashTable hashTable = new IntHashTable();
        for (int i = 0; i < 20; i++)
        {
            hashTable.Add(i * 3);
        }

        Console.WriteLine($"Содержит 9? {hashTable.Contains(9)}");
        Console.WriteLine($"Содержит 21? {hashTable.Contains(21)}");

        hashTable.Print();
    }
}