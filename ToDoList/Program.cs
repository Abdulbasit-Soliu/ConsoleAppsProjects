var applicationInteractor = new ConsoleInteractor();
var todos = new TodoItem(applicationInteractor);
var userActionHandler = new UserInputHandler(todos,applicationInteractor);


var todoApplication = new TodoConsoleAppRunner(applicationInteractor, userActionHandler);
try
{
    todoApplication.Run();
}catch (Exception ex)
{
    // Log Exception
}

