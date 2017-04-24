using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class Banco
    {
        public int idBanco { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string FechaRegistro { get; set; }

        string strConnection = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();






        public void insert(Banco banco)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "insert into Banco(Nombre,Descripcion) values('" + banco.Nombre + "','" + banco.Descripcion + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void actualizar(Banco banco)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "update Banco set Nombre='" + banco.Nombre + "',Descripcion='" + banco.Descripcion + "' where idBanco="+banco.idBanco;
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void eliminar(int idBanco)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "delete from Banco where idBanco=" + idBanco;
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<Banco> listar()
        {
            List<Banco> bancos = new List<Banco>();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select idBanco,Nombre,Descripcion,convert(varchar(10),FechaRegistro,103) FechaRegistro from Banco";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Banco banco = new Banco();
                        banco.idBanco = Convert.ToInt32(reader["idBanco"]);
                        banco.Nombre = (string)reader["nombre"];
                        banco.Descripcion = (string)reader["descripcion"];
                        banco.FechaRegistro = (string)reader["FechaRegistro"];
                        bancos.Add(banco);
                    }
                }
            }

            return bancos;


        }


        public Banco Editar(int idBanco)
        {
            Banco bancos = new Banco();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select idBanco,Nombre,Descripcion,convert(varchar(10),FechaRegistro,103) FechaRegistro from Banco where idBanco="+idBanco;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Banco banco = new Banco();
                        banco.idBanco = Convert.ToInt32(reader["idBanco"]);
                        banco.Nombre = (string)reader["nombre"];
                        banco.Descripcion = (string)reader["descripcion"];
                        banco.FechaRegistro = (string)reader["FechaRegistro"];
                        bancos = banco;
                    }
                }
            }

            return bancos;


        }
    }
