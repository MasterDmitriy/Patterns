using System;
using DAL.Models;
using Newtonsoft.Json;

namespace DAL.Observers
{
    public class RemoveObserver<T> : IObserver<T>
        where T : BaseEntity
    {
        public void Update(T entity)
        {
            Console.WriteLine($"Removed entity: {JsonConvert.SerializeObject(entity)}");
        }
    }
}