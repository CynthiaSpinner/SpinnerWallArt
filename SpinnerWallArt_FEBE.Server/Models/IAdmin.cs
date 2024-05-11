using System;
using System.Collections.Generic;
using SpinnerWallArt_FEBE.Server.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;


namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface IAdmin
    {
        public string GetAllUsers();
    }
}
