using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain
{
    public class TodoEntry
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public TodoEntry() { }
        public TodoEntry(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Description}|{CreatedAt:O}";
        }
        public string ToDisplayString()
        {
            return $"{Description} (added on {CreatedAt:dd MMM yyyy, HH:mm})";
        }

        
        public static TodoEntry? FromString(string line)
        {
            var parts = line.Split('|');
            if (parts.Length != 2) return null;

            if (DateTime.TryParse(parts[1], out var timestamp))
            {
                return new TodoEntry
                {
                    Description = parts[0],
                    CreatedAt = timestamp
                };
            }

            return null;
        }


    }
}
