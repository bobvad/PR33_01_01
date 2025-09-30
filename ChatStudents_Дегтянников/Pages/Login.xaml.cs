using ChatStudents_Дегтянников.Classes;
using ChatStudents_Дегтянников.Models;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.IO;
namespace ChatStudents_Дегтянников.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string srcUserImage = "";
        Classes.UsersContext users = new Classes.UsersContext();
        public Login()
        {
            InitializeComponent();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фотографию:";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                srcUserImage = openFileDialog.FileName;
            }
        }
        public bool CheckEmpty(string Pattern,string Input)
        {
            Match m = Regex.Match(Input,Pattern );
            return m.Success;
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty("[A-ЯёЁ][a-яА-ЯёЁ]*$", Lastname.Text))
            {
                MessageBox.Show("Укажите фамилию.");
                return;
            }
            if (!CheckEmpty("[A-ЯёЁ][a-яА-ЯёЁ]*$", Firstname.Text))
            {
                MessageBox.Show("Укажите имя.");
                return;
            }
            if (!CheckEmpty("[A-ЯёЁ][a-яА-ЯёЁ]*$", Surname.Text))
            {
                MessageBox.Show("Укажите отчество.");
                return;
            }
            if (String.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите изображение.");
                return;
            }
            if (users.Users.Where(x => x.FirstName == Firstname.Text &&
                x.LastName == Lastname.Text &&
                x.Surname == Surname.Text).Count() > 0)
            {
                MainWindow.Instance.LoginUser = users.Users.Where(x => x.FirstName == Firstname.Text &&
                    x.LastName == Lastname.Text &&
                    x.Surname == Surname.Text).First();
                MainWindow.Instance.LoginUser.Photo = File.ReadAllBytes(srcUserImage);
                users.SaveChanges();
            }
            else
            {
                users.Users.Add(new Users(Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(srcUserImage)));
                users.SaveChanges();
                MainWindow.Instance.LoginUser = users.Users.Where(x => x.FirstName == Firstname.Text &&
                    x.LastName == Lastname.Text &&
                    x.Surname == Surname.Text).First();
            }
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
    }
}
