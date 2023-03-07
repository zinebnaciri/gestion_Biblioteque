using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Tp
{
    public partial class Home : Form

    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost; username=root;password=;database=gestionbib");
        public Home()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillGrid();

       


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //pour sortir de la form actuelle et aller vers la forme envisagé
            GestionClient G = new GestionClient();
            this.Hide();// FERMER LA FORME ACTUELLE
            G.Show();//montrer la forme souhaité
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Livre over = new Livre();
            over.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionEmprunt empr = new GestionEmprunt();
            empr.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Livre l = new Livre();
            l.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CD cd = new CD();
            cd.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Periodique pr = new Periodique();
            pr.Show();
            this.Hide();
        }
        private void FillGrid()
        {
            conn.Open();

            string displayQuery = "SELECT e.id,c.nom,c.prenom,o.type,o.titre,e.date_demprunt,e.date_retour FROM emprunt e,client c, ouvrage o WHERE c.id=e.id_client AND o.code=e.id_ouvrage ";
            MySqlDataAdapter da = new MySqlDataAdapter(displayQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valueOfSearch = textBox1.Text.ToString();
            search(valueOfSearch);
        }
        public void search(string valueOfSearch)
        {
            string displayQuery = "SELECT e.id,c.nom,c.prenom,o.type,o.titre,e.date_demprunt,e.date_retour FROM emprunt e,client c, ouvrage o WHERE c.id=e.id_client AND o.code=e.id_ouvrage AND CONCAT(e.id,c.nom,c.prenom,o.type,o.titre) like '%" + textBox1.Text + "%' ";
            MySqlCommand cmd = new MySqlCommand(displayQuery, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

