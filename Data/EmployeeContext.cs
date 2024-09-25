using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDbContext")
        {
        }
        public DbSet<Model.Employee> Employees { get; set; }
    }
}
