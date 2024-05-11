using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class UsersRepository : IUsers
    {

        private readonly IDbConnection _conn;

        public UsersRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public Response Login(Users users, MySqlConnection conn)
        {
            return (Response)_conn.Query<Users>("SELECT * FROM spinnerprints.users WHERE Password = {Users} AND Email = {Users} = @ ;");
        }

        public Response ProfileUpdate(Users users, MySqlConnection conn)
        {
            throw new NotImplementedException();
        }

        public Response Register(Users users, MySqlConnection conn)
        {
            throw new NotImplementedException();
        }

        public Response UserView(Users users, MySqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
