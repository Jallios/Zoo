using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Zoo_WPF.Models;


namespace Zoo_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly string registryPath = 
            Path.Combine(Registry.CurrentUser.Name, "Software", "MyLoginSaver");

        private static string GetRegistryKey(string key)
        {
            return (string)Registry.GetValue(registryPath, key, string.Empty);
        }

        private static void SetRegistryKey(string key, string value)
        {
            Registry.SetValue(registryPath, key, value, RegistryValueKind.String);
        }

        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = pswPassword.Password;

            SetRegistryKey("Login", login);

            Employee user = new Employee() 
            {
                Login = login,
                Password = password
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://192.168.183.253:7254/api/Employees/SignIn", content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiRes = await response.Content.ReadAsStringAsync();
                                Key.token = apiRes;
                                Admin admin = new Admin();
                                admin.Show();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Не верный логин или пароль!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
