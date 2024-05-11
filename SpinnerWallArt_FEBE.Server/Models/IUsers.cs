using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface IUsers
    {
        public Response Register(Users users, MySqlConnection conn);
        public Response Login(Users users, MySqlConnection conn);
        public Response UserView(Users users, MySqlConnection conn);
        public Response ProfileUpdate(Users users, MySqlConnection conn);
    }
}
