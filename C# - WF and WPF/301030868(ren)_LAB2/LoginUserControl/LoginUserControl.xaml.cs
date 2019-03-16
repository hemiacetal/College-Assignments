/*
 *  Filename:       LoginUserControl.xaml.cs
 *  Author:         Vivian Ren (301030868)
 *  Due date:       February 8, 2019
 *  Description:    Part of Question 2 for Lab 2 of COMP212.
 *                  Contains all interaction logic for the LoginUserControl element.
 *                  Username/Passwords should typically be in some sort of encrypted
 *                  data table, but in this case we just initialize a single username "myusername"
 *                  and password "mypassword" to check the workings of a UserControl within
 *                  the MainWindow of 301030868(ren)_Question2_LoginUserControlTest using
 *                  Dependency Properties.
 *                  Clicking the login button shows the user a message box with authentication, 
 *                  confirming if they wrote the right username and password combination or not.
 * 
 */

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

namespace LoginUserControl
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        public bool LoginAuthentication(string username, string password)
        {
            return username.Equals(Username) && password.Equals(Password);
        }

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static DependencyProperty UsernameProperty =
           DependencyProperty.Register(nameof(Username), typeof(string), typeof(LoginUserControl), new PropertyMetadata("Username"));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static DependencyProperty PasswordProperty =
           DependencyProperty.Register(nameof(Password), typeof(string), typeof(LoginUserControl), new PropertyMetadata("Password"));

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (LoginAuthentication(usernameTextBox.Text, passwordTextBox.Password))
                MessageBox.Show("Welcome, " + Username + "!");
            else
                MessageBox.Show("Invalid Credentials.");
        }
    }
}
