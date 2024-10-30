using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07DataAccess.Services
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;

        public DatabaseConnectionService()
        {
            _connectionString = "Server=localhost;Database=test1;User ID=testuser;Password=testuser";
        }

        public string GetConnectionString()

        { 
            return _connectionString; 
        }

    }
}
