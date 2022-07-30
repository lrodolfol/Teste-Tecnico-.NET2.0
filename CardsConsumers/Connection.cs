using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CadsManagerLib.Models;
using CardsManagerLib.Models.Data.Dtos;
using MySql.Data.MySqlClient;

namespace CardsConsumers
{

    public class Connection
    {
        static string connString;
        static DbProviderFactory factory;
        private DbConnection coon;

        public Connection()
        {
            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            //factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            factory = new MySqlClientFactory();

            //connString = ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString;
            //connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=todo_manager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            /*using (DbConnection coon = factory.CreateConnection())
            {
                coon.ConnectionString = connString;
                coon.Open();

                Show(coon);
            };*/
        }

        public bool Insert(CreateCardDto card)
        {
            this.OpenDb();

            DbCommand cmd = factory.CreateCommand();
            cmd.Connection = coon;
            cmd.CommandText = "INSERT INTO progress (title, UserStory, DeadLine, Priority) VALUES (@title, @userStory, @deadLine, @priority)";

            DbParameter param = factory.CreateParameter();
            param.ParameterName = "@title";
            param.Value = card.title;
            cmd.Parameters.Add(param);

            param = factory.CreateParameter();
            param.ParameterName = "@userStory";
            param.Value = card.UserStory;
            cmd.Parameters.Add(param);

            param = factory.CreateParameter();
            param.ParameterName = "deadLine";
            param.Value = card.DeadLine;
            cmd.Parameters.Add(param);

            param = factory.CreateParameter();
            param.ParameterName = "priority";
            param.Value = card.Priority;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            

            this.CloseDb();
        }
        public void Show(DbConnection conn)
        {
            using (DbCommand cmd = factory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM todo";

                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["id"]);
                    }
                }
            };
        }

        public void OpenDb()
        {
            coon = new MySqlConnection("Server=localhost;Database=progress_manager;Uid=root;Pwd=sinqia123;");

            /*coon = factory.CreateConnection();
            coon.ConnectionString = connString;*/
            coon.Open();
        }
        public void CloseDb()
        {
            coon.Close();
        }
    }
}
