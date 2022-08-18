using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StoreWPF
{
    /// <summary>
    /// Логика взаимодействия для CrudWindow.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
        private const string URI = "https://localhost:7097/api/Product";
        public CrudWindow()
        {
            InitializeComponent();
            InitializeProduct();
        }

        private void InitializeProduct()
        {
            Id0Product.Text = StoreData.Data.Products[0].Name + 
                '\n' + StoreData.Data.Products[0].Description +
                '\n' + StoreData.Data.Products[0].Price + " BYN" +
                "\n Amount " + StoreData.Data.Products[0].Amount;
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            nameEditContent.Text = StoreData.Data.Products[0].Name;
            priceEditContent.Text = StoreData.Data.Products[0].Price.ToString();
            descriptionEditContent.Text = StoreData.Data.Products[0].Description;
            amountEditContent.Text = StoreData.Data.Products[0].Amount.ToString();
       
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void EditImageClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                EditImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }   
        }

        private void EditApllyButtonClicked(object sender, RoutedEventArgs e)
        {
            StoreData.Data.Products[0].Name = nameEditContent.Text;
            StoreData.Data.Products[0].Price = Convert.ToInt32(priceEditContent.Text);
            StoreData.Data.Products[0].Description = descriptionEditContent.Text;
            StoreData.Data.Products[0].Amount = Convert.ToInt32(amountEditContent.Text);

            PutRequest();
        }

        private void PutRequest()
        {
            var jsonStr = JsonConvert.SerializeObject(StoreData.Data.Products[0]);
            var data = Encoding.ASCII.GetBytes(jsonStr);

            using (var client = new WebClient())
            {
                client.Headers.Add("accept: text/plain");
                client.Headers.Add("Content-Type: application/json");
                client.UploadData(URI, "PUT", data);
            }
        }

        private byte[] SerializeToByteArray(object obj)
        {
            BinaryFormatter bf = new();

            try
            {
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);

                    return ms.ToArray();
                }
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
            }
            return null;
        }
    }
}
