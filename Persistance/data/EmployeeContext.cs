﻿using Application.Interface;
using Employer.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.data
{
    public class EmployeeContext : IEmployeeContext


    {
        
        public DbSet<Employee> Employees { get; set; }
    }
}
