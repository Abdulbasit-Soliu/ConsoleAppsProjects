using System.Diagnostics.Metrics;

public class TodoItem : ITodoService
{
    private List<string> _todo = new List<string>();
    private readonly IApplicationInteractor _applicationInteractor;
    public TodoItem(IApplicationInteractor applicationInteractor)
    {
        _applicationInteractor = applicationInteractor;
    }
    public void Add()
    {

        bool isInputValid = false;
        while (!isInputValid)
        {
            _applicationInteractor.PrintMessage("Enter the TODO description:");
            var userInput = _applicationInteractor.GetInput();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                _applicationInteractor.PrintMessage("The description cannot be empty.");
            }
            else if (!_todo.Contains(userInput))
            {
                _applicationInteractor.PrintMessage("The description must be unique.");
            }
            else
            {
                _todo.Add(userInput);
                _applicationInteractor.PrintMessage($"TODO successfully added: {userInput}");
                isInputValid = true;
            }
        }
    }

    public void Remove()
    {
        bool isInputValid = false;
        while (!isInputValid)
        {
            _applicationInteractor.PrintMessage("Select the index of the TODO you want to remove:");
            SeeAll();
            if (_todo.Count == 0)
            {
                _applicationInteractor.PrintMessage("No TODOs have been added yet.");
                break;
            }
            var userInput = _applicationInteractor.GetInput();
            int userInputtedIndex;
            var convertSuccess = int.TryParse(userInput, out userInputtedIndex);
            if (!string.IsNullOrEmpty(userInput) || !string.IsNullOrWhiteSpace(userInput))
            {
                _applicationInteractor.PrintMessage("Selected index cannot be empty.");
            }
            else if (convertSuccess == false || userInputtedIndex <= 0 || userInputtedIndex > _todo.Count)
            {
                _applicationInteractor.PrintMessage("The given index is not valid.");
            }
            else
            {
                _todo.RemoveAt(userInputtedIndex - 1);
            }

        }



    }

    public void SeeAll()
    {
        int index = 0;
        if (_todo.Count > 0)
        {
            foreach (var todo in _todo)
            {
                index++;
                _applicationInteractor.PrintMessage($"{index}. {todo}");
            }
        }
        else
        {
            _applicationInteractor.PrintMessage("No TODOs have been added yet.");

        }

    }
}