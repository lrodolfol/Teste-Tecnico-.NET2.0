using CardsManagerLib.Models.Data.Dtos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsConsumers.Todo
{
    public class Connection
    {
        static string connString;
        static DbProviderFactory factory;
        private DbConnection coon;

        public Connection()
        {
            factory = new MySqlClientFactory();
            connString = ConfigurationManager.ConnectionStrings["dbConnStringTodo"].ConnectionString;
        }
        public Boolean Insert(CreateCardDto card)
        {
            OpenDb();

            DbCommand cmd = factory.CreateCommand();
            cmd.Connection = coon;
            cmd.CommandText = "INSERT INTO todo (title, UserStory, DeadLine, Priority) VALUES (@title, @userStory, @deadLine, @priority)";

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
        public Boolean Delete(int IdCard)
        {
            try
            {
                OpenDb();
                DbCommand cmd = factory.CreateCommand();
                cmd.Connection = coon;
                cmd.CommandText = "DELETE FROM todo WHERE id = @id";

                DbParameter param = factory.CreateParameter();
                param.ParameterName = "@id";
                param.Value = IdCard;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseDb();
            }
        }
        public void OpenDb()
        {
            coon = new MySqlConnection(connString);
            coon.Open();
        }
        public void CloseDb()
        {
            coon.Close();
        }
    }
}
