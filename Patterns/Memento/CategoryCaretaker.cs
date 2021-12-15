using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Repositories;
using Patterns.Factories;

namespace Patterns.Memento
{
    public class CategoryCaretaker
    {
        private List<Category> _mementos = new();
        private Originator _originator = null;

        private readonly IRepository<Category> _repository;

        public CategoryCaretaker(Originator originator, IRepositoryFactory repositoryFactory)
        {
            _originator = originator;
            _repository = repositoryFactory.CategoryRepository;
        }

        public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            var category = _originator.Save();
            _repository.Update(category);
            _mementos.Add(category);
        }

        public void Undo()
        {
            if (!_mementos.Any())
            {
                return;
            }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.WriteLine("\nCaretaker: Restoring state to: " + memento.Name);

            var isExist = _repository.GetById(memento.Id) != null;

            if (isExist)
            {
                _originator.Restore(memento);
                _repository.Update(memento);
            }
        }
    }
}