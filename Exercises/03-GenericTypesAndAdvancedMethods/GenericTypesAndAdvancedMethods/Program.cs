

var numbers = new ListOfInts();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(40);
numbers.Add(50);

numbers.RemoveAt(2);


Console.ReadKey();

// Implementation of int array.
class ListOfInts
{
    // Initial size is 4. (For example)
    // In real list it is 0.
    private int[] _items = new int[4];
    // Size is 0 by default.
    private int _size = 0;

    // Adds an integer to the integer list.
    public void Add(int item)
    { 
        // If there is no room for new item, double the size
        // of the list.
        if(_size >= _items.Length)
        {
            var newItems = new int[_items.Length * 2];

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

        // Last element is doubled (10,20,30,40,50) -> (10,20,40,50,50)
        // Just set it to 0 for simplicity. -> (10,20,40,50,0)
        _items[_size] = 0;
    }
}

