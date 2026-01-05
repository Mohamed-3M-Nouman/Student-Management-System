using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hciProject.Data
{
    class DBHelper
    {
        private string connectionString = @"Data Source=.;Initial Catalog=StudentSystemDB;Integrated Security=True;TrustServerCertificate=True";

        SqlConnection con;

        public DBHelper()
        {
            con = new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string queryText)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryText, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الاتصال: " + ex.Message);
            }
            return dt;
        }

        public int ExecuteNonQuery(string queryText)
        {
            int rowsAffected = 0;
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                SqlCommand cmd = new SqlCommand(queryText, con);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في التنفيذ: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return rowsAffected;
        }


        public object ExecuteScalar(string queryText)
        {
            object result = null;
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                SqlCommand cmd = new SqlCommand(queryText, con);
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تنفيذ Scalar: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return result;
        }
    }
}