using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain
{
    public class TodoList
    {

        private readonly List<TodoEntry> _items = new();

        public IReadOnlyList<TodoEntry> Items => _items;

        public bool Add(string description)
        {
            if (string.IsNullOrWhiteSpace(description) || _items.Any(x => x.Description == description))
                return false;

            _items.Add(new TodoEntry(description));
            return true;

        }
        public TodoEntry? Remove(int index)
        {
            if (index < 0 || index >= _items.Count)
                return null;

            var removed = _items[index];
            _items.RemoveAt(index);
            return removed;

        }

        public void SetItems(List<TodoEntry> entries)
        {
            _items.Clear();
            _items.AddRange(entries);
        }
    }
}
