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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ZooManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            // ZooManagementSystemDBConnectionString
            InitializeComponent();
        }


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            // Verification of login to admin panel
            if (adminname_txt.Text=="BSB" && adminpass_txt.Text=="123")
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            // Closing the application
            Application.Current.Shutdown();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            // Login verification to the user panel
            string connectionString = ConfigurationManager.ConnectionStrings["ZooManagementSystem.Properties.Settings.ZooManagementSystemDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                if(sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                string query = "select count(1) from Users where username=@Username and password=@Password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", username_txt.Text);
                sqlCommand.Parameters.AddWithValue("@Password", userpass_txt.Text);
                // ExecuteScalar is typically used when your query returns a single value.
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if(count == 1)
                {
                    Window4 window4 = new Window4();
                    window4.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
