using AssesmentTokenBased.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentTokenBased
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using(EmployeesEntities db=new EmployeesEntities())
            {
                return db.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}