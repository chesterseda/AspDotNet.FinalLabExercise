using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleData.Data;
using WorkScheduleData.Models;

namespace WorkScheduleData.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
    }

    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(WorkScheduleContext context) : base(context)
        {
        }
    }
}
