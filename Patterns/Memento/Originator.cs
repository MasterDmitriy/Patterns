using System;
using DAL.Models;

namespace Patterns.Memento
{
    public class Originator
    {
        private readonly Category _category;

        public Originator(Category category)
        {
            _category = new Category { Id = category.Id, Name = category.Name };
        }

        public Category Save()
        {
            return new() {Id = _category.Id, Name = _category.Name};
        }

        public void Restore(Category memento)
        {
            _category.Name = memento.Name;
            Console.Write($"Originator: My name has changed to: {memento.Name}");
        }

        public void Update(string name)
        {
            _category.Name = name;
        }
    }
}