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
    public partial class Report : Form
    {
        static public NpgsqlConnection con;
        public DataTable dt = new DataTable();
        bool diagram = false;
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"Car\".\"ID_Car\", SUM(\"Accident\".\"Insurance\") AS Аварии, SUM(\"Service_rec\".\"Price\") AS ТО FROM public.\"Car\", public.\"Accident\", public.\"Service_rec\" " +
                " WHERE \"Car\".\"ID_Car\" = \"Accident\".\"ID_Car\" AND \"Car\".\"ID_Car\" = \"Service_rec\".\"ID_Car\" GROUP BY \"Car\".\"ID_Car\" ORDER BY \"Car\".\"ID_Car\"", con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) 
            {
                comboBox1.Items.Add(rdr.GetValue(0));
                comboBox2.Items.Add(rdr.GetValue(1));
                comboBox3.Items.Add(rdr.GetValue(2));
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Авто");
            dt.Columns.Add("Стоимость");
            rdr.Close();
            NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT \"Brand\".\"Name\", \"Model\".\"Name\", \"Car\".\"Year\", \"Car\".\"Price\" FROM public.\"Brand\", public.\"Model\", public.\"Car\" WHERE \"Car\".\"ID_Brand\" = \"Brand\".\"ID_Brand\" AND \"Car\".\"ID_Model\" = \"Model\".\"ID_Model\"", con);
            NpgsqlDataReader rdr1 = cmd1.ExecuteReader();
            int i = 0;
            while (rdr1.Read())
            {
                dt.Rows.Add(rdr1.GetValue(0) + " " + rdr1.GetValue(1) + " " + rdr1.GetValue(2),
                    System.Convert.ToInt32(comboBox2.Items[i]) + System.Convert.ToInt32(comboBox3.Items[i]) + System.Convert.ToInt32(rdr1.GetValue(3)));
                i++;
            }
            dataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            //По горизонтальной оси откладываем названия машин:
            chart1.Series["Series1"].XValueMember = "Авто";
            //'По вертикальной оси откладываем объемы продаж:
            chart1.Series["Series1"].YValueMembers = "Стоимость";
            //Название графика (диаграммы):
            chart1.Titles.Clear();  //Очистка названия
            chart1.Titles.Add("Расчет полной стоимости владения");
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            diagram = !diagram;
            if (diagram)
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            else
                chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }
    }
}
