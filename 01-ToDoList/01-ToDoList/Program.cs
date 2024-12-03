List<String> todoList = new List<String>();
string[] validOperations = ["S", "A", "R", "E"];
string userChoiceUpper;

do
{
    PrintIntro();

    userChoiceUpper = GetUserChoiceUpper();

    if(validOperations.Contains(userChoiceUpper))
    {
        HandleOption(userChoiceUpper, todoList);
    }
    else
    {
        Console.WriteLine("Incorrect input");
    }
}
while (userChoiceUpper != "E");



void PrintIntro()
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

string GetUserChoiceUpper()
{
    string userChoice = Console.ReadLine();
    return userChoice.ToUpper();
}


void HandleOption(string userChoiceUpper, List<string> todoList)
{
    

    switch(userChoiceUpper)
    {
        case "S":
            ShowTodos(todoList);
            break;
        case "A":
            AddTodo(todoList);
            break;
        case "R":
            RemoveTodo(todoList);
            break;
        case "E":
            Exit(todoList);
            break;
    }
    

}

void Exit(List<string> todoList)
{
    Console.WriteLine("Thanks for using the todo list app.");
    Console.WriteLine("Have a nice day!");
}

void RemoveTodo(List<string> todoList)
{
    if(todoList.Count == 0)
    {
        Console.WriteLine("No TODOS have been added yet.");
        return;
    }

    int removeTodoIndex = getRemoveTodoIndexInput(todoList);
    string desciptionOfRemovedTodo = todoList[removeTodoIndex];
    todoList.RemoveAt(removeTodoIndex);
    Console.WriteLine($"TODO removed: {desciptionOfRemovedTodo}");
}

int getRemoveTodoIndexInput(List<string> todoList)
{

    bool isValidIndex = false;
    string removeTodoIndexInput = "";

    int removeTodoIndex = todoList.Count;
    bool isRemoveTodoIndexParsed = false;

    while (!isValidIndex)
    {
        ShowTodos(todoList);
        Console.WriteLine("Select the index of the TODO you want to remove: ");
        removeTodoIndexInput = Console.ReadLine();

        if (removeTodoIndexInput.Length == 0)
        {
            Console.WriteLine("Selected index cannot be empty.");
            continue;
        }
        
        
        isRemoveTodoIndexParsed = int.TryParse(removeTodoIndexInput, out removeTodoIndex);

        if (!isRemoveTodoIndexParsed || removeTodoIndex >= todoList.Count || removeTodoIndex < 0)
        {
            Console.WriteLine("The given index is not valid.");
            continue;
        }

        isValidIndex = true;
        
    }

    return removeTodoIndex;
}

void AddTodo(List<string> todoList)
{
    string addTodoInput = getAddTodoInput(todoList);
    todoList.Add(addTodoInput);
    Console.WriteLine($"TODO successfully added: {addTodoInput}");

}

string getAddTodoInput(List<string> todoList)
{

    bool isValidDescription = false;
    string addTodoInput = "";

    while (!isValidDescription)
    {
        Console.WriteLine("Enter the TODO description: ");
        addTodoInput = Console.ReadLine();

        if (addTodoInput.Length == 0)
        {
            Console.WriteLine("The description cannot be empty.");
            continue;
        }

        if (todoList.Contains(addTodoInput))
        {
            Console.WriteLine("The description must be unique.");
            continue;
        }

        isValidDescription = true;
    }
    
    return addTodoInput;
}

void ShowTodos(List<string> todoList)
{
    if(todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }

    foreach(string todo in todoList)
    {
        Console.WriteLine($"{todoList.IndexOf(todo) + 1}. {todo}");
    }
}




