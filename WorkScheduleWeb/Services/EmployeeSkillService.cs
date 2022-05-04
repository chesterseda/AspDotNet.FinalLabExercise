using System.Collections.Generic;
using WorkScheduleData.Models;
using WorkScheduleData.Repositories;

namespace WorkScheduleWeb.Services
{
    public interface IEmployeeSkillService
    {
        //public EmployeeSkill FindByPrimaryKey(int id);

        public EmployeeSkill Update(EmployeeSkill employeeSkill);

        public void SaveChanges();
    }
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        public EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }
        //public Skill FindByPrimaryKey(int id)
        //{
        //    return _employeeSkillRepository.FindByPrimaryKey(id);
        //}

        public EmployeeSkill Update(EmployeeSkill employeeSkill)
        {
           return _employeeSkillRepository.Update(employeeSkill);
        }

        public void SaveChanges()
        {
            _employeeSkillRepository.SaveChanges();
        }
    }
}
