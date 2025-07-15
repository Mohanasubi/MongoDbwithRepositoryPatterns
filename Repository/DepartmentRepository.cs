using ASP.MongoDb.API.Entity;
using ASP.MongoDb.API.Settings;
using Microsoft.Extensions.Options;

namespace ASP.MongoDb.API.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        // Additional methods specific to Department can be added here
       
    }
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {


        public DepartmentRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {

        }

    }
}
