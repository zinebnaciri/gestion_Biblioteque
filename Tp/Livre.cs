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
    public partial class Livre : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public Livre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Ajouter
        {
            string insertQuery = "INSERT INTO ouvrage (code,titre,auteur,editeur,type) VALUES('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','LIVRE')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Livre Ajouté Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show(" Livre non ajouté");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();

        }
       
        private void button2_Click(object sender, EventArgs e) // modifiEr
        {
            string insertQuery = "UPDATE ouvrage SET titre='" + textBox1.Text + "',auteur='" + textBox2.Text + "',editeur='" + textBox4.Text + "', type='LIVRE' WHERE code='" + textBox3.Text + "'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Livre modifié Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show(" Livre non Modifié");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();


        }

        private void button3_Click(object sender, EventArgs e)// supprimer
        {
            try
            {
                string deleteQuery = "DELETE FROM ouvrage WHERE code='" + textBox3.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, conn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Livre Supprimé Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show(" Livre non Supprimé");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
         


        }

        private void button4_Click(object sender, EventArgs e)
        {
            GestionOuvrage ouv = new GestionOuvrage();
            ouv.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Livre_Load(object sender, EventArgs e)
        {
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
       
        private void FillGrid()
        {
            conn.Open();

            string displayQuery = "SELECT code,titre,auteur,editeur FROM ouvrage WHERE (type='LIVRE')";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells["editeur"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["auteur"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["titre"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["code"].Value.ToString();
          
        }
    }
}
