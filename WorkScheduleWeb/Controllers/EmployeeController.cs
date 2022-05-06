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
        private readonly IEmployeeService _employeeService;

        private readonly ISkillService _skillService;

        private readonly IEmployeeSkillService _employeeSkillService;

        public EmployeeController(IEmployeeService employeeService, ISkillService skillService, IEmployeeSkillService employeeSkillService)
        {
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
            var employee = _employeeService.FindByPrimaryKey(id);
            employee.Active = false;
            _employeeService.Update(employee);
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
            var employee = _employeeService.FindByPrimaryKey(id);
            var skills = _skillService.FindAll();
            ViewData["skillList"] = _employeeSkillService.GetByEmployeeId(id);
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                Employee = employee,
                Skills = skills
            };
            return View("Form", employeeDTO);
        }
        public IActionResult AddSkill(string action, EmployeeDTO employeeDTO)
        {
            return Save(action, employeeDTO);
        }
        public IActionResult Save(string action, EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                employeeDTO.Employee.Active = true;
                if (action.ToLower().Equals("add"))
                {
                    _employeeService.Insert(employeeDTO.Employee);
                }
                else if (action.ToLower().Equals("edit") || action.ToLower().Equals("addskill"))
                {

                    _employeeService.Update(employeeDTO.Employee);
                    if(employeeDTO.SkillId != 0)
                    {
                        if (!_employeeSkillService.IsExisting(employeeDTO.Employee.EmployeeId, employeeDTO.SkillId))
                        {
                            EmployeeSkill employeeSkill = new EmployeeSkill()
                            {
                                EmployeeId = employeeDTO.Employee.EmployeeId,
                                SkillsId = employeeDTO.SkillId
                            };
                            _employeeSkillService.Insert(employeeSkill);
                        }
                        if (action.ToLower().Equals("addskill"))
                        {
                            ViewData["skillList"] = _employeeSkillService.GetByEmployeeId(employeeDTO.Employee.EmployeeId);
                            ViewData["Action"] = "Edit";
                            var skills = _skillService.FindAll();
                            employeeDTO.Skills = skills;
                            return View("Form", employeeDTO);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }


                    }
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
