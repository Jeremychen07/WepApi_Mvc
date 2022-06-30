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


  }
}
