using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkScheduleData.Models;
using WorkScheduleData.Repositories;
using WorkScheduleWeb.Models;
using WorkScheduleWeb.Services;

namespace WorkScheduleWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;

        private readonly IEmployeeService _employeeService;

        private readonly ISkillService _skillService;

        private readonly IEmployeeSkillService _employeeSkillService;

        public EmployeeController(IEmployeeRepository employeeRepository,IEmployeeService employeeService, ISkillService skillService, IEmployeeSkillService employeeSkillService)
        {
            this.employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _skillService = skillService;
            _employeeSkillService = employeeSkillService;
        }
        public IActionResult Index()
        {
            var employeeList = _employeeService.FindAllActive().ToList();
            return View(employeeList);
        }

        public IActionResult Delete(int id)
        {
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            employee.Active = false;
            employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewData["Action"] = "Add";
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                Employee = new Employee()
            };
            return View("Form", employeeDTO);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            var skills = _skillService.FindAll();
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                Employee = employee,
                Skills = skills
            };
            return View("Form", employeeDTO);
        }

        public IActionResult Save(string action, EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                employeeDTO.Employee.Active = true;
                if (action.ToLower().Equals("add"))
                {
                    employeeRepository.Insert(employeeDTO.Employee);
                }
                else if (action.ToLower().Equals("edit"))
                {
                    employeeRepository.Update(employeeDTO.Employee);

                    foreach (var skill in employeeDTO.Skills)
                    {
                        EmployeeSkill employeeSkill = new EmployeeSkill()
                        {
                            EmployeeId = employeeDTO.Employee.EmployeeId,
                            SkillsId = skill.SkillsId
                        };

                        _employeeSkillService.Update(employeeSkill);
                    }
                    _employeeSkillService.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", employeeDTO.Employee);
            }
        }
    }
}
