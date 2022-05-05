using System.Collections.Generic;
using WorkScheduleData.Models;
using WorkScheduleData.Repositories;

namespace WorkScheduleWeb.Services
{
    public interface IEmployeeSkillService
    {
        public EmployeeSkill Insert(EmployeeSkill employeeSkill);

        public IEnumerable<string> GetByEmployeeId(int id);

        public bool IsExisting(int EmployeeId, int skillId);
    }
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;

        public EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }

        public EmployeeSkill Insert(EmployeeSkill employeeSkill)
        {
            return _employeeSkillRepository.Insert(employeeSkill);
        }

        public IEnumerable<string> GetByEmployeeId(int id)
        {
            return _employeeSkillRepository.GetByEmployeeId(id);
        }

        public bool IsExisting(int EmployeeId, int skillId)
        {
            return _employeeSkillRepository.IsExisting(EmployeeId, skillId);
        }
    }
}
