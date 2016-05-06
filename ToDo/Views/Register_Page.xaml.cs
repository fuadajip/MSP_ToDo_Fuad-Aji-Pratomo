using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using SQLite.Net.Attributes;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register_Page : Page
    {

        //Deklarasi variabel path Sqlite
        String path;
        SQLite.Net.SQLiteConnection conn;
        int tabelcondition;

        public Register_Page()
        {
            this.InitializeComponent();

            //Inisialisasi database dan open connection//
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.todo_regist");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
           tabelcondition= conn.CreateTable<Models.M_Register>();
        }

        private void backLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login_Page));
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            if (inputName.Text.Trim() == "" && inputEmail.Text.Trim()=="" && inputPassword.Password.Trim() == "" && inputPassword2.Password.Trim() == "")
            {
                MessageDialog();
            }
            else if (inputName.Text.Trim() == "")
            {
                MessageDialog();
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(inputEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                EmailValidation();
            }
            else if (inputPassword.Password.Trim() == "")
            {
                MessageDialog();
            }
            else if (inputPassword2.Password.Trim() == "")
            {
                MessageDialog();
            }
            else if (inputEmail.Text.Trim() == "")
            {
                MessageDialog();
            }
            else
            {
                if(inputPassword.Password != inputPassword2.Password)
                {
                    PasswordNotMatch();
                }else
                {
                    submitRegist();
                }
            }

        }

        private void submitRegist()
        {
            if (conn == null)
            {
                dbStatusDialog();
            }
            else
            {
                conn.Insert(new Models.M_Register()
                {
                    Fullname = inputName.Text,
                    Email = inputEmail.Text,
                    Password = inputPassword.Password,
                    CreatedAt = DateTime.Now.ToString("dd-MM-yyyy"),
                    UpdatedAt = DateTime.Now.ToString("dd-MM-yyyy")
                });
                InsertDialog();
            }
        }

        private async void dbStatusDialog()
        {
            var dialog = new MessageDialog("Database connection error");
            await dialog.ShowAsync();
        }

        private async void EmailValidation()
        {
            var dialog = new MessageDialog("Invalid email");
            await dialog.ShowAsync();
        }
        private async void MessageDialog()
        {
            var dialog = new MessageDialog("Fill the field");
            await dialog.ShowAsync();
        }
        private async void InsertDialog()
        {
            var dialog = new MessageDialog("Registered success");
            await dialog.ShowAsync();
        }

        private async void PasswordNotMatch()
        {
            var dialog = new MessageDialog("Password not match");
            await dialog.ShowAsync();
        }

    }//end partial class
}//End Bracket
