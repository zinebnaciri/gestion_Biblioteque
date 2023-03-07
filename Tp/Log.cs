namespace Tp
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Login = textBox1.Text;
            String PassWord = textBox2.Text;
            if (Login!=""&& PassWord!="") {
                if (Login == "ADMIN" && PassWord == "123")
                {
                    Home form=new Home();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    label3.Visible = true;
                    label3.BackColor = Color.Aqua;
                    label3.Text = "Mot de passe/Login est incorrect";
                }
            }else{
                label3.Visible = true;
                label3.BackColor = Color.Aqua;
                label3.Text = "veullez saisir les champs obligatoires";
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}