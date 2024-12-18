
// Collection of integers
var numbers = new SimpleList<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);

// Collection of strings
var words = new SimpleList<string>();
words.Add("aaa");
words.Add("bbb");
words.Add("ccc");

// Collection of DateTimes
var dates = new SimpleList<DateTime>();
dates.Add(new DateTime(2025, 1, 6));
dates.Add(new DateTime(2025, 1, 3));

Console.ReadKey();

// Implementation of generic type list.
class SimpleList<T>
{
    // Initial size is 4. (For example)
    // In real list it is 0.
    private T[] _items = new T[4];
    // Size is 0 by default.
    private int _size = 0;

    // Adds an integer to the integer list.
    public void Add(T item)
    { 
        // If there is no room for new item, double the size
        // of the list.
        if(_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for(int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        // Add the item and increment the size.
        _items[_size] = item;
        ++_size;
    }

    // Removes an element for given index.
    public void RemoveAt(int index)
    {
        // Check if it is in the bound.
        if(index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }

        // Decrease the size.
        --_size;

        // Shift elements to the left from given index.
        // So element for given index would be removed.
        for (int i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }

        // Last element is duplicated at the end.
        // Just set it to default for simplicity.
        // Since it is known that its type is T,
        // we can just write defualt instead of default(T).
        _items[_size] = default;
    }

    // Indexer method
    public T GetAtIndex(int index)
    {
        // Check if it is in the bound.
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }

        return _items[index];
    }
}

