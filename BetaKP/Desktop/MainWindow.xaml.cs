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
using System.Data.Entity;
using Desktop.Views.Windows;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var context = new Model.Context())
            {
                var listUsers = context.Users.ToList();  // список пользователей
                foreach (var item in listUsers)
                {
                    MessageBox.Show(item.FirstName);
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)  // авторизация
        {
            // валидация

            using(var context = new Model.Context())
            {
                var user = context.Users.Include(i => i.TypeUser).FirstOrDefault(i => 
                i.Login == tbLogin.Text.Trim() && i.Password == pbPassword.Password.Trim());
                if(user != null)
                {
                    MessageBox.Show($"Добро пожаловать {user.Fio}\n" +
                        $"Вы войдете под учетной записью {user.TypeUser.Name}!");
                    switch (user.TypeUser.Name)  // открытие рабочего окна пользователя
                    {
                        case "Пользователь":
                            new UserWindow().Show();
                            break;
                        case "Администратор":
                            new AdminWindow().Show();
                            break;
                        default:
                            MessageBox.Show("Что-то пошло не так!");
                            break;
                    }
                    Close();  // закрытие текущего окна
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует!");
                }
            }
        }
    }
}
