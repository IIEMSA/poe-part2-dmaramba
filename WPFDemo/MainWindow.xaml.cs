using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatBot chatBot;

        public MainWindow()
        {
            InitializeComponent();
            chatBot = new ChatBot();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            var userMessage = txtName.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
                return;

            // Add user message
            AddMessageToChat($"You: {userMessage}", Brushes.Black, HorizontalAlignment.Right);

            // Check for both sentiment and cyber keywords
            var sentimentResponse = new Sentiment().GetSentiment(userMessage);
            var chatbotResponse = chatBot.GetResponse(userMessage);

            string botReply;

            // If both sentiment and cyber keyword are detected, combine them
            if (!string.IsNullOrEmpty(sentimentResponse) && !string.IsNullOrEmpty(chatbotResponse))
            {
                botReply = $"{sentimentResponse} {chatbotResponse}";
            }
            // If only sentiment is detected
            else if (!string.IsNullOrEmpty(sentimentResponse))
            {
                botReply = sentimentResponse;
            }
            // If only cyber keyword is detected
            else if (!string.IsNullOrEmpty(chatbotResponse))
            {
                botReply = chatbotResponse;
            }
            // If neither is detected
            else
            {
                botReply = "I'm sorry, I don't have information about that. Try asking about phishing or passwords!";
            }

            // Add bot response
            AddMessageToChat($"Cyberbot: {botReply}", Brushes.DarkBlue, HorizontalAlignment.Left);

            // Clear input
            txtName.Clear();
            txtName.Focus();

            // Scroll to bottom
            scrollViewer.ScrollToBottom();
        }

        private void AddMessageToChat(string message, Brush color, HorizontalAlignment alignment)
        {
            var messageBlock = new TextBlock
            {
                Text = message,
                FontSize = 14,
                Foreground = color,
                Margin = new Thickness(5, 5, 5, 5),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = alignment,
                MaxWidth = 500
            };

            chatPanel.Children.Add(messageBlock);
        }
    }
}