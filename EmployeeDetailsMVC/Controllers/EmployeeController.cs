using EmployeeDetailsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using CommonLayer;
using BusinessLayer.Interface;
using System.Text;

namespace EmployeeDetailsMVC.Controllers
{

    public class EmployeeController : Controller
    {
        private IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        public IActionResult EmployeeList()
        {
            var empList = this.employeeBL.EmployeeList();
            return View(empList);
        }
        public IActionResult Create(Parent obj)
        {
            //loadDDL();
            return View(obj);
        }

        [HttpPost]
        public IActionResult AddEmployee(Parent employee)
        {


            try
            {
                bool insertEmployee = this.employeeBL.InsertEmployee(employee);
                if (insertEmployee == true)
                {
                    return RedirectToAction("EmployeeList");

                }
                else
                {
                    return RedirectToAction("Create", employee);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("EmployeeList");
            }
        }

        public IActionResult DeleteEmployee(Parent employee)
        {
            try
            {
                bool deleteEmployee = this.employeeBL.DeleteEmployee(employee);
                if (deleteEmployee == true)
                {
                    return RedirectToAction("EmployeeList");

                }
                else
                {
                    return RedirectToAction("EmployeeList", employee);
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("EmployeeList");
            }

        }

        //public async Task<IActionResult> DeleteEmp(int id)
        //{
        //    try
        //    {
        //        var std = await _Db.Employee.FindAsync(id);
        //        if (std != null)
        //        {
        //            _Db.Employee.Remove(std);
        //            await _Db.SaveChangesAsync();
        //        }

        //        return RedirectToAction("EmployeeList");
        //    }
        //    catch(Exception ex)
        //    {
        //        return RedirectToAction("EmployeeList");
        //    }
        //}

        //public ActionResult loadDDL()
        //{
            

        //    List<Departments> depList = new List<Departments>();
        //        //depList.Add(new Departments() { Id = 1, Department = "Hr", IsCheck = false });
        //        //depList.Add(new Departments() { Id = 2, Department = "Finance", IsCheck = false });
        //        //depList.Add(new Departments() { Id = 3, Department = "Sales", IsCheck = false });
        //        //depList.Add(new Departments() { Id = 4, Department = "Others", IsCheck = false });



        //    Departments departments = new Departments();
        //    departments.department = depList;
        //    return View(departments);

        //}

        //[HttpPost]
        //public ActionResult Create(Departments dp)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in dp.department)
        //    {
        //        if (item.IsCheck)
        //        {
        //            sb.Append(item.Department + ",");
        //        }
        //    }
        //    ViewBag.selectDepartment = "selected departments are" + sb.ToString();
        //    return View(dp);
        //}



    }
}
