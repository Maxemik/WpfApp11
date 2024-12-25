using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна
        }

        private void FindExpression1_Click(object sender, RoutedEventArgs e)
        {
            // Задаем строку для поиска
            string input = "2+3 223 2223"; // Исходная строка
            string pattern = @"\b2\+3\b"; // Регулярное выражение для поиска "2+3"

            // Проверяем соответствие регулярному выражению
            Match match = Regex.Match(input, pattern);
            resultsListBox.Items.Clear(); // Очистка предыдущих результатов

            if (match.Success) // Если найдено совпадение
            {
                resultsListBox.Items.Add($"Найдено: {match.Value}"); // Выводим найденное значение
            }
            else
            {
                resultsListBox.Items.Add("Совпадений не найдено."); // Сообщение об отсутствии совпадений
            }
        }

        private void FindExpression2_Click(object sender, RoutedEventArgs e)
        {
            // Задаем строку для поиска
            string input = "aa aba abba abbba abbbba abbbbba"; // Исходная строка
            string pattern = @"\babba\b|\babbba\b|\babbbba\b"; // Регулярное выражение для поиска abba, abbba, abbbba

            // Получаем все совпадения регулярного выражения
            MatchCollection matches = Regex.Matches(input, pattern);
            resultsListBox.Items.Clear(); // Очистка предыдущих результатов

            if (matches.Count > 0) // Если есть совпадения
            {
                foreach (Match match in matches) // Перебираем все найденные совпадения
                {
                    resultsListBox.Items.Add($"Найдено: {match.Value}"); // Выводим каждое найденное значение
                }
            }
            else
            {
                resultsListBox.Items.Add("Совпадений не найдено."); // Сообщение об отсутствии совпадений
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрытие приложения при нажатии кнопки "Выход"
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Кошеренков Максим Сергеевич\nНомер работы: 11\nЗадание: Найти строки с использованием регулярных выражений.", "О программе");
            // Вывод информации о разработчике и задании при нажатии кнопки "О программе"
        }
    }
}