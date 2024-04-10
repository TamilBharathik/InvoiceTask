using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace backendtask.Context
{
    public class DapperDBContext
     {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperDBContext(IConfiguration _configuration) {
            this._configuration = _configuration ?? throw new ArgumentException(nameof(_configuration));
            this.connectionstring = this._configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("Connection string is null.");;
            
        }

        public object Product { get; internal set; }= new object(); 


         public IDbConnection CreateConnection() => new OracleConnection(connectionstring);
    }
}