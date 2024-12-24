


int number = 5;
var John = new Person { Name = "John", Age = 34 };

Console.WriteLine("Number before: " + number); // 5
Console.WriteLine("John's Age before: " + John.Age); // 34

AddOneToNumber(number);
AddOneAgeToPerson(John);

Console.WriteLine("Number now: " + number); // 5 (Same)
Console.WriteLine("John's Age now: " + John.Age); // 35 (Changed)

Console.ReadLine();

void AddOneToNumber(int number)
{
    number++;
}

void AddOneAgeToPerson(Person person)
{
    person.Age++;
}

internal class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}