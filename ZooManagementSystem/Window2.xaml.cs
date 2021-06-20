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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        SqlConnection sqlConnection;
        public Window2()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["ZooManagementSystem.Properties.Settings.ZooManagementSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            ShowUsernameList();
            ShowPasswordList();
            ShowContactNumberList();
        }

        private void ShowContactNumberList()
        {
            // Showing contact number of users from database
            try
            {
                string query = "select * from Users";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable userstable = new DataTable();
                    sqlDataAdapter.Fill(userstable);
                    number_lstbx.DisplayMemberPath = "Contact_Number";
                    number_lstbx.SelectedValuePath = "Id";
                    number_lstbx.ItemsSource = userstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowPasswordList()
        {
            // Showing password of users from database
            try
            {
                string query = "select * from Users";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable userstable = new DataTable();
                    sqlDataAdapter.Fill(userstable);
                    password_lstbx.DisplayMemberPath = "Password";
                    password_lstbx.SelectedValuePath = "Id";
                    password_lstbx.ItemsSource = userstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowUsernameList()
        {
            // Showing username of users from database
            try
            {
                string query = "select * from Users";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable userstable = new DataTable();
                    sqlDataAdapter.Fill(userstable);
                    username_lstbx.DisplayMemberPath = "Username";
                    username_lstbx.SelectedValuePath = "Id";
                    username_lstbx.ItemsSource = userstable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            // Updating the information of users in the database
            try
            {
                string query = "Update Users set username=@Username, password=@Password, contact_number=@Contact_Number where username=@Username";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Username", username_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Password", password_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Contact_Number", number_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("User is updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Window2 window2 = new Window2();
                window2.ShowDialog();
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            // Deleting user information in the database
            try
            {
                string query = "delete from Users where username=@Username";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Username", username_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("User is deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                Window2 window2 = new Window2();
                window2.ShowDialog();
            }
        }

        private void add_user_btn_Click(object sender, RoutedEventArgs e)
        {
            // Adding user information in the database
            try
            {
                string query = "insert into Users values (@Username,@Password,@Contact_Number)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Username", username_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Password", password_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Contact_Number", number_txt.Text);
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
                Window2 window2 = new Window2();
                window2.ShowDialog();
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
