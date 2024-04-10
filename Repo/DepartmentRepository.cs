using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using backendtask.Model;
using backendtask.Repositories;

namespace backendtask.Repo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string? _connectionString;

    public DepartmentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }

    public void CreateDepartment(Department department)
    {
        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            connection.Execute("department_pkg.create_department",
                new
                {
                    p_department_id = department.DepartmentId,
                    p_department_name = department.DepartmentName
                },
                commandType: CommandType.StoredProcedure);
        }
    }
    }
}