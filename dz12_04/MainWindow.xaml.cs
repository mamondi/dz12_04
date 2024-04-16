using System;
using System.IO;
using System.Windows;

//2 та 3 практичні

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
                string firstValue = frstarrayInput.Text;
                string secondValue = scndarrayInput.Text;
                string thirdValue = thrdarrayInput.Text;
                string fourthValue = frtharrayInput.Text;
                string fifthValue = fiftharrayInput.Text;

                if (string.IsNullOrEmpty(firstValue) || string.IsNullOrEmpty(secondValue) ||
                    string.IsNullOrEmpty(thirdValue) || string.IsNullOrEmpty(fourthValue) ||
                    string.IsNullOrEmpty(fifthValue))
                {
                    MessageBox.Show("Всі поля повинні бути заповнені", "Помилка");
                    return;
                }

                string[] values = new string[] { firstValue, secondValue, thirdValue, fourthValue, fifthValue };

                File.WriteAllLines("array.txt", values);

                MessageBox.Show("Масив успішно збережено в файл array.txt", "Успіх");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка під час збереження: " + ex.Message, "Помилка");
            }
        }
        private void loadArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "array.txt";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    frstarrayInput.Clear();
                    scndarrayInput.Clear();
                    thrdarrayInput.Clear();
                    frtharrayInput.Clear();
                    fiftharrayInput.Clear();

                    if (lines.Length == 5)
                    {
                        frstarrayInput.Text = lines[0];
                        scndarrayInput.Text = lines[1];
                        thrdarrayInput.Text = lines[2];
                        frtharrayInput.Text = lines[3];
                        fiftharrayInput.Text = lines[4];

                        MessageBox.Show("Масив завантажено з файлу array.txt", "Успіх");
                    }
                    else
                    {
                        MessageBox.Show("Неправильний формат файлу array.txt", "Помилка");
                    }
                }
                else
                {
                    MessageBox.Show("Файл array.txt не знайдено", "Помилка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка");
            }
        }
    }
}
