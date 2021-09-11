using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DopeQuotes
{
    public partial class Form1 : Form
    {

        public void refreshDataBase()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=dope_quotes;User Id=postgres;Password=123456;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from dope_quotes";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        public Form1()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=dope_quotes;User Id=postgres;Password=123456;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from dope_quotes";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=dope_quotes;User Id=postgres;Password=123456;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO dope_quotes (author_name, quote_text) VALUES (@author_name, @quote_text)";
            NpgsqlParameter paramAuthorName = comm.Parameters.Add("author_name", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramAuthorName.Direction = ParameterDirection.Input;
            paramAuthorName.Value = textBox1.Text;
            NpgsqlParameter paramQuoteText = comm.Parameters.Add("quote_text", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramQuoteText.Direction = ParameterDirection.Input;
            paramQuoteText.Value = textBox3.Text;
            comm.ExecuteNonQuery();

            refreshDataBase();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=dope_quotes;User Id=postgres;Password=123456;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE dope_quotes SET author_name = @author_name, quote_text = @quote_text WHERE id = @id";
            NpgsqlParameter paramAuthorName = comm.Parameters.Add("author_name", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramAuthorName.Direction = ParameterDirection.Input;
            paramAuthorName.Value = textBox1.Text;

            NpgsqlParameter paramQuoteText = comm.Parameters.Add("quote_text", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramQuoteText.Direction = ParameterDirection.Input;
            paramQuoteText.Value = textBox3.Text;

            NpgsqlParameter paramId = comm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = int.Parse(textBox2.Text);

            comm.ExecuteNonQuery();

            refreshDataBase();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=dope_quotes;User Id=postgres;Password=123456;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "DELETE from dope_quotes WHERE id = @id";

            NpgsqlParameter paramId = comm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = int.Parse(textBox2.Text);

            comm.ExecuteNonQuery();


            refreshDataBase();
        }
    }
}
