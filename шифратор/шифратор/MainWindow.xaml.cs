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

namespace шифратор
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;
            if (inputText.Length != 16)
            {
                MessageBox.Show("Введите предложение из 16 символов.");
                return;
            }

            string encryptedText = EncryptText(inputText);

            OutputTextBox.Text = encryptedText;
        }

        private string EncryptText(string inputText)
        {
            char[,] matrix = new char[4, 4];
            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = inputText[index];
                    index++;
                }
            }

            for (int i = 0; i < 4; i += 2)
            {
                for (int j = 0; j < 4; j++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[i + 1, j];
                    matrix[i + 1, j] = temp;
                }
            }

            for (int j = 0; j < 4; j += 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[i, j + 1];
                    matrix[i, j + 1] = temp;
                }
            }

            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    encryptedText.Append(matrix[i, j]);
                }
            }

            return encryptedText.ToString();
        }
    }
}