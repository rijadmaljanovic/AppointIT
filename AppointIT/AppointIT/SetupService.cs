using Microsoft.EntityFrameworkCore;
using System.IO;
using AppointIT.Services.Database;


namespace AppointIT
{
    public class SetupService
    {
        public void Init(MyContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(MyContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "dataSeed.sql");
            var query = File.ReadAllText(path);



            context.Database.ExecuteSqlRaw(query);
        }
    }
}