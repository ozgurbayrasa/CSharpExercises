// See https://aka.ms/new-console-template for more information

using LinkedListImplementation.LinkedListModel;

var list = new SinglyLinkedList<string>();

list.AddToFront("a");
list.AddToFront("b");
list.AddToFront("c");

foreach (var item in list)
{
    Console.Write(item + " --> ");
}

Console.ReadKey();
