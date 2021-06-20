using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ZooManagementSystem
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        SqlConnection sqlConnection;
        public Window3()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["ZooManagementSystem.Properties.Settings.ZooManagementSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            ShowNameList();
            ShowAgeList();
            ShowGenderList();
            ShowColorList();
            ShowSpeciesList();
        }

        private void ShowSpeciesList()
        {
            // Showing species of animals from database
            try
            {
                string query = "select * from Animals";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable animalstable = new DataTable();
                    sqlDataAdapter.Fill(animalstable);
                    species_lst.DisplayMemberPath = "Species";
                    species_lst.SelectedValuePath = "Id";
                    species_lst.ItemsSource = animalstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowColorList()
        {
            // Showing color of animals from database
            try
            {
                string query = "select * from Animals";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable animalstable = new DataTable();
                    sqlDataAdapter.Fill(animalstable);
                    color_lst.DisplayMemberPath = "Color";
                    color_lst.SelectedValuePath = "Id";
                    color_lst.ItemsSource = animalstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowGenderList()
        {
            // Showing gender of animals from database
            try
            {
                string query = "select * from Animals";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable animalstable = new DataTable();
                    sqlDataAdapter.Fill(animalstable);
                    gender_lst.DisplayMemberPath = "Gender";
                    gender_lst.SelectedValuePath = "Id";
                    gender_lst.ItemsSource = animalstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowAgeList()
        {
            // Showing age of animals from database
            try
            {
                string query = "select * from Animals";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable animalstable = new DataTable();
                    sqlDataAdapter.Fill(animalstable);
                    age_lst.DisplayMemberPath = "Age";
                    age_lst.SelectedValuePath = "Id";
                    age_lst.ItemsSource = animalstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowNameList()
        {
            // Showing name of animals from database
            try
            {
                string query = "select * from Animals";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable animalstable = new DataTable();
                    sqlDataAdapter.Fill(animalstable);
                    name_lst.DisplayMemberPath = "Name";
                    name_lst.SelectedValuePath = "Id";
                    name_lst.ItemsSource = animalstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            // Updating the information of animals in the database
            try
            {
                string query = "Update Animals set name=@Name, age=@Age, gender=@Gender, color=@Color, species=@Species where name=@Name";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", name_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Age", age_txt.Text);

                if (male_rdbtn.IsChecked == true)
                {
                    sqlCommand.Parameters.AddWithValue("@Gender", male_rdbtn.Content);
                }
                else if (female_rdbtn.IsChecked == true)
                {
                    sqlCommand.Parameters.AddWithValue("@Gender", female_rdbtn.Content);
                }

                // SelectedValue returns a ComboBoxItem.
                var item = (ComboBoxItem)color_cmb.SelectedValue;
                sqlCommand.Parameters.AddWithValue("@Color", (string)item.Content);
                sqlCommand.Parameters.AddWithValue("@Species", species_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Animal is updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Window3 window3 = new Window3();
                window3.ShowDialog();
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            // Deleting the information of animals in the database
            try
            {
                string query = "delete from Animals where name=@Name";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", name_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Animal is deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Window3 window3 = new Window3();
                window3.ShowDialog();
            }
        }

        private void add_animal_btn_Click(object sender, RoutedEventArgs e)
        {
            // Adding the information of animals in the database
            try
            {
                string query = "insert into Animals values (@Name,@Age,@Gender,@Color,@Species)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", name_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Age", age_txt.Text);

                if (male_rdbtn.IsChecked==true)
                {
                    sqlCommand.Parameters.AddWithValue("@Gender", male_rdbtn.Content);
                }
                else if (female_rdbtn.IsChecked == true)
                {
                    sqlCommand.Parameters.AddWithValue("@Gender", female_rdbtn.Content);
                }

                // SelectedValue returns a ComboBoxItem.
                var item = (ComboBoxItem)color_cmb.SelectedValue;
                sqlCommand.Parameters.AddWithValue("@Color", (string)item.Content);
                sqlCommand.Parameters.AddWithValue("@Species", species_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("User is added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Window3 window3 = new Window3();
                window3.ShowDialog();
            }
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            // Return to the previous window
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
