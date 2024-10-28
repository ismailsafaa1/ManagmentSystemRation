using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagmentSystemRation
{
    public partial class Month1 : Form
    {
        public Month1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=.;Database=RationTB;User Id=sa;Password=sa123456;Encrypt=true;TrustServerCertificate=True;");
        void populate()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "SELECT * FROM FirstMonths";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Month1_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Fields cannot be left empty");
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "INSERT INTO FirstMonths (name, flour, rice, lentils, oil, chickpease, sugar, paste) VALUES (@name, @flour, @rice, @lentils, @oil, @chickpease, @sugar, @paste)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@flour", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rice", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@lentils", comboBox3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@oil", comboBox4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@chickpease", comboBox5.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@sugar", comboBox6.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@paste", comboBox7.SelectedItem.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User Successfully Created");
                }
                else
                {
                    MessageBox.Show("No rows were inserted. Please check your data.");
                }
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM FirstMonths WHERE   AND name = @name AND flour = @flour AND rice= @rice AND lentils = @lentils AND oil = @oil AND chickpease = @chickpease AND sugar = @sugar AND  paste = @paste";
                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@flour", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rice", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@lentils", comboBox3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@oil", comboBox4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@chickpease", comboBox5.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@sugar", comboBox6.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@paste", comboBox7.SelectedItem.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("No user found with the specified details");
                }
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
