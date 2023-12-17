using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project
{
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }



        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var Username = UsernameText.Text;
            var Password = PasswordText.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.Name == Username && user.Password == Password);
                if (userfound) 
                {
                    GrantAcces();
                    Close();
                }
                else
                {
                    MessageBox.Show("User not found!");
                }



            }




        }



        public void GrantAcces()
        {
            MainWindow main= new MainWindow();
            main.Show();

        }


    }



}
