using WorkScheduleData.Repositories;
using WorkScheduleData.Models;
using System.Collections.Generic;

namespace WorkScheduleWeb.Services
{
    public interface IEmployeeService
    {
        public Employee Update(Employee employee);

        public Employee Insert(Employee employee);

        public Employee FindByPrimaryKey(int id);
        public IEnumerable<Employee> FindAll();

        public IEnumerable<Employee> FindAllActive();
    }
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee FindByPrimaryKey(int id)
        {
            return _employeeRepository.FindByPrimaryKey(id);
        }

        public IEnumerable<Employee> FindAll()
        {
            return _employeeRepository.FindAll();
        }

        public IEnumerable<Employee> FindAllActive()
        {
            return _employeeRepository.FindAllActive();
        }

        public Employee Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }

        public Employee Insert(Employee employee)
        {
            return _employeeRepository.Insert(employee);
        }
    }
}
