using Cars_Price.AddForms;
using Cars_Price.ListForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cars_Price
{
    public partial class Main : Form
    {
        public string username;
        static public NpgsqlConnection con;
        public DataTable dt = new DataTable();
        public int mode = 1; //Текущая выбранная таблица
        public Main(string username_)
        {
            username = username_;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = "Автомобили. Текущий пользователь: " + username;
            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"ID_Brand\", \"Name\" FROM public.\"Brand\" ORDER BY \"Name\" ASC", con); //Подгрузка списка марок
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr.GetValue(1));
                comboBox3.Items.Add(rdr.GetValue(0));
            }
            rdr.Close();
            //cmd = new NpgsqlCommand("SELECT \"ID_Model\", \"Name\" FROM public.\"Model\" ORDER BY \"Name\" ASC", con); //Подгрузка списка моделей
            //rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    comboBox2.Items.Add(rdr.GetValue(1));
            //    comboBox4.Items.Add(rdr.GetValue(0));
            //}
            //rdr.Close();
            cmd = new NpgsqlCommand("SELECT \"ID_Car\", \"Brand\".\"Name\" AS Марка, \"Model\".\"Name\" AS Модель, \"Engine\".\"Capacity\" AS Двигатель," +
                " \"GearBox\".\"Type\" AS КПП, \r\n\"Body\".\"Name\" AS Кузов, \"Year\" AS Год, \"Mileage\" AS Пробег, \"Color\" AS Цвет, \"Price\" AS Стоимость," +
                " \"Description\" AS Описание \r\n\tFROM public.\"Car\", public.\"Brand\", public.\"Model\", public.\"Engine\", public.\"GearBox\"," +
                " public.\"Body\"\r\n\tWHERE \"Car\".\"ID_Brand\" = \"Brand\".\"ID_Brand\" AND \"Car\".\"ID_Model\" = \"Model\".\"ID_Model\" AND" +
                " \"Car\".\"ID_Engine\" = \"Engine\".\"ID_Engine\"\r\n\t\tAND \"Car\".\"ID_Gearbox\" = \"GearBox\".\"ID_Gearbox\" AND" +
                " \"Car\".\"ID_Body\" = \"Body\".\"ID_Body\";", con);

            dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный проект разработан в рамках курсовой работы\n" +
                "по дисциплине PosGreSQL под руководством\n" +
                "ст. преп. Куркурина Н.Д.\n" +
                "Разработал:\n" +
                "Камоликов В.А. ДИНРБ-31", "Справочная информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "";
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Acura":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Acura;
                    break;
                case "Alfa Romeo":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Alfa_Romeo;
                    break;
                case "Aston Martin":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Aston_Martin;
                    break;
                case "Audi":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Audi;
                    break;
                case "Bentley":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Bentley;
                    break;
                case "BMW":
                    pictureBox1.Image = Cars_Price.Properties.Resources.BMW;
                    break;
                case "Bugatti":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Bugatti;
                    break;
                case "Buick":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Buick;
                    break;
                case "Cadillac":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Cadillac;
                    break;
                case "Chery":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Chery;
                    break;
                case "Chevrolet":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Chevrolet;
                    break;
                case "Chrysler":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Chrysler;
                    break;
                case "Citroen":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Citroen;
                    break;
                case "Dacia":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Dacia;
                    break;
                case "Daewoo":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Daewoo;
                    break;
                case "Dodge":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Dodge;
                    break;
                case "Ferrari":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Ferrari;
                    break;
                case "Fiat":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Fiat;
                    break;
                case "Ford":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Ford;
                    break;
                case "ГАЗ":
                    pictureBox1.Image = Cars_Price.Properties.Resources.GAZ;
                    break;
                case "Holden":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Holden;
                    break;
                case "Honda":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Honda;
                    break;
                case "Hyundai":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Hyundai;
                    break;
                case "Infiniti":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Infiniti;
                    break;
                case "Jaguar":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Jaguar;
                    break;
                case "Jeep":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Jeep;
                    break;
                case "Kia":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Kia;
                    break;
                case "ЛАДА":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Lada;
                    break;
                case "Lamborghini":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Lamborghini;
                    break;
                case "Lancia":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Lancia;
                    break;
                case "Land Rover":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Land_Rover;
                    break;
                case "Lexus":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Lexus;
                    break;
                case "Lotus":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Lotus;
                    break;
                case "Maserati":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Maserati;
                    break;
                case "Maybach":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Maybach;
                    break;
                case "Mazda":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Mazda;
                    break;
                case "Mercedes":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Mercedes;
                    break;
                case "Mercury":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Mercury;
                    break;
                case "Mini":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Mini;
                    break;
                case "Mitsubishi":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Mitsubishi;
                    break;
                case "Nissan":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Nissan;
                    break;
                case "Opel":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Opel;
                    break;
                case "Pagani":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Pagani;
                    break;
                case "Peugeot":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Peugeot;
                    break;
                case "Pontiac":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Pontiac;
                    break;
                case "Porsche":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Porsche;
                    break;
                case "Renault":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Renault;
                    break;
                case "Rolls Royce":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Rolls_Royce;
                    break;
                case "Rover":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Rover;
                    break;
                case "Saab":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Saab;
                    break;
                case "Scion":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Scion;
                    break;
                case "Seat":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Seat;
                    break;
                case "Skoda":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Skoda;
                    break;
                case "Ssang Yong":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Ssang_Yong;
                    break;
                case "Subaru":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Subaru;
                    break;
                case "Suzuki":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Suzuki;
                    break;
                case "Toyota":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Toyota;
                    break;
                case "Vauxhall":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Vauxhall;
                    break;
                case "Volkswagen":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Volkswagen;
                    break;
                case "Volvo":
                    pictureBox1.Image = Cars_Price.Properties.Resources.Volvo;
                    break;
                default:
                    pictureBox1.Image = Cars_Price.Properties.Resources.default1;
                    break;

            }//Смена картинок марок
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"ID_Car\", \"Brand\".\"Name\" AS Марка, \"Model\".\"Name\" AS Модель, \"Engine\".\"Capacity\" AS Двигатель," +
                " \"GearBox\".\"Type\" AS КПП, \r\n\"Body\".\"Name\" AS Кузов, \"Year\" AS Год, \"Mileage\" AS Пробег, \"Color\" AS Цвет, \"Price\" AS Стоимость," +
                " \"Description\" AS Описание \r\n\tFROM public.\"Car\", public.\"Brand\", public.\"Model\", public.\"Engine\", public.\"GearBox\"," +
                " public.\"Body\"\r\n\tWHERE \"Car\".\"ID_Brand\" = \"Brand\".\"ID_Brand\" AND \"Car\".\"ID_Model\" = \"Model\".\"ID_Model\" AND" +
                " \"Car\".\"ID_Engine\" = \"Engine\".\"ID_Engine\"\r\n\t\tAND \"Car\".\"ID_Gearbox\" = \"GearBox\".\"ID_Gearbox\" AND" +
                " \"Car\".\"ID_Body\" = \"Body\".\"ID_Body\" AND \"Brand\".\"ID_Brand\" = $1", con)
            {
                Parameters = { new NpgsqlParameter() { Value = comboBox3.SelectedItem } }
            };
            dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            cmd = new NpgsqlCommand("SELECT \"ID_Model\", \"Name\" FROM public.\"Model\" WHERE \"ID_Brand\" = $1 ORDER BY \"Name\" ASC", con) //Подгрузка списка моделей
            {
                Parameters = { new NpgsqlParameter() { Value = comboBox3.SelectedItem } }
            };
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr.GetValue(1));
                comboBox4.Items.Add(rdr.GetValue(0));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.ShowDialog();
            Main_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e) //Удаление
        {
            if (dataGridView1.Rows.Count > 1)
            {

                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM public.\"Car\"\r\n\tWHERE \"ID_Car\" = $1", con)
                {
                    Parameters = { new NpgsqlParameter() { Value = dataGridView1[0, dataGridView1.CurrentRow.Index].Value } }
                };
                cmd.ExecuteNonQuery();
                Main_Load(sender, e);
            }

        }


        private void получитьСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Load(sender, e);
        }

        private void маркиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.ShowDialog();
        }

        private void моделиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            model.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //Редактирование
        {

        }

        private void двигателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Engine engine = new Engine();
            engine.ShowDialog();
        }

        private void кППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GearBox gearBox = new GearBox();
            gearBox.ShowDialog();
        }

        private void кузоваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Body body = new Body();
            body.ShowDialog();
        }

        private void сервисыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.ShowDialog();
        }

        private void работыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceRecord serviceRecord = new ServiceRecord();
            serviceRecord.ShowDialog();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Image = Cars_Price.Properties.Resources.floppa;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = comboBox2.SelectedIndex;
            String connectionString = "host=localhost; Port=5432; User Id=postgres; Password=1236; Database=Cars;";
            con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"ID_Car\", \"Brand\".\"Name\" AS Марка, \"Model\".\"Name\" AS Модель, \"Engine\".\"Capacity\" AS Двигатель," +
                " \"GearBox\".\"Type\" AS КПП, \r\n\"Body\".\"Name\" AS Кузов, \"Year\" AS Год, \"Mileage\" AS Пробег, \"Color\" AS Цвет, \"Price\" AS Стоимость," +
                " \"Description\" AS Описание \r\n\tFROM public.\"Car\", public.\"Brand\", public.\"Model\", public.\"Engine\", public.\"GearBox\"," +
                " public.\"Body\"\r\n\tWHERE \"Car\".\"ID_Brand\" = \"Brand\".\"ID_Brand\" AND \"Car\".\"ID_Model\" = \"Model\".\"ID_Model\" AND" +
                " \"Car\".\"ID_Engine\" = \"Engine\".\"ID_Engine\"\r\n\t\tAND \"Car\".\"ID_Gearbox\" = \"GearBox\".\"ID_Gearbox\" AND" +
                " \"Car\".\"ID_Body\" = \"Body\".\"ID_Body\" AND \"Brand\".\"ID_Brand\" = $1 AND \"Model\".\"ID_Model\" = $2", con)
            {
                Parameters = { new NpgsqlParameter() { Value = comboBox3.SelectedItem },
                                new NpgsqlParameter() { Value = comboBox4.SelectedItem } }
            };
            dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }

        private void дТПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accident accident = new Accident();
            accident.ShowDialog();
        }

        private void получитьПолныйРасчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
    }
}
