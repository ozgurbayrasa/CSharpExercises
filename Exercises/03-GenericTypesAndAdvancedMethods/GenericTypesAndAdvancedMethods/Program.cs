
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
}


Console.ReadKey();