public class TodoConsoleAppRunner 
{
    public TodoConsoleAppRunner(IApplicationInteractor applicationInteractor, IUserActionHandler actionHandler)
    {
        _applicationInteractor = applicationInteractor;

        _actionHandler = actionHandler;
    }
    private readonly IApplicationInteractor _applicationInteractor;
    private readonly IUserActionHandler _actionHandler;
    public void Run()
    {
       
       _actionHandler.HandleUserActions();
    }
   
}
