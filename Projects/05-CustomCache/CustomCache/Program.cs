// Both printing and cachiing decorator used.
IDataDownloader dataDownloader = new PrintingDataDownloader(
    new CachingDataDownloder(
        new SlowDataDownloader()));

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId) 
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class Cache<TKey, TData>  
{
    public TKey Key;
    public TData Value;

    private readonly Dictionary<TKey, TData> _cache = new();

    // Cache class doesn't need to know how fetching mechanism works.
    // It is only needed to know it should hava a method that return TData type
    // from TKey type.
    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime)
    {
        // If it is not cached, retrieve data and save it to cache.
        if (!_cache.ContainsKey(key))
        {
            _cache[key] = getForTheFirstTime(key);
        }
        return _cache[key];
    }
}

// This class is only responsible for using cache when downloding.
public class CachingDataDownloder : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly Cache<string, string>_cache = new();

    public CachingDataDownloder(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        // We only need to pass download data method.
        return _cache.Get(resourceId, _dataDownloader.DownloadData);
    }
}

// This class is only responsible for using print when downloding.
public class PrintingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;

    public PrintingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        var data = _dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready!");
        return data;
    }
}
