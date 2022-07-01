using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TEmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public TEmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }
     
        [HttpGet]
		    public List<TEmployee> Get()
		    {
			    return _context.TEmployees.ToList();
		    }

        [HttpGet("{fEmpId}")]
        public TEmployee Get(string fEmpId)
        {
          var tEmployees = _context.TEmployees
            .FirstOrDefault(m => m.FEmpId == fEmpId);
          return tEmployees;
        }
				[HttpPost]
				public int Post(TEmployee tEmployee)
				{
					int num = 0;
					try
					{
						_context.TEmployees.Add(tEmployee);
						num = _context.SaveChanges();
					}
					catch (Exception ex)
					{
						num = 0;
					}
					return num;
				}
				[HttpDelete("{fEmpId}")]
				public int Delete(string fEmpId)
				{
					int num = 0;
					try
					{
						var tEmployee = _context.TEmployees
							.FirstOrDefault(m => m.FEmpId == fEmpId);
						_context.TEmployees.Remove(tEmployee);
						num = _context.SaveChanges();
					}
					catch (Exception ex)
					{
						num = 0;
					}
					return num;
				}
				[HttpPut]
				public int Put(TEmployee tEmployee)
				{
					int num = 0;
					try
					{
						var employee = _context.TEmployees
							.FirstOrDefault(m => m.FEmpId == tEmployee.FEmpId);
						if (employee == null)
						{
							return 0;
						}
						employee.FName = tEmployee.FName;
						employee.FGender = tEmployee.FGender;
						employee.FMail = tEmployee.FMail;
						employee.FSalary = tEmployee.FSalary;
						num = _context.SaveChanges();
					}
					catch (Exception ex)
					{
						num = 0;
					}
					return num;
				}
	}
}
