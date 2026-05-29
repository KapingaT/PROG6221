using System;
using System.Collections.Generic;
using System.Text;

namespace ProgP2_chatbox
{
  
        internal class Chatbox
        {
            private string userName;

            public void GetName()
            {
                // For WPF, name is collected in MainWindow
                // This method is kept for console compatibility
            }

            private void StartChat()
            {
                // For WPF, chat is handled in MainWindow
            }

            private string GenerateResponse(string input)
            {
                return Conversation.GetResponse(input, userName);
            }
        }
    }

