using AssesmentTokenBased.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssesmentTokenBased.Controllers
{
    public class EmployeesController : ApiController
    {
        [Authorize]
        public IEnumerable<Employee> get()
        {
            using(EmployeesEntities db=new EmployeesEntities())
            {
                return db.Employees.ToList();
            }
        }
    }
}
