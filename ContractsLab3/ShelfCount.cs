namespace ContractsLab3;

/// <summary>
/// Represents one inventory shelf count identified by aisle and slot.
/// </summary>
public class ShelfCount : IEquatable<ShelfCount>, IComparable<ShelfCount>
{
    private string _aisle;
    private int _slot;
    private double _valueOnHand;

    /// <summary>
    /// Gets the aisle containing the counted shelf slot.
    /// </summary>
    public string Aisle
    {
        get { return _aisle; }
    }

    /// <summary>
    /// Gets the shelf slot number.
    /// </summary>
    public int Slot
    {
        get { return _slot; }
    }

    /// <summary>
    /// Gets the recorded dollar value on hand for this shelf count.
    /// </summary>
    public double ValueOnHand
    {
        get { return _valueOnHand; }
    }

    /// <summary>
    /// Creates a shelf count for one aisle and slot with its recorded value on hand.
    /// </summary>
    public ShelfCount(string aisle, int slot, double valueOnHand)
    {
        _aisle = aisle;
        _slot = slot;
        _valueOnHand = valueOnHand;
    }

    /// <summary>
    /// Determines whether two shelf counts have the same aisle and slot.
    /// </summary>
    public bool Equals(ShelfCount other)
    {
        if (other == null)
        {
            return false;
        }

        return string.Equals(Aisle, other.Aisle, StringComparison.Ordinal) && Slot == other.Slot;
    }

    /// <summary>
    /// Determines whether an object represents the same shelf count.
    /// </summary>
    public override bool Equals(object obj)
    {
        return Equals(obj as ShelfCount);
    }

    /// <summary>
    /// Returns a hash code based on the shelf count's aisle and slot.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Aisle, Slot);
    }

    /// <summary>
    /// Compares shelf counts by aisle and then slot.
    /// </summary>
    public int CompareTo(ShelfCount other)
    {
        if (other == null)
        {
            return 1;
        }

        int byAisle = string.Compare(Aisle, other.Aisle, StringComparison.Ordinal);

        if (byAisle != 0)
        {
            return byAisle;
        }

        return Slot.CompareTo(other.Slot);
    }

    /// <summary>
    /// Returns the formatted shelf count information.
    /// </summary>
    public override string ToString()
    {
        return String.Format("{0,-6} #{1} {2,8:N2}", Aisle, Slot, ValueOnHand);
    }
}