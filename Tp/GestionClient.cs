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
    public partial class GestionClient : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public GestionClient()
        {
            InitializeComponent();

        }
      



        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            textBox1.Text = textBox3.Text = textBox3.Text = string.Empty;

        }
        private void button1_Click(object sender, EventArgs e)//Ajouter
        {
            string insertQuery = "INSERT INTO client (prenom,nom,cin) VALUES('" + textBox2.Text + "','" + textBox1.Text + "','"+textBox3.Text+"')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery,conn);
            
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Client Ajouté Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                   
                  


                }
                else
                {
                    MessageBox.Show(" Client non ajouté");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            conn.Close();
            FillGrid();

        }
       
        private void button3_Click(object sender, EventArgs e) //supprimer
        {
            try
            {
                string deleteQuery = "DELETE FROM client WHERE cin='" + textBox3.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, conn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Client Supprimé Avec Succès");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show(" client non Supprimé");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            FillGrid();


        }
        int a;
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            a = e.RowIndex;
           DataGridViewRow r = dataGridView1.Rows[a];
            textBox1.Text = r.Cells[0].Value.ToString();
            textBox2.Text = r.Cells[1].Value.ToString();
            textBox3.Text= r.Cells[2].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
          Livre l = new Livre();
            l.Show();
            this.Hide();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            GestionClient for1 = new GestionClient();
            for1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {CD cd = new CD();
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

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GestionClient_Shown(object sender, EventArgs e)
        {
            
        }

        private void GestionClient_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            conn.Open();

            string displayQuery = "SELECT * FROM client ";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            conn.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox2.Text = dataGridView1.CurrentRow.Cells["prenom"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["nom"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["cin"].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
