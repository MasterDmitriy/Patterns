using System;
using DAL.Models;
using Newtonsoft.Json;

namespace DAL.Observers
{
    public class InsertObserver<T> : IObserver<T>
        where T : BaseEntity
    {
        public void Update(T entity)
        {
            Console.WriteLine($"Inserted entity: {JsonConvert.SerializeObject(entity)}");
        }
    }
}