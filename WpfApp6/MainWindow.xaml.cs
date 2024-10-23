using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateCloseButtonState();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                TextBox1.Text = text;
                TextBox2.Text = text;
                UpdateCloseButtonState();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            UpdateCloseButtonState();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрывает приложение
        }

        private void FontStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontStyleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string fontName = selectedItem.Content.ToString();
                TextBox1.FontFamily = new System.Windows.Media.FontFamily(fontName);
                TextBox2.FontFamily = new System.Windows.Media.FontFamily(fontName);
            }
        }

        private void UpdateCloseButtonState()
        {
            // Enable button if both text boxes are empty
            CloseButton.IsEnabled = string.IsNullOrWhiteSpace(TextBox1?.Text) && string.IsNullOrWhiteSpace(TextBox2?.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCloseButtonState();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Opacity = 0.7;
            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Opacity = 1.0;
            }
        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.Opacity = 0.5;
            }
        }
        private void Button_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                button.Opacity = 0.7;
            }
        }
    }
}