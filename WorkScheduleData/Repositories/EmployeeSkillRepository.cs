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
        public IEnumerable<string> GetByEmployeeId(int id);

        public bool IsExisting(int EmployeeId, int skillId);
    }

    public class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(WorkScheduleContext context) : base(context)
        {
        }

        public IEnumerable<string> GetByEmployeeId(int id)
        {
            var employees = Context.EmployeeSkills.Join(Context.Skills,
                es => es.SkillsId,
                s => s.SkillsId,
                (es, s) => new
                {
                    Description = s.Description,
                    EmployeeId = es.EmployeeId,
                }).Where(e => e.EmployeeId == id);

            List<string> employeeList = new List<string>();
            foreach (var employee in employees)
            {
                employeeList.Add(employee.Description);
            }

            return employeeList;
        }

        public bool IsExisting(int EmployeeId, int skillId)
        {
            var isExist = Context.EmployeeSkills.Where(e => e.EmployeeId == EmployeeId && e.SkillsId == skillId).FirstOrDefault();
            if (isExist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}
