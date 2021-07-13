using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.prm
{
    public class prmEmpresas
    {
        private string connectionString = "Server=devbdw64b.uag.mx,1433;Database=bdSistemas;Trusted_Connection=True;MultipleActiveResultSets=True";
        public List<PrmEmpresa> Get()
        {
            List<PrmEmpresa> empresas = new List<PrmEmpresa>();
            //Consulta de SQL
            string query = "select Empresa, IdEmpresa from prmEmpresa";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //mandar query
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //lecturas
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    PrmEmpresa prmEmpresa = new PrmEmpresa ();
                    prmEmpresa.Empresa = reader.GetString(0);
                    prmEmpresa.IdEmpresa = reader.GetInt32(1);
                    empresas.Add(prmEmpresa);
                }
                sqlConnection.Close();

            }
            return empresas;
        }
        public string Empresa(int IdEmpresa)
        {
            string empresa = "";
            string query = "select Empresa from PrmEmpresa where IdEmpresa = @IdEmpresa";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                while (reader.Read()) //Mientras haya lectura de datos
                {
                    empresa = reader.GetString(0);
                }
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    return empresa;
                }
                sqlConnection.Close();
            }
            return empresa;
        }

    }
}
