using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operation.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
                {
                    new Employee() {Id=1, Name= "chirag", DateOfJoining=DateTime.Parse("20/10/2023"), Department="IT", Salary = 20000 },
                    new Employee() {Id=2, Name= "saurav", DateOfJoining=DateTime.Parse("20/10/2023"), Department="HR", Salary = 30000 },
                    new Employee() {Id=3, Name= "ajay", DateOfJoining=DateTime.Parse("20/10/2023"), Department="sales", Salary = 40000 },
                    

                };
            }
            
        }
       
        public IActionResult Index()
        {
        
            return View(list);
        }

        public IActionResult Add() { 
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee) { 
            list.Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Employee emp = list.Where(x => x.Id == id ).FirstOrDefault();
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                ViewBag.msg ="No record found";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            foreach(Employee emp in list)
            {
                if(emp.Id == employee.Id)
                {
                    emp.Name = employee.Name;
                    emp.Salary = employee.Salary;
                    emp.DateOfJoining = employee.DateOfJoining;
                    emp.Department = employee.Department;
                    break;
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }
        [HttpPost]
        public IActionResult Delete(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }


    }
}
