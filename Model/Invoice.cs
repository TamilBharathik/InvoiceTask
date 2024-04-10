using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendtask.Model
{
    public class Invoice
    {
    public Guid InvoiceNumber { get; set; }
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public decimal TotalAmount { get; set; }
    }
}