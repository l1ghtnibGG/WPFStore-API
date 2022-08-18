using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StoreData.Data = new StoreData();   
            GetProducts();

            Id0Name.Text = StoreData.Data.Products[0].Name
                + '\n' + StoreData.Data.Products[0].Price + " BYN"; 
            Id1Name.Text = StoreData.Data.Products[1].Name
                + '\n' + StoreData.Data.Products[1].Price + " BYN";
            Id2Name.Text = StoreData.Data.Products[2].Name
                + '\n' + StoreData.Data.Products[2].Price + " BYN";
            Id3Name.Text = StoreData.Data.Products[3].Name 
                + '\n' + StoreData.Data.Products[3].Price + " BYN";
        }

        private void GetProducts()
        {
            var url = "https://localhost:7097/api/Product";

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string resposne;
                using(StreamReader sr = new(httpWebResponse.GetResponseStream()))
                {
                    resposne = sr.ReadToEnd();  
                }

                StoreData.Data = JsonConvert.DeserializeObject<StoreData>(resposne);
            }
            catch(WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Id1Clicked(Object sender, RoutedEventArgs e)
        {
            CrudWindow crudWindow = new();
            crudWindow.Show(); 
        }

        /*private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                imgPic1.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            Background = Brushes.White;

            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                imgPic2.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }*/
    }
}
