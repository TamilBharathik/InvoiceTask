using Dapper;
using System.Data;
using backendtask.Context;
using backendtask.Model;
using Oracle.ManagedDataAccess.Client;
using Dapper.Oracle;


namespace backendtask.Repo
{
public class ProductRepo : IProductRepo
    {
        private readonly DapperDBContext context;

        public ProductRepo(DapperDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


// public async Task<string> Create(Product entry)
// {
//     string response = string.Empty;
//     string query = "INSERT INTO tb (ProductID, ProductName, country, InvoicePeriod, ScrapType, ManCost, MaterialCost, EstimateCost, LocalAmount) VALUES (:ProductID, :ProductName, :country, :InvoicePeriod, :ScrapType, :ManCost, :MaterialCost, :EstimateCost, :LocalAmount)";
//     var parameters = new
//     {
// entry.ProductID,
// entry.ProductName,
// entry.country,
// entry.InvoicePeriod,
// entry.ScrapType,
// entry.ManCost,
// entry.MaterialCost,
// entry.EstimateCost,
// entry.LocalAmount

//     };

//     using (var connection = this.context.CreateConnection())
//     {
//         await connection.ExecuteAsync(query, parameters);
//         response = "Data is created and stored in the database table";
//     }

//     return response;
// }

// public async Task<string> Create(Product entry)
// {
//     string response = string.Empty;
//     using (var connection = new OracleConnection("Default"))
//     {
//         var parameters = new OracleDynamicParameters();
//         parameters.Add("ProductID", entry.ProductID);
//         parameters.Add("ProductName", entry.ProductName);
//         parameters.Add("Country", entry.country);
//         parameters.Add("InvoicePeriod", entry.InvoicePeriod);
//         parameters.Add("ScrapType", entry.ScrapType);
//         parameters.Add("ManCost", entry.ManCost);
//         parameters.Add("MaterialCost", entry.MaterialCost);
//         parameters.Add("EstimateCost", entry.EstimateCost);
//         parameters.Add("LocalAmount", entry.LocalAmount);
//         parameters.Add("Image", entry.Image);

//         await connection.ExecuteAsync("TB_PACKAGE.insert_record", parameters, commandType: CommandType.StoredProcedure);
        
//         response = "Data is created and stored in the database table";
//     }

//     return response;
// }

public async Task<string> Create(Product entry)
{
    string response = string.Empty;
    
    try
    {
        using (var con = new OracleConnection("Default"))
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add("productID_in", entry.ProductID);
            parameters.Add("productName_in", entry.ProductName);
            parameters.Add("COUNTRY_in", entry.country);
            parameters.Add("INVOICEPERIOD_in", entry.InvoicePeriod);
            parameters.Add("SCRAPTYPE_in", entry.ScrapType);
            parameters.Add("MANCOST_in", entry.ManCost);
            parameters.Add("MATERIALCOST_in", entry.MaterialCost);
            parameters.Add("ESTIMATECOST_in", entry.EstimateCost);
            parameters.Add("LOCALAMOUNT_in", entry.LocalAmount);
            parameters.Add("Image_in", entry.Image);

            await con.ExecuteAsync("TB_PACKAGE.insert_record", parameters, commandType: CommandType.StoredProcedure);
            response = "Data is created and stored in the database table";
        }
    }
    catch (Exception ex)
    {
        response = $"An error occurred while inserting the product: {ex.Message}";
    }

    return response;
}

public async Task<List<Product>> GetAll()
{
    string query = "select * from tb";
    using (var connection = this.context.CreateConnection())
    {
        var list = await connection.QueryAsync<Product>(
            query
        );
        return list.ToList();
    }
}



public async Task<Product?> Getbycode(int ProductID)
{
    string query = "SELECT * FROM tb WHERE ProductID = :ProductID"; 
    using (var connection = this.context.CreateConnection())
    {
        var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { ProductID });
        return product;
    }
}


public async Task<string> Remove(int ProductID)
{
    string response = string.Empty;
    string query = "DELETE FROM tb WHERE ProductID = :ProductID";
    
    using (var connection = this.context.CreateConnection())
    {
        await connection.ExecuteAsync(query, new { ProductID = ProductID });
        response = "Deleted Successfully";
    }
    return response;
}


public async Task<string> Update(Product Entry, int ProductID)
{
    string response = string.Empty;
    string query = "UPDATE TB SET productName = :productName, country = :country, invoicePeriod = :invoicePeriod, scrapType = :scrapType, manCost = :manCost, materialCost = :materialCost, estimateCost = :estimateCost, localAmount = :localAmount WHERE productID = :productID";
    
    var parameters = new DynamicParameters();
parameters.Add("ProductID", Entry.ProductID, DbType.Int32);
parameters.Add("ProductName", Entry.ProductName, DbType.String);
parameters.Add("Country", Entry.country, DbType.String);

parameters.Add("InvoicePeriod", Entry.InvoicePeriod, DbType.String);
parameters.Add("ScrapType", Entry.ScrapType, DbType.String);

parameters.Add("ManCost", Entry.ManCost, DbType.Decimal);
parameters.Add("MaterialCost", Entry.MaterialCost, DbType.Decimal);
parameters.Add("EstimateCost", Entry.EstimateCost, DbType.Decimal);
parameters.Add("LocalAmount", Entry.LocalAmount, DbType.Decimal);

 
    
    using (var connection = this.context.CreateConnection())
    {
        await connection.ExecuteAsync(query, parameters);
        response = "Your requirements are updated successfully";
    }
    return response;
}

        Task<string> IProductRepo.Create(Product Entry)
        {
            throw new NotImplementedException();
        }
    }
}