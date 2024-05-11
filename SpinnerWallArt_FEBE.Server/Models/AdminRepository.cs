using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class AdminRepository : IAdmin
    {
        private readonly IDbConnection _conn;

        public AdminRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _conn.Query<Users>("SELECT * FROM Users;");
            
        }
    }
}
