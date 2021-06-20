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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        SqlConnection sqlConnection;
        public Window4()
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

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            // Return to the previous window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
