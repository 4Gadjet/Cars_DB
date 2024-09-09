using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Price
{

    public partial class AUTH : Form
    {
        static public NpgsqlConnection con;
        public DataTable dt = new DataTable();
        public AUTH()
        {
            dt.Columns.Add("login");
            dt.Columns.Add("password");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"user\", pass\r\n\tFROM public.\"Users\"", con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            int UserCount = 0;
            while (rdr.Read())
            {
                UserCount++;
                
            }
            rdr.Close();
            if (UserCount == 0)
            {
                MessageBox.Show("Авторизация отсутствует!!!");
                Application.Exit();
            }
            //Логины и пароли с базы приходят

        }

        private void button1_Click(object sender, EventArgs e)
        {


            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"user\", pass\r\n\tFROM public.\"Users\"", con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt.Rows.Add(rdr.GetValue(0), rdr.GetValue(1)); //Тут записали все логины и пароли в виртуальную таблицу

            }
            rdr.Close();
            if (textBox1.TextLength < 1 || textBox2.TextLength < 1)
            {
                MessageBox.Show("Ошибка", "Поля должны быть заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else 
            {
                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    if (textBox1.Text == dt.Rows[i][0].ToString() && textBox2.Text == dt.Rows[i][1].ToString()) 
                    {
                        Main main = new Main(dt.Rows[i][0].ToString());
                        main.ShowDialog();
                        this.Hide();
                    }
                }
            }
        }
    }
}
