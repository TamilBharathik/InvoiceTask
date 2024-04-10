using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using backendtask.Model;
using System.Data;
using backendtask.Repo;
using backendtask.Repositories;
public class InvoiceRepository : IInvoiceRepository
{
    private readonly string? _connectionString;

    public InvoiceRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }

    public void CreateInvoice(Invoice invoice)
    {
        using (var connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            connection.Execute("invoice_pkg.create_invoice",
                new
                {
                    p_invoice_number = invoice.InvoiceNumber,
                    p_department_id = invoice.DepartmentId,
                    p_department_name = invoice.DepartmentName,
                    p_total_amount = invoice.TotalAmount
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
