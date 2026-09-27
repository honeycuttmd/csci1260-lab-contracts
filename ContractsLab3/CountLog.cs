namespace ContractsLab3;

/// <summary>
/// Writes shelf count records to a log file and manages cleanup.
/// </summary>
public class CountLog : IDisposable
{
    private StreamWriter _writer;
    private string _path;
    private int _count;
    private bool _isClosed;

    /// <summary>
    /// Gets the path of the log file.
    /// </summary>
    public string Path
    {
        get { return _path; }
    }

    /// <summary>
    /// Gets the number of shelf count records written.
    /// </summary>
    public int Count
    {
        get { return _count; }
    }

    /// <summary>
    /// Gets whether the log has been closed.
    /// </summary>
    public bool IsClosed
    {
        get { return _isClosed; }
    }

    /// <summary>
    /// Opens a log file for writing shelf count records.
    /// </summary>
    public CountLog(string path)
    {
        _path = path;
        _writer = new StreamWriter(path);
        _writer.WriteLine("LOG OPENED");
        _count = 0;
        _isClosed = false;
    }

    /// <summary>
    /// Writes a shelf count record to the log.
    /// </summary>
    public void Write(ShelfCount r)
    {
        _count++;

        _writer.WriteLine(String.Format("{0,3} {1}", Count, r));
    }

    /// <summary>
    /// Closes the log safely and writes the final line count.
    /// </summary>
    public void Dispose()
    {
        if (_isClosed)
        {
            return;
        }

        // Ensure the writer still closes if writing the footer fails.
        try
        {
            try
            {
                _writer.WriteLine(String.Format("LOG CLOSED, {0} lines written", Count));
            }
            finally
            {
                _writer.Close();
            }
        }
        catch
        {

        }

        _isClosed = true;
    }
}