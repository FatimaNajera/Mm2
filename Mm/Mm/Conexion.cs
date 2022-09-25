using System;
using System.Data;
using System.Data.SqlClient;


internal class Conexion
{
    static SqlConnection cnx;
    static string cadena = @"Server=LAPTOP-5H1JL3D4\SQLEXPRESS;Database=AltasBajasCambios;Trusted_Connection=True;;";

    public static void Conectar()
    {
        cnx = new SqlConnection(cadena);
        cnx.Open();
    }
    public static void Desconectar()
    {
        cnx.Close();
        cnx = null;
    }
    public static int EjecutaConsulta(string consulta)
    {
        int filasAfectadas = 0;
        Conectar();
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        filasAfectadas = cmd.ExecuteNonQuery();
        Desconectar();
        return filasAfectadas;
    }
    public static DataTable EjecutaSeleccion(string consulta)
    {
        DataTable dt = new DataTable();
        Conectar();
        SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
        da.Fill(dt);
        Desconectar();
        return dt;
    }
    public static Object EjecutaEscalar(string consulta)
    {
        DataTable dt = new DataTable();
        Conectar();
        SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
        da.Fill(dt);
        Desconectar();
        return dt.Rows[0].ItemArray[0];
    }
}

