using System;
using System.Windows;

namespace AikenToDecimal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // массив с двоично-десятичными значениями в коде Айкена для каждой цифры
        private static readonly string[] aikenCodes = { "0000", "0001", "0010", "0011", "0100", "1011", "1100", "1101", "1110", "1111" };

        // обработчик нажатия кнопки "Start"
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string aikenInput = AikenInput.Text;

            // проверка правильности введенного числа (длина должна быть кратной 4)
            if (aikenInput.Length % 4 != 0)
            {
                MessageBox.Show("Введите корректный двоично-десятичный код Айкена (длина должна быть кратна 4)");
                return;
            }

            try
            {
                string decimalNumber = ConvertAikenToDecimal(aikenInput);
                DecimalOutput.Text = decimalNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // преобразование двоично-десятичного числа Айкена в десятичное
        private string ConvertAikenToDecimal(string aikenCode)
        {
            string result = "";

            // Разбивка входного кода на группы по 4 бита (тетрады)
            for (int i = 0; i < aikenCode.Length; i += 4)
            {
                string tetrad = aikenCode.Substring(i, 4);

                // ищем тетраду в массиве кода Айкена
                int decimalValue = Array.IndexOf(aikenCodes, tetrad);

                if (decimalValue == -1)
                {
                    throw new Exception($"Неверная тетрада: {tetrad}");
                }

                // добавляем найденное десятичное значение к результату
                result += decimalValue.ToString();
            }

            return result;
        }

        // обработчик кнопки "Exit"
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
