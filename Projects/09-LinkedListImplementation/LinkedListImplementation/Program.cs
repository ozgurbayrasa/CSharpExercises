// See https://aka.ms/new-console-template for more information

using LinkedListImplementation.LinkedListModel;

var list = new SinglyLinkedList<string>();

list.AddToFront("a");
list.AddToFront("b");
list.AddToFront("c");

list.Add("e");
list.Add("f");

list.Remove("b");
list.Remove("f");

Console.WriteLine("Contains b?" + list.Contains("b"));
Console.WriteLine("Contains e?" + list.Contains("e"));

foreach (var item in list)
{
    Console.Write(item + " --> ");
}

Console.ReadKey();
