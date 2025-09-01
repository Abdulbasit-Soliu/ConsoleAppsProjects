using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Interfaces
{
   public interface IStringsRepository <T>
    {
        List<T> Read(string filePath);
        void Write (string filePath, List<T> entries);
    }
}
