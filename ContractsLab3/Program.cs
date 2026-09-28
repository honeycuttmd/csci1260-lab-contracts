namespace ContractsLab3;

/// <summary>
/// Runs the contracts lab demonstration.
/// </summary>
public class Program
{
    /// <summary>
    /// Runs the demonstration and siplays their results.
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("=== RIVER CITY SUPPLY ===\n");

        List<ShelfCount> records = new List<ShelfCount>
        {
            new ShelfCount("DAIRY", 3, 21.50),
            new ShelfCount("DRY", 1, 19.00),
            new ShelfCount("DAIRY", 1, 15.00),
            new ShelfCount("DRY", 1, 19.00),
            new ShelfCount("DAIRY", 3, 18.75),
            new ShelfCount("FROZEN", 2, 30.00),
            new ShelfCount("DRY", 4, 12.50),
        };

        Console.WriteLine("Seven records created, in this order:");

        for (int i = 0; i < records.Count; i++)
        {
            Console.WriteLine(String.Format(" {0,2} {1}", i + 1, records[i]));
        }

        Console.WriteLine();
        Console.WriteLine("Contract 1: Equals and GetHashCode");

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Record 1 equals record 5 (same key, new value)?",
            records[0].Equals(records[4])));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Record 2 equals record 4 (identical)?",
            records[1].Equals(records[3])));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Record 1 equals record 3?",
            records[0].Equals(records[2])));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Record 2 and record 4 are the same object?",
            ReferenceEquals(records[1], records[3])));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Equal records report equal hash codes?",
            records[0].GetHashCode() == records[4].GetHashCode()));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Records created:",
            records.Count));

        HashSet<ShelfCount> set = new HashSet<ShelfCount>();

        foreach (ShelfCount record in records)
        {
            set.Add(record);
        }

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Distinct records in the set:",
            set.Count));

        List<ShelfCount> distinct = new List<ShelfCount>(set);

        Console.WriteLine();

        Console.WriteLine("Contract 2: CompareTo, the natural order");

        distinct.Sort();

        foreach (ShelfCount record in distinct)
        {
            Console.WriteLine($"  {record}");
        }

        Console.WriteLine();
        Console.WriteLine("Contract 3: a comparer, chosen at the call site");

        Console.WriteLine(" HighestValueFirst");

        distinct.Sort(new HighestValueFirst());

        foreach (ShelfCount record in distinct)
        {
            Console.WriteLine($"    {record}");
        }

        Console.WriteLine(" GroupedByKey");

        distinct.Sort(new GroupedByKey());

        foreach (ShelfCount record in distinct)
        {
            Console.WriteLine($"    {record}");
        }

        Console.WriteLine();
        Console.WriteLine("Contract 4: cleanup that runs even when the code throws");

        distinct.Sort(new HighestValueFirst());

        CountLog log = null;

        try
        {
            using (log = new CountLog("count-log.txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    log.Write(distinct[i]);
                }

                throw new InvalidOperationException("scanner fault after 3 writes");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($" Caught: {ex.Message}");
        }

        bool safeTwice = true;

        try
        {
            log.Dispose();
        }
        catch
        {
            safeTwice = false;
        }

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "The log closed itself?",
            log.IsClosed));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Closing it a second time was safe?",
            safeTwice));

        Console.WriteLine(String.Format(
            " {0,-50}{1,6}",
            "Lines the log wrote before the fault:",
            log.Count));

        Console.WriteLine(" count-log.txt now says:");

        foreach (string line in File.ReadAllLines("count-log.txt"))
        {
            Console.WriteLine($"    {line}");
        }
    }
}