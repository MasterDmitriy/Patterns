using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DAL.Models;
using Newtonsoft.Json;
using Patterns.Builders;
using Patterns.Factories;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var factory = new RepositoryFactory();

            //WorkWithBrandType(factory);
            WorkWithBrand(factory);


        }

        private static void WorkWithBrand(IRepositoryFactory factory)
        {
            var brandRepository = factory.BrandRepository;
            var brandBuilder = new BrandBuilder();
            brandBuilder.AddName("brand name").AddBrandTypeId(1);

            var addedEntity = brandRepository.Add(brandBuilder.Build());
            Console.WriteLine("Added entity");
            Console.WriteLine(JsonConvert.SerializeObject(addedEntity));

            var brands = brandRepository.GetAll(brand => brand.BrandType).ToList();
            Console.WriteLine("All entities");
            Console.WriteLine(JsonConvert.SerializeObject(brands));
        }

        private static void WorkWithBrandType(IRepositoryFactory factory)
        {
            var brandTypeRepository = factory.BrandTypeRepository;
            var brandTypeBuilder = new BrandTypeBuilder();
            brandTypeBuilder.AddName("brand type name6").AddBrand(new Brand { Name = "brand name3" }).AddBrand(new Brand { Name = "brand name4" });

            var addedEntity = brandTypeRepository.Add(brandTypeBuilder.Build());
            Console.WriteLine("Added entity");
            Console.WriteLine(JsonConvert.SerializeObject(addedEntity));

            var brandTypes = brandTypeRepository.GetAll(brandType => brandType.Brands).ToList();
            Console.WriteLine("All entities");
            Console.WriteLine(JsonConvert.SerializeObject(brandTypes));

            brandTypeRepository.DeleteById(addedEntity.Id);
            brandTypes = brandTypeRepository.GetAll(brandType => brandType.Brands).ToList();
            Console.WriteLine("All entities after delete");
            Console.WriteLine(JsonConvert.SerializeObject(brandTypes));

            var entityBeforeUpdate = brandTypeRepository.GetById(brandTypes[1].Id);
            Console.WriteLine("Entity before update");
            Console.WriteLine(JsonConvert.SerializeObject(entityBeforeUpdate));

            entityBeforeUpdate.Name = "updated brand type";
            brandTypeRepository.Update(entityBeforeUpdate);
            var entityAfterUpdate = brandTypeRepository.GetById(entityBeforeUpdate.Id);
            Console.WriteLine("Entity after update");
            Console.WriteLine(JsonConvert.SerializeObject(entityAfterUpdate));
        }

        private static void Print<T>(T input)
        {
            var type = input.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType)
                {
                    var value = property.GetValue(input, null);
                    if (value is IList list)
                    {
                        foreach (var listValue in list)
                        {
                            Print(listValue);
                        }
                    }
                }

                Console.WriteLine($"{property.Name} = {property.GetValue(input)}");
            }
        }
    }
}
