using Employer.Domain;
using Employer.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmployerRepository

    {
        List<Employee> GetAllEmployer();
    }
}
