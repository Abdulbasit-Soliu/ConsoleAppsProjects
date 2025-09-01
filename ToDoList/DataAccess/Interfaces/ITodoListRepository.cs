using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Interfaces
{
    public interface ITodoListRepository <TodoEntry>
    {
        void Save(List<TodoEntry> todosEntry);
        List<TodoEntry> Load();
    }
}
