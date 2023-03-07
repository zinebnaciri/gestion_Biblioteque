using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Tp
{
    public partial class CD : Form
    {

        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public CD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow data = dataGridView1.Rows[a];
            data.Cells[0].Value = textBox1.Text;
            data.Cells[1].Value = textBox2.Text;
            data.Cells[2].Value = textBox3.Text;
          
        }
        int a;
        private void button3_Click(object sender, EventArgs e)
        {
            a = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(a);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            a = e.RowIndex;
            DataGridViewRow r = dataGridView1.Rows[a];
            textBox1.Text = r.Cells[0].Value.ToString();
            textBox2.Text = r.Cells[1].Value.ToString();
            textBox3.Text = r.Cells[2].Value.ToString();
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GestionOuvrage ouv = new GestionOuvrage();
            ouv.Show();
            this.Hide();
        }

        private void CD_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
                string insertQuery = "UPDATE ouvrage SET titre='" + textBox1.Text + "',auteur='" + textBox2.Text + "' WHERE code='" + textBox3.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, conn);
                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("CD modifié Avec Succès");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                       
                    }
                    else
                    {
                        MessageBox.Show(" CD non Modifié");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                conn.Close();
                FillGrid();


            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM ouvrage WHERE code='" + textBox3.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, conn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("CD Supprimé Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show(" CD non Supprimé");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             string insertQuery = "INSERT INTO ouvrage (code,titre,auteur,type) VALUES('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','CD')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("CD Ajouté Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    
                }
                else
                {
                    MessageBox.Show(" CD non ajouté");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           GestionClient g = new GestionClient();
            g.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Livre l = new Livre();
            l.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CD cd = new CD();
            cd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Periodique pr = new Periodique();
            pr.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GestionEmprunt emp = new GestionEmprunt();
            emp.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillGrid()
        {
            conn.Open();

            string displayQuery = "SELECT code,titre,auteur FROM ouvrage WHERE (type='CD')";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            textBox2.Text = dataGridView2.CurrentRow.Cells["auteur"].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells["titre"].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells["code"].Value.ToString();
        }
    }
}
