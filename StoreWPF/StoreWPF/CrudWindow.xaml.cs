using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace StoreWPF
{
    /// <summary>
    /// Логика взаимодействия для CrudWindow.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
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
    }
}
