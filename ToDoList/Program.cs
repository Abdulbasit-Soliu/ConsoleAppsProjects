using ToDoList.Application;
using ToDoList.DataAccess;
using ToDoList.Domain;

const string filePath = "Todos.txt";
var applicationInteractor = new ConsoleInteractor();
var todoList = new TodoList();
var repo = new StringsTextualRepository<TodoEntry>();
var todosRepo = new TodoListRepository<TodoEntry>(repo, filePath);
var todos = new TodoService(applicationInteractor, todoList, todosRepo, filePath);
var userActionHandler = new UserInputHandler(todos, applicationInteractor);


var todoApplication = new TodoConsoleAppRunner(applicationInteractor, userActionHandler);
try
{
    todoApplication.Run();
}
catch (Exception ex)
{
    // Log Exception
}

