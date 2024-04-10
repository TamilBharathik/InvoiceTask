using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backendtask.Model;

namespace backendtask.Repositories
{
    public interface IDepartmentRepository
    {
        void CreateDepartment(Department department);
        // You can define other methods for department management here
    }
}
