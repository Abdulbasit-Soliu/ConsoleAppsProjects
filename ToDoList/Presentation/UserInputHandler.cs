public class UserInputHandler : IUserActionHandler
{
    private readonly ITodoService _todos;
    private readonly IApplicationInteractor _applicationInteractor;

    public UserInputHandler(ITodoService todos, IApplicationInteractor applicationInteractor)
    {
        _todos = todos;
        _applicationInteractor = applicationInteractor;
    }
    public void HandleUserActions()
    {
        bool exit = false;
        while (exit == false)
        {
            PrintHomePageMessage();
            var userInput = _applicationInteractor.GetInput();
            switch (userInput.ToUpperInvariant())
            {
                case "S":
                    _todos.SeeAll();
                    break;
                case "A":

                    _todos.Add();
                    break;
                case "R":

                    _todos.Remove();
                    break;
                case "E":

                    exit = true;
                    break;
                default:
                    _applicationInteractor.PrintMessage($"{userInput} is an Incorrect input");
                    break;
            }
        }
    }
    private void PrintHomePageMessage()
    {
        _applicationInteractor.PrintMessage(MessageTemplates.HomePageMessage());
    }
}