using System;
using System.IO;
using System.Windows;

namespace dz12_04
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] array = {
                    int.Parse(frstarrayInput.Text),
                    int.Parse(scndarrayInput.Text),
                    int.Parse(thrdarrayInput.Text),
                    int.Parse(frtharrayInput.Text),
                    int.Parse(fiftharrayInput.Text)
                };

                string filePath = @"D:\Projects\c#\dz12_04\dz12_04\array.txt";
                File.WriteAllLines(filePath, Array.ConvertAll(array, x => x.ToString()));

                MessageBox.Show("Масив збережено в файлі array.txt", "Успіх");
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть числа в усі поля", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка");
            }
        }
    }
}
