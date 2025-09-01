using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Domain;

namespace ToDoList.DataAccess
{
    public abstract class StringsRepository<T> : IStringsRepository<T>
    {
        protected abstract List<T> TextToTODOEntries(string data);
        protected abstract string ToDoEntriesToText(List<T> data);


        public List<T> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileData = File.ReadAllText(filePath);
                return TextToTODOEntries(fileData);
            }
            return new List<T>();

        }

       
        public void Write(string filePath, List<T> entries)
        {

            File.WriteAllText(filePath, ToDoEntriesToText(entries));


        }
    }
}
