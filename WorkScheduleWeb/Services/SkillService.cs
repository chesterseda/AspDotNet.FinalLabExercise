using System.Collections.Generic;
using WorkScheduleData.Models;
using WorkScheduleData.Repositories;

namespace WorkScheduleWeb.Services
{
    public interface ISkillService
    {
        public Skill FindByPrimaryKey(int id);
        public IEnumerable<Skill> FindAll();
    }
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public Skill FindByPrimaryKey(int id)
        {
            return _skillRepository.FindByPrimaryKey(id);
        }

        public IEnumerable<Skill> FindAll()
        {
            return _skillRepository.FindAll();
        }

    }
}
