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
    public partial class GestionEmprunt : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public GestionEmprunt()
        {
            InitializeComponent();
          
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            
        }

        private void button4_Click(object sender, EventArgs e)//Retour
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
          Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO emprunt  (id,id_client,id_ouvrage,date_demprunt,date_retour) VALUES('" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','"+dateTimePicker1.Value+"','"+dateTimePicker2.Value+"')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Emprunt Ajouté Avec Succès");
                    textBox1.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)

        {
            
        }

        private void GestionEmprunt_Load(object sender, EventArgs e)
        {
            FillGrid();//remplire datagrid
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT id from client", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name=reader.GetString("id");
                comboBox2.Items.Add(name);

            }
            cmd.Dispose();
            reader.Close();
            MySqlCommand cmd1 = new MySqlCommand("SELECT code from ouvrage", conn);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string name1 = reader1.GetString("code");
                comboBox1.Items.Add(name1);

            }
            cmd1.Dispose();
            reader1.Close();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM emprunt WHERE id='" + textBox1.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, conn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Emprunt Supprimé Avec Succès");
                    textBox1.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();

                }
                else
                {
                    MessageBox.Show(" Emprunt non Supprimé");

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

            string displayQuery = "SELECT * FROM emprunt ";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string insertQuery = "UPDATE emprunt SET id_client='" + comboBox2.Text + "',id_ouvrage='" + comboBox1.Text + "', date_demprunt='" + dateTimePicker1.Value + "',date_retour='" + dateTimePicker2.Value + "' WHERE id='" + textBox1.Text + "'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Emprunt modifié Avec Succès");
                    textBox1.Clear();
                  
                }
                else
                {
                    MessageBox.Show(" Emprunt non Modifié");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox1.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["id_ouvrage"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["id_client"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["date_demprunt"].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["date_retour"].Value);


        }
    }
}
