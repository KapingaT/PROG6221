using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace CyberPalAssistantWPF
{
    public partial class MainWindow : Window
    {
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void SubmitNameButton_Click(object sender, RoutedEventArgs e)
        {
            userName = NameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(userName))
            {
                NameInputPanel.Visibility = Visibility.Collapsed;
                string welcomeMessage = $"Hello {userName}! I'm CyberPal, your cybersecurity assistant. Let me tell you what I can help you with:\n\n" +
                                       "=== MY CAPABILITIES ===\n" +
                                       "• Passwords - Learn to create and manage strong passwords\n" +
                                       "• Phishing - Recognize and avoid email/text scams\n" +
                                       "• Malware - Protection against viruses and malicious software\n" +
                                       "• Ransomware - Prevent file-encrypting attacks\n" +
                                       "• Firewalls - Network protection basics\n" +
                                       "• Two-Factor Authentication - Extra security for your accounts\n" +
                                       "• Identity Theft - Protect your personal information\n" +
                                       "• Social Engineering - Recognize manipulation tactics\n" +
                                       "• Public WiFi - Stay safe on public networks\n\n" +
                                       "=== HOW TO USE ===\n" +
                                       "• Type your question in the text box below\n" +
                                       "• Click the SEND button or press ENTER\n" +
                                       "• Use the quick topic buttons for common questions\n" +
                                       "• Say 'help' anytime to see this menu again\n" +
                                       "• Say 'bye' or 'goodbye' to end our conversation\n\n" +
                                       "What would you like to learn about today?";

                AddBotMessage(welcomeMessage);
                UpdateResponseDisplay(welcomeMessage);
                ScrollToBottom();
            }
            else
            {
                MessageBox.Show("Please enter your name to continue.", "Name Required",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !(Keyboard.Modifiers == ModifierKeys.Shift))
            {
                e.Handled = true;
                SendMessage();
            }
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e)
        {
            string voiceResponse = "Voice input feature coming soon! I'll be able to listen to your questions in a future update.";
            AddBotMessage(voiceResponse);
            UpdateResponseDisplay(voiceResponse);
            ScrollToBottom();
        }

        private void QuickTopic_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string message = button.Tag.ToString();
                MessageTextBox.Text = message;
                SendMessage();
            }
        }

        private void ClearChat_Click(object sender, RoutedEventArgs e)
        {
            ChatListBox.Items.Clear();
            if (!string.IsNullOrEmpty(userName))
            {
                string clearMessage = $"Chat cleared! Welcome back {userName}! Type 'help' to see what I can do for you.";
                AddBotMessage(clearMessage);
                UpdateResponseDisplay(clearMessage);
                ScrollToBottom();
            }
            else
            {
                UpdateResponseDisplay("Chat history has been cleared.");
            }
        }

        private void SendMessage()
        {
            string message = MessageTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                AddUserMessage(message);
                MessageTextBox.Clear();
                ProcessBotResponse(message);
                ScrollToBottom();
            }
        }

        private void ProcessBotResponse(string userMessage)
        {
            string response = GetIntelligentResponse(userMessage);
            AddBotMessage(response);
            UpdateResponseDisplay(response);
            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            if (ChatListBox.Items.Count > 0)
            {
                ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
            }
        }

        private void UpdateResponseDisplay(string response)
        {
            ResponseDisplayBox.Text = response;
            ResponseTimestamp.Text = DateTime.Now.ToString("h:mm:ss tt");

            try
            {
                ResponseDisplayBox.Opacity = 0;
                var animation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
                ResponseDisplayBox.BeginAnimation(UIElement.OpacityProperty, animation);
            }
            catch
            {
                ResponseDisplayBox.Opacity = 1;
            }
        }

        private string GetIntelligentResponse(string userMessage)
        {
            string input = userMessage.ToLower().Trim();

            // Exit/Goodbye
            if (input == "bye" || input == "goodbye" || input == "exit" || input == "quit")
            {
                return $"Goodbye {userName}! Stay safe online! Remember, CyberPal is always here if you need help. 👋";
            }

            // Greetings
            if (input == "hello" || input == "hi" || input == "hey" || input == "greetings")
            {
                string[] greetings = {
                    $"Hello {userName}! Nice to see you! What would you like to learn about cybersecurity today?",
                    $"Hi {userName}! Ready to learn how to stay safe online? Just ask me anything!",
                    $"Hey {userName}! I'm here to help you with cybersecurity. What's on your mind?"
                };
                return greetings[new Random().Next(greetings.Length)];
            }

            // Help
            if (input.Contains("help") || input.Contains("what can you do") || input == "help me")
            {
                return GetHelpMessage();
            }

            // About the bot
            if (input.Contains("about") || input.Contains("yourself") || input.Contains("who are you"))
            {
                return "I'm CyberPal, your friendly cybersecurity assistant! I explain online safety in simple terms. Just ask me about passwords, phishing, viruses, or any other security topic, and I'll give you an easy-to-understand answer.";
            }

            // Tips
            if (input.Contains("tip") || input.Contains("advice") || input.Contains("suggestion") || input == "tips")
            {
                string[] tips = {
                    " Tip: Always keep your phone and computer updated. Updates fix security problems!",
                    " Tip: Use a different password for every account. That way, if one gets stolen, the others stay safe!",
                    " Tip: Turn on two-factor authentication (2FA) for your email and bank accounts. It's like having a second lock on your door!",
                    " Tip: If an email looks suspicious or asks for personal info, don't click anything. Delete it instead!",
                    " Tip: Back up your important photos and files to an external drive or cloud storage. Then if something goes wrong, you won't lose them!",
                    " Tip: Never share your passwords with anyone - not even friends or family. Keep them secret!",
                    " Tip: Before clicking a link, hover your mouse over it to see where it really goes. If it looks strange, don't click!"
                };
                return tips[new Random().Next(tips.Length)];
            }

            // PASSWORD topics with simple definition
            if (input.Contains("password") || input.Contains("passphrase"))
            {
                string[] passwordResponses = {
                    " DEFINITION: A password is a secret word or phrase that proves who you are. It's like a key that unlocks your online accounts.\n\n" +
                    " SIMPLE TIP: Create passwords that are long and easy to remember. For example: 'BlueTacoTuesday$' is better than 'Btt123'.\n\n" +
                    " Remember: Use different passwords for different accounts. If someone steals one password, they can't get into your other accounts!",

                    " DEFINITION: Strong passwords are hard for others to guess but easy for you to remember.\n\n" +
                    " SIMPLE TIP: Use a phrase like 'I love pizza on Fridays!' and turn it into 'ILovePizzaOnFridays!' - that's long, strong, and easy to remember!\n\n" +
                    " Remember: Never write passwords on sticky notes or share them with anyone!",

                    " DEFINITION: Password managers are apps that remember all your passwords for you. You only need to remember one master password!\n\n" +
                    " SIMPLE TIP: Try a free password manager like Bitwarden. It creates super-strong passwords and fills them in automatically.\n\n" +
                    " Remember: One strong master password protects all your other passwords - so make it a good one!"
                };
                return passwordResponses[new Random().Next(passwordResponses.Length)];
            }

            // PHISHING topics with simple definition
            if (input.Contains("phish") || input.Contains("scam") || input.Contains("fake email") || input.Contains("phishing"))
            {
                string[] phishingResponses = {
                    " DEFINITION: Phishing is when scammers send fake emails or texts that look real. They want you to click bad links or give them your passwords.\n\n" +
                    " SIMPLE TIP: If an email says 'urgent' or asks for your password, it's probably a scam. Real companies never ask for passwords by email!\n\n" +
                    " Remember: When in doubt, don't click! Go directly to the website by typing the address yourself.",

                    " DEFINITION: Scammers pretend to be from companies like Amazon, Netflix, or your bank to trick you.\n\n" +
                    " SIMPLE TIP: Check the sender's email address carefully. 'amaz0n@gmail.com' is NOT the real Amazon!\n\n" +
                    " Remember: Look for spelling mistakes and weird grammar - those are signs of a scam email.",

                    " DEFINITION: Phishing links take you to fake websites that look real but steal your info.\n\n" +
                    " SIMPLE TIP: Before clicking a link, hover your mouse over it. Does the address look strange? If yes, don't click!\n\n" +
                    " Remember: If something seems too good to be true (like 'You won $1000!'), it's probably a scam."
                };
                return phishingResponses[new Random().Next(phishingResponses.Length)];
            }

            // MALWARE topics with simple definition
            if (input.Contains("malware") || input.Contains("virus") || input.Contains("trojan") || input.Contains("worm"))
            {
                string[] malwareResponses = {
                    " DEFINITION: Malware (short for MALicious softWARE) is a bad program that hurts your computer. Viruses are one type of malware.\n\n" +
                    "SIMPLE TIP: Malware is like a cold for your computer. It can steal your info, show you ads, or lock your files.\n\n" +
                    " Remember: Don't download programs from strange websites. Stick to official app stores and trusted sites!",

                    " DEFINITION: A computer virus spreads from one computer to another, just like a sick person spreads a cold virus.\n\n" +
                    " SIMPLE TIP: Install antivirus software (Windows has free one called Defender). It catches viruses before they hurt your computer.\n\n" +
                    " Remember: Never open email attachments from people you don't know - that's how viruses spread!",

                    " DEFINITION: Trojans pretend to be good programs but do bad things. They're named after the Trojan Horse from Greek mythology.\n\n" +
                    " SIMPLE TIP: Only download software from official websites. Free game or 'crack' downloads often hide Trojans.\n\n" +
                    " Remember: If a website says 'Download this to speed up your PC' - it might actually be a Trojan!"
                };
                return malwareResponses[new Random().Next(malwareResponses.Length)];
            }

            // RANSOMWARE topics with simple definition
            if (input.Contains("ransomware"))
            {
                string[] ransomwareResponses = {
                    "DEFINITION: Ransomware is a type of malware that locks your files and demands money (a ransom) to unlock them.\n\n" +
                    " SIMPLE TIP: Back up your important photos and documents! Save copies to a USB drive or cloud storage like Google Drive.\n\n" +
                    " Remember: If you have backups, ransomware can't hurt you. You can just restore your files!",

                    " DEFINITION: Ransomware criminals want you to pay them in cryptocurrency like Bitcoin. But paying doesn't guarantee you'll get your files back.\n\n" +
                    "⚠ SIMPLE TIP: Never pay the ransom! Paying encourages criminals to keep attacking people.\n\n" +
                    " Remember: Keep your computer updated and don't click suspicious links. That's the best way to avoid ransomware!"
                };
                return ransomwareResponses[new Random().Next(ransomwareResponses.Length)];
            }

            // FIREWALL topics with simple definition
            if (input.Contains("firewall"))
            {
                string[] firewallResponses = {
                    " DEFINITION: A firewall is like a security guard for your internet connection. It decides what data can come in and go out of your computer.\n\n" +
                    " SIMPLE TIP: Windows already has a free firewall built-in. Just make sure it's turned on!\n\n" +
                    " Remember: A firewall blocks bad guys from accessing your computer through the internet.",

                    " DEFINITION: Think of a firewall as the wall around a castle. It lets friendly people in but keeps enemies out.\n\n" +
                    " SIMPLE TIP: Check your firewall settings by searching 'Windows Security' on your computer.\n\n" +
                    " Remember: You need BOTH a firewall AND antivirus software. They work together to protect you!"
                };
                return firewallResponses[new Random().Next(firewallResponses.Length)];
            }

            // TWO-FACTOR AUTHENTICATION topics with simple definition
            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("multi-factor") || input.Contains("mfa"))
            {
                string[] faResponses = {
                    " DEFINITION: Two-Factor Authentication (2FA) is like having two locks on your door. You need BOTH your password AND a second code to get in.\n\n" +
                    " SIMPLE TIP: Turn on 2FA for your email, bank, and social media accounts. It makes it MUCH harder for hackers to break in!\n\n" +
                    " Remember: Even if someone steals your password, they still can't get in without the second code!",

                    " DEFINITION: The second factor is usually a code sent to your phone by text message or through an app like Google Authenticator.\n\n" +
                    " SIMPLE TIP: Use an authenticator app instead of text messages. It's more secure and works even without cell service!\n\n" +
                    " Remember: Save backup codes somewhere safe. If you lose your phone, you'll need them to get into your accounts!",

                    " DEFINITION: Hardware keys are small devices (like YubiKey) that you plug into your computer. They're the strongest form of 2FA.\n\n" +
                    " SIMPLE TIP: For very important accounts (like your email), consider buying a $20-30 security key.\n\n" +
                    " Remember: Any 2FA is better than no 2FA. Even text message codes are much better than just a password alone!"
                };
                return faResponses[new Random().Next(faResponses.Length)];
            }

            // IDENTITY THEFT topics with simple definition
            if (input.Contains("identity theft") || input.Contains("identity"))
            {
                string[] identityResponses = {
                    " DEFINITION: Identity theft is when someone steals your personal information (like your name, address, or Social Security number) and pretends to be you.\n\n" +
                    " SIMPLE TIP: Never share your Social Security number, birth date, or address with strangers online or over the phone.\n\n" +
                    " Remember: Check your bank statements every month. If you see charges you don't recognize, tell your bank immediately!",

                    " DEFINITION: Thieves can use your identity to open credit cards, take loans, or even commit crimes in your name.\n\n" +
                    " SIMPLE TIP: Freeze your credit with the three credit bureaus (Equifax, Experian, TransUnion). It's free and stops criminals from opening accounts in your name.\n\n" +
                    " Remember: You can check your credit report for free once a year at AnnualCreditReport.com. Do it to catch problems early!"
                };
                return identityResponses[new Random().Next(identityResponses.Length)];
            }

            // SOCIAL ENGINEERING topics with simple definition
            if (input.Contains("social engineering") || input.Contains("social"))
            {
                string[] socialResponses = {
                    " DEFINITION: Social engineering is when criminals trick you into giving them information instead of hacking your computer.\n\n" +
                    " SIMPLE TIP: Scammers might call pretending to be tech support or send emails pretending to be your boss. Always verify before sharing info!\n\n" +
                    " Remember: If someone calls asking for your password, credit card, or personal info - hang up! Call the company back using their official number.",

                    " DEFINITION: Criminals use psychology to manipulate you. They create fear ('Your account will be closed!') or excitement ('You won a prize!') to make you act without thinking.\n\n" +
                    " SIMPLE TIP: Stop and think before clicking or sharing. Ask yourself: 'Is this normal? Could this be a trick?'\n\n" +
                    " Remember: Real emergencies don't happen by email. If something feels wrong, it probably is!"
                };
                return socialResponses[new Random().Next(socialResponses.Length)];
            }

            // PUBLIC WIFI topics with simple definition
            if (input.Contains("public wifi") || input.Contains("wifi") || input.Contains("hotspot"))
            {
                string[] wifiResponses = {
                    " DEFINITION: Public WiFi is the free internet at coffee shops, airports, and hotels. But it's not secure - others can see what you're doing!\n\n" +
                    " SIMPLE TIP: Don't do banking or shopping on public WiFi. Save those for your home internet or phone's data plan.\n\n" +
                    " Remember: On public WiFi, assume people can see your activity. Don't type passwords or credit card numbers!",

                    " DEFINITION: A VPN (Virtual Private Network) creates a secret tunnel for your internet traffic, even on public WiFi.\n\n" +
                    " SIMPLE TIP: Use a paid VPN service (like NordVPN or ExpressVPN) if you often use public WiFi. It keeps your data private.\n\n" +
                    "Remember: Free VPNs might sell your data .that's worse than not using one! Stick with paid, trusted services.",

                    " DEFINITION: When you connect to public WiFi, anyone else on that network could potentially see what websites you visit.\n\n" +
                    " SIMPLE TIP: Turn off 'file sharing' on your computer before using public WiFi. That way, strangers can't access your files.\n\n" +
                    " Remember: Your phone's data is usually more secure than public WiFi. Use that for sensitive stuff!"
                };
                return wifiResponses[new Random().Next(wifiResponses.Length)];
            }

            // Default response
            string[] defaultResponses = {
                $"I'm not sure about that, {userName}. Could you ask me about a cybersecurity topic? Try:\n\n• 'What is phishing?'\n• 'How do I create strong passwords?'\n• 'What is malware?'\n• 'Tell me about 2FA'\n\nType 'help' to see everything I can teach you!",

                $"Great question! Let me help with cybersecurity. You can ask me things like:\n\n• 'What is ransomware?'\n• 'How does a firewall work?'\n• 'What is identity theft?'\n• 'Give me security tips'\n\nWhat would you like to learn?",

                $"I want to help, but I need you to ask about cybersecurity topics. Try asking:\n\n• 'What is social engineering?'\n• 'Is public WiFi safe?'\n• 'How do I spot a scam email?'\n\nType 'help' for the full list of topics I know about!"
            };

            return defaultResponses[new Random().Next(defaultResponses.Length)];
        }

        private string GetHelpMessage()
        {
            return $"=== CYBERPAL HELP MENU ===\n\n" +
                   $"Hi {userName}! Here's what I can teach you in simple terms:\n\n" +
                   " **PASSWORDS**\n" +
                   "   Ask me: 'What is a strong password?' or 'How do I remember passwords?'\n\n" +

                   " **PHISHING**\n" +
                   "   Ask me: 'What is phishing?' or 'How to spot a scam email?'\n\n" +

                   " **MALWARE & VIRUSES**\n" +
                   "   Ask me: 'What is malware?' or 'How do I avoid viruses?'\n\n" +

                   " **RANSOMWARE**\n" +
                   "   Ask me: 'What is ransomware?' or 'How to protect files?'\n\n" +

                   " **FIREWALLS**\n" +
                   "   Ask me: 'What is a firewall?' or 'Do I need a firewall?'\n\n" +

                   " **TWO-FACTOR AUTHENTICATION**\n" +
                   "   Ask me: 'What is 2FA?' or 'How to turn on 2FA?'\n\n" +

                   " **IDENTITY THEFT**\n" +
                   "   Ask me: 'What is identity theft?' or 'How to protect my identity?'\n\n" +

                   " **SOCIAL ENGINEERING**\n" +
                   "   Ask me: 'What is social engineering?' or 'How do scammers trick people?'\n\n" +

                   " **PUBLIC WIFI**\n" +
                   "   Ask me: 'Is public WiFi safe?' or 'What is a VPN?'\n\n" +

                   "=== QUICK COMMANDS ===\n" +
                   "• 'tips' - Get random security advice\n" +
                   "• 'about' - Learn about me\n" +
                   "• 'bye' - End our conversation\n\n" +
                   "Just ask me anything about these topics, and I'll explain in simple, easy-to-understand words!";
        }

        private void AddUserMessage(string message)
        {
            ChatListBox.Items.Add(new ChatMessage
            {
                Sender = userName,
                Text = message,
                Alignment = HorizontalAlignment.Right,
                BubbleStyle = (Style)FindResource("UserBubbleStyle"),
                Timestamp = DateTime.Now.ToString("h:mm tt")
            });
        }

        private void AddBotMessage(string message)
        {
            ChatListBox.Items.Add(new ChatMessage
            {
                Sender = "CyberPal",
                Text = message,
                Alignment = HorizontalAlignment.Left,
                BubbleStyle = (Style)FindResource("BotBubbleStyle"),
                Timestamp = DateTime.Now.ToString("h:mm tt")
            });
        }
    }

    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public Style BubbleStyle { get; set; }
        public string Timestamp { get; set; }
    }
}