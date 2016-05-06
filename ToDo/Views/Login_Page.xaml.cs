using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace ToDo.View
{

    public sealed partial class Login_Page : Page
    {
        //Deklarasi variabel path Sqlite
        String path;
        SQLite.Net.SQLiteConnection conn;
        public string email, name;

        public Login_Page()
        {
            this.InitializeComponent();
            //Inisialisasi database dan open connection//
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.todo_regist");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register_Page));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (inputEmail.Text.Trim() == "" && inputPassword.Password.Trim() =="")
            {
                MessageDialog();
            }else if (inputPassword.Password.Trim() == "")
            {
                MessageDialog();
            }else if(inputEmail.Text.Trim() == "")
            {
                MessageDialog();
            }
            else
            {
                String getEmail = inputEmail.Text.Trim();
                String getPassword = inputPassword.Password;
                if (conn == null)
                {
                    ConnCheck();
                }else
                {
                    using (conn)
                    {
                        if (conn == null)
                        {
                            ConnCheck();
                        }else
                        {
                            this.Frame.Navigate(typeof(Views.Home_Page));
                        }
                        Debug.WriteLine(conn.DatabasePath);

                    }
                    //this.Frame.Navigate(typeof(Views.Home_Page));
                }
               
               // getUserData(getEmail, getPassword);
                
            }
            
        }
        
        private void getUserData(String getEmail, String getPassword)
        {
            
            using (conn)
            {
                var query = conn.Query<Models.M_Login>(@"SELECT Fullname, Email, CreatedAt
                    FROM M_Register WHERE Email ==" + getEmail + "AND Password ==" + getPassword + ";");
                //Kenapa :(((

                foreach (var message in query)
                {
                    email = message.Email;
                    name = message.Fullname;
                    
                }
                
            }
        }

       //******************************Alert******************************************//
        private async void MessageDialog()
        {
            var dialog = new MessageDialog("Fill The Field");
            await dialog.ShowAsync();
        }

        private async void EmailValidation()
        {
            var dialog = new MessageDialog("Invalid Email");
            await dialog.ShowAsync();
        }

        private async void ConnCheck()
        {
            var dialog = new MessageDialog("Failde Get Food Path");
            await dialog.ShowAsync();
        }
    } //Login Page Class End
}
