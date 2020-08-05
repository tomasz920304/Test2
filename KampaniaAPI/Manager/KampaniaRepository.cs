using Dapper;
using KampaniaProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KampaniaAPI.Manager
{
    public class KampaniaRepository : IKampaniaRepository
    {
        string connectionString;
        public KampaniaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Kampania> List()
        {
            var _KampaniaList = new List<Kampania>();
            var querySql = "select * from Kampania;";
            using (var connection = new SqlConnection(connectionString))
            {
                var KampaniaList = connection.Query(querySql);
                foreach (var item in KampaniaList)
                {
                    _KampaniaList.Add(new Kampania { Id = Convert.ToInt32($"{item.Id}"), Nazwa = $"{item.Nazwa}", Koszt = Convert.ToInt32($"{item.Koszt}") });
                }
            }
            return _KampaniaList;
        }

        public Kampania Get(int id)
        {
            var _Kampania = new Kampania();
            var querySql = $"select * from kampania where id = {id};";
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Query(querySql).FirstOrDefault();

                _Kampania.Id = Convert.ToInt32($"{user.Id}");
                _Kampania.Nazwa = $"{user.Nazwa}";
                _Kampania.Koszt = Convert.ToInt32($"{user.Koszt}");
            }
            return _Kampania;
        }

        public void Create(Kampania kampania)
        {
            if (kampania.Koszt < 0)
            {
                throw new ArgumentException();
            }

            string insertSql = $"insert into Kampania values ('{kampania.Nazwa}', {kampania.Koszt});";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRow = connection.Execute(insertSql);

                if (affectedRow == 0)
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public void Edit(Kampania kampania)
        {
            if (kampania.Koszt < 0)
            {
                throw new ArgumentException();
            }

            string insertSql = $"update Kampania set Nazwa = '{kampania.Nazwa}', Koszt = {kampania.Koszt} where Id = {kampania.Id};";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRow = connection.Execute(insertSql);

                if (affectedRow == 0)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public void Delete(int id)
        {
            string insertSql = $"delete from Kampania where id = {id};";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRow = connection.Execute(insertSql);

                if (affectedRow == 0)
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public string Koszt()
        {
            string _Koszt = "";
            var querySql = "select sum(Koszt) as sum from Kampania;";
            using (var connection = new SqlConnection(connectionString))
            {
                var Koszt = connection.Query(querySql).FirstOrDefault();
                _Koszt = $"{Koszt.sum}";
            }
            return _Koszt;
        }    
    }
}
