using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Domain;

namespace ToDoList.DataAccess
{
    public class TodoListRepository<TodoEntry> : ITodoListRepository<TodoEntry>
    {
        private readonly IStringsRepository<TodoEntry> _stringsRepository;
        private readonly string _filePath;
        public TodoListRepository(IStringsRepository<TodoEntry> stringsRepository, string filePath) 
        {
            _stringsRepository = stringsRepository;
            _filePath = filePath;
        }
        public List<TodoEntry> Load()
        {
            return _stringsRepository.Read(_filePath).ToList();
        }

        public void Save(List<TodoEntry> todos)
        {
            _stringsRepository.Write(_filePath, todos);
        }

       
       
    }
}
