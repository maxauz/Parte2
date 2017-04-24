using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class OrdenPago
    {
        public int idOrdenPago { get; set; }
        public double Monto { get; set; }

        public string Moneda{ get; set; }

        public string FechaPago{ get; set; }

        public string Estado { get; set; }

        public int idSucursal{get;set;}

        string strConnection = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();






        public void insert(OrdenPago OrdenPago)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {


               string sql = " insert into OrdenPago (Monto,Moneda,Estado) values (" +OrdenPago.Monto+",'"+OrdenPago.Moneda+"', 'p'); ";
 sql +="insert into Sucursal_OrdenPago(idSucursal,idOrdenPago) values("+OrdenPago.idSucursal+",SCOPE_IDENTITY()); ";

                
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void actualizar(OrdenPago OrdenPago)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "update OrdenPago set Monto="+OrdenPago.Monto+" ,Moneda='"+OrdenPago.Moneda+"', Estado='"+OrdenPago.Estado+"' where idOrdenPago="+OrdenPago.idOrdenPago;

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void eliminar(int idOrdenPago)
        {

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "delete from Sucursal_OrdenPago where idOrdenPago="+idOrdenPago +"; ";
sql+=" delete from OrdenPago where idOrdenPago=" + idOrdenPago+";";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public List<OrdenPago> listarServicioOrdenPagoPorSucursalTipoMoneda(string Sucursal,string TipoMoneda)
        {
            List<OrdenPago> OrdenPagos = new List<OrdenPago>();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select op.idOrdenPago,op.Monto,convert(varchar(10),op.FechaPago,103) FechaPago, ";
                sql += " CASE WHEN op.Estado='p' THEN 'Pagada' WHEN op.Estado='d' ";
                sql += " THEN 'Declinada' WHEN op.Estado='f' THEN 'Fallida' WHEN op.Estado='a'THEN 'Anulada'";
                sql += "  END as Estado,";
                sql += "    CASE WHEN op.Moneda='s' THEN 'S/.' WHEN op.Moneda='d' THEN '$.' END as Moneda, ";
                sql += " s_op.idSucursal from OrdenPago op ";
                sql += " inner join Sucursal_OrdenPago s_op on op.idOrdenPago=s_op.idOrdenPago";
                sql += " inner join Sucursal s on s.idSucursal=s_op.idSucursal";
                sql += " where s.nombre='" + Sucursal+"' and op.Moneda='"+TipoMoneda+"'";
                

                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrdenPago OrdenPago = new OrdenPago();
                        OrdenPago.idOrdenPago = Convert.ToInt32(reader["idOrdenPago"]);
                        OrdenPago.Monto = Convert.ToDouble(reader["Monto"]);
                        OrdenPago.Estado = (string)reader["Estado"];
                        OrdenPago.FechaPago = (string)reader["FechaPago"];
                        OrdenPago.Moneda = (string)reader["Moneda"];
                        OrdenPago.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                        OrdenPagos.Add(OrdenPago);
                    }
                }
            }

            return OrdenPagos;


        }

        public List<OrdenPago> listar(int idSucursal)
        {
            List<OrdenPago> OrdenPagos = new List<OrdenPago>();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select op.idOrdenPago,op.Monto,convert(varchar(10),op.FechaPago,103) FechaPago, ";
        sql+=" CASE WHEN op.Estado='p' THEN 'Pagada' WHEN op.Estado='d' ";
 sql+=" THEN 'Declinada' WHEN op.Estado='f' THEN 'Fallida' WHEN op.Estado='a'THEN 'Anulada'";
sql+="  END as Estado,";
sql += "    CASE WHEN op.Moneda='s' THEN 'S/.' WHEN op.Moneda='d' THEN '$.' END as Moneda, ";
sql+=" s_op.idSucursal from OrdenPago op ";
sql+=" inner join Sucursal_OrdenPago s_op on op.idOrdenPago=s_op.idOrdenPago";
sql+=" where s_op.idSucursal="+idSucursal;
                

                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrdenPago OrdenPago = new OrdenPago();
                        OrdenPago.idOrdenPago = Convert.ToInt32(reader["idOrdenPago"]);
                        OrdenPago.Monto= Convert.ToDouble(reader["Monto"]);
                        OrdenPago.Estado = (string)reader["Estado"];
                        OrdenPago.FechaPago = (string)reader["FechaPago"];
                        OrdenPago.Moneda= (string)reader["Moneda"];
                        OrdenPago.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                        OrdenPagos.Add(OrdenPago);
                    }
                }
            }

            return OrdenPagos;


        }


        public OrdenPago Editar(int idOrdenPago)
        {
            OrdenPago OrdenPagos = new OrdenPago();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "select OrdenPago.idOrdenPago,Monto,Moneda,Estado,IdSucursal ";
sql+=" from OrdenPago ";
sql += "inner join Sucursal_OrdenPago on Sucursal_OrdenPago.idOrdenPago=OrdenPago.idOrdenPago";
sql+=" where OrdenPago.idOrdenPago=" + idOrdenPago;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrdenPago OrdenPago = new OrdenPago();
                        OrdenPago.idOrdenPago = Convert.ToInt32(reader["idOrdenPago"]);
                        OrdenPago.Monto = Convert.ToDouble(reader["Monto"]);
                        OrdenPago.Moneda = (string)reader["Moneda"];
                        OrdenPago.Estado = (string)reader["Estado"];
                        OrdenPago.idSucursal = Convert.ToInt32(reader["idSucursal"]);
                       
                        OrdenPagos = OrdenPago;
                    }
                }
            }

            return OrdenPagos;


        }
    }

