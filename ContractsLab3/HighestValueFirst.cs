namespace ContractsLab3;

/// <summary>
/// Compares shelf counts by value from highest to lowest.
/// </summary>
public class HighestValueFirst : IComparer<ShelfCount>
{
    /// <summary>
    /// Compares shelf counts by value using natural order to break ties.
    /// </summary>
    public int Compare(ShelfCount a, ShelfCount b)
    {
        int byValue = b.ValueOnHand.CompareTo(a.ValueOnHand);

        if (byValue != 0)
        {
            return byValue;
        }

        return a.CompareTo(b);
    }
}