using System.Collections.Generic;
using WorkScheduleData.Models;

namespace WorkScheduleWeb.Models
{
    public class EmployeeDTO
    {
        public Employee Employee { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
