using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.DataAccess
{
    public class StringsTextualRepository<T> : StringsRepository<T>
    {
        private readonly string _seperator = Environment.NewLine;
        protected override List<T> TextToTODOEntries(string data)
        {
            var lines = data.Split(_seperator, StringSplitOptions.RemoveEmptyEntries);
            var entries = new List<TodoEntry>();

            foreach (var line in lines)
            {
                var entry = TodoEntry.FromString(line);
                if (entry != null)
                    entries.Add(entry);
            }

            return entries.Cast<T>().ToList();

        }

        protected override string ToDoEntriesToText(List<T> data)
        {
            return string.Join(_seperator, data.Select(e => e.ToString()));

        }
    }
}
