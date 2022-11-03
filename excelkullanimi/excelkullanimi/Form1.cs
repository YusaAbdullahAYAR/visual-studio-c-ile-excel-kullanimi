using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace excelkullanimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\acer\Desktop\Kursiyer Bilgileri son.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";");
        void listele()
        {
            
           OleDbDataAdapter da = new OleDbDataAdapter("select * from [sayfa1$]", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into [sayfa1$] (isim,soyisim) values (@P1,@P2)", baglanti);

            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("veriler eklendi");
        }
    }
}
