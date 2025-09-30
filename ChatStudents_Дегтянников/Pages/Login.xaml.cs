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
        Classes.UserMessageContext users = new Classes.UserMessageContext();
        public Login()
        {
            InitializeComponent();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фотографию:";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All files (*.*)]*.*"; // Если файл выбран
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
            if (!CheckEmpty("[A-ЯЁ][a-яё]*5", Lastname.Text))
            {
                MessageBox.Show("Укажите фамилию.");
                return;
            }
            if (!CheckEmpty("[A-ЯЁ][a-яё]*5", Firstname.Text))
            {
                MessageBox.Show("Укажите имя.");
                return;
            }
            if (!CheckEmpty("[A-ЯЁ][a-яё]*5", Surname.Text))
            {
                MessageBox.Show("Укажите отчество.");
                return;
            }
            if (String.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите изображение.");
                return;
            }
            if (UserMessageContext.Users.Where(x => x.Firstname == Firstname.Text &&
                x.Lastname == Lastname.Text &&
                x.Surname == Surname.Text).Count() > 0)
            {
                MainWindow.Instance.LoginUser = userContext.Users.Where(x => x.Firstname == Firstname.Text &&
                    x.Lastname == Lastname.Text &&
                    x.Surname == Surname.Text).First();
                MainWindow.Instance.LoginUser.Photo = File.ReadAllBytes(srcUserImage);
                UserMessageContext.SaveChanges();
            }
            else
            {
                UserMessageContext.Users.Add(new Users(Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(srcUserImage)));
                UserMessageContext.SaveChanges();
                MainWindow.Instance.LoginUser = UserMessageContext.Users.Where(x => x.Firstname == Firstname.Text &&
                    x.Lastname == Lastname.Text &&
                    x.Surname == Surname.Text).First();
            }
            MainWindow.Instance.OpenPages(new Pages.Main());
        }
    }
}
