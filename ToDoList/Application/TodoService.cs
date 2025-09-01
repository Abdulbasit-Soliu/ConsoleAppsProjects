using ToDoList.DataAccess.Interfaces;
using ToDoList.Domain;

namespace ToDoList.Application
{
    public class TodoService : ITodoService
    {

        private readonly IApplicationInteractor _applicationInteractor;
        private readonly TodoList _todoList;
        private readonly ITodoListRepository<TodoEntry> _todoRepository;
        private readonly string _filePath;
        public TodoService(IApplicationInteractor applicationInteractor, TodoList todoList, ITodoListRepository<TodoEntry> todoListRepository, string filePath)
        {
            _applicationInteractor = applicationInteractor;
            _todoList = todoList;
            _todoRepository = todoListRepository;
            _filePath = filePath;
        }
        public void Add()
        {

            bool isInputValid = false;
            while (!isInputValid)
            {
                _applicationInteractor.PrintMessage("Enter the TODO description:");
                var userInput = _applicationInteractor.GetInput();
                if (_todoList.Add(userInput))
                {

                    _applicationInteractor.PrintMessage($"TODO successfully added: {userInput}");
                    isInputValid = true;
                }
                else
                {
                    _applicationInteractor.PrintMessage("Invalid or duplicate TODO.");
                }

            }
            _todoRepository.Save(_todoList.Items.ToList());
        }

        public void Remove()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                _applicationInteractor.PrintMessage("Select the index of the TODO you want to remove:");
                SeeAll();

                if (_todoList.Items.Count == 0)
                {
                    break;
                }

                var userInput = _applicationInteractor.GetInput();
                if (!int.TryParse(userInput, out int userInputtedIndex))
                {
                    _applicationInteractor.PrintMessage("Invalid input. Please enter a number.");
                    continue;
                }

                int index = userInputtedIndex - 1;
                var removedItem = _todoList.Remove(index);

                if (removedItem != null)
                {
                    _applicationInteractor.PrintMessage($"TODO removed: {removedItem}");
                    isInputValid = true;
                }
                else
                {
                    _applicationInteractor.PrintMessage("Invalid or Empty Selected");
                }
            }

            _todoRepository.Save(_todoList.Items.ToList());

        }

        public void SeeAll()
        {
            int index = 0;
            var savedData = _todoRepository.Load();
            _todoList.SetItems(savedData);
            if (_todoList.Items.Count > 0)
            {
                foreach (var todo in _todoList.Items)
                {
                    index++;
                    _applicationInteractor.PrintMessage($"{index}. {todo.ToDisplayString()}");
                }
            }
            else
            {
                _applicationInteractor.PrintMessage("No TODOs have been added yet.");

            }

        }
    }
}