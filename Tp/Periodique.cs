using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tp
{
    public partial class Periodique : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public Periodique()
        {
            InitializeComponent();
        }

        private void Periodique_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text,  textBox3.Text, textBox4.Text);
            textBox1.Clear();
           
            textBox3.Clear();
            textBox4.Clear();
           
        }
        int a;

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow data = dataGridView1.Rows[a];
            data.Cells[0].Value = textBox1.Text;
            
            data.Cells[2].Value = textBox3.Text;
            data.Cells[3].Value = textBox4.Text;
         
        }

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
           
            textBox3.Text = r.Cells[2].Value.ToString();
            textBox4.Text = r.Cells[3].Value.ToString();
            
        }

        private void Retour_Click(object sender, EventArgs e)
        {
           GestionOuvrage ouvr = new GestionOuvrage();
            ouvr.Show();
            this.Hide();
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

        private void button10_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO ouvrage (code,titre,periodicite,type) VALUES('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','PERIODIQUE')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Periodique Ajouté Avec Succès");
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                    dataGridView1.Rows[0].Cells[2].Value = textBox4.Text;
                }
                else
                {
                    MessageBox.Show(" Periodique non ajouté");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();
        }


        private void FillGrid()
        {
            conn.Open();
            
         string displayQuery = "SELECT code,titre,periodicite FROM ouvrage WHERE (type='PERIODIQUE')";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close(); 

        
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
                    MessageBox.Show("Periodique Supprimé Avec Succès");
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show(" Periodique non Supprimé");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                string insertQuery = "UPDATE ouvrage SET titre='" + textBox1.Text + "',periodicite='" + textBox4.Text + "' WHERE code='" + textBox3.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, conn);
                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Periodique modifié Avec Succès");
                        textBox1.Clear();
                      
                        textBox3.Clear();
                        textBox4.Clear();
                    }
                    else
                    {
                        MessageBox.Show(" Periodique non Modifié");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                conn.Close();
                FillGrid();


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells["periodicite"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["titre"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["code"].Value.ToString();
        }
    }
}
