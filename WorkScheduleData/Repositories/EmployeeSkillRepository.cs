using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkScheduleData.Data;
using WorkScheduleData.Models;

namespace WorkScheduleData.Repositories
{
    public interface IEmployeeSkillRepository : IBaseRepository<EmployeeSkill>
    {
        public void SaveChanges();

        public EmployeeSkill Update(EmployeeSkill entity);
    }

    public class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(WorkScheduleContext context) : base(context)
        {
        }

        public EmployeeSkill Update(EmployeeSkill entity)
        {

            this.Context.Attach<EmployeeSkill>(entity);


            this.Context.Entry<EmployeeSkill>(entity).State = EntityState.Modified;
            return entity;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }


}
