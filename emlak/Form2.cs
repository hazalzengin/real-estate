using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace emlak
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=emlak;Integrated Security=True");
        private void show()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand komut = new SqlCommand("Select* From sitebiligi", connect);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = read["id"].ToString();
                ekle.SubItems.Add(read["site"].ToString());
                ekle.SubItems.Add(read["oda"].ToString());
                ekle.SubItems.Add(read["metre"].ToString());
                ekle.SubItems.Add(read["fiyat"].ToString());
                ekle.SubItems.Add(read["blok"].ToString());
                ekle.SubItems.Add(read["no"].ToString());
                ekle.SubItems.Add(read["adsoyad"].ToString());
                ekle.SubItems.Add(read["telefon"].ToString());
                ekle.SubItems.Add(read["notlar"].ToString());
                ekle.SubItems.Add(read["satkira"].ToString());

                listView1.Items.Add(ekle);

            }
            connect.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Fıstıklık")
            {
                button1.BackColor = Color.Yellow;
            }
            if (comboBox1.Text == "Beykent")
            {
                button2.BackColor = Color.Green;
            }
            if (comboBox1.Text == "Güneykent")
            {
                button4.BackColor = Color.DeepSkyBlue;
            }
            if (comboBox1.Text == "Kuzeyşehir")
            {
                button3.BackColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Insert Into sitebiligi(id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira)values('" + textBox8.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + comboBox2.Text.ToString() + "')",connect);
            komut.ExecuteNonQuery();
            connect.Close();
            show();
        }
        int id = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand komut=new SqlCommand("Delete from sitebiligi where id=("+ id + ")",connect);
            komut.ExecuteNonQuery();
            connect.Close();
            show();
               
            }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox8.Text=listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }
    }
}
