using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleData.Data;
using WorkScheduleData.Models;

namespace WorkScheduleData.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public IEnumerable<Employee> FindAllActive();
    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(WorkScheduleContext context) : base(context)
        {
        }

        public IEnumerable<Employee> FindAllActive()
        {
            IQueryable<Employee> query = this.Context.Set<Employee>();
            return query.Select(e => e).Where(e => e.Active==true).ToList();
        }
    }
}
