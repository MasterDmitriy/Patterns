using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public class SingletonContext
    {
        private static SportEquipmentContext _context;
        private static readonly DbContextOptions<SportEquipmentContext> DbContextOptions;

        static SingletonContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SportEquipmentContext>();

            DbContextOptions = optionsBuilder.UseMySql(
                "server=127.0.0.1;user=root;password=Killer916$;database=sportDb;")
                .Options;
        }

        public static SportEquipmentContext Context => _context ??= new SportEquipmentContext(DbContextOptions);
    }
}