using poepart1.Program.classes;
using ProgP2_chatbox;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CybersecurityChatbotWPF
{
    public partial class MainWindow : Window
    {
        private string userName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            // Hide chat interface until name is entered
            HideChatInterface();

            // Play voice greeting
            Audio.PlayGreeting();
        }

        private void HideChatInterface()
        {
            ChatListBox.Visibility = Visibility.Collapsed;
            MessageTextBox.Visibility = Visibility.Collapsed;
            SendButton.Visibility = Visibility.Collapsed;
            VoiceButton.Visibility = Visibility.Collapsed;
        }

        private void ShowChatInterface()
        {
            ChatListBox.Visibility = Visibility.Visible;
            MessageTextBox.Visibility = Visibility.Visible;
            SendButton.Visibility = Visibility.Visible;
            VoiceButton.Visibility = Visibility.Visible;
        }

        private void SubmitNameButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty. Please enter your name.",
                              "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            userName = name;

            // Hide name panel, show chat interface
            NameInputPanel.Visibility = Visibility.Collapsed;
            ShowChatInterface();

            // Display welcome messages
            DisplayWelcomeMessages();

            // Focus on input
            MessageTextBox.Focus();
        }

        private void DisplayWelcomeMessages()
        {
            AddBotMessage($"Welcome, {userName}!");
            AddBotMessage("Type 'exit' to quit the chat.\n");
            AddBotMessage("You can ask me about the following cybersecurity topics:");
            AddBotMessage("• Malware, Virus, Ransomware, Spyware");
            AddBotMessage("• Firewall, Two-factor authentication");
            AddBotMessage("• Password safety, Phishing");
            AddBotMessage("• Identity theft, Social engineering");
            AddBotMessage("• Secure websites, Data breaches");
            AddBotMessage("• Public WiFi safety, Encryption\n");
            AddBotMessage($"How can I help you today, {userName}?");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void SendMessage()
        {
            string message = MessageTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
                return;

            AddUserMessage(message);
            MessageTextBox.Clear();

            // Check for exit command
            if (IsExitCommand(message))
            {
                HandleExit();
                return;
            }

            // Get and display response
            string response = Conversation.GetResponse(message, userName);
            AddBotMessage(response);
        }

        private bool IsExitCommand(string message)
        {
            string lowerMessage = message.ToLower();
            return lowerMessage == "exit" || lowerMessage == "quit";
        }

        private void HandleExit()
        {
            AddBotMessage($"Goodbye {userName}! Stay safe online. ");
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for voice functionality
            AddBotMessage("Voice recognition feature coming soon! ");
        }

        private void QuickTopic_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag?.ToString() is string topic && !string.IsNullOrEmpty(topic))
            {
                MessageTextBox.Text = topic;
                SendMessage();
            }
        }

        private void ClearChat_Click(object sender, RoutedEventArgs e)
        {
            ChatListBox.Items.Clear();
            AddBotMessage("Chat cleared! I'm still here if you need cybersecurity help.");
        }

        private void AddUserMessage(string message)
        {
            ChatListBox.Items.Add(new ChatMessage
            {
                Sender = userName,
                Text = message,
                Alignment = HorizontalAlignment.Right,
                BubbleStyle = (Style)FindResource("UserBubbleStyle"),
                Timestamp = DateTime.Now.ToString("HH:mm")
            });
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            ChatListBox.Items.Add(new ChatMessage
            {
                Sender = "Cybersecurity Bot",
                Text = message,
                Alignment = HorizontalAlignment.Left,
                BubbleStyle = (Style)FindResource("BotBubbleStyle"),
                Timestamp = DateTime.Now.ToString("HH:mm")
            });
            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            if (ChatListBox.Items.Count > 0)
                ChatListBox.ScrollIntoView(ChatListBox.Items[^1]);
        }

        private void ChatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class ChatMessage
    {
        public string Sender { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public HorizontalAlignment Alignment { get; set; }
        public Style? BubbleStyle { get; set; }
        public string Timestamp { get; set; } = string.Empty;
    }
}