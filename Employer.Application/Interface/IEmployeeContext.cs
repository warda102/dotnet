using Employer.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
