using System;
using DAL.Models;
using Newtonsoft.Json;

namespace DAL.Observers
{
    public class UpdateObserver<T> : IObserver<T>
        where T : BaseEntity
    {
        public void Update(T entity)
        {
            Console.WriteLine($"Updated entity: {JsonConvert.SerializeObject(entity)}");
        }
    }
}