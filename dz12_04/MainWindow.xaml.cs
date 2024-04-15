using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace FileViewerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FilePathTextBox.TextChanged += FilePathTextBox_TextChanged;
        }

        private void FilePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FileContentTextBox.Text = "";
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Будь ласка, введіть шлях до файлу.");
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не існує.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                FileContentTextBox.Text = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при читанні файлу: " + ex.Message);
            }
        }
    }
}
