using ASP.MongoDb.API.Entity;
using ASP.MongoDb.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ASP.MongoDb.API.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
      
    }
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
      

        public EmployeeRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {
         
        }

    }
}
