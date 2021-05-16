using Dapper;
using HospitalWaitTimes.Helpers;
using Npgsql;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Services
{
    public class AWSService
    {
        private AWSDatabaseConfig _awsConfig;
        private readonly IDbConnection _conn;
        public AWSService(AWSDatabaseConfig awsConfig)
        {
            _awsConfig = awsConfig;
            _conn = GetDbConnection();
        }

        public IDbConnection GetDbConnection()
        {
            return new NpgsqlConnection(_awsConfig.GetPGSQLConnectionString());
        }

        public async Task DropIllnessEntryTable()
        {
            await _conn.QueryAsync(@$"DROP TABLE IF EXISTS illness_entry;");
        }

        public async Task CreateIllnessEntryTable()
        {
            await _conn.QueryAsync(@$"CREATE TABLE illness_entry (
	                                                        id serial PRIMARY KEY,
	                                                        illness_name VARCHAR (100) UNIQUE NOT NULL,
	                                                        full_name VARCHAR (200) NOT NULL,
	                                                        created_on DATE NOT NULL
                                                        );");
        }

        public async Task InsertUserIllnessEntry(string illnessName, string fullName)
        {
            await _conn.QueryAsync(@$"INSERT INTO illness_entry (illness_name, full_name, created_on)
                                                            VALUES ('{Helper.StripInvalidCharacters(illnessName)}',
                                                                        '{Helper.StripInvalidCharacters(fullName)}', now());");
        }

        public class AWSDatabaseConfig
        {
            public string _hostname, _databasename, _username, _password, _port;
            public AWSDatabaseConfig(string hostname, string databasename, string username, string password, string port)
            {
                _hostname = hostname;
                _databasename = databasename;
                _username = username;
                _password = password;
                _port = port;
            }
            public string GetPGSQLConnectionString()
            {
                return $"Host={ _hostname};Port={_port};Username={_username};Password={_password};Database={_databasename}";
            }
        }
    }
}
