using EvaluacionEmpresa.Models.prm;
using EvaluacionEmpresa.Models.custom;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.querys
{
    public class prmEvaluaciones
    {
        private string connectionString = "Server=devbdw64b.uag.mx,1433;Database=bdSistemas;Trusted_Connection=True;MultipleActiveResultSets=True";
        public void AgregarEvaluacion(PrmEvaluacion prmEvaluacion)
        {
            string query = "insert into prmEvaluacion(Periodo, FechaInicio, FechaFinal) values" +
                            "(@Periodo, @FechaInicio, @FechaFinal)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@Periodo", prmEvaluacion.Periodo);
                sqlCommand.Parameters.AddWithValue("@FechaInicio", prmEvaluacion.FechaInicio);
                sqlCommand.Parameters.AddWithValue("@FechaFinal", prmEvaluacion.FechaFinal);

                sqlConnection.Open();
                //se ejecuta el insert
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<PrmEvaluacion> Ver() //Regresa todas las evaluaciones, sirve de prueba
        {

            List<PrmEvaluacion> evaluaciones = new List<PrmEvaluacion>(); //Creamos una lista tipo PrmEvaluacion
            string query = "select * from PrmEvaluacion"; // Ver todos los campos de la tabla PrmEvaluacion
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                while (reader.Read()) //Mientras haya lectura de datos
                {
                    
                    PrmEvaluacion prmEvaluacion = new PrmEvaluacion();//creamos unnuevo objeto de la clase PrmEvaluacion para agregar a la lista llamda "evaluaciones"
                    prmEvaluacion.IdEvaluacion = reader.GetInt32(0);
                    prmEvaluacion.Periodo = reader.GetString(1);
                    prmEvaluacion.FechaInicio = reader.GetDateTime(2);
                    prmEvaluacion.FechaFinal = reader.GetDateTime(3);
                    evaluaciones.Add(prmEvaluacion);
                }
                sqlConnection.Close();
            }
            return evaluaciones;
        }
        public List<PrmEvaluacion> Vigentes()
        {
            List<PrmEvaluacion> periodos = new List<PrmEvaluacion>();
            //consulta para saber en que periodo estamos, en caso de que hay un periodo iniciado
            string query = "select * from prmEvaluacion where Getdate() between (select FechaInicio) and (select FechaFinal) order by FechaFinal asc";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //mandar query
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //lecturas
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    PrmEvaluacion prmEvaluacion = new PrmEvaluacion();
                    prmEvaluacion.IdEvaluacion = reader.GetInt32(0);
                    prmEvaluacion.Periodo = reader.GetString(1);
                    prmEvaluacion.FechaInicio = reader.GetDateTime(2);
                    prmEvaluacion.FechaFinal = reader.GetDateTime(3);
                    periodos.Add(prmEvaluacion);
                }
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    return periodos;
                }
                
                 sqlConnection.Close();
             }
            return periodos;
            
        }
        public List<PrmEvaluacion> Pasados()
        {
            List<PrmEvaluacion> periodos = new List<PrmEvaluacion>();
            string query = "select * from prmEvaluacion where GETDATE() > FechaFinal";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //mandar query
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //lecturas
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    PrmEvaluacion prmEvaluacion = new PrmEvaluacion();
                    prmEvaluacion.IdEvaluacion = reader.GetInt32(0);
                    prmEvaluacion.Periodo = reader.GetString(1);
                    prmEvaluacion.FechaInicio = reader.GetDateTime(2);
                    prmEvaluacion.FechaFinal = reader.GetDateTime(3);
                    periodos.Add(prmEvaluacion);
                }
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    return periodos;
                }

                sqlConnection.Close();
            }
            return periodos;
        }
        public prmPeriodos Periodos(PrmEvaluacion prmEvaluaciones, int uag)
        {
            prmPeriodos prmPeriodos = new prmPeriodos();
            string query = "select (select count(ee.IdEvaluacion) from prmEvaluacionEmpresa as ee "+
            "inner join prmResponsable as r on ee.IdResponsable = r.IdResponsable " +
            "where ee.IdEvaluacion = @IdEvaluacion and r.IdUAG = @uag), " +
            "(select count(prmEmpresa.IdEmpresa) from prmEmpresa " +
            "inner join prmResponsable on prmEmpresa.IdEmpresa = prmResponsable.IdEmpresa " +
            "inner join prmGiro on prmGiro.IdGiro = prmEmpresa.IdGiro " +
            "where prmResponsable.IdUAG = @uag and prmEmpresa.Activa = 1)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@uag", uag);
                sqlCommand.Parameters.AddWithValue("@IdEvaluacion", prmEvaluaciones.IdEvaluacion);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                if (reader.Read()) //Mientras haya lectura de datos
                {
                    prmPeriodos.IdEvaluacion = prmEvaluaciones.IdEvaluacion;
                    prmPeriodos.Periodo = prmEvaluaciones.Periodo;
                    prmPeriodos.FechaFinal = prmEvaluaciones.FechaFinal;
                    prmPeriodos.FechaInicio = prmEvaluaciones.FechaInicio;
                    prmPeriodos.Completos = reader.GetInt32(0);
                    prmPeriodos.Totales = reader.GetInt32(1);
                    sqlConnection.Close();
                    return prmPeriodos;
                }
                sqlConnection.Close();
            }
            return prmPeriodos;
        }

        public List<prmEmpresaResponsableActiva> NoEvaluadas(List<prmEmpresaResponsableActiva> responsableActivas, int idEvaluacion, int uag)
        {
            List<prmEmpresaResponsableActiva> prm1 = new List<prmEmpresaResponsableActiva>();
            foreach(var r in responsableActivas)
            {
                prm1.Add(r);
            }
            string query = "select prmEvaluacionEmpresa.IdEmpresa from prmEvaluacionEmpresa inner join prmResponsable as r on r.IdResponsable = prmEvaluacionEmpresa.IdResponsable where IdEvaluacion = @IdEvaluacion and r.IdUAG = @uag";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@uag", uag);
                sqlCommand.Parameters.AddWithValue("@idEvaluacion", idEvaluacion);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                while (reader.Read()) //Mientras haya lectura de datos
                {
                    foreach (var ra in responsableActivas)
                    {
                        if(ra.IdEmpresa == reader.GetInt32(0))
                        {
                            prm1.Remove(ra);
                        }
                        else
                        {

                        }
                    }
                }
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    return prm1;
                }
                sqlConnection.Close();
            }

            return prm1;
        }

        public List<prmEmpresaResponsableActiva> MisEmpresas(int uag)
        {
            List<prmEmpresaResponsableActiva> empresas = new List<prmEmpresaResponsableActiva>();
            //Ver las empresas que tengas bajo responsabilidad y esten activas
            string query = "select prmEmpresa.IdEmpresa, prmGiro.Giro, prmEmpresa.Empresa, prmEmpresa.RazonSocial, prmEmpresa.RFC, prmEmpresa.Domicilio,prmEmpresa.Telefono, prmEmpresa.Email, prmEmpresa.Pais, prmEmpresa.Estado, prmEmpresa.Municipio, prmEmpresa.URL from prmEmpresa inner join prmResponsable on prmEmpresa.IdEmpresa = prmResponsable.IdEmpresa inner join prmGiro on prmGiro.IdGiro = prmEmpresa.IdGiro where prmResponsable.IdUAG = @uag  and prmEmpresa.Activa = 1";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@uag", uag);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                while (reader.Read()) //Mientras haya lectura de datos
                {
                    prmEmpresaResponsableActiva prm = new prmEmpresaResponsableActiva();
                    
                    prm.IdEmpresa = reader.GetInt32(0);
                    prm.Empresa = reader.GetString(2);
                    prm.Giro = reader.GetString(1);
                    prm.RazonSocial = reader.GetString(3);
                    prm.RFC = reader.GetString(4);
                    prm.Domicilio = reader.GetString(5);
                    prm.Telefono = reader.GetString(6);
                    prm.Email = reader.GetString(7);
                    prm.Pais = reader.GetString(8);
                    prm.Estado = reader.GetString(9);
                    prm.Municipio = reader.GetString(10);
                    prm.URL = reader.GetString(11);
                    empresas.Add(prm);
                }
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    return empresas;
                }
                sqlConnection.Close();
            }
            return empresas;
        }
        public int VerIdResponsable (prmEvaluar prmEvaluar)
        {
            string query = "select IdResponsable from prmResponsable where IdUAG = @uag and IdEmpresa = @IdEmpresa";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@uag", prmEvaluar.IdUAG);
                sqlCommand.Parameters.AddWithValue("@IdEmpresa", prmEvaluar.IdEmpresa);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                if (reader.Read()) //Mientras haya lectura de datos
                {
                    int responsable;
                    responsable = reader.GetInt32(0);
                    sqlConnection.Close();
                    return responsable;
                }
                else
                {
                    sqlConnection.Close();
                    return 0;
                    
                }
            }
        }
        
        public void AgregarEvaluacionEmpresa(prmEvaluar prmEvaluar, int IdResponsable)
        {
            string query = "insert into prmEvaluacionEmpresa values (@IdEvaluacion, @IdEmpresa, @IdResponsable)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@IdEvaluacion", prmEvaluar.IdEvaluacion);
                sqlCommand.Parameters.AddWithValue("@IdEmpresa", prmEvaluar.IdEmpresa);
                sqlCommand.Parameters.AddWithValue("@IdResponsable", IdResponsable);

                sqlConnection.Open();
                //se ejecuta el insert
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public int confirmarEvaluacionEmpresa(prmEvaluar prmEvaluar, int IdResponsable)
        {
            int id;
            string query = "";
            if (IdResponsable == 0)
                query = "select IdEvaluacionEmpresa from prmEvaluacionEmpresa where IdEvaluacion = @IdEvaluacion and IdEmpresa = @IdEmpresa";
            else
                query = "select IdEvaluacionEmpresa from prmEvaluacionEmpresa where IdEvaluacion = @IdEvaluacion and IdEmpresa = @IdEmpresa and IdResponsable = @IdResponsable";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@IdEvaluacion", prmEvaluar.IdEvaluacion);
                sqlCommand.Parameters.AddWithValue("@IdEmpresa", prmEvaluar.IdEmpresa);
                sqlCommand.Parameters.AddWithValue("@IdResponsable", IdResponsable);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                if (reader.Read()) //Mientras haya lectura de datos
                {
                    
                    id= reader.GetInt32(0);
                    sqlConnection.Close();
                    return id;
                }
                else
                {
                    sqlConnection.Close();
                    return 0;
                }
            }
            
        }
        public PrmContrato VerContrato(int IdEvaluacionEmpresa)
        {
            PrmContrato prmContrato = new PrmContrato();
            string query = "select * from prmContrato where IdEvaluacionEmpresa = @IdEvaluacionEmpresa";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@IdEvaluacionEmpresa", IdEvaluacionEmpresa);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(); //se ejecuta la consulta
                if (reader.Read()) //Mientras haya lectura de datos
                {
                    int r = reader.GetInt32(0);
                    prmContrato.IdContrato = reader.GetInt32(0);
                    prmContrato.IdEvaluacionEmpresa = reader.GetInt32(1);
                    prmContrato.Contrato = reader.GetBoolean(2);
                    prmContrato.Cconfidencialidad = reader.GetBoolean(3);
                    prmContrato.PoliticasNormas = reader.GetBoolean(4);
                    prmContrato.NivelesServicio = reader.GetBoolean(5);
                    prmContrato.Incidentes = reader.GetBoolean(6);
                    prmContrato.Comentarios = reader.GetString(7);
                    sqlConnection.Close();
                    return prmContrato;
                }
                else
                {
                    sqlConnection.Close();
                    return prmContrato;
                }
            }
        }
        public void AgregarContrato(prmEvaluar prmEvaluar, int IdEvaluacionEmpresa)
        { 
            string query = "insert into prmContrato values(@IdEvaluacionEmpresa, @Contrato, @CConfidencialidad, @PoliticasNormas, @NivelesServicio, @Incidentes, @Comentarios)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@IdEvaluacionEmpresa", IdEvaluacionEmpresa);
                sqlCommand.Parameters.AddWithValue("@Contrato", prmEvaluar.Contrato);
                sqlCommand.Parameters.AddWithValue("@CConfidencialidad", prmEvaluar.CConfidencialidad);
                sqlCommand.Parameters.AddWithValue("@PoliticasNormas", prmEvaluar.PoliticasNormas);
                sqlCommand.Parameters.AddWithValue("@NivelesServicio", prmEvaluar.NvlServicio);
                sqlCommand.Parameters.AddWithValue("@Incidentes", prmEvaluar.Incidentes);
                sqlCommand.Parameters.AddWithValue("@Comentarios", prmEvaluar.Comentarios1);

                sqlConnection.Open();
                //se ejecuta el insert
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void AgregarDesempenio(prmEvaluar prmEvaluar, int IdEvaluacionEmpresa)
        {
            string query = "insert into prmDesempenio values(@IdEvaluacionEmpresa, @Fecha ,@Especializacion, @Solucion, @Tecnologia, @AtencionSoporte, @TiempoEntrega, @Precio, @Calidad, @Comentarios)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //Mandar parametros
                sqlCommand.Parameters.AddWithValue("@IdEvaluacionEmpresa", IdEvaluacionEmpresa);
                sqlCommand.Parameters.AddWithValue("@Fecha", prmEvaluar.Fecha);
                sqlCommand.Parameters.AddWithValue("@Especializacion", prmEvaluar.Especializacion);
                sqlCommand.Parameters.AddWithValue("@Solucion", prmEvaluar.Solucion);
                sqlCommand.Parameters.AddWithValue("@Tecnologia", prmEvaluar.Tecnologia);
                sqlCommand.Parameters.AddWithValue("@AtencionSoporte", prmEvaluar.AtencionSoporte);
                sqlCommand.Parameters.AddWithValue("@TiempoEntrega", prmEvaluar.TiempoEntrega);
                sqlCommand.Parameters.AddWithValue("@Precio", prmEvaluar.Precio);
                sqlCommand.Parameters.AddWithValue("@Calidad", prmEvaluar.Calidad);
                sqlCommand.Parameters.AddWithValue("@Comentarios", prmEvaluar.Comentario2);
                sqlConnection.Open();
                //se ejecuta el insert
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
