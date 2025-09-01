using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList.DataAccess
{
    public class StringsJsonRepository<T> : StringsRepository<T>
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        protected override string ToDoEntriesToText(List<T> data)
        {
            return JsonSerializer.Serialize(data,_options);
        }

        protected override List<T> TextToTODOEntries(string data)
        {
            return JsonSerializer.Deserialize<List<T>>(data, _options)!;
        }
    }
}
