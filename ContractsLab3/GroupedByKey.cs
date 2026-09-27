namespace ContractsLab3;

/// <summary>
/// Groups shelf count by aisle, then value, then slot.
/// </summary>
public class GroupedByKey : IComparer<ShelfCount>
{
    /// <summary>
    /// Orders shelf counts by aisle ascending, value descending, and slot ascending.
    /// </summary>
    public int Compare(ShelfCount a, ShelfCount b)
    {
        int byAisle = string.Compare(a.Aisle, b.Aisle, StringComparison.Ordinal);

        if (byAisle != 0)
        {
            return byAisle;
        }

        int byValue = b.ValueOnHand.CompareTo(a.ValueOnHand);

        if (byValue != 0)
        {
            return byValue;
        }

        return a.Slot.CompareTo(b.Slot);
    }
}