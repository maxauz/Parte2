using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public  class  Sucursal
    {
        public int idSucursal { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string FechaRegistro { get; set; }
        public int idBanco { get; set; }

        public List<Banco> Bancos { get; set; }
        string strConnection = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();






        public void insert(Sucursal sucursal)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "insert into Sucursal(Nombre,Direccion,idBanco) values('" + sucursal.Nombre + "','" + sucursal.Direccion + "',"+sucursal.idBanco+")";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void actualizar(Sucursal sucursal)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "update Sucursal set Nombre='" + sucursal.Nombre + "',Direccion='" + sucursal.Direccion + "',idBanco="+sucursal.idBanco+" where idSucursal=" + sucursal.idSucursal;

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void eliminar(int idSucursal)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "delete from Sucursal where idSucursal=" + idSucursal;
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }



        public List<Sucursal> listarSucursalXNombreBanco(string banco)
        {
            List<Sucursal> Sucursals = new List<Sucursal>();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select s.idSucursal,s.Nombre , Direccion,convert(varchar(10),s.FechaRegistro,103) FechaRegistro from Banco b ";

sql +=" inner join Sucursal s on b.idBanco=s.idBanco";

sql += " where b.Nombre='" + banco + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sucursal Sucursal = new Sucursal();
                        Sucursal.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                        Sucursal.Nombre = (string)reader["nombre"];
                        Sucursal.Direccion = (string)reader["direccion"];
                        Sucursal.FechaRegistro = (string)reader["FechaRegistro"];
                        Sucursals.Add(Sucursal);
                    }
                }
            }

            return Sucursals;


        }


        public List<Sucursal> listar()
        {
            List<Sucursal> Sucursals = new List<Sucursal>();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select idSucursal,Nombre,Direccion,convert(varchar(10),FechaRegistro,103) FechaRegistro from Sucursal";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sucursal Sucursal = new Sucursal();
                        Sucursal.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                        Sucursal.Nombre = (string)reader["nombre"];
                        Sucursal.Direccion = (string)reader["direccion"];
                        Sucursal.FechaRegistro = (string)reader["FechaRegistro"];
                        Sucursals.Add(Sucursal);
                    }
                }
            }

            return Sucursals;


        }


        public Sucursal Editar(int idSucursal)
        {
            Sucursal Sucursals = new Sucursal();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select idSucursal,Nombre,Direccion,convert(varchar(10),FechaRegistro,103) FechaRegistro,idBanco from Sucursal where idSucursal="+idSucursal;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sucursal Sucursal = new Sucursal();
                        Sucursal.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                        Sucursal.Nombre = (string)reader["nombre"];
                        Sucursal.Direccion = (string)reader["direccion"];
                        Sucursal.FechaRegistro = (string)reader["FechaRegistro"];
                        Sucursal.idBanco = Convert.ToInt32(reader["idBanco"]);
                        Sucursals = Sucursal;
                    }
                }
            }

            return Sucursals;


        }
    }
