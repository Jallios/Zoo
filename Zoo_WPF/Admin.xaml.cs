using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Zoo_WPF.Models;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Zoo_WPF
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Excel.Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private async void Posts_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Posts"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                                Posts.ItemsSource = posts;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        public async void PostsUpdate()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Posts"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                                Posts.ItemsSource = posts;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private async void Hours_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/HoursWeeks"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<HoursWeek> hours = JsonConvert.DeserializeObject<List<HoursWeek>>(apiResponse);
                                Hours.ItemsSource = hours;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        public async void HoursUpdate()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/HoursWeeks"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<HoursWeek> hours = JsonConvert.DeserializeObject<List<HoursWeek>>(apiResponse);
                                Hours.ItemsSource = hours;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private async void DiseaseCards_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/DiseaseCards"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<DiseaseCard> diseaseCard = JsonConvert.DeserializeObject<List<DiseaseCard>>(apiResponse);
                                DiseaseCards.ItemsSource = diseaseCard;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        public async void DiseaseCardsUpdate()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/DiseaseCards"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<DiseaseCard> diseaseCard = JsonConvert.DeserializeObject<List<DiseaseCard>>(apiResponse);
                                DiseaseCards.ItemsSource = diseaseCard;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private async void Animal_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Animals"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                                Animal.ItemsSource = animals;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        public async void AnimalUpdate()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Animals"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                                Animal.ItemsSource = animals;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private async void Post_Posts_Click(object sender, RoutedEventArgs e)
        {
            Post post = new Post()
            {
                NamePost = txtPosts.Text
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PostAsync("https://192.168.183.253:7254/api/Posts", content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Put_Posts_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Posts.SelectedValue.ToString());
            Post post = new Post()
            {
                IdPost = id,
                NamePost = txtPosts.Text
            };
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PutAsync("https://192.168.183.253:7254/api/Posts/" + id, content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Delete_Posts_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Posts.SelectedValue.ToString());

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.DeleteAsync("https://192.168.183.253:7254/api/Posts/" + id))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Post_Hours_Click(object sender, RoutedEventArgs e)
        {
            HoursWeek hours = new HoursWeek()
            {
                Hours = Convert.ToInt32(txtHours.Text)
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(hours), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PostAsync("https://192.168.183.253:7254/api/HoursWeeks", content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                HoursUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Put_Hours_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Hours.SelectedValue.ToString());

            HoursWeek hours = new HoursWeek()
            {
                IdHours = id,
                Hours = Convert.ToInt32(txtHours.Text)
            };
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(hours), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PutAsync("https://192.168.183.253:7254/api/HoursWeeks/" + id, content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Delete_Hours_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Hours.SelectedValue.ToString());

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.DeleteAsync("https://192.168.183.253:7254/api/HoursWeeks/" + id))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                HoursUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Post_Animals_Click(object sender, RoutedEventArgs e)
        {
            decimal weight = decimal.Parse(txtWeight.Text);
            decimal height = decimal.Parse(txtHeight.Text);

            int type = Int32.Parse(cmbTypeOfAnimal.SelectedValue.ToString());
            int nd = Int32.Parse(cmbNumberCardDiseases.SelectedValue.ToString());
            int av = Int32.Parse(cmbAviary.SelectedValue.ToString());
            int status = Int32.Parse(cmbStatusAnimal1.SelectedValue.ToString());

            Animal animal = new Animal()
            {
                NameAnimal = txtName.Text,
                Weight = weight,
                Height = height,
                TypeOfAnimalId = type,
                DiseaseId = nd,
                AviaryId = av,
                StatusAnimalId = status
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PostAsync("https://192.168.183.253:7254/api/Animals", content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                AnimalUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Put_Animals_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Animal.SelectedValue.ToString());
            decimal weight = decimal.Parse(txtWeight.Text);
            decimal height = decimal.Parse(txtHeight.Text);

            int type = Int32.Parse(cmbTypeOfAnimal.SelectedValue.ToString());
            int nd = Int32.Parse(cmbNumberCardDiseases.SelectedValue.ToString());
            int av = Int32.Parse(cmbAviary.SelectedValue.ToString());
            int status = Int32.Parse(cmbStatusAnimal1.SelectedValue.ToString());

            Animal animal = new Animal()
            {
                IdAnimal = id,
                NameAnimal = txtName.Text,
                Weight = weight,
                Height = height,
                TypeOfAnimalId = type,
                DiseaseId = nd,
                AviaryId = av,
                StatusAnimalId = status
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PutAsync("https://192.168.183.253:7254/api/Animals/" + id, content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Delete_Animals_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(Animal.SelectedValue.ToString());

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.DeleteAsync("https://192.168.183.253:7254/api/Animals/" + id))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                AnimalUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Post_DiseaseCards_Click(object sender, RoutedEventArgs e)
        {
            DiseaseCard disease = new DiseaseCard()
            {
                NumberCardDiseases = Convert.ToInt32(txtNumberCardDiseases.Text),
                Diseases = txtDiseases.Text,
                DateStartIllness = dpDateStartIllness.SelectedDate,
                DateEndIllness = dpDateEndIllness.SelectedDate
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PostAsync("https://192.168.183.253:7254/api/DiseaseCards", content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                DiseaseCardsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Put_DiseaseCards_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(DiseaseCards.SelectedValue.ToString());

            DiseaseCard disease = new DiseaseCard()
            {
                IdDisease = id,
                NumberCardDiseases = Convert.ToInt32(txtNumberCardDiseases.Text),
                Diseases = txtDiseases.Text,
                DateStartIllness = dpDateStartIllness.SelectedDate,
                DateEndIllness = dpDateEndIllness.SelectedDate
            };

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");

                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.PutAsync("https://192.168.183.253:7254/api/DiseaseCards/" + id, content))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                PostsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void Delete_DiseaseCards_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(DiseaseCards.SelectedValue.ToString());

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.DeleteAsync("https://192.168.183.253:7254/api/DiseaseCards/" + id))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResp = await response.Content.ReadAsStringAsync();
                                MessageBox.Show("Успешно!!!");
                                DiseaseCardsUpdate();
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void cmbTypeOfAnimal_Loaded(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/TypeOfAnimals"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<TypeOfAnimal> typeOfanimals = JsonConvert.DeserializeObject<List<TypeOfAnimal>>(apiResponse);
                                cmbTypeOfAnimal.ItemsSource = typeOfanimals;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void cmbNumberCardDiseases_Loaded(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/DiseaseCards"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<DiseaseCard> diseaseCards = JsonConvert.DeserializeObject<List<DiseaseCard>>(apiResponse);
                                cmbNumberCardDiseases.ItemsSource = diseaseCards;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void cmbAviary_Loaded(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Aviaries"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Aviary> aviaries = JsonConvert.DeserializeObject<List<Aviary>>(apiResponse);
                                cmbAviary.ItemsSource = aviaries;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void cmbStatusAnimal1_Loaded(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/StatusAnimals"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<StatusAnimal> statusAnimals = JsonConvert.DeserializeObject<List<StatusAnimal>>(apiResponse);
                                cmbStatusAnimal1.ItemsSource = statusAnimals;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
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

        private async void AM_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/Ams"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Am> am = JsonConvert.DeserializeObject<List<Am>>(apiResponse);
                                AM.ItemsSource = am;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private void Word_Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Excel_Export_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; //www.yazilimkodlama.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < AM.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = AM.Columns[j].Header;
            }
            for (int i = 0; i < AM.Columns.Count; i++)
            { //www.yazilimkodlama.com
                for (int j = 0; j < AM.Items.Count; j++)
                {
                    TextBlock b = AM.Columns[i].GetCellContent(AM.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private async void cmbTypeOfWork_Loaded(object sender, RoutedEventArgs e)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync("https://192.168.183.253:7254/api/TypeOfWorks"))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<TypeOfWork> typeOfWorks = JsonConvert.DeserializeObject<List<TypeOfWork>>(apiResponse);
                                cmbTypeOfWork.ItemsSource = typeOfWorks;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            string URI;
            string employee = txtEmployee.Text;
            int type = Int32.Parse(cmbTypeOfWork.SelectedValue.ToString());

            if (employee == "" && type == 0)
            {
                URI = "https://192.168.183.253:7254/api/Ams";
            }
            if (string.IsNullOrEmpty(employee) && type == null)
            {
                URI = "https://192.168.183.253:7254/api/Ams";
            }
            else if (string.IsNullOrEmpty(employee) && type != null)
            {
                URI = "https://192.168.183.253:7254/api/Ams?type=" + type;
            }
            else if (!string.IsNullOrEmpty(employee) && type == null)
            {
                URI = "https://192.168.183.253:7254/api/Ams?employee=" + employee;
            }
            else
            {
                URI = "https://192.168.183.253:7254/api/Ams?employee=" + employee + "&type=" + type;
            }


            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    dynamic data = JObject.Parse(Key.token);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + data.access_token);
                    using (var response = await httpClient.GetAsync(URI))
                    {
                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                List<Am> am = JsonConvert.DeserializeObject<List<Am>>(apiResponse);
                                AM.ItemsSource = am;

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                Key key = new Key();
                                key.RefreshToken();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!!!");
                        }
                    }
                }
            }
        }

        dynamic Excel.Window.Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Excel.Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        dynamic Excel.Window.Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public int WindowNumber => throw new NotImplementedException();

        XlWindowState Excel.Window.WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}
